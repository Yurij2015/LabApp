using System;
using System.Collections.Generic;

#nullable disable

namespace LabApp.Models
{
    public partial class Position
    {
        public Position()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string PositionTitle { get; set; }
        public string PositionDesc { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
