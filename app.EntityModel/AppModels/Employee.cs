namespace app.EntityModel.AppModels
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string EmployeeCode { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }


        public long? ManagerId { get; set; }
        public Employee Manager { get; set; }
        public long? DepartmentId { get; set; }
        public Department Department { get; set; }
        public long? DesignationId { get; set; }
        public Designation Designation { get; set; }
        public long? JobStatusId { get; set; }
        public JobStatus JobStatus { get; set; }
        public long? ShiftId { get; set; }
        public Shift Shift { get; set; }
        public long? EmployeeGradeId { get; set; }
        public EmployeeGrade EmployeeGrade { get; set; }
        public long? EmployeeCategoryId { get; set; }
        public EmployeeCategory EmployeeCategory { get; set; }
        public long? ServiceTypeId { get; set; }
        public EmployeeServiceType ServiceType { get; set; }
        public long? OfficeTypeId { get; set; }
        public OfficeType OfficeType { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime ProbationEndDate { get; set; }
        public DateTime? PermanentDate { get; set; }
        public long EmployeeOrder { get; set; }
        public string Remarks { get; set; }      
        public DateTime? EndDate { get; set; }
        public string EndReason { get; set; }


        public int? CountryId { get; set; }
        public Country Country { get; set; }
        public int? DivisionId { get; set; }
        public Division Division { get; set; }
        public int? DistrictId { get; set; }
        public District District { get; set; }
        public int? UpazilaId { get; set; }
        public Upazila Upazila { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }

        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string SpouseName { get; set; }
        public long? GenderId { get; set; }
        public DropdownItem Gender { get; set; }
        public long? ReligionId { get; set; }
        public DropdownItem Religion { get; set; }
        public long? BloodGroupId { get; set; }
        public DropdownItem BloodGroup { get; set; }
        public long? MaritalTypeId { get; set; }
        public DropdownItem MaritalType { get; set; }
        public string NationalIdNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfMarriage { get; set; }
        public string TinNo { get; set; }

        public string PhotoUrl { get; set; }
        public string SignUrl { get; set; }

    }
}
