using System.Collections.Generic;

namespace Domain.Entities
{
    public class Unit
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Symbol { get; set; }


        public bool Validate()
        {
            return true;
        }
    }

}
