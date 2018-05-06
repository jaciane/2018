using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Perfil")]
        public int IdProfile { get; set; }

        //[Required]
        //[Display(Name = "Empresa")]
        //public int? IdCompany { get; set; }

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
        [EmailAddress(ErrorMessage = "O campo {0} não está em um formato válido")]
        [StringLength(50, ErrorMessage = "O limite máximo de caracteres no campo {0} é de 50")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        public string Active { get; set; }

        public bool EmailConfirmed { get; set; }

        public string SecurityStamp { get; set; }

        public bool RecieveNotification { get; set; }

        public string Username { get; set; }

        [Display(Name = "Perfil")]
        public ProfileViewModel Profile { get; set; }
        public List<ProfileViewModel> ProfileList { get; set; }
        //public List<UserNotificationViewModel> UserNotificationList { get; set; }
    }

    public class UserViewIndex
    {
        public List<UserViewModel> UserList { get; set; }
        public string ResearchName { get; set; }
        public string ResearchEmail { get; set; }
        public string ResearchCpf { get; set; }
        public string ResearchCompany { get; set; }
        public string ResearchProfile { get; set; }
        public string ResearchActive { get; set; }

        public string StatusName(string Active)
        {
            if (Active == ((int)GenericStatusEnum.Active).ToString()) return "Ativo";
            return "Inativo";
        }
    }

    public class UserDisplayViewModel
    {
        public int Id { get; set; }
        
        public string Cpf { get; set; }
        
        public string Name { get; set; }
        
        public string Email { get; set; }

        public string Username { get; set; }
    }
}
