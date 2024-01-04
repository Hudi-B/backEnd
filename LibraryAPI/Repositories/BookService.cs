using LibraryAPI.Models;
using LibraryAPI.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Repositories
{
    public class BookService : IBookInterface
    {
        private readonly LibraryDbContext dbContext;

        public BookService(LibraryDbContext dbContext)
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
                PublicationDate = createBookDTO.PublicationDate.Date,
                Availability = createBookDTO.Availability,
                Author = author
            };
            await dbContext.Books.AddAsync(book);
            await dbContext.SaveChangesAsync();

            return book;
        }
        //GET
        public async Task<IEnumerable<Book>> Get()
        {
            return await dbContext.Books.ToListAsync();
        }
        //GETbyId
        public async Task<Book> GetById(Guid Id)
        {
            return await dbContext.Books.FirstAsync(x => x.Id.Equals(Id));
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
            bookId.PublicationDate = updateBookDTO.PublicationDate.Date;
            bookId.Availability = updateBookDTO.Availability;

            await dbContext.SaveChangesAsync();

            return bookId;
        }
    }
}
