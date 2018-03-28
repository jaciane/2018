using Domain.Enum;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class ProfileViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "O limite máximo de letras do campo {0} é de 50")]
        [RegularExpression(@"^[A-zÀ-ÿ0-9\s]*$", ErrorMessage = "No campo {0} não são permitidos caracteres especiais")]
        [DisplayName("Perfil")]
        public string Name { get; set; }
        public string Active { get; set; }

        public List<List<PermissionViewModel>> PermissionGrouped { get; set; }
        public List<PermissionViewModel> PermissionList { get; set; }
        public List<AccessViewModel> AccessList { get; set; }

        [Required(ErrorMessage = "Deve selecionar ao menos uma permissão.")]
        public List<int> SelectedPermissionIdList { get; set; }
    }

    public class ProfileViewIndex
    {
        public List<ProfileViewModel> ProfileList { get; set; }
        public string ResearchName { get; set; }
        public string ResearchActive { get; set; }

        public string StatusName(string Active)
        {
            if (Active == ((int)GenericStatusEnum.Active).ToString()) return "Ativo";
            return "Inativo";
        }
    }
}
