using System;
using System.Collections.Generic;

#nullable disable

namespace LabApp.Models
{
    public partial class ProductImage
    {
        public int Id { get; set; }
        public string LinkImage { get; set; }
        public int? ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
