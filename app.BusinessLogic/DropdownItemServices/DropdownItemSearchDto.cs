using System.ComponentModel;
using app.EntityModel;
using app.EntityModel.DataTableSearchModels;
using app.Utility;

namespace app.Services.DropdownItemServices
{
    public class DropdownItemSearchDto: BaseDataTableSearch
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
        [DisplayName("Dropdown Type")]
        public int DropdownTypeId { get; set; }
        public string DropdownTypeName => GlobalVariable.GetEnumDescription((DropdownTypeEnum)DropdownTypeId);
    }
}
