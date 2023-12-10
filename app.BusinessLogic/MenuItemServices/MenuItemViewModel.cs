namespace app.Services.MenuItemServices
{
    public class MenuItemViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int OrderNo { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Icon { get; set; }
        public long MenuId { get; set; }
        public string MenuName { get; set; }
        public bool IsActive { get; set; }
        public bool IsPermission { get; set; }
        public bool IsMenuShow { get; set; } 
        public IEnumerable<MenuItemViewModel> DataList { get; set; }
    }
}
