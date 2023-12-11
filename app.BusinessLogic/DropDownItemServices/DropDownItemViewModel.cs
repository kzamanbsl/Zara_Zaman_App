using app.EntityModel;
using app.EntityModel.AppModels;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Infrastructure;
using app.Services.DropdownItemServices;
using app.Utility;
using app.Utility.UtilityServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.DropdownItemServices
{
    public class DropdownItemViewModel:BaseEntity
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
        public int DropdownTypeId { get; set; }
        public string DropdownTypeName { get { return GlobalVariable.GetEnumDescription((DropdownTypeEnum)DropdownTypeId); } }

        public IEnumerable<DropdownItemViewModel> DropdownItemList { get; set; }
    }
}
