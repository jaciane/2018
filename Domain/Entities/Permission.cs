using System.Collections.Generic;

namespace Domain.Entities
{
    public class Permission
    {
        //public Permission()
        //{
        //    AccessList = new HashSet<Access>();
        //}

        public int Id { get; set; }

        public int? IdUser { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

        //public virtual ICollection<Access> AccessList { get; set; }


        public bool Validate()
        {
            return true;
        }
    }

}
