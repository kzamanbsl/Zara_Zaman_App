using app.EntityModel;
using app.Services.JobStatusServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.JobStatusServices
{
    public class JobStatusViewModel:BaseViewModel
    {
        public string Name { get; set; }
        public IEnumerable<JobStatusViewModel> JobStatusList { get; set; }
    }
}
