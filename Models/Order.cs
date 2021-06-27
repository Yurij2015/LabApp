using System;
using System.Collections.Generic;

#nullable disable

namespace LabApp.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int? ProductId { get; set; }
        public int? CustomerId { get; set; }
        public int? ProductCount { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
