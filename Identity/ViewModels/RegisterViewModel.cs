using Application.ViewModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Identity.Model
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "O campo E-mail n�o est� em um formato v�lido")]
        [StringLength(50, ErrorMessage = "O limite m�ximo de caracteres no campo {0} � de 50")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [StringLength(14, ErrorMessage = "O limite m�ximo de digitos no campo {0} � de 14")]
        [Required]
        //[IsCpfValid]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Required]
        [Display(Name = "Nome")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo {0} deve ter entre 3 e 50 letras")]
        [RegularExpression(@"^[A-z�-�\s]*$", ErrorMessage = "No campo {0} n�o s�o permitidos n�meros nem caracteres especiais")]
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