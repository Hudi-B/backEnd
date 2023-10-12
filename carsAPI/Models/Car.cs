using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace carsAPI.Models
{
    public class Car
    {
        [Key] //set table key
        public Guid Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")] //update type of column
        public string? Model { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
