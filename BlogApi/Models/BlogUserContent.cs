using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApi.Models
{
    public class BlogUserContent
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName ="varchar(30)")]
        public string? Title { get; set; }
        [Required]
        [Column(TypeName ="longtext")]
        public string? Content { get; set; }
        [Required]
        public Guid blogUserId { get; set; }
        public BlogUser? blogUser { get; set; }
        public DateTime Created  { get; set; }


    }
}
