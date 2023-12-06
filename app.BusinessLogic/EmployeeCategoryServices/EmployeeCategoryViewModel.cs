using app.EntityModel;
using app.Services.DesignationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.EmployeeCategoryServices
{
    public class EmployeeCategoryViewModel:BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<EmployeeCategoryViewModel> EmployeeCategoryList { get; set; }
    }
}
