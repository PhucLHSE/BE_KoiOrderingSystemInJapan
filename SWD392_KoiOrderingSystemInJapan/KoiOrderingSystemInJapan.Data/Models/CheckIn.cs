﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace KoiOrderingSystemInJapan.Data.Models;

public partial class CheckIn
{
    public int CheckInId { get; set; }

    public int CustomerId { get; set; }

    public int ConsultingStaffId { get; set; }

    public DateTime? CheckInDate { get; set; }

    public string CheckInStatus { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string Notes { get; set; }

    public int? ScheduleId { get; set; }

    public virtual User ConsultingStaff { get; set; }

    public virtual User Customer { get; set; }

    public virtual TripSchedule Schedule { get; set; }
}