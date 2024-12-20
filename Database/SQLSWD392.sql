USE [master]
GO
/****** Object:  Database [KoiOrderingSystemInJapan]    Script Date: 11/6/2024 11:34:25 AM ******/
CREATE DATABASE [KoiOrderingSystemInJapan]
GO
ALTER DATABASE [KoiOrderingSystemInJapan] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KoiOrderingSystemInJapan].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KoiOrderingSystemInJapan] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KoiOrderingSystemInJapan] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KoiOrderingSystemInJapan] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KoiOrderingSystemInJapan] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KoiOrderingSystemInJapan] SET ARITHABORT OFF 
GO
ALTER DATABASE [KoiOrderingSystemInJapan] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [KoiOrderingSystemInJapan] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KoiOrderingSystemInJapan] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KoiOrderingSystemInJapan] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KoiOrderingSystemInJapan] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KoiOrderingSystemInJapan] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KoiOrderingSystemInJapan] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KoiOrderingSystemInJapan] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KoiOrderingSystemInJapan] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KoiOrderingSystemInJapan] SET  ENABLE_BROKER 
GO
ALTER DATABASE [KoiOrderingSystemInJapan] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KoiOrderingSystemInJapan] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KoiOrderingSystemInJapan] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KoiOrderingSystemInJapan] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KoiOrderingSystemInJapan] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KoiOrderingSystemInJapan] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [KoiOrderingSystemInJapan] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [KoiOrderingSystemInJapan] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [KoiOrderingSystemInJapan] SET  MULTI_USER 
GO
ALTER DATABASE [KoiOrderingSystemInJapan] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KoiOrderingSystemInJapan] SET DB_CHAINING OFF 
GO
ALTER DATABASE [KoiOrderingSystemInJapan] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [KoiOrderingSystemInJapan] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [KoiOrderingSystemInJapan] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [KoiOrderingSystemInJapan] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [KoiOrderingSystemInJapan] SET QUERY_STORE = ON
GO
ALTER DATABASE [KoiOrderingSystemInJapan] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [KoiOrderingSystemInJapan]
GO
/****** Object:  Table [dbo].[CheckIns]    Script Date: 11/6/2024 11:34:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CheckIns](
	[CheckInID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[ConsultingStaffID] [int] NOT NULL,
	[CheckInDate] [datetime] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[Notes] [nvarchar](500) NULL,
	[ScheduleID] [int] NULL,
	[CheckInStatus] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CheckInID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Farms]    Script Date: 11/6/2024 11:34:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Farms](
	[FarmID] [int] IDENTITY(1,1) NOT NULL,
	[FarmName] [nvarchar](200) NOT NULL,
	[Location] [nvarchar](300) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[OwnerName] [nvarchar](200) NOT NULL,
	[ContactEmail] [nvarchar](100) NOT NULL,
	[ContactPhone] [nvarchar](20) NOT NULL,
	[EstablishedYear] [int] NULL,
	[AreaSize] [float] NULL,
	[IsActive] [bit] NOT NULL,
	[Rating] [tinyint] NULL,
	[Website] [nvarchar](500) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[ImageFarm] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[FarmID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 11/6/2024 11:34:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[FeedbackID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[OrderKoiID] [int] NULL,
	[OrderTripID] [int] NULL,
	[ServiceRating] [tinyint] NULL,
	[ProductRating] [tinyint] NULL,
	[Comment] [nvarchar](500) NULL,
	[Reply] [nvarchar](500) NULL,
	[FeedbackDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[FeedbackID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InsurancePolicies]    Script Date: 11/6/2024 11:34:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InsurancePolicies](
	[InsuranceID] [int] IDENTITY(1,1) NOT NULL,
	[PolicyName] [nvarchar](200) NOT NULL,
	[CoverageDetails] [nvarchar](500) NULL,
	[Price] [money] NOT NULL,
	[DurationMonths] [int] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[InsuranceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KoiFishes]    Script Date: 11/6/2024 11:34:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KoiFishes](
	[KoiFishID] [int] IDENTITY(1,1) NOT NULL,
	[KoiFishVarietyId] [int] NOT NULL,
	[FarmID] [int] NOT NULL,
	[Weight] [float] NOT NULL,
	[Length] [float] NOT NULL,
	[Color] [nvarchar](200) NOT NULL,
	[Price] [money] NOT NULL,
	[DateAdded] [datetime] NULL,
	[IsAvailable] [bit] NULL,
	[Notes] [nvarchar](500) NULL,
	[Supplier] [nvarchar](200) NULL,
	[Gender] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[KoiFishID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KoiFishVarieties]    Script Date: 11/6/2024 11:34:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KoiFishVarieties](
	[KoiFishVarietyId] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](200) NOT NULL,
	[ScientificName] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[LifespanYears] [int] NULL,
	[AverageSize] [float] NOT NULL,
	[Habitat] [nvarchar](300) NULL,
	[Diet] [nvarchar](300) NULL,
	[ColorPattern] [nvarchar](300) NULL,
	[IsEndangered] [bit] NULL,
	[CareDifficulty] [nvarchar](100) NULL,
	[ImageKoiFish] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[KoiFishVarietyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderHistory]    Script Date: 11/6/2024 11:34:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderHistory](
	[OrderHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[OrderKoiID] [int] NULL,
	[OrderTripID] [int] NULL,
	[OrderDate] [datetime] NULL,
	[TotalPrice] [money] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderKoiFishDetails]    Script Date: 11/6/2024 11:34:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderKoiFishDetails](
	[OrderKoiFishDetailID] [int] IDENTITY(1,1) NOT NULL,
	[OrderKoiID] [int] NOT NULL,
	[KoiFishID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[TotalPrice]  AS ([Quantity]*[UnitPrice]) PERSISTED,
PRIMARY KEY CLUSTERED 
(
	[OrderKoiFishDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderKoiFishes]    Script Date: 11/6/2024 11:34:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderKoiFishes](
	[OrderKoiID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[OrderDate] [datetime] NULL,
	[TotalPrice] [money] NOT NULL,
	[Deposit] [money] NULL,
	[RemainingBalance] [money] NOT NULL,
	[DeliveryDate] [date] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[DeliveryMethod] [nvarchar](200) NULL,
	[SpecialInstructions] [nvarchar](500) NULL,
	[CancellationReason] [nvarchar](500) NULL,
	[InsuranceID] [int] NOT NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderKoiID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderTrips]    Script Date: 11/6/2024 11:34:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderTrips](
	[OrderTripID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[TripID] [int] NOT NULL,
	[OrderDate] [datetime] NULL,
	[TotalPrice] [money] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[CancellationReason] [nvarchar](500) NULL,
	[SpecialRequests] [nvarchar](500) NULL,
	[ScheduleID] [int] NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderTripID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 11/6/2024 11:34:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[PaymentID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[OrderKoiID] [int] NULL,
	[OrderTripID] [int] NULL,
	[PaymentDate] [datetime] NULL,
	[Amount] [money] NOT NULL,
	[PaymentMethod] [nvarchar](100) NULL,
	[PaymentDescription] [nvarchar](500) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[Currency] [nvarchar](10) NULL,
	[IsPartialPayment] [bit] NOT NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RefundRequests]    Script Date: 11/6/2024 11:34:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RefundRequests](
	[RefundRequestID] [int] IDENTITY(1,1) NOT NULL,
	[OrderKoiID] [int] NOT NULL,
	[RequestDate] [datetime] NULL,
	[RefundAmount] [money] NULL,
	[Reason] [nvarchar](500) NULL,
	[ProcessedDate] [datetime] NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[RefundRequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 11/6/2024 11:34:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ScheduleFarms]    Script Date: 11/6/2024 11:34:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScheduleFarms](
	[ScheduleFarmID] [int] IDENTITY(1,1) NOT NULL,
	[ScheduleID] [int] NOT NULL,
	[FarmID] [int] NOT NULL,
	[VisitDate] [date] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ScheduleFarmID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trips]    Script Date: 11/6/2024 11:34:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trips](
	[TripID] [int] IDENTITY(1,1) NOT NULL,
	[TripDate] [date] NOT NULL,
	[Price] [money] NOT NULL,
	[Duration] [nchar](100) NULL,
	[MaxParticipants] [int] NULL,
	[MinParticipants] [int] NULL,
	[Transportation] [nvarchar](200) NULL,
	[MeetingLocation] [nvarchar](300) NULL,
	[SpecialInstructions] [nvarchar](500) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[AverageRating] [float] NULL,
	[CancellationPolicy] [nvarchar](500) NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[TripID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TripSchedules]    Script Date: 11/6/2024 11:34:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TripSchedules](
	[ScheduleID] [int] IDENTITY(1,1) NOT NULL,
	[TripID] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[MaxParticipants] [int] NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ScheduleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/6/2024 11:34:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](200) NOT NULL,
	[UserName] [nvarchar](200) NOT NULL,
	[Password] [nvarchar](200) NOT NULL,
	[Email] [nvarchar](200) NOT NULL,
	[PhoneNumber] [nvarchar](20) NOT NULL,
	[BirthDate] [date] NOT NULL,
	[Address] [nvarchar](300) NOT NULL,
	[Gender] [int] NULL,
	[ImageUser] [nvarchar](500) NULL,
	[HireDate] [date] NULL,
	[RoleID] [int] NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[RegistrationDate] [datetime] NULL,
	[IsVerified] [bit] NOT NULL,
	[LastPurchaseDate] [datetime] NULL,
	[TotalSpent] [money] NULL,
	[PreferredContactMethod] [nvarchar](100) NULL,
	[MembershipLevel] [nvarchar](100) NULL,
	[Notes] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CheckIns] ADD  DEFAULT (getdate()) FOR [CheckInDate]
GO
ALTER TABLE [dbo].[CheckIns] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Farms] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Farms] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Feedback] ADD  DEFAULT (getdate()) FOR [FeedbackDate]
GO
ALTER TABLE [dbo].[InsurancePolicies] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[KoiFishes] ADD  DEFAULT (getdate()) FOR [DateAdded]
GO
ALTER TABLE [dbo].[KoiFishes] ADD  DEFAULT ((1)) FOR [IsAvailable]
GO
ALTER TABLE [dbo].[KoiFishVarieties] ADD  DEFAULT ((0)) FOR [IsEndangered]
GO
ALTER TABLE [dbo].[OrderHistory] ADD  DEFAULT (getdate()) FOR [OrderDate]
GO
ALTER TABLE [dbo].[OrderHistory] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[OrderKoiFishes] ADD  DEFAULT (getdate()) FOR [OrderDate]
GO
ALTER TABLE [dbo].[OrderKoiFishes] ADD  DEFAULT ((0)) FOR [Deposit]
GO
ALTER TABLE [dbo].[OrderKoiFishes] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[OrderTrips] ADD  DEFAULT (getdate()) FOR [OrderDate]
GO
ALTER TABLE [dbo].[OrderTrips] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Payments] ADD  DEFAULT (getdate()) FOR [PaymentDate]
GO
ALTER TABLE [dbo].[Payments] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Payments] ADD  DEFAULT ((0)) FOR [IsPartialPayment]
GO
ALTER TABLE [dbo].[RefundRequests] ADD  DEFAULT (getdate()) FOR [RequestDate]
GO
ALTER TABLE [dbo].[Roles] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Roles] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[ScheduleFarms] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Trips] ADD  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Trips] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[TripSchedules] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[TripSchedules] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [RegistrationDate]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((0)) FOR [IsVerified]
GO
ALTER TABLE [dbo].[CheckIns]  WITH CHECK ADD FOREIGN KEY([ConsultingStaffID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[CheckIns]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[CheckIns]  WITH CHECK ADD FOREIGN KEY([ScheduleID])
REFERENCES [dbo].[TripSchedules] ([ScheduleID])
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD FOREIGN KEY([OrderKoiID])
REFERENCES [dbo].[OrderKoiFishes] ([OrderKoiID])
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD FOREIGN KEY([OrderTripID])
REFERENCES [dbo].[OrderTrips] ([OrderTripID])
GO
ALTER TABLE [dbo].[KoiFishes]  WITH CHECK ADD FOREIGN KEY([FarmID])
REFERENCES [dbo].[Farms] ([FarmID])
GO
ALTER TABLE [dbo].[KoiFishes]  WITH CHECK ADD FOREIGN KEY([KoiFishVarietyId])
REFERENCES [dbo].[KoiFishVarieties] ([KoiFishVarietyId])
GO
ALTER TABLE [dbo].[OrderHistory]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[OrderHistory]  WITH CHECK ADD FOREIGN KEY([OrderKoiID])
REFERENCES [dbo].[OrderKoiFishes] ([OrderKoiID])
GO
ALTER TABLE [dbo].[OrderHistory]  WITH CHECK ADD FOREIGN KEY([OrderTripID])
REFERENCES [dbo].[OrderTrips] ([OrderTripID])
GO
ALTER TABLE [dbo].[OrderKoiFishDetails]  WITH CHECK ADD FOREIGN KEY([KoiFishID])
REFERENCES [dbo].[KoiFishes] ([KoiFishID])
GO
ALTER TABLE [dbo].[OrderKoiFishDetails]  WITH CHECK ADD FOREIGN KEY([OrderKoiID])
REFERENCES [dbo].[OrderKoiFishes] ([OrderKoiID])
GO
ALTER TABLE [dbo].[OrderKoiFishes]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[OrderKoiFishes]  WITH CHECK ADD  CONSTRAINT [FK_OrderKoiFishes_InsuranceID] FOREIGN KEY([InsuranceID])
REFERENCES [dbo].[InsurancePolicies] ([InsuranceID])
GO
ALTER TABLE [dbo].[OrderKoiFishes] CHECK CONSTRAINT [FK_OrderKoiFishes_InsuranceID]
GO
ALTER TABLE [dbo].[OrderTrips]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[OrderTrips]  WITH CHECK ADD FOREIGN KEY([ScheduleID])
REFERENCES [dbo].[TripSchedules] ([ScheduleID])
GO
ALTER TABLE [dbo].[OrderTrips]  WITH CHECK ADD FOREIGN KEY([TripID])
REFERENCES [dbo].[Trips] ([TripID])
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD FOREIGN KEY([OrderKoiID])
REFERENCES [dbo].[OrderKoiFishes] ([OrderKoiID])
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD FOREIGN KEY([OrderTripID])
REFERENCES [dbo].[OrderTrips] ([OrderTripID])
GO
ALTER TABLE [dbo].[RefundRequests]  WITH CHECK ADD FOREIGN KEY([OrderKoiID])
REFERENCES [dbo].[OrderKoiFishes] ([OrderKoiID])
GO
ALTER TABLE [dbo].[ScheduleFarms]  WITH CHECK ADD FOREIGN KEY([FarmID])
REFERENCES [dbo].[Farms] ([FarmID])
GO
ALTER TABLE [dbo].[ScheduleFarms]  WITH CHECK ADD FOREIGN KEY([ScheduleID])
REFERENCES [dbo].[TripSchedules] ([ScheduleID])
GO
ALTER TABLE [dbo].[TripSchedules]  WITH CHECK ADD FOREIGN KEY([TripID])
REFERENCES [dbo].[Trips] ([TripID])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[Farms]  WITH CHECK ADD CHECK  (([ContactEmail] like '%@%.%'))
GO
ALTER TABLE [dbo].[Farms]  WITH CHECK ADD CHECK  (([EstablishedYear]<=datepart(year,getdate())))
GO
ALTER TABLE [dbo].[Farms]  WITH CHECK ADD CHECK  (([Rating]>=(1) AND [Rating]<=(5)))
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD CHECK  (([ProductRating]>=(1) AND [ProductRating]<=(5)))
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD CHECK  (([ServiceRating]>=(1) AND [ServiceRating]<=(5)))
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD CHECK  (([Email] like '%@%.%'))
GO
USE [master]
GO
ALTER DATABASE [KoiOrderingSystemInJapan] SET  READ_WRITE 
GO
SET IDENTITY_INSERT [dbo].[CheckIns] ON 

INSERT [dbo].[CheckIns] ([CheckInID], [CustomerID], [ConsultingStaffID], [CheckInDate], [CreatedDate], [UpdatedDate], [Notes], [ScheduleID], [CheckInStatus]) VALUES (5, 1, 1, CAST(N'2024-10-10T00:00:00.000' AS DateTime), CAST(N'2024-10-01T00:00:00.000' AS DateTime), CAST(N'2024-10-01T00:00:00.000' AS DateTime), NULL, 1, 1)
INSERT [dbo].[CheckIns] ([CheckInID], [CustomerID], [ConsultingStaffID], [CheckInDate], [CreatedDate], [UpdatedDate], [Notes], [ScheduleID], [CheckInStatus]) VALUES (6, 2, 1, CAST(N'2024-10-10T00:00:00.000' AS DateTime), CAST(N'2024-10-01T00:00:00.000' AS DateTime), CAST(N'2024-10-01T00:00:00.000' AS DateTime), NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[CheckIns] OFF
GO
SET IDENTITY_INSERT [dbo].[Farms] ON 

INSERT [dbo].[Farms] ([FarmID], [FarmName], [Location], [Description], [OwnerName], [ContactEmail], [ContactPhone], [EstablishedYear], [AreaSize], [IsActive], [Rating], [Website], [CreatedDate], [UpdatedDate], [ImageFarm]) VALUES (1, N'Koi Farm A', N'Tokyo', N'Koi fish farm with high quality koi fish', N'Tanaka San', N'ownerA@koifarm.com', N'0801234567', 1990, 15.5, 1, 5, N'www.koifarma.com', CAST(N'2024-11-06T13:45:32.143' AS DateTime), NULL, NULL)
INSERT [dbo].[Farms] ([FarmID], [FarmName], [Location], [Description], [OwnerName], [ContactEmail], [ContactPhone], [EstablishedYear], [AreaSize], [IsActive], [Rating], [Website], [CreatedDate], [UpdatedDate], [ImageFarm]) VALUES (2, N'Koi Farm B', N'Kyoto', N'Koi fish farm specializing in rare koi fish', N'Yamada San', N'ownerB@koifarm.com', N'0802345678', 2000, 10.2, 1, 4, N'www.koifarmb.com', CAST(N'2024-11-06T13:45:32.143' AS DateTime), NULL, NULL)
INSERT [dbo].[Farms] ([FarmID], [FarmName], [Location], [Description], [OwnerName], [ContactEmail], [ContactPhone], [EstablishedYear], [AreaSize], [IsActive], [Rating], [Website], [CreatedDate], [UpdatedDate], [ImageFarm]) VALUES (3, N'Koi Farm A', N'Tokyo', N'A beautiful koi farm.', N'John Doe', N'contact@koifarma.com', N'1234567890', 2000, 5, 1, 5, NULL, CAST(N'2024-11-06T22:01:07.410' AS DateTime), NULL, NULL)
INSERT [dbo].[Farms] ([FarmID], [FarmName], [Location], [Description], [OwnerName], [ContactEmail], [ContactPhone], [EstablishedYear], [AreaSize], [IsActive], [Rating], [Website], [CreatedDate], [UpdatedDate], [ImageFarm]) VALUES (4, N'Koi Farm B', N'Osaka', N'A popular koi farm.', N'Jane Smith', N'contact@koifarmb.com', N'0987654321', 2010, 10, 1, 4, NULL, CAST(N'2024-11-06T22:01:07.410' AS DateTime), NULL, NULL)
INSERT [dbo].[Farms] ([FarmID], [FarmName], [Location], [Description], [OwnerName], [ContactEmail], [ContactPhone], [EstablishedYear], [AreaSize], [IsActive], [Rating], [Website], [CreatedDate], [UpdatedDate], [ImageFarm]) VALUES (5, N'Sakura Koi Farm', N'Sapporo, Hokkaido', NULL, N'Taro Suzuki', N'sakura@example.com', N'0803322110', 2005, 10.5, 1, 5, NULL, CAST(N'2024-11-06T22:19:32.840' AS DateTime), NULL, NULL)
INSERT [dbo].[Farms] ([FarmID], [FarmName], [Location], [Description], [OwnerName], [ContactEmail], [ContactPhone], [EstablishedYear], [AreaSize], [IsActive], [Rating], [Website], [CreatedDate], [UpdatedDate], [ImageFarm]) VALUES (6, N'Fuji Koi Farm', N'Nagoya, Aichi', NULL, N'Kenji Tanaka', N'fuji@example.com', N'0802233445', 2010, 7.2, 1, 4, NULL, CAST(N'2024-11-06T22:19:32.840' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Farms] OFF
GO
SET IDENTITY_INSERT [dbo].[Feedback] ON 

INSERT [dbo].[Feedback] ([FeedbackID], [CustomerID], [OrderKoiID], [OrderTripID], [ServiceRating], [ProductRating], [Comment], [Reply], [FeedbackDate], [UpdatedDate]) VALUES (1, 1, 1, NULL, 5, 4, N'Service is great, koi fish is healthy', NULL, CAST(N'2024-11-06T22:12:25.257' AS DateTime), NULL)
INSERT [dbo].[Feedback] ([FeedbackID], [CustomerID], [OrderKoiID], [OrderTripID], [ServiceRating], [ProductRating], [Comment], [Reply], [FeedbackDate], [UpdatedDate]) VALUES (2, 2, 2, NULL, 3, 3, N'Quality is not as expected', NULL, CAST(N'2024-11-06T22:12:25.257' AS DateTime), NULL)
INSERT [dbo].[Feedback] ([FeedbackID], [CustomerID], [OrderKoiID], [OrderTripID], [ServiceRating], [ProductRating], [Comment], [Reply], [FeedbackDate], [UpdatedDate]) VALUES (3, 1, 1, NULL, 5, 4, N'The koi fish was in excellent condition.', NULL, CAST(N'2024-11-06T22:19:32.847' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Feedback] OFF
GO
GO
SET IDENTITY_INSERT [dbo].[InsurancePolicies] ON 

INSERT [dbo].[InsurancePolicies] ([InsuranceID], [PolicyName], [CoverageDetails], [Price], [DurationMonths], [CreatedDate], [UpdatedDate]) VALUES (1, N'Basic Koi Insurance', N'Covers basic health issues and losses due to natural disasters.', 1000.0000, 12, CAST(N'2024-11-06T13:43:49.977' AS DateTime), NULL)
INSERT [dbo].[InsurancePolicies] ([InsuranceID], [PolicyName], [CoverageDetails], [Price], [DurationMonths], [CreatedDate], [UpdatedDate]) VALUES (2, N'Premium Koi Insurance', N'Covers comprehensive health issues, theft, and natural disasters.', 2000.0000, 24, CAST(N'2024-11-06T13:43:49.977' AS DateTime), NULL)
INSERT [dbo].[InsurancePolicies] ([InsuranceID], [PolicyName], [CoverageDetails], [Price], [DurationMonths], [CreatedDate], [UpdatedDate]) VALUES (3, N'Full Coverage Koi Insurance', N'Covers all health issues, theft, and full loss replacement.', 3000.0000, 36, CAST(N'2024-11-06T13:43:49.977' AS DateTime), NULL)
INSERT [dbo].[InsurancePolicies] ([InsuranceID], [PolicyName], [CoverageDetails], [Price], [DurationMonths], [CreatedDate], [UpdatedDate]) VALUES (4, N'Basic Coverage', N'Covers basic health checkups and loss', 2000.0000, 12, CAST(N'2024-11-06T22:26:24.670' AS DateTime), NULL)
INSERT [dbo].[InsurancePolicies] ([InsuranceID], [PolicyName], [CoverageDetails], [Price], [DurationMonths], [CreatedDate], [UpdatedDate]) VALUES (5, N'Premium Coverage', N'Full coverage including transportation and special care', 5000.0000, 24, CAST(N'2024-11-06T22:26:24.670' AS DateTime), NULL)
INSERT [dbo].[InsurancePolicies] ([InsuranceID], [PolicyName], [CoverageDetails], [Price], [DurationMonths], [CreatedDate], [UpdatedDate]) VALUES (6, N'Total Protection Insurance', N'All-inclusive protection plan for koi', 7500.0000, 36, CAST(N'2024-11-06T22:26:24.670' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[InsurancePolicies] OFF
GO
SET IDENTITY_INSERT [dbo].[KoiFishes] ON 

INSERT [dbo].[KoiFishes] ([KoiFishID], [KoiFishVarietyId], [FarmID], [Weight], [Length], [Color], [Price], [DateAdded], [IsAvailable], [Notes], [Supplier], [Gender]) VALUES (1, 1, 1, 5.5, 60, N'Red and White', 1000000.0000, CAST(N'2024-11-06T13:45:38.923' AS DateTime), 1, NULL, N'Supplier A', 1)
INSERT [dbo].[KoiFishes] ([KoiFishID], [KoiFishVarietyId], [FarmID], [Weight], [Length], [Color], [Price], [DateAdded], [IsAvailable], [Notes], [Supplier], [Gender]) VALUES (2, 2, 2, 6, 65, N'Red, White, and Black', 1500000.0000, CAST(N'2024-11-06T13:45:38.923' AS DateTime), 1, NULL, N'Supplier B', 0)
INSERT [dbo].[KoiFishes] ([KoiFishID], [KoiFishVarietyId], [FarmID], [Weight], [Length], [Color], [Price], [DateAdded], [IsAvailable], [Notes], [Supplier], [Gender]) VALUES (3, 1, 1, 1.5, 30, N'Red and white', 150.0000, CAST(N'2024-11-06T22:01:07.410' AS DateTime), 1, N'Healthy koi', N'Koi Supplier A', 1)
INSERT [dbo].[KoiFishes] ([KoiFishID], [KoiFishVarietyId], [FarmID], [Weight], [Length], [Color], [Price], [DateAdded], [IsAvailable], [Notes], [Supplier], [Gender]) VALUES (4, 2, 1, 1.2, 28, N'Red, white, and black', 180.0000, CAST(N'2024-11-06T22:01:07.410' AS DateTime), 1, N'Healthy koi', N'Koi Supplier B', 2)
INSERT [dbo].[KoiFishes] ([KoiFishID], [KoiFishVarietyId], [FarmID], [Weight], [Length], [Color], [Price], [DateAdded], [IsAvailable], [Notes], [Supplier], [Gender]) VALUES (5, 1, 1, 5.6, 22.5, N'Red and White', 30000.0000, CAST(N'2024-11-06T22:19:32.840' AS DateTime), 1, NULL, N'Nippon Suppliers', 0)
INSERT [dbo].[KoiFishes] ([KoiFishID], [KoiFishVarietyId], [FarmID], [Weight], [Length], [Color], [Price], [DateAdded], [IsAvailable], [Notes], [Supplier], [Gender]) VALUES (6, 2, 2, 6.1, 23, N'Red, White, and Black', 35000.0000, CAST(N'2024-11-06T22:19:32.840' AS DateTime), 1, NULL, N'Nippon Suppliers', 1)
SET IDENTITY_INSERT [dbo].[KoiFishes] OFF
GO
SET IDENTITY_INSERT [dbo].[KoiFishVarieties] ON 

INSERT [dbo].[KoiFishVarieties] ([KoiFishVarietyId], [TypeName], [ScientificName], [Description], [LifespanYears], [AverageSize], [Habitat], [Diet], [ColorPattern], [IsEndangered], [CareDifficulty], [ImageKoiFish]) 
VALUES (1, N'Kohaku', N'Cyprinus carpio', N'A type of Koi fish with a white body and red pattern.', 30, 75, N'Pond', N'Omnivore', N'Red and White', 0, N'Medium', NULL)

INSERT [dbo].[KoiFishVarieties] ([KoiFishVarietyId], [TypeName], [ScientificName], [Description], [LifespanYears], [AverageSize], [Habitat], [Diet], [ColorPattern], [IsEndangered], [CareDifficulty], [ImageKoiFish]) 
VALUES (2, N'Taisho Sanke', N'Cyprinus carpio', N'A type of Koi fish with a white body and red and black patterns.', 25, 70, N'River', N'Omnivore', N'Red, White, and Black', 0, N'Hard', NULL)

INSERT [dbo].[KoiFishVarieties] ([KoiFishVarietyId], [TypeName], [ScientificName], [Description], [LifespanYears], [AverageSize], [Habitat], [Diet], [ColorPattern], [IsEndangered], [CareDifficulty], [ImageKoiFish]) 
VALUES (3, N'Kohaku', N'Cyprinus rubrofuscus', N'Red and white Koi fish.', 200, 60, N'Ponds', N'Omnivore', N'Red and white', 0, N'Easy', N'')

INSERT [dbo].[KoiFishVarieties] ([KoiFishVarietyId], [TypeName], [ScientificName], [Description], [LifespanYears], [AverageSize], [Habitat], [Diet], [ColorPattern], [IsEndangered], [CareDifficulty], [ImageKoiFish]) 
VALUES (4, N'Sanke', N'Cyprinus rubrofuscus', N'Red, white, and black Koi fish.', 200, 60, N'Ponds', N'Omnivore', N'Red, white, and black', 0, N'Medium', N'')

INSERT [dbo].[KoiFishVarieties] ([KoiFishVarietyId], [TypeName], [ScientificName], [Description], [LifespanYears], [AverageSize], [Habitat], [Diet], [ColorPattern], [IsEndangered], [CareDifficulty], [ImageKoiFish]) 
VALUES (5, N'Kohaku', N'Cyprinus carpio', NULL, 40, 24, N'Freshwater', N'Algae and Insects', N'Red and White', 0, N'Medium', NULL)

INSERT [dbo].[KoiFishVarieties] ([KoiFishVarietyId], [TypeName], [ScientificName], [Description], [LifespanYears], [AverageSize], [Habitat], [Diet], [ColorPattern], [IsEndangered], [CareDifficulty], [ImageKoiFish]) 
VALUES (6, N'Sanke', N'Cyprinus carpio', NULL, 35, 22, N'Freshwater', N'Plants and Worms', N'Red, White, and Black', 0, N'Medium', NULL)

SET IDENTITY_INSERT [dbo].[KoiFishVarieties] OFF
GO

SET IDENTITY_INSERT [dbo].[OrderHistory] ON 

INSERT [dbo].[OrderHistory] ([OrderHistoryID], [CustomerID], [OrderKoiID], [OrderTripID], [OrderDate], [TotalPrice], [CreatedDate], [UpdatedDate], [Status]) VALUES (1, 1, 1, NULL, CAST(N'2024-11-06T22:19:32.847' AS DateTime), 35000.0000, CAST(N'2024-11-06T22:19:32.847' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[OrderHistory] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderKoiFishDetails] ON 

INSERT [dbo].[OrderKoiFishDetails] ([OrderKoiFishDetailID], [OrderKoiID], [KoiFishID], [Quantity], [UnitPrice]) VALUES (2, 1, 2, 1, 180.0000)
INSERT [dbo].[OrderKoiFishDetails] ([OrderKoiFishDetailID], [OrderKoiID], [KoiFishID], [Quantity], [UnitPrice]) VALUES (3, 1, 1, 1, 30000.0000)
SET IDENTITY_INSERT [dbo].[OrderKoiFishDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderKoiFishes] ON 

INSERT [dbo].[OrderKoiFishes] ([OrderKoiID], [CustomerID], [OrderDate], [TotalPrice], [Deposit], [RemainingBalance], [DeliveryDate], [CreatedDate], [UpdatedDate], [DeliveryMethod], [SpecialInstructions], [CancellationReason], [InsuranceID], [Status]) VALUES (1, 1, CAST(N'2024-11-06T22:01:07.413' AS DateTime), 300.0000, 50.0000, 250.0000, CAST(N'2024-12-01' AS Date), CAST(N'2024-11-06T22:01:07.413' AS DateTime), NULL, N'Air', NULL, NULL, 1, NULL)
INSERT [dbo].[OrderKoiFishes] ([OrderKoiID], [CustomerID], [OrderDate], [TotalPrice], [Deposit], [RemainingBalance], [DeliveryDate], [CreatedDate], [UpdatedDate], [DeliveryMethod], [SpecialInstructions], [CancellationReason], [InsuranceID], [Status]) VALUES (2, 2, CAST(N'2024-11-06T22:01:07.413' AS DateTime), 200.0000, 0.0000, 200.0000, CAST(N'2024-12-15' AS Date), CAST(N'2024-11-06T22:01:07.413' AS DateTime), NULL, N'Ground', NULL, NULL, 1, NULL)
SET IDENTITY_INSERT [dbo].[OrderKoiFishes] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderTrips] ON 

INSERT [dbo].[OrderTrips] ([OrderTripID], [CustomerID], [TripID], [OrderDate], [TotalPrice], [CreatedDate], [UpdatedDate], [CancellationReason], [SpecialRequests], [ScheduleID], [Status]) VALUES (1, 1, 1, CAST(N'2024-11-06T22:19:32.840' AS DateTime), 10000.0000, CAST(N'2024-11-06T22:19:32.840' AS DateTime), NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[OrderTrips] OFF
GO
SET IDENTITY_INSERT [dbo].[Payments] ON 

INSERT [dbo].[Payments] ([PaymentID], [CustomerID], [OrderKoiID], [OrderTripID], [PaymentDate], [Amount], [PaymentMethod], [PaymentDescription], [CreatedDate], [UpdatedDate], [Currency], [IsPartialPayment], [Status]) VALUES (1, 1, 1, NULL, CAST(N'2024-11-06T22:19:32.847' AS DateTime), 35000.0000, N'Credit Card', NULL, CAST(N'2024-11-06T22:19:32.847' AS DateTime), NULL, N'JPY', 0, NULL)
SET IDENTITY_INSERT [dbo].[Payments] OFF
GO
SET IDENTITY_INSERT [dbo].[RefundRequests] ON 

INSERT [dbo].[RefundRequests] ([RefundRequestID], [OrderKoiID], [RequestDate], [RefundAmount], [Reason], [ProcessedDate], [Status]) VALUES (1, 1, CAST(N'2025-01-10T00:00:00.000' AS DateTime), 10000000.0000, NULL, CAST(N'2025-01-10T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[RefundRequests] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleID], [RoleName], [Description], [CreatedDate], [UpdatedDate], [IsActive], [CreatedBy], [UpdatedBy]) 
VALUES (1, N'Manager', N'Manages the system and oversees all operations', CAST(N'2024-11-06T13:45:22.437' AS DateTime), NULL, 1, 1, NULL)

INSERT [dbo].[Roles] ([RoleID], [RoleName], [Description], [CreatedDate], [UpdatedDate], [IsActive], [CreatedBy], [UpdatedBy]) 
VALUES (2, N'Customer', N'Customer purchasing Koi fish or booking tours', CAST(N'2024-11-06T13:45:22.437' AS DateTime), NULL, 1, 1, NULL)

INSERT [dbo].[Roles] ([RoleID], [RoleName], [Description], [CreatedDate], [UpdatedDate], [IsActive], [CreatedBy], [UpdatedBy]) 
VALUES (3, N'Sales Staff', N'Employees assisting with sales and organizing tours', CAST(N'2024-11-06T13:45:22.437' AS DateTime), NULL, 1, 1, NULL)

INSERT [dbo].[Roles] ([RoleID], [RoleName], [Description], [CreatedDate], [UpdatedDate], [IsActive], [CreatedBy], [UpdatedBy]) 
VALUES (4, N'Consultant Staff', N'Employees providing consultation for Koi fish and related services', CAST(N'2024-11-06T13:45:22.437' AS DateTime), NULL, 1, 1, NULL)

INSERT [dbo].[Roles] ([RoleID], [RoleName], [Description], [CreatedDate], [UpdatedDate], [IsActive], [CreatedBy], [UpdatedBy]) 
VALUES (5, N'Delivery Staff', N'Employees responsible for delivering Koi fish and handling logistics', CAST(N'2024-11-06T13:45:22.437' AS DateTime), NULL, 1, 1, NULL)

SET IDENTITY_INSERT [dbo].[Roles] OFF
GO

SET IDENTITY_INSERT [dbo].[ScheduleFarms] ON 

INSERT [dbo].[ScheduleFarms] ([ScheduleFarmID], [ScheduleID], [FarmID], [VisitDate], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (4, 1, 1, CAST(N'2024-10-10' AS Date), CAST(N'2024-10-01T00:00:00.000' AS DateTime), CAST(N'2024-10-01T00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[ScheduleFarms] OFF
GO
SET IDENTITY_INSERT [dbo].[Trips] ON 

INSERT [dbo].[Trips] ([TripID], [TripDate], [Price], [Duration], [MaxParticipants], [MinParticipants], [Transportation], [MeetingLocation], [SpecialInstructions], [IsActive], [CreatedDate], [UpdatedDate], [AverageRating], [CancellationPolicy], [Status]) 
VALUES (1, CAST(N'2023-12-01' AS Date), 500000.0000, N'1 Day', 20, 5, N'Bus', N'Central Station, Tokyo', N'Bring your ID and water', 0, CAST(N'2024-11-06T13:45:44.410' AS DateTime), NULL, NULL, NULL, NULL)

INSERT [dbo].[Trips] ([TripID], [TripDate], [Price], [Duration], [MaxParticipants], [MinParticipants], [Transportation], [MeetingLocation], [SpecialInstructions], [IsActive], [CreatedDate], [UpdatedDate], [AverageRating], [CancellationPolicy], [Status]) 
VALUES (2, CAST(N'2023-12-10' AS Date), 600000.0000, N'2 Days', 30, 10, N'Train', N'Kyoto Main Station', N'Departs at 8:00 AM, please arrive on time', 0, CAST(N'2024-11-06T13:45:44.410' AS DateTime), NULL, NULL, NULL, NULL)

INSERT [dbo].[Trips] ([TripID], [TripDate], [Price], [Duration], [MaxParticipants], [MinParticipants], [Transportation], [MeetingLocation], [SpecialInstructions], [IsActive], [CreatedDate], [UpdatedDate], [AverageRating], [CancellationPolicy], [Status]) 
VALUES (3, CAST(N'2024-11-01' AS Date), 10000.0000, N'Full Day', 20, 5, N'Bus', N'Tokyo Central Station', N'Wear comfortable shoes', 0, CAST(N'2024-11-06T22:19:32.840' AS DateTime), NULL, NULL, NULL, NULL)

SET IDENTITY_INSERT [dbo].[Trips] OFF
GO

SET IDENTITY_INSERT [dbo].[TripSchedules] ON 

INSERT [dbo].[TripSchedules] ([ScheduleID], [TripID], [StartDate], [EndDate], [MaxParticipants], [IsActive], [CreatedDate], [UpdatedDate], [CreatedBy], [UpdatedBy]) VALUES (1, 1, CAST(N'2024-10-10' AS Date), CAST(N'2024-10-15' AS Date), 2, 1, CAST(N'2024-10-01T00:00:00.000' AS DateTime), CAST(N'2024-10-01T00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[TripSchedules] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [FullName], [UserName], [Password], [Email], [PhoneNumber], [BirthDate], [Address], [Gender], [ImageUser], [HireDate], [RoleID], [IsActive], [CreatedDate], [UpdatedDate], [RegistrationDate], [IsVerified], [LastPurchaseDate], [TotalSpent], [PreferredContactMethod], [MembershipLevel], [Notes]) VALUES (1, N'Nguyen Van A', N'nguyenvana', N'password123', N'vana@example.com', N'0901234567', CAST(N'1980-01-01' AS Date), N'123 Tokyo', 1, NULL, CAST(N'2023-01-01' AS Date), 1, 1, CAST(N'2024-11-06T13:45:27.577' AS DateTime), NULL, CAST(N'2024-11-06T13:45:27.577' AS DateTime), 0, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([UserID], [FullName], [UserName], [Password], [Email], [PhoneNumber], [BirthDate], [Address], [Gender], [ImageUser], [HireDate], [RoleID], [IsActive], [CreatedDate], [UpdatedDate], [RegistrationDate], [IsVerified], [LastPurchaseDate], [TotalSpent], [PreferredContactMethod], [MembershipLevel], [Notes]) VALUES (2, N'Tran Thi B', N'tranthib', N'password123', N'thib@example.com', N'0902345678', CAST(N'1990-02-02' AS Date), N'456 Kyoto', 0, NULL, NULL, 2, 1, CAST(N'2024-11-06T13:45:27.577' AS DateTime), NULL, CAST(N'2024-11-06T13:45:27.577' AS DateTime), 0, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([UserID], [FullName], [UserName], [Password], [Email], [PhoneNumber], [BirthDate], [Address], [Gender], [ImageUser], [HireDate], [RoleID], [IsActive], [CreatedDate], [UpdatedDate], [RegistrationDate], [IsVerified], [LastPurchaseDate], [TotalSpent], [PreferredContactMethod], [MembershipLevel], [Notes]) VALUES (3, N'Le Van C', N'levanc', N'password123', N'vanc@example.com', N'0903456789', CAST(N'1985-03-03' AS Date), N'789 Osaka', 1, NULL, CAST(N'2023-05-01' AS Date), 3, 1, CAST(N'2024-11-06T13:45:27.577' AS DateTime), NULL, CAST(N'2024-11-06T13:45:27.577' AS DateTime), 0, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([UserID], [FullName], [UserName], [Password], [Email], [PhoneNumber], [BirthDate], [Address], [Gender], [ImageUser], [HireDate], [RoleID], [IsActive], [CreatedDate], [UpdatedDate], [RegistrationDate], [IsVerified], [LastPurchaseDate], [TotalSpent], [PreferredContactMethod], [MembershipLevel], [Notes]) VALUES (4, N'John Doe', N'johndoe', N'password123', N'john.doe@example.com', N'1234567890', CAST(N'1985-01-01' AS Date), N'123 Main St', 1, NULL, NULL, 1, 1, CAST(N'2024-11-06T22:01:07.410' AS DateTime), NULL, CAST(N'2024-11-06T22:01:07.410' AS DateTime), 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([UserID], [FullName], [UserName], [Password], [Email], [PhoneNumber], [BirthDate], [Address], [Gender], [ImageUser], [HireDate], [RoleID], [IsActive], [CreatedDate], [UpdatedDate], [RegistrationDate], [IsVerified], [LastPurchaseDate], [TotalSpent], [PreferredContactMethod], [MembershipLevel], [Notes]) VALUES (5, N'Jane Smith', N'janesmith', N'password123', N'jane.smith@example.com', N'0987654321', CAST(N'1990-02-02' AS Date), N'456 Elm St', 2, NULL, NULL, 3, 1, CAST(N'2024-11-06T22:01:07.410' AS DateTime), NULL, CAST(N'2024-11-06T22:01:07.410' AS DateTime), 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([UserID], [FullName], [UserName], [Password], [Email], [PhoneNumber], [BirthDate], [Address], [Gender], [ImageUser], [HireDate], [RoleID], [IsActive], [CreatedDate], [UpdatedDate], [RegistrationDate], [IsVerified], [LastPurchaseDate], [TotalSpent], [PreferredContactMethod], [MembershipLevel], [Notes]) VALUES (6, N'Alice Tanaka', N'alice.tanaka', N'password123', N'alice@example.com', N'0801234567', CAST(N'1980-07-12' AS Date), N'Tokyo, Japan', 0, NULL, NULL, 2, 1, CAST(N'2024-11-06T22:19:32.837' AS DateTime), NULL, CAST(N'2024-11-06T22:19:32.837' AS DateTime), 0, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([UserID], [FullName], [UserName], [Password], [Email], [PhoneNumber], [BirthDate], [Address], [Gender], [ImageUser], [HireDate], [RoleID], [IsActive], [CreatedDate], [UpdatedDate], [RegistrationDate], [IsVerified], [LastPurchaseDate], [TotalSpent], [PreferredContactMethod], [MembershipLevel], [Notes]) VALUES (7, N'Bob Sato', N'bob.sato', N'password456', N'bob@example.com', N'0908765432', CAST(N'1992-04-22' AS Date), N'Osaka, Japan', 1, NULL, NULL, 1, 1, CAST(N'2024-11-06T22:19:32.837' AS DateTime), NULL, CAST(N'2024-11-06T22:19:32.837' AS DateTime), 0, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([UserID], [FullName], [UserName], [Password], [Email], [PhoneNumber], [BirthDate], [Address], [Gender], [ImageUser], [HireDate], [RoleID], [IsActive], [CreatedDate], [UpdatedDate], [RegistrationDate], [IsVerified], [LastPurchaseDate], [TotalSpent], [PreferredContactMethod], [MembershipLevel], [Notes]) VALUES (8, N'Chika Yamada', N'chika.yamada', N'password789', N'chika@example.com', N'0701122334', CAST(N'1985-01-15' AS Date), N'Kyoto, Japan', 0, NULL, NULL, 3, 1, CAST(N'2024-11-06T22:19:32.837' AS DateTime), NULL, CAST(N'2024-11-06T22:19:32.837' AS DateTime), 0, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderKoiFishDetails] ON;
INSERT INTO [dbo].[OrderKoiFishDetails] 
    ([OrderKoiFishDetailID], [OrderKoiID], [KoiFishID], [Quantity], [UnitPrice]) 
VALUES 
    (4, 1, 2, 1, 180.0000);
SET IDENTITY_INSERT [dbo].[OrderKoiFishDetails] OFF;
GO
