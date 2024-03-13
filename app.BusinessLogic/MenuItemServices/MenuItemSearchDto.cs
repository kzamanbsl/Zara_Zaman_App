using app.EntityModel.DataTableSearchModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace app.Services.MenuItemServices
{
    public class MenuItemSearchDto : BaseDataTableSearch
    {
        public long Id { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Short Name")]
        public string ShortName { get; set; }

        [DisplayName("Order No")]
        public int OrderNo { get; set; }
        public string Controller { get; set; }

        [DisplayName("Controller Action")]
        public string ControllerAction { get; set; }
        public string Icon { get; set; }

        [DisplayName("Menu")]
        public long MenuId { get; set; }

        [DisplayName("Menu")]
        public string MenuName { get; set; }
        public bool IsPermission { get; set; }
        public bool IsMenuShow { get; set; } = true;

    }
}
