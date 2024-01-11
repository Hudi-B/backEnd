using LibraryAPIv2.Models.Dtos;
using LibraryAPIv2.Models;

namespace LibraryAPIv2.Repositories
{
    public interface INationalityInterface
    {
        Task<Nationality> Post(CreateNationalityDTO createNationalityDTO);
        Task<IEnumerable<Nationality>> Get();
        Task<Nationality> GetById(Guid Id);
        Task Delete(Guid Id);
        Task<Nationality> Put(Guid Id, UpdateNationalityDTO updateNationalityDTO);
    }
}
