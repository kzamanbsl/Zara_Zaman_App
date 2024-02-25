using app.EntityModel.DataTableSearchModels;
using app.Services.DepartmentServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.UnitServices
{
    public class UnitSearchDto : BaseDataTableSearch
    {
        public string Name { get; set; }
       
    }
}
