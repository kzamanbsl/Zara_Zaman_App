using app.Services.DepartmentServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.UnitServices
{
    public class UnitViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public IEnumerable<UnitViewModel> UnitList { get; set; }
    }
}
