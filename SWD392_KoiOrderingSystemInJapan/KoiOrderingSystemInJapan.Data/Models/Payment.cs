﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using KoiOrderingSystemInJapan.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KoiOrderingSystemInJapan.Data.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int CustomerId { get; set; }

    public int? OrderKoiId { get; set; }

    public int? OrderTripId { get; set; }

    public DateTime? PaymentDate { get; set; }

    public decimal Amount { get; set; }

    public string PaymentMethod { get; set; }

    public string PaymentDescription { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string Currency { get; set; }

    public bool IsPartialPayment { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PaymentStatus Status { get; set; }

    public virtual User Customer { get; set; }

    public virtual OrderKoiFish OrderKoi { get; set; }

    public virtual OrderTrip OrderTrip { get; set; }
}