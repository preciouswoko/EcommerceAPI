using EcommerceData.Model;
using EcommerceData.ViewModel;
using EcommerceService.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceService.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public  IEnumerable<Product> GetProducts()
        {
            IEnumerable<Product> products = new List<Product>();
            try
            {
                products =_productRepository.GetAll();
                return products;
            }
            catch(Exception e)
            {
                var ee = e;
                return products;
            }

        }

        public async Task<List<Product>> GetByVendor(int vendorid)
        {
            var product = new List<Product>();
            try
            {
                product = await _productRepository.GetByCondition(x => x.VendorId == vendorid);

                return product;
            }
            catch (Exception e)
            {
                var ee = e;
                return product;
            }


        }

        public async Task<List<Product>> GetProduct(int productid)
        {
            var product = new List<Product>();


            try
            {
                product = await _productRepository.GetByCondition(x => x.Id == productid);

                return product;
            }
            catch (Exception e)
            {
                var ee = e;
                return product;
            }


        }
        public async Task<List<Product>> SearchProduct(string name)
        {
            List<Product> prod = new List<Product>();
            try
            {
               prod = await _productRepository.GetByCondition(x => x.Name == name);

                return prod;
            }
            catch (Exception e)
            {
                var ee = e;
                return prod;
            }
        }

        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                var productWeWantToDel = await _productRepository.GetbyID(id);
                _productRepository.Delete(productWeWantToDel);
                return true;
            }
            catch (Exception e)
            {
                var ee = e;
                return false;
            }


        }

        public async Task<bool> UpdateProduct(int id, UpdateProductRequest request)
        {
            try
            {
                var productWeWantEdit = await _productRepository.GetbyID(id);
                if (productWeWantEdit == null)
                {
                    return false;
                }
                productWeWantEdit.Name = request.Name;
                productWeWantEdit.Price = request.Price;
               // productWeWantEdit.PictureURL = productpictureurl;
                productWeWantEdit.Quantity = request.Quantity;
                _productRepository.Update(productWeWantEdit);
                return true;
            }
            catch (Exception e)
            {
                var ee = e;
                return false;
            }
        }

        public async void AddProduct(AddProductRequest request)
        {
            Product ci = new Product()
            {
                VendorId = request.VendorId,
                Name = request.Name,
               // PictureURL = request.PictureURL,
                Quantity = request.Quantity,
                Price = request.Price

            };
            _productRepository.Add(ci);
        }
    }
}
