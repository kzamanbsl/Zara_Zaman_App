namespace app.Services.ServiceTypeServices
{
    public class ServiceTypeViewModel:BaseViewModel
    {
        public string Name { get; set; }
        public IEnumerable<ServiceTypeViewModel> ServiceTypeList { get; set; }
    }
}
