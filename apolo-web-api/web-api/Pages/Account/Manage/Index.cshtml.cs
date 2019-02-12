using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using ApoloWebApi.Data;
using ApoloWebApi.Services;
using ApoloWebApi.Data.VO;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ApoloWebApi.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly IPersonRepository _repos;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            IPersonRepository repos)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _repos = repos;
        }
        public bool IsEmailConfirmed { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModelPerson Input { get; set; }                

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var person = _repos.GetPersonByUserId(user.Id);

            if (user == null)
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");            

            Input = new InputModelPerson
            {
                Id = person.Id,
                Name = person.Name,
                Date = person.BirthDate.ToString("yyyy-MM-dd"),
                Occupation = person.Occupation,                
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };

            var roleName = _userManager.GetRolesAsync(user).Result.FirstOrDefault();
            Input.Role = Input.Roles.FirstOrDefault(r => r.Text.Equals(roleName)).Value;
            ViewData["Roles"] = new SelectList(Input.Roles, "Value", "Text");

            IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);

            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var user = await _userManager.GetUserAsync(User);
            var person = _repos.GetPersonById(Input.Id);
            var oldRole = _userManager.GetRolesAsync(user).Result.FirstOrDefault();
            var newRole = Enum.GetName(typeof(Roles), Int32.Parse(Input.Role));

            if (user == null)
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");

            try
            {
                _repos.UpdatePerson(person, Input);
                if (!oldRole.Equals(newRole))
                {
                    await _userManager.RemoveFromRoleAsync(user, oldRole);
                    await _userManager.AddToRoleAsync(user, newRole);
                }
            }
            catch (DbUpdateConcurrencyException){ throw; }

            if (Input.Email != user.Email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, Input.Email);
                if (!setEmailResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting email for user with ID '{user.Id}'.");
                }
            }

            if (Input.PhoneNumber != user.PhoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    throw new ApplicationException($"Unexpected error occurred setting phone number for user with ID '{user.Id}'.");
                }
            }

            StatusMessage = "Seu perfil foi atualizado";
            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
            await _emailSender.SendEmailConfirmationAsync(user.Email, callbackUrl);

            StatusMessage = "Verification email sent. Please check your email.";
            return RedirectToPage();
        }
    }
}
