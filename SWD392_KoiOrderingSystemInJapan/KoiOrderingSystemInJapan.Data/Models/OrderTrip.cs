﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using KoiOrderingSystemInJapan.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KoiOrderingSystemInJapan.Data.Models;

public partial class OrderTrip
{
    public int OrderTripId { get; set; }

    public int CustomerId { get; set; }

    public int TripId { get; set; }

    public DateTime? OrderDate { get; set; }

    public decimal TotalPrice { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string CancellationReason { get; set; }

    public string SpecialRequests { get; set; }

    public int? ScheduleId { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public OrderTripStatus Status { get; set; }

    public virtual User Customer { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<OrderHistory> OrderHistories { get; set; } = new List<OrderHistory>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual TripSchedule Schedule { get; set; }

    public virtual Trip Trip { get; set; }
}