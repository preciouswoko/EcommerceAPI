using EcommerceData.Model;
using EcommerceData.ViewModel;
using EcommerceService.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceService
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<IEnumerable<CartItem>> GetItems()
        {

            return _cartRepository.GetAll();
        }
        public async void AddItems(CartItemRequest request)
        {
            CartItem ci = new CartItem()
            {
                // UserId = "1234",
                UserId = request.UserId,
                ItemName = request.ItemName,
                NumOfItem = request.NumOfItem

            };
            _cartRepository.Add(ci);
        }
        public async Task<List<CartItem>> GetItem(string userid)
        {

            return await _cartRepository.GetByCondition(x => x.UserId == userid);

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

