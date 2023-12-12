using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Services.EmployeeServices
{
    public class EmployeeViewModel : BaseViewModel
    {
        public string EmployeeId { get; set; }
        [Required]
        public string Name { get; set; }
        public string EmployeeCode { get; set; }
        public string ShortName { get; set; }
        public string PresentAddress { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string SpouseName { get; set; }
        public string MobileNo { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DisplayName("Personal Email")]
        public string Email { get; set; }
        public string PermanentAddress { get; set; }
        public int DepartmentId { get; set; }
        public int DesignationId { get; set; }
        public int JobStatusId { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime ProbationEndDate { get; set; }
        public DateTime PermanentDate { get; set; }
        public int ShiftId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfMarriage { get; set; }
        public int GradeId { get; set; }
        public int CountryId { get; set; }
        public int GenderId { get; set; }
        public int MaritalTypeId { get; set; }
        public int DivisionId { get; set; }
        public string Division { get; set; }
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string Upzilla { get; set; }
        public int UpzillaId { get; set; }
        public string NationalId { get; set; }
        public string TinNo { get; set; }
        public string Religion { get; set; }
        public int ReligionId { get; set; }
        public int BloodGroupId { get; set; }
        public int EmployeeCategoryId { get; set; }
        public int ServiceTypeId { get; set; }
        public int DesignationFlag { get; set; }
        public string PhotoUrl { get; set; }
        public string SignUrl { get; set; }
        public string OfficeType { get; set; }
        public int OfficeTypeId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EndDate { get; set; }
        public string EndReason { get; set; }
        public int EmployeeOrder { get; set; }
        public string Remarks { get; set; }
        public string SearchText { get; set; }
        public string StrJoiningDate { get; set; }
        public string DepartmentName { get; set; }
        public string DesignationName { get; set; }
        public string BloodGroupName { get; set; }
        [Required]
        public long ManagerId { get; set; }
    }
}
