using Auth.Models;

namespace Authentication.Service.IService
{
    public interface IJwtGenerator
    {
        string GenerateJwtToken(ApplicationUser applicationUser, IEnumerable<string> roles);
    }
}
