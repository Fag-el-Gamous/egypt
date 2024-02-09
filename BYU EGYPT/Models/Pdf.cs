using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class Pdf
{
    public long BoxId { get; set; }

    public string? FileName { get; set; }

    public virtual ICollection<FieldBook> FieldBooks { get; set; } = new List<FieldBook>();

    public virtual ICollection<Burial> Burials { get; set; } = new List<Burial>();

    public virtual ICollection<Textile> Textiles { get; set; } = new List<Textile>();
}
