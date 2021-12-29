using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EcommerceData.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public int VendorId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string ProductCategory { get; set; }
        public double Discount { get; set; }
        public DateTime DateCreated { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public double ProductWeight { get; set; }
        public double ProductSize { get; set; }
        public string Specfication { get; set; }
        public DateTime DeliveryDays { get; set; }
        public DateTime CartDate { get; set; }

    }
}
