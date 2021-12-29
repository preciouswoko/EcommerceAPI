using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EcommerceData.ViewModel
{
    public class AddProductRequest
    {
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int VendorId { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public double Price { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int Quantity { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        [StringLength(maximumLength: 300, ErrorMessage = "Name too Long , give a shorter name")]
        public string Name { get; set; }

        [Required]
        public string ProductCategory { get; set; }

        [Required]
        public double Discount { get; set; }
        public DateTime DateCreated { get; set; }
        public string Picture { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double ProductWeight { get; set; }
        public double ProductSize { get; set; }

        [Required]
        public string Specfication { get; set; }

        [Required]
        public DateTime DeliveryDays { get; set; }
        public DateTime CartDate { get; set; }
        // public string PictureURL { get; set; }
    }
    public class UpdateProductRequest
    {
        [Required]
        //public int VendorId { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public double Price { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int Quantity { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        [StringLength(maximumLength: 300, ErrorMessage = "Name too Long , give a shorter name")]
        public string Name { get; set; }
        public string ProductCategory { get; set; }
        public double Discount { get; set; }
        public DateTime DateCreated { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public double ProductWeight { get; set; }
        public double ProductSize { get; set; }
        [Required]
        public string Specfication { get; set; }
        [Required]
        public DateTime DeliveryDays { get; set; }
        public DateTime CartDate { get; set; }
        // public string PictureURL { get; set; }
    }
}
