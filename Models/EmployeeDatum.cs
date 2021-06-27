using System;
using System.Collections.Generic;

#nullable disable

namespace LabApp.Models
{
    public partial class EmployeeDatum
    {
        public int Id { get; set; }
        public string Passport { get; set; }
        public string Email { get; set; }
        public string Education { get; set; }
        public string Hobby { get; set; }
        public int? EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
