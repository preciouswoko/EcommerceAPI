using EcommerceData.Model;
using EcommerceData.Response;
using EcommerceData.ViewModel;
using EcommerceService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace EcommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [Route("GetCart")]
        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return (StatusCode(400, new Response { ResponseCode = "99", ResponseMessage = "Invalid Details", Data = null }));

                }
                var val = _cartService.GetItems();
                if (val == null)
                {
                    return (StatusCode(400, new Response { ResponseCode = "99", ResponseMessage = "Id Not Found", Data = null }));
                }
                return Ok(new Response { ResponseCode = "00", ResponseMessage = "Sucessfull", Data = val });
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
        [Route("AddCart")]
        [HttpPost]
        public async Task<IActionResult> AddCart([FromBody] CartItemRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                       return (StatusCode(400, new Response { ResponseCode = "99", ResponseMessage = "Id Not Found", Data = null }));
                   
                }
                _cartService.AddItems(request);

                return Ok(new Response { ResponseCode = "00", ResponseMessage = "Sucessfull", Data = null });

                //return (StatusCode(400, new Response { ResponseCode = "99", ResponseMessage = "Invalid Details", Data = null }));
            }
               
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [Route("GetCartById")]
        [HttpGet]
        public async Task<IActionResult> GetCartById(string userid)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return (StatusCode(400, new Response { ResponseCode = "99", ResponseMessage = "Id Not Found", Data = null }));

                }
                var val = await _cartService.GetItem(userid);
                if (val.Count == 0)
                {
                    return (StatusCode(400, new Response { ResponseCode = "99", ResponseMessage = "Id Not Found", Data = null }));
                }
                return Ok(new Response { ResponseCode = "00", ResponseMessage = "Sucessfull", Data = val });
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [Route("UpdateCart")]
        [HttpPut]
        public async Task<IActionResult> UpdateCart(int id, int newCartItemNum)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return (StatusCode(400, new Response { ResponseCode = "99", ResponseMessage = "Invalid details", Data = null }));

                }
                bool res = await _cartService.UpdateCart(id, newCartItemNum);
                if (res == false)
                {
                    return (StatusCode(400, new Response { ResponseCode = "99", ResponseMessage = "Id Not Found", Data = null }));
                }
                return Ok(new Response { ResponseCode = "00", ResponseMessage = "Sucessfull", Data = null });

            }
            catch(Exception e)
            {
                return StatusCode(500, e);
            }
            
        }


        [Route("DeleteCart")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCart(int id)
        {
            try
            {
                var res = await _cartService.DeleteCart(id);
                if (res == false)
                {
                    return (StatusCode(400, new Response { ResponseCode = "99", ResponseMessage = "Id Not Found", Data = null }));
                }
                return Ok(new Response { ResponseCode = "00", ResponseMessage = "Sucessfull", Data = null });
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }

        }
    }
}
