using EcommerceData.Data;
using EcommerceData.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceService.Repository
{
    public class CartRepository: Repository<CartItem>, ICartRepository
    {
        public CartRepository(EcommerceDbContext dbContext) : base(dbContext)
        {

        }
    }
}
