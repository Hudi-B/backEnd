using LibraryAPIv2.Models.Dtos;
using LibraryAPIv2.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPIv2.Repositories
{
    public class BookService : IBookInterface
    {
        private readonly LibraryV2Context dbContext;

        public BookService(LibraryV2Context dbContext)
        {
            this.dbContext = dbContext;
        }
        //POST
        public async Task<Book> Post(CreateBookDTO createBookDTO)
        {
            var author = await dbContext.Authors.FindAsync(createBookDTO.AuthorId);

            if (author == null)
            {
                throw new InvalidOperationException("No author with Id");
            }

            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = createBookDTO.Title,
                Genre = createBookDTO.Genre,
                Pubdate = createBookDTO.Pubdate,
                AuthorId = author.Id,
            };

            await dbContext.Books.AddAsync(book);
            await dbContext.SaveChangesAsync();

            return book;
        }
        //GET
        public async Task<IEnumerable<Book>> Get()
        {
            return await dbContext.Books
                                  .Include(x => x.Author)
                                  .ToListAsync();
        }
        //GETbyId
        public async Task<Book> GetById(Guid Id)
        {
            return await dbContext.Books
                                  .Include(x => x.Author)
                                  .FirstAsync(x => x.Id.Equals(Id));
        }
        //GETbyAuthor
        public async Task<IEnumerable<Book>> GetBooksByAuthor(Guid authorId)
        {
            return await dbContext.Books
                                  .Where(book => book.AuthorId == authorId)
                                  .ToListAsync();
        }
        //DELETE
        public async Task Delete(Guid Id)
        {
            await dbContext.Books.Where(x => x.Id == Id).ExecuteDeleteAsync();
            await dbContext.SaveChangesAsync();
        }
        //PUT
        public async Task<Book> Put(Guid Id, UpdateBookDTO updateBookDTO)
        {
            var bookId = await dbContext.Books.FirstOrDefaultAsync(x => x.Id.Equals(Id));
            bookId.Title = updateBookDTO.Title;
            bookId.Genre = updateBookDTO.Genre;
            bookId.Pubdate = updateBookDTO.Pubdate;
            bookId.AuthorId = updateBookDTO.AuthorId;

            await dbContext.SaveChangesAsync();

            return bookId;
        }
    }
}
