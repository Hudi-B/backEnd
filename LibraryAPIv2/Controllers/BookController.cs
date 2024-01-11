using LibraryAPIv2.Models.Dtos;
using LibraryAPIv2.Models;
using LibraryAPIv2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPIv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookInterface bookInterface;

        public BookController(IBookInterface bookInterface)
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
        [HttpGet("author/{authorId}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksByAuthor(Guid authorId)
        {
            var books = await bookInterface.GetBooksByAuthor(authorId);

            if (books == null || !books.Any())
            {
                return NotFound();
            }

            return Ok(books);
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
