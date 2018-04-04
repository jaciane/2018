using Application.ViewModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Identity.Model
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "O campo E-mail não está em um formato válido")]
        [StringLength(50, ErrorMessage = "O limite máximo de caracteres no campo {0} é de 50")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [StringLength(14, ErrorMessage = "O limite máximo de digitos no campo {0} é de 14")]
        [Required]
        //[IsCpfValid]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Required]
        [Display(Name = "Nome")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo {0} deve ter entre 3 e 50 letras")]
        [RegularExpression(@"^[A-zÀ-ÿ\s]*$", ErrorMessage = "No campo {0} não são permitidos números nem caracteres especiais")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Perfil")]
        public int IdProfile { get; set; }

        [Required]
        [Display(Name = "Empresa")]
        public int IdCompany { get; set; }

        public string Profile { get; set; }

        public List<ProfileViewModel> ProfileList { get; set; }
    }
}