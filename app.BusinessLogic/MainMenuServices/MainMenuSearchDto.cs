using System.ComponentModel;
using app.EntityModel.CoreModel;
using app.EntityModel.DataTableSearchModels;

namespace app.Services.MainMenuServices
{
    public class MainMenuSearchDto : BaseDataTableSearch
    {
        public long Id { get; set; }    
        public string Name { get; set; }
        public string Icon { get; set; }
        [DisplayName("Order No")]
        public int OrderNo { get; set; }
        public bool IsActive { get; set; }

        public List<MainMenu> DataList { get; set; }    
    }
}
