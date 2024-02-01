using Auth.Models;
using Authentication.Models.DTOs;
using Authentication.Service.IService;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Service
{
    public class AuthService : IAuth
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly IJwtGenerator _jwtGenerator;

        public AuthService(AppDbContext appDbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IJwtGenerator jwtGenerator)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<bool> AssignRole(string email, string roleName)
        {
            var user = _appDbContext.AppUser
                .FirstOrDefault(user => user.Email.ToLower() == email.ToLower());

            if (user != null)
            {
                if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                {
                    _roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
                }

                await _userManager.AddToRoleAsync(user, roleName);

                return true;
            }

            return false;
        }
        public async Task<string> Register(RegisterRequestDTO registerRequestDTO)
        {
            ApplicationUser user = new()
            {
                UserName = registerRequestDTO.UserName,
                NormalizedUserName = registerRequestDTO.UserName.ToUpper(),
                Email = registerRequestDTO.Email,
                Age = registerRequestDTO.Age,
                Fullname = registerRequestDTO.Fullname,
            };

            try
            {
                var result = await _userManager.CreateAsync(user, registerRequestDTO.Password);

                if (result.Succeeded)
                {
                    var userToReturn = await _userManager.FindByNameAsync(registerRequestDTO.UserName);

                    RegisterResponseDTO registerResponseDTO = new()
                    {
                        Id = userToReturn.Id,
                        Email = userToReturn.Email,
                        UserName = userToReturn.UserName,
                        FullName = userToReturn.Fullname
                    };

                    return registerResponseDTO.Id;
                }
                else
                {
                    return result.Errors.FirstOrDefault()?.Description ?? "An unknown error occurred.";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            //TODO
        }
    }
}
