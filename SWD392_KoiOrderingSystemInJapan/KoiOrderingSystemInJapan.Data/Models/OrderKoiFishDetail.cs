﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace KoiOrderingSystemInJapan.Data.Models;

public partial class OrderKoiFishDetail
{
    public int OrderKoiFishDetailId { get; set; }

    public int OrderKoiId { get; set; }

    public int KoiFishId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal? TotalPrice { get; set; }

    public virtual KoiFish KoiFish { get; set; }

    public virtual OrderKoiFish OrderKoi { get; set; }
}