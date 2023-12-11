using app.EntityModel;
using app.Services.DropDownItemServices;
using app.Utility;
using app.Utility.UtilityServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.DropDownItemServices
{
    public class DropDownItemViewModel:BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<DropDownItemViewModel> DropDownItemList { get; set; }
        public string Description { get; set; }
        public int DropDownTypeId { get; set; }
        //public string DropDownTypeName
        //{
        //    get { return UtilityService.GetEnumDescription((DropdownTypeEnum)DropDownTypeId); }
        //}
    }
}
