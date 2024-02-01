using Authentication.Models.DTOs;
using Authentication.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuth _authService;

        public AuthController(IAuth authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO requestDTO)
        {
            var errorMessage = await _authService.Register(requestDTO);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                return StatusCode(400, errorMessage);
            }

            return StatusCode(201, "Successful Registration.");
        }

        [HttpPost("AssignRole")]
        public async Task<ActionResult> AssignRole([FromBody] RoleDTO roleDTO)
        {
            var assignRoleSuccessful = await _authService.AssignRole(roleDTO.Email, roleDTO.RoleName.ToUpper());

            if (!assignRoleSuccessful)
            {
                return BadRequest();
            }

            return StatusCode(200, "Successful role assignment.");
        }
    }
}
