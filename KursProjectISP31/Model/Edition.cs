using System;
using System.Collections.Generic;

namespace KursProjectISP31.Model;

public partial class Edition
{
    public int IdEdition { get; set; }

    public int IdAuthor { get; set; }

    public string EditionName { get; set; } = null!;

    public int Volume { get; set; }

    public int Circulation { get; set; }

    public virtual Author IdAuthorNavigation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
