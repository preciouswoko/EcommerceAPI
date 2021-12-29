using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EcommerceData.ViewModel
{
    public class CartItemRequest
    {
        public string UserId { get; set; }
      
        [Required(ErrorMessage = "Number of item not picked")]
        [Display(Name = "Product Name")]
        [StringLength(maximumLength:  300, ErrorMessage ="Name too Long , give a shorter name")]
        public string ItemName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        [Display(Name = "Unit")]
        public int NumOfItem { get; set; }
    }
}
