using System;
using System.Collections.Generic;

#nullable disable

namespace LabApp.Models
{
    public partial class Division
    {
        public Division()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string DivisionTitle { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
