using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class Publication
{
    public int PublicationId { get; set; }

    public string? PublicationTitle { get; set; }

    public string? Author { get; set; }

    public string? Description { get; set; }

    public DateTime? PublicationDate { get; set; }

    public string? PublicationType { get; set; }

    public string? OnlineLink { get; set; }

    public string? IsFree { get; set; }

    public string? Topic { get; set; }

    public string? PublicationFilePath { get; set; }

    public string? PublicationFileName { get; set; }
}
