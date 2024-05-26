using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.EntityModel.AppModels.EmployeeModels
{
    public class EmployeeGrade : BaseEntity
    {
        public string Name { get; set; }
        public string PayScale { get; set; }
    }
}
