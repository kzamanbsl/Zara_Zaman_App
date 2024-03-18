namespace app.Services.CustomerServices
{
    public class CustomerViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string BusinessIdNo { get; set; }
        public string BankName { get; set; }
        //public int? CountryId { get; set; }
        //public string CountryName { get; set; }
        //public int? DivisionId { get; set; }
        //public string DivisionName { get; set; }
        //public int? DistrictId { get; set; }
        //public string DistrictName { get; set; }
        //public int? UpazilaId { get; set; }
        //public string UpazilaName { get; set; }
        public IEnumerable<CustomerViewModel> CustomerList { get; set; }
    }
}
