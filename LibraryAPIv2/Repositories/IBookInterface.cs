using LibraryAPIv2.Models.Dtos;
using LibraryAPIv2.Models;

namespace LibraryAPIv2.Repositories
{
    public interface IBookInterface
    {
        Task<Book> Post(CreateBookDTO createBookDTO);
        Task<IEnumerable<Book>> Get();
        Task<Book> GetById(Guid Id);
        Task<IEnumerable<Book>> GetBooksByAuthor(Guid authorId);
        Task Delete(Guid Id);
        Task<Book> Put(Guid Id, UpdateBookDTO updateBookDTO);
    }
}
