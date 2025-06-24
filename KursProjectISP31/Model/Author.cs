using System;
using System.Collections.Generic;

namespace KursProjectISP31.Model;

public partial class Author
{
    public int IdAuthor { get; set; }

    public string? Surname { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? AdditionalInformation { get; set; }

    public virtual ICollection<Edition> Editions { get; set; } = new List<Edition>();
}
