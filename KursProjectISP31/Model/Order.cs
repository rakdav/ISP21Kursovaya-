using System;
using System.Collections.Generic;

namespace KursProjectISP31.Model;

public partial class Order
{
    public int IdOrder { get; set; }

    public int IdCustomer { get; set; }

    public string Vid { get; set; } = null!;

    public int IdEdition { get; set; }

    public int IdPrintingHouse { get; set; }

    public string DateStart { get; set; } = null!;

    public string DateFinish { get; set; } = null!;

    public int? Completed { get; set; }

    public virtual Customer IdCustomerNavigation { get; set; } = null!;

    public virtual Edition IdEditionNavigation { get; set; } = null!;

    public virtual PrintingHouse IdPrintingHouseNavigation { get; set; } = null!;
}
