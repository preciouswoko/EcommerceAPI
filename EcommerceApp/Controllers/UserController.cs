using EcommerceData.Response;
using EcommerceData.ViewModel;
using EcommerceService;
using EcommerceService.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApi.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [Route("Registration")]
        [HttpPost]
        public async Task<IActionResult> Registration([FromBody]UserRequest registrationRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return (StatusCode(400, new Response { ResponseCode = "99", ResponseMessage = "PLease Add the required value", Data = null }));
                }
                var res =await _userService.CreateUser(registrationRequest);
                return Ok(res);

            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
           
        }
        [Route("LogIn")]
        [HttpPost]
        public async Task<IActionResult> LogIn([FromBody] LoginRequest registrationRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return (StatusCode(400, new Response { ResponseCode = "99", ResponseMessage = "PLease Add the required value"}));
                }
                var res =await _userService.LogIn(registrationRequest);
                if (res.ToString() == "User Does Not Exist" || res.ToString() == "Wrong Password") return (StatusCode(400, res ));
                return (StatusCode(200, res));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }         
        }

        [Route("AddRole")]
        [HttpPost]
        public async Task<IActionResult> AddRole(string roles)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return (StatusCode(400, new Response { ResponseCode = "99", ResponseMessage = "PLease Add the required Role" }));
                }
               var val = await _userService.CreateRole(roles);
                if(val == null)
                {
                    return (StatusCode(400, new Response { ResponseCode = "99", ResponseMessage = "False Role" }));

                }
                return (StatusCode(200, new Response { ResponseCode = "00", ResponseMessage = "Sucessfull" }));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [Route("GetRoles")]
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                var val =   _userService.GetRoles().Result;
                if (val == null)
                {
                    return (StatusCode(400, new Response { ResponseCode = "99", ResponseMessage = "Role Not Found", Data = null }));
                }
                return Ok(new Response { ResponseCode = "00", ResponseMessage = "Sucessfull", Data = val });
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
        [Route("GetRoleName")]
        [HttpGet]
        public async Task<IActionResult> GetRoleName(string rolename)
        {
            try
            {
                var val = await _userService.GetRole(rolename);
                if (val == null)
                {
                    return (StatusCode(400, new Response { ResponseCode = "99", ResponseMessage = "Role Not Found", Data = null }));
                }
                return Ok(new Response { ResponseCode = "00", ResponseMessage = "Sucessfull", Data = val });
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }

}
