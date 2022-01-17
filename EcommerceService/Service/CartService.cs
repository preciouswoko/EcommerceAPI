using EcommerceData.Model;
using EcommerceData.ViewModel;
using EcommerceService.Repository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceService
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        public CartService(ICartRepository cartRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<CartItem>> GetItems()
        {

            return _cartRepository.GetAll();
        }
        public async Task<string> AddItems(CartItemRequest request)
        {
            try 
            {
                
                var product = await _productRepository.GetBySingleCondition(x => x.Id == request.ItemId);

                if (product != null)
                {
                    if (product.Quantity < request.NumOfItem)
                    {
                        return "Number of product remains " + product.Quantity;
                    }
                    CartItem ci = new CartItem()
                    {
                        // UserId = "1234",
                        UserId = request.UserId,
                        ItemName = request.ItemName,
                        NumOfItem = request.NumOfItem

                    };
                    
                    _cartRepository.Add(ci);
                    return "";

                }
                return "Product does not exist";
            }
            catch (Exception ex)
            {
                var e = ex;
                return ex.Message;
            }
          
            
        }
        public async Task<List<CartItem>> GetItem(string userid)
        {

            return await _cartRepository.GetByCondition(x => x.UserId == userid);

        }

        public async Task<List<CartItem>> GetItemByID(int id)
        {

            return await _cartRepository.GetByCondition(x => x.Id == id);

        }
        public async Task<bool> UpdateCart(int id, int newItemNum)
        {
            try
            {
                var itemWeWantEdit = await _cartRepository.GetbyID(id);
                if(itemWeWantEdit == null)
                {
                    return false; 
                }
                itemWeWantEdit.NumOfItem = newItemNum;
                _cartRepository.Update(itemWeWantEdit);
                return true;
            }
            catch(Exception e )
            {
                var ee = e;
                return false;
            }

            


        }
        public async Task<bool> DeleteCart(int id)
        {
            try
            {
                var itemWeWantToDel = await _cartRepository.GetbyID(id);
                _cartRepository.Delete(itemWeWantToDel);
                return true;
            }
            catch(Exception e)
            {
                var ee = e;
                return false;
            }
            

        }



    }


    }

