using EcommerceData.Response;
using EcommerceData.ViewModel;
using EcommerceService.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApi.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductService;

        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }

        // GET: ProductController
        [Route("GetProducts")]
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
               var val=_ProductService.GetProducts();
                if (val == null)
                {
                    return (StatusCode(400, new Response { ResponseCode = "99", ResponseMessage = "Id Not Found", Data = null }));
                }
                return Ok(new Response { ResponseCode = "00", ResponseMessage = "Sucessfull", Data = val });
            }
            catch(Exception e)
            {
                return StatusCode(500, e);
            }
            
        }

        // POST: ProductController /Create
        [Route("AddProduct")]
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddProductRequest request)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return (StatusCode(400, new Response { ResponseCode = "99", ResponseMessage = "PLease Add the required value", Data = null }));

                }
                 _ProductService.AddProduct(request);
                return Ok(new Response { ResponseCode = "00", ResponseMessage = "Sucessfull", Data = null });
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        // GET: ProductController/Id
        [Route("GetVendorById")]
        [HttpGet]
        public async Task<IActionResult> GetVendorById(int vendorid)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var val = await _ProductService.GetByVendor(vendorid);
                    if (val.Count == 0)
                    {
                        return (StatusCode(400, new Response { ResponseCode = "99", ResponseMessage = "Id Not Found", Data = null }));
                    }
                    return Ok(new Response { ResponseCode = "00", ResponseMessage = "Sucessfull", Data = val });
                }
                return (StatusCode(400, new Response { ResponseCode = "99", ResponseMessage = "Id Not Found", Data = null }));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }


        }
        // GET: ProductController/Id
        [Route("GetProductById")]
        [HttpGet]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                //var d =2 << 10;
                var val = await _ProductService.GetProduct(id);
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

        // PUT: ProductController/Edit
        [Route("UpdateProduct")]
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool res = await _ProductService.UpdateProduct(id, request);
                    if (res == false)
                    {
                        return (StatusCode(400, new Response { ResponseCode = "99", ResponseMessage = "Id Not Found", Data = null }));
                    }
                    return Ok(new Response { ResponseCode = "00", ResponseMessage = "Sucessfull", Data = null });
                }
                return (StatusCode(400, new Response { ResponseCode = "99", ResponseMessage = "invalid details", Data = null }));

            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }

        }

        // DELETE ProductController
        [Route("DeleteProduct")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                bool res = await _ProductService.DeleteProduct(id);
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
