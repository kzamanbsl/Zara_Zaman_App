using app.EntityModel;
using app.Services.OfficeTypeServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.OfficeTypeServices
{
    public class OfficeTypeViewModel : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<OfficeTypeViewModel> OfficeTypeList { get; set; }
    }
}
