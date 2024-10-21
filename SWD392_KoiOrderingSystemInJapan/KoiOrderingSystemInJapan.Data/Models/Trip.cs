﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace KoiOrderingSystemInJapan.Data.Models;

public partial class Trip
{
    public int TripId { get; set; }

    public DateOnly TripDate { get; set; }

    public decimal Price { get; set; }

    public string Duration { get; set; }

    public int? MaxParticipants { get; set; }

    public int? MinParticipants { get; set; }

    public string Transportation { get; set; }

    public string MeetingLocation { get; set; }

    public string SpecialInstructions { get; set; }

    public string Status { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public double? AverageRating { get; set; }

    public string CancellationPolicy { get; set; }

    public virtual ICollection<OrderTrip> OrderTrips { get; set; } = new List<OrderTrip>();

    public virtual ICollection<TripSchedule> TripSchedules { get; set; } = new List<TripSchedule>();
}