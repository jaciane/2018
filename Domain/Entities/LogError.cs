using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class LogError
    {
        public int Id { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Description { get; set; }
        public string StackTrace { get; set; }
        public DateTime OccurrenceTime { get; set; }

        public bool Validate()
        {
            return true;
        }
    }
}
