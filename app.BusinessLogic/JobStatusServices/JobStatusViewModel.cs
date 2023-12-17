namespace app.Services.JobStatusServices
{
    public class JobStatusViewModel:BaseViewModel
    {
        public string Name { get; set; }
        public IEnumerable<JobStatusViewModel> JobStatusList { get; set; }
    }
}
