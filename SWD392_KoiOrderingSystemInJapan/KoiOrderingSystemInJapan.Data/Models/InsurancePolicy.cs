﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace KoiOrderingSystemInJapan.Data.Models;

public partial class InsurancePolicy
{
    public int InsuranceId { get; set; }

    public string PolicyName { get; set; }

    public string CoverageDetails { get; set; }

    public decimal Price { get; set; }

    public int DurationMonths { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<OrderKoiFish> OrderKoiFishes { get; set; } = new List<OrderKoiFish>();
}