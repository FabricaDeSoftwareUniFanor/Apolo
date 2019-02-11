using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using ApoloWebApi.Data;
using ApoloWebApi.Services;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using ApoloWebApi.Data.VO;

namespace ApoloWebApi.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private IPersonRepository _repos;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            IPersonRepository repos,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<LoginModel> logger,
            IEmailSender emailSender)
        {
            _repos = repos;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModelPerson Input { get; set; }
        [BindProperty]
        public RegisterInputModel InputPassword { get; set; }

        public string ReturnUrl { get; set; }

        public class RegisterInputModel
        {
            [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
            [StringLength(100, ErrorMessage = "A {0} deve ser no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Senha")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirmar senha")]
            [Compare("Password", ErrorMessage = "As senhas não correspondem.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            Input = new InputModelPerson();
            ViewData["Roles"] = new SelectList(Input.Roles, "Value", "Text");
            ReturnUrl = returnUrl;
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = Input.Email, PhoneNumber = Input.PhoneNumber, Email = Input.Email };
                var newPerson = new Person
                {
                    Name = Input.Name,
                    BirthDate = Input.BirthDate,
                    Occupation = Input.Occupation
                };
                var result = await _userManager.CreateAsync(user, InputPassword.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                    await _emailSender.SendEmailConfirmationAsync(Input.Email, callbackUrl);

                    //Adicionando os dados de usuário na tabela Pessoa
                    _repos.AddPerson(user.Id, newPerson);

                    //Atribuindo uma role para usuário
                    var roleName = Enum.GetName(typeof(Roles), Int32.Parse(Input.Role));
                    await _userManager.AddToRoleAsync(user, roleName);

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(Url.GetLocalUrl(returnUrl));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
