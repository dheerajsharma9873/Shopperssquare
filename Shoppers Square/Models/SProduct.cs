using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Shoppers_Square.Models
{
    public class SProduct
    {
        [Key]
        public int Pid { get; set; }
        [Required(ErrorMessage ="Product name is required")]
        public string PName { get; set; }
        [Required(ErrorMessage ="Product price is required")]
        public double PPrice { get; set; }
        [Required(ErrorMessage ="Product Details is required")]
        public string PDetails { get; set; }
        public string ProductImage { get; set; }

    }
}