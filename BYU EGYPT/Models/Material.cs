using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class Material
{
    public string Material1 { get; set; } = null!;

    public virtual ICollection<Artifact> Artifacts { get; set; } = new List<Artifact>();
}
