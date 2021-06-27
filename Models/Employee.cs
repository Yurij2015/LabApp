using System;
using System.Collections.Generic;

#nullable disable

namespace LabApp.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeData = new HashSet<EmployeeDatum>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int? PositionId { get; set; }
        public int? DivisionId { get; set; }

        public virtual Division Division { get; set; }
        public virtual Position Position { get; set; }
        public virtual ICollection<EmployeeDatum> EmployeeData { get; set; }
    }
}
