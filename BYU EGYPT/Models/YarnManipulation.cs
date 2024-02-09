using System;
using System.Collections.Generic;

namespace BYU_EGYPT.Models;

public partial class YarnManipulation
{
    public int TextileId { get; set; }

    public int YarnManipulationId { get; set; }

    public short? BurialNumber { get; set; }

    public string? Component { get; set; }

    public string? Material { get; set; }

    public string? Manipulation { get; set; }

    public string? PlyDirection { get; set; }

    public string? TwistDirection { get; set; }

    public string? SpinAngle { get; set; }

    public short? ThreadCount { get; set; }

    public string? Thickness { get; set; }

    public virtual TextileManipulation? ManipulationNavigation { get; set; }

    public virtual TextileMaterial? MaterialNavigation { get; set; }

    public virtual TextilePlyDirection? PlyDirectionNavigation { get; set; }

    public virtual TextileSpinAngle? SpinAngleNavigation { get; set; }

    public virtual Textile Textile { get; set; } = null!;

    public virtual TextileThickness? ThicknessNavigation { get; set; }

    public virtual TextileTwistDirection? TwistDirectionNavigation { get; set; }
}
