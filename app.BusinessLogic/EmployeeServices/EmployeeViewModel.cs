using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using app.EntityModel.AppModels;

namespace app.Services.EmployeeServices
{
    public class EmployeeViewModel : BaseViewModel
    {
        [Required]
        public string Name { get; set; }

        [DisplayName("Short Name")]
        public string ShortName { get; set; }

        [DisplayName("Employee Code")]
        public string EmployeeCode { get; set; }

        public string Email { get; set; }

        [DisplayName("Mobile No")]
        public string MobileNo { get; set; }


        public long? ManagerId { get; set; }
        [DisplayName("Manager Name")]
        public string ManagerName { get; set; }

        public long? DepartmentId { get; set; }
        [DisplayName("Department Name")]
        public string DepartmentName { get; set; }

        public long? DesignationId { get; set; }
        [DisplayName("Designation Name")]
        public string DesignationName { get; set; }

        public long? JobStatusId { get; set; }
        [DisplayName("Job Status Name")]
        public string JobStatusName { get; set; }

        public long? ShiftId { get; set; }
        [DisplayName("Shift Name")]
        public string ShiftName { get; set; }

        public long? EmployeeGradeId { get; set; }
        [DisplayName("Employee Grade Name")]
        public string EmployeeGradeName { get; set; }

        public long? EmployeeCategoryId { get; set; }
        [DisplayName("Employee Category Name")]
        public string EmployeeCategoryName { get; set; }

        public long? ServiceTypeId { get; set; }
        [DisplayName("Service Type Nae")]
        public string ServiceTypeName { get; set; }

        public long? OfficeTypeId { get; set; }
        [DisplayName("Office Type Name")]
        public string OfficeTypeName { get; set; }

        [DisplayName("Joining Date")]
        public DateTime JoiningDate { get; set; }

        [DisplayName("Probation End Date")]
        public DateTime ProbationEndDate { get; set; }

        [DisplayName("Permanent Date")]
        public DateTime PermanentDate { get; set; }

        [DisplayName("Employee Order")]
        public long EmployeeOrder { get; set; }

        public string Remarks { get; set; }

        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }

        [DisplayName("End Reason")]
        public string EndReason { get; set; }


        public int? CountryId { get; set; }
        [DisplayName("Country Name")]
        public string CountryName { get; set; }

        public int? DivisionId { get; set; }
        [DisplayName("Division Name")]
        public string DivisionName { get; set; }

        public int? DistrictId { get; set; }
        [DisplayName("District Name")]
        public string DistrictName { get; set; }

        public int? UpazilaId { get; set; }
        [DisplayName("Upazila Name")]
        public string UpazilaName { get; set; }

        [DisplayName("Present Address")]
        public string PresentAddress { get; set; }

        [DisplayName("Permanent Address")]
        public string PermanentAddress { get; set; }

        [DisplayName("Father Name")]
        public string FatherName { get; set; }

        [DisplayName("Mother Name")]
        public string MotherName { get; set; }

        [DisplayName("Spouse Name")]
        public string SpouseName { get; set; }

        public int? GenderId { get; set; }
        [DisplayName("Gender Name")]
        public string GenderName { get; set; }

        public int? ReligionId { get; set; }
        [DisplayName("Religion Name")]
        public string ReligionName { get; set; }

        public int? BloodGroupId { get; set; }
        [DisplayName("Blood Group Name")]
        public string BloodGroupName { get; set; }

        public int? MaritalTypeId { get; set; }
        [DisplayName("Marital Type Name")]
        public string MaritalTypeName { get; set; }

        [DisplayName("NID No")]
        public string NationalIdNo { get; set; }

        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Date of Marriage")]
        public DateTime DateOfMarriage { get; set; }

        [DisplayName("TIN No")]
        public string TinNo { get; set; }

        public string PhotoUrl { get; set; }
        public string SignUrl { get; set; }
    }
}
