using BlogApi.Models;
using BlogApi.Models.Dtos;

namespace BlogApi.Repositories
{
    public interface IBlogUserInterface
    {
        Task<IEnumerable<BlogUser>> Get();
        Task<BlogUser> GetById(Guid Id);
        Task<BlogUser> Post(CreateBlogUserDto createBlogUserDto);
        Task<BlogUser> Put(Guid Id,UpdateBlogUserDto updateBlogUserDto);
        Task Delete(Guid Id);
    }
}
