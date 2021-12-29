using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EcommerceData.ViewModel
{
   public class CategoryRequest
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(maximumLength: 300, ErrorMessage = "Name too Long , give a shorter name")]
        public string CategoryName { get; set; }
    }
}
