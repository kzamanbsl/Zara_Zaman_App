using app.EntityModel;
using app.Services.LeaveCategoryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.LeaveCategoryServices
{
    public class LeaveCategoryViewModel: BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<LeaveCategoryViewModel> LeaveCategoryList { get; set; }
    }
}
