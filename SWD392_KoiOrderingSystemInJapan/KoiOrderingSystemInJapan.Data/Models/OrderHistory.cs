﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace KoiOrderingSystemInJapan.Data.Models;

public partial class OrderHistory
{
    public int OrderHistoryId { get; set; }

    public int CustomerId { get; set; }

    public int? OrderKoiId { get; set; }

    public int? OrderTripId { get; set; }

    public DateTime? OrderDate { get; set; }

    public decimal TotalPrice { get; set; }

    public string Status { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual User Customer { get; set; }

    public virtual OrderKoiFish OrderKoi { get; set; }

    public virtual OrderTrip OrderTrip { get; set; }
}