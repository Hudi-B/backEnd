using LibraryAPI.Models;
using LibraryAPI.Models.Dtos;
using LibraryAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorInterface authorInterface;

        public AuthorController (IAuthorInterface authorInterface)
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
