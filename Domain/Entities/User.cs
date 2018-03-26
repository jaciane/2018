using System;

namespace Domain.Entities
{
    public class User
    {
        // public User()
        //{
        //    UserLoginList = new HashSet<UserLogin>();
        //    UserNotificationList = new HashSet<UserNotification>();
        //}
        public int Id { get; set; }
        public int IdProfile { get; set; }
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Active { get; set; }
        public string Username { get; set; }
        //public bool EmailConfirmed { get; set; }
        //public string PasswordHash { get; set; }
        //public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        //public bool PhoneNumberConfirmed { get; set; }
        //public bool TwoFactorEnabled { get; set; }
        //public DateTime? LockoutEndDateUTC { get; set; }
        //public bool LockoutEnabled { get; set; }
        //public bool RecieveNotification { get; set; }
        //public int AccessFailedCount { get; set; }
        //public virtual Profile Profile { get; set; }
        //public virtual ICollection<UserLogin> UserLoginList { get; set; }
        //public virtual ICollection<UserNotification> UserNotificationList { get; set; }
        /*TODO clear*/
    }
}
