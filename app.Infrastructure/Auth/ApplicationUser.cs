using Microsoft.AspNetCore.Identity;

namespace app.Infrastructure.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string Prefix { get; set; }
        public int UserType { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string Address { get; set; }
    }

}
