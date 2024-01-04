using LibraryAPI.Models.Dtos;
using LibraryAPI.Models;
using LibraryAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookInterface bookInterface;

        public BookController (IBookInterface bookInterface)
        {
            this.bookInterface = bookInterface;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> Post(CreateBookDTO createBookDTO)
        {
            return StatusCode(201, await bookInterface.Post(createBookDTO));
        }

        [HttpGet]
        public async Task<ActionResult<Book>> Get()
        {
            return StatusCode(201, await bookInterface.Get());
        }
        [HttpGet("id")]
        public async Task<ActionResult<Book>> GetById(Guid Id)
        {
            return await bookInterface.GetById(Id);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid Id)
        {
            await bookInterface.Delete(Id);
            return Ok();
        }
        [HttpPut("id")]
        public async Task<ActionResult<Book>> Put(Guid Id, UpdateBookDTO updateBookDTO)
        {
            var result = await bookInterface.Put(Id, updateBookDTO);
            return StatusCode(201, result);
        }
    }
}
