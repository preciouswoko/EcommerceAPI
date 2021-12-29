using EcommerceData.Model;
using EcommerceData.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceService.Service
{
   public  interface IProductService
    {
        IEnumerable<Product> GetProducts();
        void AddProduct(AddProductRequest request);
        Task<List<Product>> GetByVendor(int vendorid);
        Task<List<Product>> GetProduct(int productid);
        Task<List<Product>> SearchProduct(string name);
        Task<bool> UpdateProduct(int id, UpdateProductRequest request);
        Task<bool> DeleteProduct(int id);
    }
}
