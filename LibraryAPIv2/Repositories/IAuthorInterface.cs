using LibraryAPIv2.Models.Dtos;
using LibraryAPIv2.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPIv2.Repositories
{
    public interface IAuthorInterface
    {
        Task<Author> Post(CreateAuthorDTO createAuthorDTO);
        Task<IEnumerable<Author>> Get();
        Task<Author> GetById(Guid Id);
        Task<IEnumerable<Author>> GetAuthorsByNationality(Guid nationalityId);
        Task Delete(Guid Id);
        Task<Author> Put(Guid Id, UpdateAuthorDTO updateAuthorDTO);
    }
}
