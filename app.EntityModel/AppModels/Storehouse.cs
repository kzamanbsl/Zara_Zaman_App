using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.EntityModel.AppModels
{
    public class Storehouse : BaseEntity
    {
        public string Name { get;set; }
        public string Location { get;set; }
        public string Description { get;set; }
    }
}
