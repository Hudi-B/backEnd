using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static productAPI.DTOs;

namespace productAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static readonly List<ProductDTO> productDTOs = new()
        {
            new ProductDTO(Guid.NewGuid(), "Termék1", 3000, DateTimeOffset.Now, DateTimeOffset.Now),
            new ProductDTO(Guid.NewGuid(), "Termék2", 3500, DateTimeOffset.Now, DateTimeOffset.Now),
            new ProductDTO(Guid.NewGuid(), "Termék3", 2000, DateTimeOffset.Now, DateTimeOffset.Now)
        };
    }
}
