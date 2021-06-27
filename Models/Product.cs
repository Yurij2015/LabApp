using System;
using System.Collections.Generic;

#nullable disable

namespace LabApp.Models
{
    public partial class Product
    {
        public Product()
        {
            Orders = new HashSet<Order>();
            ProductImages = new HashSet<ProductImage>();
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDesctipton { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
