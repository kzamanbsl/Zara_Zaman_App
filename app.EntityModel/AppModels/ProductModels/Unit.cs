using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.EntityModel.AppModels.ProductModels
{
    public class Unit : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
