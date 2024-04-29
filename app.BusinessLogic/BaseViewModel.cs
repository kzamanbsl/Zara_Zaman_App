using System.ComponentModel.DataAnnotations;

namespace app.Services
{
    public class BaseViewModel
    {
        public long Id { get; set; }

        [Display(Name = "User Id")]
        public string UserId { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "User Email")]
        public string UserEmail { get; set; }

        [Display(Name = "User Address")]
        public string UserAddress { get; set; }

        [Display(Name = "User Mobile")]
        public string UserMobile { get; set; }

        [Display(Name = "User Type")]
        public int UserType { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
