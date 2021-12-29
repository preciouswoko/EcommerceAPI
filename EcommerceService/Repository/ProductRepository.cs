using EcommerceData.Data;
using EcommerceData.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceService.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(EcommerceDbContext dbContext) : base(dbContext)
        {

        }
    }
}
