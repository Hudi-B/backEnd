using LibraryAPIv2.Models;
using LibraryAPIv2.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPIv2.Repositories
{
    public class NationalityService : INationalityInterface
    {
        private readonly LibraryV2Context dbContext;

        public NationalityService(LibraryV2Context dbContext)
        {
            this.dbContext = dbContext;
        }
        //POST
        public async Task<Nationality> Post(CreateNationalityDTO createNationalityDTO)
        {
            var nationality = new Nationality
            {
                Id = Guid.NewGuid(),
                Nation = createNationalityDTO.Nation,
            };
            await dbContext.Nationalities.AddAsync(nationality);
            await dbContext.SaveChangesAsync();

            return nationality;
        }
        //GET
        public async Task<IEnumerable<Nationality>> Get()
        {
            return await dbContext.Nationalities
                                  .Include(x => x.Authors)
                                  .ToListAsync();
        }
        //GETbyId
        public async Task<Nationality> GetById(Guid Id)
        {
            return await dbContext.Nationalities
                                  .Include(x => x.Authors)
                                  .FirstAsync(x => x.Id.Equals(Id));
        }
        //DELETE
        public async Task Delete(Guid Id)
        {
            await dbContext.Nationalities.Where(x => x.Id == Id).ExecuteDeleteAsync();
            await dbContext.SaveChangesAsync();
        }
        //PUT
        public async Task<Nationality> Put(Guid Id, UpdateNationalityDTO updateNationalityDTO)
        {
            var authorId = await dbContext.Nationalities.FirstOrDefaultAsync(x => x.Id.Equals(Id));
            authorId.Nation = updateNationalityDTO.Nation;

            await dbContext.SaveChangesAsync();

            return authorId;
        }
    }
}
