using LibraryAPI.Models;
using LibraryAPI.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Repositories
{
    public class AuthorService : IAuthorInterface
    {
        private readonly LibraryDbContext dbContext;

        public AuthorService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //POST
        public async Task<Author> Post(CreateAuthorDTO createAuthorDTO)
        {
            var author = new Author
            {
                Id = Guid.NewGuid(),
                Name = createAuthorDTO.Name,
                Birthdate = createAuthorDTO.Birthdate.Date,
                Nationality = createAuthorDTO.Nationality
            };
            await dbContext.Authors.AddAsync(author);
            await dbContext.SaveChangesAsync();

            return author;
        }
        //GET
        public async Task<IEnumerable<Author>> Get()
        {
            return await dbContext.Authors.ToListAsync();
        }
        //GETbyId
        public async Task<Author> GetById(Guid Id)
        {
            return await dbContext.Authors.FirstAsync(x => x.Id.Equals(Id));
        }
        //DELETE
        public async Task Delete(Guid Id)
        {
            await dbContext.Authors.Where(x => x.Id == Id).ExecuteDeleteAsync();
            await dbContext.SaveChangesAsync();
        }
        //PUT
        public async Task<Author> Put(Guid Id, UpdateAuthorDTO updateAuthorDTO)
        {
            var authorId = await dbContext.Authors.FirstOrDefaultAsync(x => x.Id.Equals(Id));
            authorId.Name = updateAuthorDTO.Name;
            authorId.Birthdate = updateAuthorDTO.Birthdate;
            authorId.Nationality = updateAuthorDTO.Nationality;

            await dbContext.SaveChangesAsync();

            return authorId;
        }
    }
}
