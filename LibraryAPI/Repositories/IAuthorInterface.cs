using LibraryAPI.Models;
using LibraryAPI.Models.Dtos;

namespace LibraryAPI.Repositories
{
    public interface IAuthorInterface
    {
        Task<Author> Post(CreateAuthorDTO createAuthorDTO);
        Task<IEnumerable<Author>> Get();
        Task<Author> GetById(Guid Id);
        Task Delete(Guid Id);
        Task<Author> Put(Guid Id, UpdateAuthorDTO updateAuthorDTO);
    }
}
