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
using System.Linq;
using ApoloWebApi.Data.VO;

namespace ApoloWebApi.Pages.Account
{
    public class RegisterModel : PageModel
    {
        public Roles roles;
        private IPersonRepository _repos;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(                                
            IPersonRepository repos,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<LoginModel> logger,
            IEmailSender emailSender)
        {
            _roleManager = roleManager;
            _repos = repos;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public RegisterInputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class RegisterInputModel
        {
            [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]            
            [Display(Name = "Nome")]
            public string Name { get; set; }

            [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
            [Display(Name = "Data de Nascimento")]
            [DataType(DataType.Date)]
            public DateTime BirthDate { get; set; }

            [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
            [Display(Name = "Profissão")]            
            public string Occupation { get; set; }
            
            [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
            [Display(Name = "Contato")]
            [DataType(DataType.PhoneNumber)]            
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]            
            [Display(Name = "Tipo Usuário")]
            public string Role { get; set; }

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
            ViewData["Roles"] = new SelectList(_roleManager.Roles, "Id", "Name").OrderBy(r => r.Text);
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            if (ModelState.IsValid)
            {                
                var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email };
                var result = await _userManager.CreateAsync(user, Input.Password);
                var newPerson = new Person
                {
                    Name = Input.Name,
                    BirthDate = Input.BirthDate,
                    Occupation = Input.Occupation                   
                };
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                    await _emailSender.SendEmailConfirmationAsync(Input.Email, callbackUrl);

                    //Atribuindo uma role para usuário                                        
                    var role = await _roleManager.FindByIdAsync(Input.Role);
                    IdentityResult roleResult = await _userManager.AddToRoleAsync(user, role.Name);

                    //Adicionando os dados de usuário na tabela Pessoa
                    _repos.AddPerson(user.Id, newPerson);

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
