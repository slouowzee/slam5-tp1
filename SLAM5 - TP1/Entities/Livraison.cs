using System;
using System.Collections.Generic;

namespace SLAM5___TP1.Entities;

public partial class Livraison
{
    public int Id { get; set; }

    public string Lbl { get; set; } = null!;

    public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();
}
