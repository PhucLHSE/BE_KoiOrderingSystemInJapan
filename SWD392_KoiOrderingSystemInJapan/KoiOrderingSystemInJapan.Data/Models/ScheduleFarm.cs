﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace KoiOrderingSystemInJapan.Data.Models;

public partial class ScheduleFarm
{
    public int ScheduleFarmId { get; set; }

    public int ScheduleId { get; set; }

    public int FarmId { get; set; }

    public DateOnly VisitDate { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual Farm Farm { get; set; }

    public virtual TripSchedule Schedule { get; set; }
}