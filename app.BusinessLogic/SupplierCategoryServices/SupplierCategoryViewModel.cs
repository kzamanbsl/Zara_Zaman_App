namespace app.Services.SupplierCategoryServices
{
    public class SupplierCategoryViewModel:BaseViewModel
    {
        public string Name { get; set; }
        public IEnumerable<SupplierCategoryViewModel> SupplierCategoryList { get; set; }
    }
}
