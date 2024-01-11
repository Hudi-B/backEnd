using LibraryAPIv2.Models.Dtos;
using LibraryAPIv2.Models;
using LibraryAPIv2.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPIv2.Repositories
{
    public class AuthorService : IAuthorInterface
    {
        private readonly LibraryV2Context dbContext;

        public AuthorService(LibraryV2Context dbContext)
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
                Gender = createAuthorDTO.Gender,
                NationalityId = createAuthorDTO.NationalityId
            };
            await dbContext.Authors.AddAsync(author);
            await dbContext.SaveChangesAsync();

            return author;
        }
        //GET
        public async Task<IEnumerable<Author>> Get()
        {
            return await dbContext.Authors
                                  .Include(x => x.Nationality)
                                  .Include(x => x.Books)
                                  .ToListAsync();
        }
        //GETbyId
        public async Task<Author> GetById(Guid Id)
        {
            return await dbContext.Authors
                                  .Include(x => x.Nationality)
                                  .Include(x => x.Books)
                                  .FirstAsync(x => x.Id.Equals(Id));
        }
        //GETbyNationality
        public async Task<IEnumerable<Author>> GetAuthorsByNationality(Guid nationalityId)
        {
            return await dbContext.Authors
                                  .Where(author => author.NationalityId == nationalityId)
                                  .ToListAsync();
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
            authorId.Gender = updateAuthorDTO.Gender;
            authorId.NationalityId = updateAuthorDTO.NationalityId;

            await dbContext.SaveChangesAsync();

            return authorId;
        }
    }
}
