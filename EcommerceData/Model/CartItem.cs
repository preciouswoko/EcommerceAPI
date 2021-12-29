using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EcommerceData.Model
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ItemName { get; set; }
        public int NumOfItem { get; set; }
    }
}
