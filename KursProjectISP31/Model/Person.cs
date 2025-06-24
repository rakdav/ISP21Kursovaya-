using System;
using System.Collections.Generic;

namespace KursProjectISP31.Model;

public partial class Person
{
    public int Idperson { get; set; }

    public string Surname { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string Phone { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
