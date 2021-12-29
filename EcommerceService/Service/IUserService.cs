using EcommerceData.Model;
using EcommerceData.Response;
using EcommerceData.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceService.Service
{
    public interface IUserService
    {
        Task<object> CreateUser(UserRequest userRequest);
        Task<object> LogIn(LoginRequest loginRequest);
        Task<object> CreateRole(string roleName);
        Task<List<GetRoleRequest>> GetRoles();
        Task<object> GetRole(string rolename);

    }
}
