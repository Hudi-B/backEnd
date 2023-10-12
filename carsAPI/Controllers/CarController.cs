using carsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace carsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        [HttpPost]
        public ActionResult<CarDTO> AddCar(CreateCarDTO car)
        {
            using (var contxt = new CarContext())
            {
                var rqst = new Car
                {
                    Id = Guid.NewGuid(),
                    Model = car.Model,
                    Description = car.Description,
                    CreatedTime = DateTime.Now
                };

                contxt.Cars.Add(rqst);
                contxt.SaveChanges();

                return Ok(rqst);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Car> UpdateCar(UpdateCarDTO car, Guid id)
        {
            using (var contxt = new CarContext())
            {
                var rslt = contxt.Cars.Find(id);
                rslt!.Model = car.Model;
                rslt!.Description = car.Description;

                contxt.SaveChanges();
                return Ok(rslt);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Car> DeleteCar(Guid id)
        {
            using (var contxt = new CarContext())
            {
                var rslt = contxt.Cars.Find(id);
                contxt.Cars.Remove(rslt!);
                contxt.SaveChanges();

                return Ok(rslt);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetCars()
        {
            using (var contxt = new CarContext())
            {
                return Ok(contxt.Cars.ToList());
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Car> GetCarsById(Guid id)
        {
            using (var contxt = new CarContext())
            {
                var rslt = contxt.Cars.FirstOrDefault(x => x.Id == id);
                return Ok(rslt);
            }
        }
    }
}
