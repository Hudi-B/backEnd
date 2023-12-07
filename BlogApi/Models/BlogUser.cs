using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApi.Models
{
    public class BlogUser
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName="varchar(50)")]
        public string? Username { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string? UserEmail { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string? UserPassword { get; set; }
        public DateTime CreatedTime { get; set; } 
    }
}
