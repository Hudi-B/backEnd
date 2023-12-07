using BlogApi.Models;
using BlogApi.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Repositories
{
    public class BlogUserContentService:IBlogUserContentInterface
    {
        private readonly BlogDbContext dbContext;

        public BlogUserContentService(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BlogUserContent>> Get()
        {
            return await dbContext.BlogUserContent.ToListAsync();
        }

        public Task<BlogUserContent> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<BlogUserContent> Post(CreateBlogUserContentDto createBlogUserContent)
        {
            var content = new BlogUserContent
            {
                Id = Guid.NewGuid(),
                Title = createBlogUserContent.Title,
                Content = createBlogUserContent.Content,
                blogUserId = createBlogUserContent.UserId,
                Created = DateTime.Now,
            };
            await dbContext.BlogUserContent.AddAsync(content);
            await dbContext.SaveChangesAsync();

            return content;
        }

        public Task<BlogUserContent> Put(Guid Id, UpdateBlogUserContentDto updateBlogUserContent)
        {
            throw new NotImplementedException();
        }
    }
}
