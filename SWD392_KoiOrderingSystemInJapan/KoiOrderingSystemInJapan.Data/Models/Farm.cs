﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace KoiOrderingSystemInJapan.Data.Models;

public partial class Farm
{
    public int FarmId { get; set; }

    public string FarmName { get; set; }

    public string Location { get; set; }

    public string Description { get; set; }

    public string OwnerName { get; set; }

    public string ContactEmail { get; set; }

    public string ContactPhone { get; set; }

    public int? EstablishedYear { get; set; }

    public double? AreaSize { get; set; }

    public bool IsActive { get; set; }

    public byte? Rating { get; set; }

    public string Website { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<KoiFish> KoiFishes { get; set; } = new List<KoiFish>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}