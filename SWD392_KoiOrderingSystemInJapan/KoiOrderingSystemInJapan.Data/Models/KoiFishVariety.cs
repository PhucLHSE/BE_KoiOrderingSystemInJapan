﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace KoiOrderingSystemInJapan.Data.Models;

public partial class KoiFishVariety
{
    public int KoiFishVarietyId { get; set; }

    public string TypeName { get; set; }

    public string ScientificName { get; set; }

    public string Description { get; set; }

    public int? LifespanYears { get; set; }

    public double AverageSize { get; set; }

    public string Habitat { get; set; }

    public string Diet { get; set; }

    public string ColorPattern { get; set; }

    public bool? IsEndangered { get; set; }

    public string CareDifficulty { get; set; }

    public virtual ICollection<KoiFish> KoiFishes { get; set; } = new List<KoiFish>();
}