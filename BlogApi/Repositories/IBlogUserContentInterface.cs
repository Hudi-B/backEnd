using BlogApi.Models;
using BlogApi.Models.Dtos;

namespace BlogApi.Repositories
{
    public interface IBlogUserContentInterface
    {
        Task<IEnumerable<BlogUserContent>> Get();
        Task<BlogUserContent> GetById(Guid Id);
        Task<BlogUserContent> Post(CreateBlogUserContentDto createBlogUserContent);
        Task<BlogUserContent> Put(Guid Id, UpdateBlogUserContentDto updateBlogUserContent);
        Task Delete(Guid Id);
    }
}
