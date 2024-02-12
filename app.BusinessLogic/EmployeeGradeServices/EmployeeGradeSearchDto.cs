using System.ComponentModel;
using app.EntityModel.DataTableSearchModels;

namespace app.Services.EmployeeGradeServices
{
    public class EmployeeGradeSearchDto : BaseDataTableSearch
    {
        public string Name { get; set; }
        
    }
}
