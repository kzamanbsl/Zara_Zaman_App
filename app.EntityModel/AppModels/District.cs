using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.EntityModel.AppModels
{
    public class District : BaseEntity
    {
        public string Name { get; set; }
        public int DivisionId { get;set; }
        public Division Division { get; set;}
       
    }
}
