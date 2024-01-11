using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LibraryAPIv2.Models;

public partial class Nationality
{
    public Guid Id { get; set; }

    public string Nation { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Author> Authors { get; set; } = new List<Author>();
}
