using EcommerceData.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceData.Data
{
    public class EcommerceDbContext:  IdentityDbContext<User>
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options)
         : base(options)
        {
        }
        public DbSet<CartItem> CartItem { get; set; }
        public DbSet<Product> Product { get; set; }

    }
}
