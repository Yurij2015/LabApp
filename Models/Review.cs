using System;
using System.Collections.Generic;

#nullable disable

namespace LabApp.Models
{
    public partial class Review
    {
        public int Id { get; set; }
        public string ReviewContent { get; set; }
        public DateTime? ReviewDate { get; set; }
        public int? CustomerId { get; set; }
        public int? ProductId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
