using BlogApi.Models;
using BlogApi.Models.Dtos;
using BlogApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Win32.SafeHandles;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class BlogUserController : ControllerBase
    {
        private readonly IBlogUserInterface blogUserInterface;

        public BlogUserController(IBlogUserInterface blogUserInterface)
        {
            this.blogUserInterface = blogUserInterface;
        }

        [HttpPost]
        public async Task<ActionResult<BlogUser>> Post(CreateBlogUserDto createBlogUserDto)
        {
            return StatusCode(201, await blogUserInterface.Post(createBlogUserDto));
        }
        [HttpGet]
        public async Task<ActionResult<BlogUser>> Get()
        {
            return StatusCode(201, await blogUserInterface.Get());
        }

        [HttpGet("id")]
        public async Task<ActionResult<BlogUser>> GetById(Guid Id) 
        {
            return await blogUserInterface.GetById(Id);
        }
        [HttpPut]
        public async Task<ActionResult<BlogUser>> Put(Guid Id, UpdateBlogUserDto updateBlogUserDto) 
        {
            var result = await blogUserInterface.Put(Id, updateBlogUserDto);
            return StatusCode(201,result);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid Id) 
        {
            await blogUserInterface.Delete(Id);
            return Ok();
        }

    }
}
