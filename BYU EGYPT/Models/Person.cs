using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class Person
{
    public int PersonId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Notes { get; set; }

    public virtual ICollection<Artifact> Artifacts { get; set; } = new List<Artifact>();

    public virtual ICollection<Textile> Textiles { get; set; } = new List<Textile>();
}
