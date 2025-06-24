using System;
using System.Collections.Generic;

namespace KursProjectISP31.Model;

public partial class PrintingHouse
{
    public int IdPrintingHouse { get; set; }

    public string СompanyName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
