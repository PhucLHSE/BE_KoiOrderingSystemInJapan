﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using KoiOrderingSystemInJapan.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KoiOrderingSystemInJapan.Data.Models;

public partial class KoiFish
{
    public int KoiFishId { get; set; }

    public int KoiFishVarietyId { get; set; }

    public int FarmId { get; set; }

    public double Weight { get; set; }

    public double Length { get; set; }

    public string Color { get; set; }

    public decimal Price { get; set; }

    public DateTime? DateAdded { get; set; }

    public bool? IsAvailable { get; set; }

    public string Notes { get; set; }

    public string Supplier { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Gender Gender { get; set; }

    public virtual Farm Farm { get; set; }

    public virtual KoiFishVariety KoiFishVariety { get; set; }

    public virtual ICollection<OrderKoiFishDetail> OrderKoiFishDetails { get; set; } = new List<OrderKoiFishDetail>();
}