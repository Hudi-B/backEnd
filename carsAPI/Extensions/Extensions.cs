namespace carsAPI.Extensions
{
    public static class Extensions
    {
        public static CarDTO AsDTO(this CarDTO car)
        {
            return new CarDTO(
                    car.Id,
                    car.Model,
                    car.Description,
                    car.CreatedTime
                );
        }
    }
}
