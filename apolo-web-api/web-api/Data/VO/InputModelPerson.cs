using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApoloWebApi.Data.VO
{
    public class InputModelPerson
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public string Date { get; set; }

        public DateTime BirthDate
        {
            get { return DateTime.Parse(Date); }
        }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Profissão")]
        public string Occupation { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [Phone]
        [Display(Name = "Contato")]        
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Tipo Usuário")]
        public string Role { get; set; }

        public List<SelectListItem> Roles { get; set; }

        public InputModelPerson()
        {
            Roles = new List<SelectListItem>()
            {
                new SelectListItem{Value = "1", Text = "Admin"},
                new SelectListItem{Value = "2", Text = "Consultor"},
                new SelectListItem{Value = "3", Text = "Paciente"}
            };
        }        
    }
}
