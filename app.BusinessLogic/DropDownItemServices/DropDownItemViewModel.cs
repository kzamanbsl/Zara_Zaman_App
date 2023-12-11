using app.EntityModel;
using app.Services.DropDownItemServices;
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
    }
}
