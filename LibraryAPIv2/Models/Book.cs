using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LibraryAPIv2.Models;

public partial class Book
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Genre { get; set; }

    public DateOnly? Pubdate { get; set; }

    public Guid? AuthorId { get; set; }

    [JsonIgnore]
    public virtual Author? Author { get; set; }
}
