﻿using System;
using System.Collections.Generic;

namespace TAREA13_AaronCondori.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int ClientId { get; set; }

    public DateTime OrderDate { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
