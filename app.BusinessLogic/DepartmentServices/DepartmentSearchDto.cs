using app.EntityModel.DataTableSearchModels;

namespace app.Services.DepartmentServices
{
    public class DepartmentSearchDto: BaseDataTableSearch
    {
        public string Name { get; set; }
       
    }
}
