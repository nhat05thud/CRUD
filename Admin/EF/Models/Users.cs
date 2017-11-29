using System;

namespace EF.Models
{
    public class Users
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Password { get; set; }
        public bool IsEmailVerified { get; set; }
        public Guid ActivationCode { get; set; } // System.Guid (Guid) sẽ genarate ra 1 mã random k bao giờ trùng
    }
}
