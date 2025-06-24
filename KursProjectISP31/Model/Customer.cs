using System;
using System.Collections.Generic;

namespace KursProjectISP31.Model;

public partial class Customer
{
    public int IdCustomer { get; set; }

    public string Vid { get; set; } = null!;

    public int IdPerson { get; set; }

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Fax { get; set; } = null!;

    public virtual Person IdPersonNavigation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
