using System.Net.NetworkInformation;
using users.Models;
using static users.Dtos;

namespace users
{
    public static class Extensions //for connecting database with records
    {
        public static UserDto AsDto(this User user)
        {
            return new UserDto(user.Id, user.Name, user.Email, user.Age, user.Created);
        }
    }
}
