using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class AccessViewModel
    {
        public int IdProfile { get; set; }

        public int IdPermission { get; set; }

        public int? IdUser { get; set; }
        
    }
}
