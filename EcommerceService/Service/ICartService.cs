using EcommerceData.Model;
using EcommerceData.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceService
{
    public interface ICartService
    {
        Task<IEnumerable<CartItem>> GetItems();
         Task<string> AddItems(CartItemRequest request);
        Task<List<CartItem>> GetItem(string id);
        Task<bool> UpdateCart(int id, int newItemNum);
        Task<bool> DeleteCart(int id);

        Task<List<CartItem>> GetItemByID(int id);
    }
}
