using BlogApi.Models;
using BlogApi.Models.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Repositories
{
    public class BlogUserService : IBlogUserInterface
    {
        private readonly BlogDbContext dbContext;

        public BlogUserService(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Delete(Guid Id)
        {
            await dbContext.BlogUsers.Where(x => x.Id==Id).ExecuteDeleteAsync();
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<BlogUser>> Get()
        {
            return await dbContext.BlogUsers.ToListAsync();
        }

        public async Task<BlogUser> GetById(Guid Id)
        {
            return await dbContext.BlogUsers.SingleOrDefaultAsync(x => x.Id.Equals(Id));
        }

        public async Task<BlogUser> Post(CreateBlogUserDto createBlogUserDto)
        {
            var user = new BlogUser
            {
                Id = Guid.NewGuid(),
                Username = createBlogUserDto.Username,
                UserEmail = createBlogUserDto.UserEmail,
                UserPassword= createBlogUserDto.Password,
                CreatedTime = DateTime.Now,
            };
            await dbContext.BlogUsers.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<BlogUser> Put(Guid Id,UpdateBlogUserDto updateBlogUserDto)
        {
            var findid = dbContext.BlogUsers.FirstOrDefault(x => x.Id.Equals(Id));
            findid.Username = updateBlogUserDto.Username;
            findid.UserEmail = updateBlogUserDto.UserEmail;
            findid.UserPassword = updateBlogUserDto.Password;

            await dbContext.SaveChangesAsync();

            return findid;
        }
    }
}
