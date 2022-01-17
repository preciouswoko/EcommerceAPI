using EcommerceData.Model;
using EcommerceData.Response;
using EcommerceData.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceService.Service
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<object> CreateUser(UserRequest userRequest)
        {
            try
            {
                var userExists = await _userManager.FindByNameAsync(userRequest.EmailAddress);
                if (userExists != null) return"User Already Exist" ;
                User user = new User()
                {
                    FirstName = userRequest.FirstName,
                    LastName = userRequest.LastName,
                    PhoneNumber = userRequest.PhoneNumber,
                    ProfilePicture = userRequest.ProfilePicture,
                    Email = userRequest.EmailAddress,
                    UserName = userRequest.EmailAddress
                };
                var res = await _userManager.CreateAsync(user, userRequest.Password);
                if(res.Succeeded!=true)return res;
                LoginRequest login = new LoginRequest()
                {
                    EmailAddress = userRequest.EmailAddress,
                    Password = userRequest.Password
                };
                var token = await LogIn(login);
                return token;
            }
            catch (Exception ex)
            {
                return ex;
            }



        }

        public async Task<Object> LogIn(LoginRequest loginRequest)
        {
            try
            {
                //var username = Microsoft.AspNetCore.Http.HttpContext.Current.User.Identity.Name;
                var user1 = _userManager.Users.SingleOrDefault(u => u.UserName == loginRequest.EmailAddress);
                if (user1 is null) return "User Does Not Exist";
                var userSigninResult = await _userManager.CheckPasswordAsync(user1, loginRequest.Password);
                //var gg =await _userManager.AddLoginAsync(user );
                if (!userSigninResult) return "Wrong Password";
                var userRoles = await _userManager.GetRolesAsync(user1);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user1.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }


                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return (new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
              //  return "Logged in Successfully";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        public async Task<Object> CreateRole(string roleName)
        {
            try
            {
                var newRole = new IdentityRole
                {
                    Name = roleName
                };
                var res = await _roleManager.CreateAsync(newRole);
                return res;

            }
            catch (Exception ex)
            {
                return ex;
            }

        }

        public async Task<List<GetRoleRequest>> GetRoles()
        {
            List<GetRoleRequest> allRoles = new List<GetRoleRequest>();
            try
            {
                var response = _roleManager.Roles.ToList();                
                foreach( IdentityRole res in response)
                {
                    GetRoleRequest getRoleRequest = new GetRoleRequest()
                    {
                        RoleId = res.Id,
                        RoleName = res.Name
                    };
                    allRoles.Add(getRoleRequest);
                }
                
                
                
            }
            
            catch (Exception ex)
            {
                var e =ex;
            }
            return allRoles;
        }

        public async Task<object> GetRole(string rolename)
        {
            try
            {
                var response = await _roleManager.FindByNameAsync(rolename);
                GetRoleRequest getRoleRequest = new GetRoleRequest()
                {
                    RoleId = response.Id,
                    RoleName = response.Name
                };
                return getRoleRequest;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        //public async Task<object> ResetPassword(string token, string newpassword, string oldPassword)
        //{
        //    try
        //    {

        //        var user = await _userManager.FindByIdAsync();
        //        if (user == null)
        //            return Error("No user found!");

        //        Microsoft.AspNetCore.Identity.SignInResult checkOldPassword =
        //            await _signInManager.PasswordSignInAsync(user.UserName, model.OldPassword, false, false);

        //        if (!checkOldPassword.Succeeded)
        //            return Error("Old password does not matched.");

        //        string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
        //        if (string.IsNullOrEmpty(resetToken))
        //            return Error("Error while generating reset token.");

        //        var result = await _userManager.ResetPasswordAsync(user, resetToken, model.Password);

        //        if (result.Succeeded)
        //            return Result();
        //        else
        //            return Error();
        //    }
        //    catch(Exception ex)
        //    {

        //    }
        //}

    }
}


