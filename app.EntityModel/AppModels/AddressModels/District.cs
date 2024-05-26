using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.EntityModel.AppModels.AddressModels
{
    public class District
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BnName { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string Website { get; set; }
        public int DivisionId { get; set; }
        public Division Division { get; set; }

    }
}