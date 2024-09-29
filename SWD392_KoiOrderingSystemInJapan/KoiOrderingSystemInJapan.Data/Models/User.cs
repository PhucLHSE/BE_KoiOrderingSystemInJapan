﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace KoiOrderingSystemInJapan.Data.Models;

public partial class User
{
    public int UserId { get; set; }

    public string FullName { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public DateOnly BirthDate { get; set; }

    public string Address { get; set; }

    public byte Gender { get; set; }

    public string ImageUser { get; set; }

    public DateOnly? HireDate { get; set; }

    public int RoleId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public bool IsVerified { get; set; }

    public DateTime? LastPurchaseDate { get; set; }

    public decimal? TotalSpent { get; set; }

    public string PreferredContactMethod { get; set; }

    public string MembershipLevel { get; set; }

    public string Notes { get; set; }

    public virtual ICollection<CheckIn> CheckInConsultingStaffs { get; set; } = new List<CheckIn>();

    public virtual ICollection<CheckIn> CheckInCustomers { get; set; } = new List<CheckIn>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<OrderHistory> OrderHistories { get; set; } = new List<OrderHistory>();

    public virtual ICollection<OrderKoiFish> OrderKoiFishes { get; set; } = new List<OrderKoiFish>();

    public virtual ICollection<OrderTrip> OrderTrips { get; set; } = new List<OrderTrip>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Role Role { get; set; }
}