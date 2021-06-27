using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace LabApp.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        [Display(Name = "Наименование")]
        public string BrandName { get; set; }
        public string BrandDescription { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
