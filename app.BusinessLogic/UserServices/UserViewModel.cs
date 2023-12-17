using System.ComponentModel.DataAnnotations;

namespace app.Services.UserServices
{
    public class UserViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string FullName { get; set; }
        public string Prefix { get; set; }
        public string RoleName { get; set; }
        public string RoleId { get; set; }
        public int UserType { get; set; }
        public bool IsActive { get; set; }
        public string Address { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Must be between 6 and 10 characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Password doesn't match.")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public IEnumerable<UserViewModel> DataList { get; set; }
    }
}
