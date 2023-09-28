using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Security;
using System;
using users.Models;
using static users.Dtos;

namespace users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        Connect connect = new();
        private readonly List<UserDto> users = new();

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetDatabase()
        {
            try
            {
                connect.connection.Open();

                string sql = "SELECT * FROM `users`";
                MySqlCommand cmd = new MySqlCommand(sql, connect.connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                foreach (var data in reader) 
                {
                    var result = new UserDto(
                        reader.GetGuid(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetInt32(3),
                        reader.GetString(4)
                        );
                    users.Add(result);
                }

                connect.connection.Close();

                return StatusCode(200, users);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{Id}")]
        public ActionResult<UserDto> GetDatabaseById(Guid Id)
        {
            try
            {
                connect.connection.Open();

                string sql = $"SELECT * FROM `users` WHERE `users`.`Id` = @id"; //"@"name(@id) to get AddWithValue object
                MySqlCommand cmd = new MySqlCommand(sql, connect.connection);
                cmd.Parameters.AddWithValue("id", Id); //safety
                MySqlDataReader reader = cmd.ExecuteReader();

                var userById = new UserDto(
                        reader.GetGuid(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetInt32(3),
                        reader.GetString(4)
                        );

                connect.connection.Close();

                return StatusCode(200, userById);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult AddUser(CreateUserDto createUser)
        {
            DateTime dateTime = DateTime.Now;
            string time = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
            var user = new User{
                    Id = Guid.NewGuid(),
                    Name = createUser.Name,
                    Email = createUser.Email,
                    Age = createUser.Age,
                    Created = time
                };

            try
            {
                connect.connection.Open();

                string sql = $"INSERT INTO `users` (`Id`, `Name`, `Email`, `Age`, `Created`) VALUES ('{user.Id}', '{user.Name}', '{user.Email}', {user.Age}, '{user.Created}')";

                MySqlCommand cmd = new MySqlCommand(sql, connect.connection);
                cmd.ExecuteNonQuery();

                connect.connection.Close();

                return StatusCode(201, sql);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]

        public ActionResult DeleteUser(Guid Id)
        {
            try
            {
                connect.connection.Open();

                string sql = $"DELETE FROM `users` WHERE `users`.`Id` = '{Id}'";

                MySqlCommand cmd = new MySqlCommand(sql, connect.connection);
                cmd.ExecuteNonQuery();

                connect.connection.Close();

                return StatusCode(201, sql);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{Id}")]

        public ActionResult UpdateUser(Guid Id, UpdateUserDto updateUser)
        {
            var user = new User
            {
                Name = updateUser.Name,
                Email = updateUser.Email,
                Age = updateUser.Age
            };
            try
            {
                connect.connection.Open();

                string sql = $"UPDATE `users` SET `Name` = '{user.Name}', `Email` = '{user.Email}', `Age` = '{user.Age}' WHERE `users`.`Id` = '{Id}'";

                MySqlCommand cmd = new MySqlCommand(sql, connect.connection);
                cmd.ExecuteNonQuery();

                connect.connection.Close();

                return StatusCode(201, user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
