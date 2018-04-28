using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class ContactViewModel
    {
        [Required]
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "O campo E-mail não está em um formato válido")]
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        [Required]
        [Display(Name = "Mensagem")]
        public string Body{ get; set; }
        public string Cc { get; set; }
        public string Bcc { get; set; }
        public string Attachments { get; set; }
        [Required]
        [Display(Name = "Nome do Emissor")]
        public string EmitterName { get; set; }
        public string RecipientName { get; set; }
        //counted with character
        [Display(Name = "Celular")]
        [StringLength(14, MinimumLength = 13, ErrorMessage = "O campo Celular deve conter entre 10 e 11 dígitos")] 
        public string Phone { get; set; }
    }
}
