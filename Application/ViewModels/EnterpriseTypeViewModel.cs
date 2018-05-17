
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class EnterpriseTypeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo descrição deve ser preenchido")]
        [StringLength(50)]
        public string Description { get; set; }

    }
}