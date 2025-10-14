using System;
using System.Collections.Generic;

namespace SLAM5___TP1.Entities;

public partial class Style
{
    public int Numstyle { get; set; }

    public string Libstyle { get; set; } = null!;

    public virtual ICollection<Partition> Partitions { get; set; } = new List<Partition>();
}
