﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.EntityModel.AppModels
{
    public class EmployeeServiceLog:BaseEntity
    {
        public DateTime ProbationEndDate { get; set; }
        public long? DepartmentId { get; set; }
        public Department Department { get; set; }
        public long? DesignationId { get; set; }
        public Designation Designation { get; set; }
        public long EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
