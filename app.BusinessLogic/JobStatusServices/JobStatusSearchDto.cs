using app.EntityModel.DataTableSearchModels;

namespace app.Services.JobStatusServices
{
    public class JobStatusSearchDto: BaseDataTableSearch
    {
        public string Name { get; set; }
    }
}
