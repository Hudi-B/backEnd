using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using static productAPI.DTOs;

namespace productAPI.Controllers
{
    [Route("productDTOs")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private static readonly List<ProductDTO> productDTOs = new()
        {
            new ProductDTO(Guid.NewGuid(), "Termék1", 3023, DateTimeOffset.Now, DateTimeOffset.Now),
            new ProductDTO(Guid.NewGuid(), "Termék2", 3500, DateTimeOffset.Now, DateTimeOffset.Now),
            new ProductDTO(Guid.NewGuid(), "Termék3", 2000, DateTimeOffset.Now, DateTimeOffset.Now)
        };

        [HttpGet]
        public IEnumerable<ProductDTO> GetAll()
        {
            return productDTOs;
        }

        [HttpGet("{id}")]
        public ProductDTO GetById(Guid id)
        {
            var product = productDTOs.Where(x => x.Id == id).FirstOrDefault();
            return product!;
        }

        [HttpPost]
        public ProductDTO PostProduct(CreateProductDTO createProduct)
        {
            var product = new ProductDTO(
                Guid.NewGuid(),
                createProduct.ProductName,
                createProduct.ProductPrice,
                DateTimeOffset.Now,
                DateTimeOffset.Now
                );

            productDTOs.Add(product);

            return product;
        }
    }
}
