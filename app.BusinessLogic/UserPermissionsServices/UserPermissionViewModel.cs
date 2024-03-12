using System.ComponentModel;
using app.Services.MenuItemServices;

namespace app.Services.UserPermissionsServices
{
   public class UserPermissionViewModel
    {
        public long Id { get; set; }
        public string TrackingId { get; set; }
        public string UserId { get; set; }

        [DisplayName("Menu Name")]
        public string MenuName { get; set; }

        [DisplayName("User Name")]
        public string UserName { get; set; }

        [DisplayName("Order No")]
        public int OrderNo { get; set; }

        public IEnumerable<MenuItemViewModel> MenuItemList { get; set; }
        public IEnumerable<UserPermissionViewModel> DataList { get; set; }
    }
}
