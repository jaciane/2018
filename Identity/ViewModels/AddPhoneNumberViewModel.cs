using System.ComponentModel.DataAnnotations;

namespace Identity.Model
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Número de Telefone")]
        public string Number { get; set; }
    }
}