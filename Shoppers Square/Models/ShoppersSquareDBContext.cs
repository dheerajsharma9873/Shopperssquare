using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Shoppers_Square.Models
{
    public class ShoppersSquareDBContext : DbContext
    {
        public DbSet<Users> userDetail { get; set; }
        public DbSet<SProduct> productDetails { get; set; }

        }
}