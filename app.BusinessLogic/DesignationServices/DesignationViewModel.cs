using app.EntityModel;
using app.Services.DepartmentServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.DesignationServices
{
    public class DesignationViewModel:BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<DesignationViewModel> DesignationList { get; set; }
    }
}
