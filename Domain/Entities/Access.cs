﻿namespace Domain.Entities
{
    public class Access
    {

        public int IdProfile { get; set; }
        public int IdPermission { get; set; }
        public int? IdUser { get; set; }

        public virtual Permission Permission { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
