using app.Services.MenuItemServices;

namespace app.Services.UserPermissionsServices
{
   public class UserPermissionViewModel
    {
        public long Id { get; set; }
        public string TrackingId { get; set; }
        public string UserId { get; set; }
        public string MenuName { get; set; }
        public string UserName { get; set; }
        public int OrderNo { get; set; }
        public IEnumerable<MenuItemViewModel> MenuItemList { get; set; }
        public IEnumerable<UserPermissionViewModel> DataList { get; set; }
    }
}
