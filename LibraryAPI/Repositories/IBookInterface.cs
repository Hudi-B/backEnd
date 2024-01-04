using LibraryAPI.Models;
using LibraryAPI.Models.Dtos;

namespace LibraryAPI.Repositories
{
    public interface IBookInterface
    {
        Task<Book> Post(CreateBookDTO createBookDTO);
        Task<IEnumerable<Book>> Get();
        Task<Book> GetById(Guid Id);
        Task Delete(Guid Id);
        Task<Book> Put(Guid Id, UpdateBookDTO updateBookDTO);
    }
}
