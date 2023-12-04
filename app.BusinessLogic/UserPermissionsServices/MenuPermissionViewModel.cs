namespace app.Services.UserPermissionsServices
{
    public class MenuPermissionViewModel
    {
        public List<MainMenuVm> MainMenuVm { get; set; }
    }

    public class MainMenuVm
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string ActiveId { get; set; }
        public List<MenuItemVm> MenuItemVMs { get; set; }
    }

    public class MenuItemVm
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Icon { get; set; }
        public int OrderNo { get; set; }
    }


}
