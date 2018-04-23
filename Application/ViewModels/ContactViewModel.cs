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
        [Display(Name = "Celular/Telefone")]
        public string Phone { get; set; }
    }
}
