using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LibraryAPIv2.Models;

public partial class Author
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Gender { get; set; }

    public Guid? NationalityId { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    [JsonIgnore]
    public virtual Nationality? Nationality { get; set; }
}
