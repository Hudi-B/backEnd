using Authentication.Models.DTOs;
using Microsoft.AspNetCore.Identity.Data;

namespace Authentication.Service.IService
{
    public interface IAuth
    {
        Task<string> Register(RegisterRequestDTO registerRequestDTO);
        Task<bool> AssignRole(string email, string roleName);
    }
}
