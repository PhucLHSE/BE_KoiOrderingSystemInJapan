﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using KoiOrderingSystemInJapan.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KoiOrderingSystemInJapan.Data.DBContext;

public partial class KoiOrderingSystemInJapanContext : DbContext
{
    public KoiOrderingSystemInJapanContext()
    {
    }

    public KoiOrderingSystemInJapanContext(DbContextOptions<KoiOrderingSystemInJapanContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CheckIn> CheckIns { get; set; }

    public virtual DbSet<Farm> Farms { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<KoiFish> KoiFishes { get; set; }

    public virtual DbSet<KoiFishVariety> KoiFishVarieties { get; set; }

    public virtual DbSet<OrderHistory> OrderHistories { get; set; }

    public virtual DbSet<OrderKoiFish> OrderKoiFishes { get; set; }

    public virtual DbSet<OrderTrip> OrderTrips { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public static string GetConnectionString(string connectionStringName)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        string connectionString = config.GetConnectionString(connectionStringName);
        return connectionString;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString("DefaultConnection"));

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=ADMIN-PC;Initial Catalog=KoiOrderingSystemInJapan;User ID=sa;Password=12345;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CheckIn>(entity =>
        {
            entity.HasKey(e => e.CheckInId).HasName("PK__CheckIns__E64976A4FD89D5C2");

            entity.Property(e => e.CheckInId).HasColumnName("CheckInID");
            entity.Property(e => e.CheckInDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CheckInStatus).HasMaxLength(100);
            entity.Property(e => e.ConsultingStaffId).HasColumnName("ConsultingStaffID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.TripId).HasColumnName("TripID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.ConsultingStaff).WithMany(p => p.CheckInConsultingStaffs)
                .HasForeignKey(d => d.ConsultingStaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CheckIns__Consul__73BA3083");

            entity.HasOne(d => d.Customer).WithMany(p => p.CheckInCustomers)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CheckIns__Custom__72C60C4A");

            entity.HasOne(d => d.Trip).WithMany(p => p.CheckIns)
                .HasForeignKey(d => d.TripId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CheckIns__TripID__71D1E811");
        });

        modelBuilder.Entity<Farm>(entity =>
        {
            entity.HasKey(e => e.FarmId).HasName("PK__Farms__ED7BBA99FB4CFE7D");

            entity.Property(e => e.FarmId).HasColumnName("FarmID");
            entity.Property(e => e.ContactEmail)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.ContactPhone)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.FarmName)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.ImageFarm).HasMaxLength(500);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Location)
                .IsRequired()
                .HasMaxLength(300);
            entity.Property(e => e.OwnerName)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Website).HasMaxLength(500);
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDF6AB41E3B7");

            entity.ToTable("Feedback");

            entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");
            entity.Property(e => e.Comment).HasMaxLength(500);
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.FeedbackDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.OrderKoiId).HasColumnName("OrderKoiID");
            entity.Property(e => e.OrderTripId).HasColumnName("OrderTripID");
            entity.Property(e => e.Reply).HasMaxLength(500);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Feedback__Custom__17036CC0");

            entity.HasOne(d => d.OrderKoi).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.OrderKoiId)
                .HasConstraintName("FK__Feedback__OrderK__17F790F9");

            entity.HasOne(d => d.OrderTrip).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.OrderTripId)
                .HasConstraintName("FK__Feedback__OrderT__18EBB532");
        });

        modelBuilder.Entity<KoiFish>(entity =>
        {
            entity.HasKey(e => e.KoiFishId).HasName("PK__KoiFishe__44D353C5BD68748C");

            entity.Property(e => e.KoiFishId).HasColumnName("KoiFishID");
            entity.Property(e => e.Color)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FarmId).HasColumnName("FarmID");
            entity.Property(e => e.IsAvailable).HasDefaultValue(true);
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.Supplier).HasMaxLength(200);

            entity.HasOne(d => d.Farm).WithMany(p => p.KoiFishes)
                .HasForeignKey(d => d.FarmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__KoiFishes__FarmI__6383C8BA");

            entity.HasOne(d => d.KoiFishVariety).WithMany(p => p.KoiFishes)
                .HasForeignKey(d => d.KoiFishVarietyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__KoiFishes__KoiFi__628FA481");
        });

        modelBuilder.Entity<KoiFishVariety>(entity =>
        {
            entity.HasKey(e => e.KoiFishVarietyId).HasName("PK__KoiFishV__A82284D760914E59");

            entity.Property(e => e.CareDifficulty).HasMaxLength(100);
            entity.Property(e => e.ColorPattern).HasMaxLength(300);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Diet).HasMaxLength(300);
            entity.Property(e => e.Habitat).HasMaxLength(300);
            entity.Property(e => e.ImageKoiFish).HasMaxLength(500);
            entity.Property(e => e.IsEndangered).HasDefaultValue(false);
            entity.Property(e => e.ScientificName)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.TypeName)
                .IsRequired()
                .HasMaxLength(200);
        });

        modelBuilder.Entity<OrderHistory>(entity =>
        {
            entity.HasKey(e => e.OrderHistoryId).HasName("PK__OrderHis__718E6CB376A3FE2B");

            entity.ToTable("OrderHistory");

            entity.Property(e => e.OrderHistoryId).HasColumnName("OrderHistoryID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.OrderKoiId).HasColumnName("OrderKoiID");
            entity.Property(e => e.OrderTripId).HasColumnName("OrderTripID");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .HasDefaultValue("Completed");
            entity.Property(e => e.TotalPrice).HasColumnType("money");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.OrderHistories)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderHist__Custo__0F624AF8");

            entity.HasOne(d => d.OrderKoi).WithMany(p => p.OrderHistories)
                .HasForeignKey(d => d.OrderKoiId)
                .HasConstraintName("FK__OrderHist__Order__10566F31");

            entity.HasOne(d => d.OrderTrip).WithMany(p => p.OrderHistories)
                .HasForeignKey(d => d.OrderTripId)
                .HasConstraintName("FK__OrderHist__Order__114A936A");
        });

        modelBuilder.Entity<OrderKoiFish>(entity =>
        {
            entity.HasKey(e => e.OrderKoiId).HasName("PK__OrderKoi__DFB1EA4929C6361F");

            entity.Property(e => e.OrderKoiId).HasColumnName("OrderKoiID");
            entity.Property(e => e.CancellationReason).HasMaxLength(500);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DeliveryMethod).HasMaxLength(200);
            entity.Property(e => e.Deposit)
                .HasDefaultValue(0m)
                .HasColumnType("money");
            entity.Property(e => e.KoiFishId).HasColumnName("KoiFishID");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.RemainingBalance).HasColumnType("money");
            entity.Property(e => e.SpecialInstructions).HasMaxLength(500);
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .HasDefaultValue("Pending");
            entity.Property(e => e.TotalPrice).HasColumnType("money");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.OrderKoiFishes)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderKoiF__Custo__01142BA1");

            entity.HasOne(d => d.KoiFish).WithMany(p => p.OrderKoiFishes)
                .HasForeignKey(d => d.KoiFishId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderKoiF__KoiFi__02084FDA");
        });

        modelBuilder.Entity<OrderTrip>(entity =>
        {
            entity.HasKey(e => e.OrderTripId).HasName("PK__OrderTri__8DF214DD3A655C6D");

            entity.Property(e => e.OrderTripId).HasColumnName("OrderTripID");
            entity.Property(e => e.CancellationReason).HasMaxLength(500);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SpecialRequests).HasMaxLength(500);
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .HasDefaultValue("Pending");
            entity.Property(e => e.TotalPrice).HasColumnType("money");
            entity.Property(e => e.TripId).HasColumnName("TripID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.OrderTrips)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderTrip__Custo__797309D9");

            entity.HasOne(d => d.Trip).WithMany(p => p.OrderTrips)
                .HasForeignKey(d => d.TripId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderTrip__TripI__7A672E12");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__9B556A58709768F1");

            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Currency).HasMaxLength(10);
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.OrderKoiId).HasColumnName("OrderKoiID");
            entity.Property(e => e.OrderTripId).HasColumnName("OrderTripID");
            entity.Property(e => e.PaymentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PaymentDescription).HasMaxLength(500);
            entity.Property(e => e.PaymentMethod).HasMaxLength(100);
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .HasDefaultValue("Completed");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.Payments)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payments__Custom__07C12930");

            entity.HasOne(d => d.OrderKoi).WithMany(p => p.Payments)
                .HasForeignKey(d => d.OrderKoiId)
                .HasConstraintName("FK__Payments__OrderK__08B54D69");

            entity.HasOne(d => d.OrderTrip).WithMany(p => p.Payments)
                .HasForeignKey(d => d.OrderTripId)
                .HasConstraintName("FK__Payments__OrderT__09A971A2");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3A27A636B6");

            entity.HasIndex(e => e.RoleName, "UQ__Roles__8A2B616046DCF820").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.RoleName)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__Schedule__9C8A5B69A781F9EC");

            entity.ToTable("Schedule");

            entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FarmId).HasColumnName("FarmID");
            entity.Property(e => e.TripId).HasColumnName("TripID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Farm).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.FarmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Schedule__FarmID__6D0D32F4");

            entity.HasOne(d => d.Trip).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.TripId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Schedule__TripID__6C190EBB");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.TripId).HasName("PK__Trips__51DC711EB25DC4EC");

            entity.Property(e => e.TripId).HasColumnName("TripID");
            entity.Property(e => e.CancellationPolicy).HasMaxLength(500);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Duration)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.MeetingLocation).HasMaxLength(300);
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.SpecialInstructions).HasMaxLength(500);
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .HasDefaultValue("Scheduled");
            entity.Property(e => e.Transportation).HasMaxLength(200);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC4CFC4205");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D1053492B680C0").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(300);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.ImageUser).HasMaxLength(500);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastPurchaseDate).HasColumnType("datetime");
            entity.Property(e => e.MembershipLevel).HasMaxLength(100);
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.PreferredContactMethod).HasMaxLength(100);
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.TotalSpent).HasColumnType("money");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(200);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__RoleID__5441852A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}