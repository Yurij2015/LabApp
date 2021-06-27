using System;
using System.Collections.Generic;

#nullable disable

namespace LabApp.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
