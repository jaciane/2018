using Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class UnitViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo descrição deve ser preenchido")]
        [StringLength(50)]
        public string Description { get; set; }

        [Required(ErrorMessage = "O campo símbolo deve ser preenchido")]
        [StringLength(5)]
        public string Symbol { get; set; }

    }
}