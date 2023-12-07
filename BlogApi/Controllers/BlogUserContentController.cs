using BlogApi.Models;
using BlogApi.Models.Dtos;
using BlogApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogUserContentController : ControllerBase
    {
        private readonly IBlogUserContentInterface blogUserContent;

        public BlogUserContentController(IBlogUserContentInterface blogUserContent)
        {
            this.blogUserContent = blogUserContent;
        }

        [HttpPost]

        public async Task<ActionResult<BlogUserContent>> Post(CreateBlogUserContentDto createBlogUserContent) 
        {
            return StatusCode(201, await blogUserContent.Post(createBlogUserContent));
        }

        [HttpGet]
        public async Task<ActionResult<BlogUserContent>> Get() 
        {
            return StatusCode(201, await blogUserContent.Get());
        }

        

    }
}
