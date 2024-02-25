using app.EntityModel.DataTableSearchModels;
using System.ComponentModel;

namespace app.Services.MenuItemServices
{
    public class MenuItemSearchDto : BaseDataTableSearch
    {
        public long Id { get; set; }
        public string Name { get; set; }

        [DisplayName("Short Name")]
        public string ShortName { get; set; }

        [DisplayName("Order No")]
        public int OrderNo { get; set; }
        public string Controller { get; set; }
        public string Icon { get; set; }
        public long MenuId { get; set; }

        [DisplayName("Menu Name")]
        public string MenuName { get; set; }
        public bool IsPermission { get; set; }
        public bool IsMenuShow { get; set; } = true;

    }
}
