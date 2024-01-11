using LibraryAPIv2.Models.Dtos;
using LibraryAPIv2.Models;
using LibraryAPIv2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPIv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalityController : ControllerBase
    {
        private readonly INationalityInterface NationalityInterface;

        public NationalityController(INationalityInterface NationalityInterface)
        {
            this.NationalityInterface = NationalityInterface;
        }

        [HttpPost]
        public async Task<ActionResult<Nationality>> Post(CreateNationalityDTO createNationalityDTO)
        {
            return StatusCode(201, await NationalityInterface.Post(createNationalityDTO));
        }

        [HttpGet]
        public async Task<ActionResult<Nationality>> Get()
        {
            return StatusCode(201, await NationalityInterface.Get());
        }
        [HttpGet("id")]
        public async Task<ActionResult<Nationality>> GetById(Guid Id)
        {
            return await NationalityInterface.GetById(Id);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid Id)
        {
            await NationalityInterface.Delete(Id);
            return Ok();
        }
        [HttpPut("id")]
        public async Task<ActionResult<Nationality>> Put(Guid Id, UpdateNationalityDTO updateNationalityDTO)
        {
            var result = await NationalityInterface.Put(Id, updateNationalityDTO);
            return StatusCode(201, result);
        }
    }
}
