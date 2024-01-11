using LibraryAPIv2.Models.Dtos;
using LibraryAPIv2.Models;
using LibraryAPIv2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPIv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorInterface authorInterface;

        public AuthorController(IAuthorInterface authorInterface)
        {
            this.authorInterface = authorInterface;
        }

        [HttpPost]
        public async Task<ActionResult<Author>> Post(CreateAuthorDTO createAuthorDTO)
        {
            return StatusCode(201, await authorInterface.Post(createAuthorDTO));
        }

        [HttpGet]
        public async Task<ActionResult<Author>> Get()
        {
            return StatusCode(201, await authorInterface.Get());
        }
        [HttpGet("id")]
        public async Task<ActionResult<Author>> GetById(Guid Id)
        {
            return await authorInterface.GetById(Id);
        }
        [HttpGet("nationality/{nationalityId}")]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthorsByNationality(Guid nationalityId)
        {
            var authors = await authorInterface.GetAuthorsByNationality(nationalityId);

            if (authors == null)
            {
                return NotFound();
            }

            return Ok(authors);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid Id)
        {
            await authorInterface.Delete(Id);
            return Ok();
        }
        [HttpPut("id")]
        public async Task<ActionResult<Author>> Put(Guid Id, UpdateAuthorDTO updateAuthorDTO)
        {
            var result = await authorInterface.Put(Id, updateAuthorDTO);
            return StatusCode(201, result);
        }
    }
}
