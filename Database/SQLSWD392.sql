
Use KoiOrderingSystemInJapan;

-- Bảng Roles
CREATE TABLE Roles (
    RoleID INT PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(100) UNIQUE not null,
    Description NVARCHAR(500),
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME,
    IsActive BIT DEFAULT 1 not null,
	CreatedBy INT, -- Ai đã tạo vai trò này
    UpdatedBy INT, -- Ai đã cập nhật vai trò này
);

-- Bảng Users
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(200) not null,
	UserName NVARCHAR(200) not null,
    Password NVARCHAR(200) not null,
    Email NVARCHAR(200) UNIQUE not null CHECK (Email LIKE '%@%.%'), -- Xác thực email cơ bản,
    PhoneNumber NVARCHAR(20) not null,
	BirthDate DATE not null,
    Address NVARCHAR(300) not null,
	Gender TINYINT not null, -- Giới tính
	ImageUser NVARCHAR(500),
    HireDate DATE,
    RoleID INT not null,
    IsActive BIT DEFAULT 1,
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME,
	RegistrationDate DATETIME DEFAULT GETDATE(),
    IsVerified BIT DEFAULT 0 not null,
    LastPurchaseDate DATETIME,
    TotalSpent MONEY,
	PreferredContactMethod NVARCHAR(100), -- Phương thức liên lạc ưa thích
    MembershipLevel NVARCHAR(100), -- Cấp độ thành viên
	Notes NVARCHAR(500), -- Ghi chú thêm
    FOREIGN KEY (RoleId) REFERENCES Roles(RoleId)
);

-- Bảng Farms
CREATE TABLE Farms (
    FarmID INT PRIMARY KEY IDENTITY(1,1),
    FarmName NVARCHAR(200) not null,
    Location NVARCHAR(300) not null,
    Description NVARCHAR(500),
    OwnerName NVARCHAR(200) not null,
    ContactEmail NVARCHAR(100) not null CHECK (ContactEmail LIKE '%@%.%'), -- Xác thực email cơ bản,
    ContactPhone NVARCHAR(20) not null,
    EstablishedYear INT CHECK (EstablishedYear <= YEAR(GETDATE())), -- Năm thành lập không được lớn hơn năm hiện tại
    AreaSize FLOAT, -- Diện tích trang trại
    IsActive BIT DEFAULT 1 not null,
    Rating TINYINT CHECK (Rating >= 1 AND Rating <= 5), -- Đánh giá từ 1 đến 5 không có số lẻ
	Website NVARCHAR(500), -- Trang web của trang trại
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME
);

-- Bảng AnimalVarieties
CREATE TABLE KoiFishVarieties (
    KoiFishVarietyId INT PRIMARY KEY IDENTITY(1,1),
    TypeName NVARCHAR(200) not null,
    ScientificName NVARCHAR(200) not null, -- Tên khoa học của loài
    Description NVARCHAR(500),
    LifespanYears INT, -- Tuổi thọ trung bình
    AverageSize FLOAT not null, -- Kích thước trung bình
    Habitat NVARCHAR(300), -- Môi trường sống tự nhiên
    Diet NVARCHAR(300), -- Chế độ ăn
    ColorPattern NVARCHAR(300), -- Mẫu màu sắc
    IsEndangered BIT DEFAULT 0, -- Có phải là loài quý hiếm
    CareDifficulty NVARCHAR(100) -- Mức độ khó trong chăm sóc
);

-- Bảng KoiFishes
CREATE TABLE KoiFishes( 
    KoiFishID INT PRIMARY KEY IDENTITY(1,1), -- Mã cá Koi
    KoiFishVarietyId INT not null, -- Liên kết với bảng KoiFishVarieties
    FarmID INT not null, -- Liên kết với bảng Farms
    --Age INT, -- Tuổi của cá Koi
    Weight FLOAT not null, -- Cân nặng
    Length FLOAT not null, -- Chiều dài
    Color NVARCHAR(200) not null, -- Màu sắc
    Price MONEY not null, -- Giá bán của cá Koi
    DateAdded DATETIME DEFAULT GETDATE(), -- Ngày đưa vào trang trại
    IsAvailable BIT DEFAULT 1, -- Cá Koi có sẵn để bán không
    Notes NVARCHAR(500), -- Ghi chú khác
	Supplier NVARCHAR(200), -- Nhà cung cấp
    Gender TINYINT not null, -- Giới tính
    FOREIGN KEY (KoiFishVarietyId) REFERENCES KoiFishVarieties(KoiFishVarietyId),
    FOREIGN KEY (FarmID) REFERENCES Farms(FarmID)
);

-- Bảng Trips
CREATE TABLE Trips (
    TripID INT PRIMARY KEY IDENTITY(1,1),
    TripDate DATE not null,
    Price MONEY not null,
    Duration NCHAR(100),
    MaxParticipants INT, -- Số lượng khách tham gia tối đa
    MinParticipants INT, -- Số lượng khách tối thiểu
    Transportation NVARCHAR(200), -- Phương tiện di chuyển
    MeetingLocation NVARCHAR(300), -- Điểm tập trung
    --IncludedServices NVARCHAR(500), -- Các dịch vụ bao gồm
    --NotIncludedServices NVARCHAR(500), -- Các dịch vụ không bao gồm
    SpecialInstructions NVARCHAR(500), -- Hướng dẫn đặc biệt
	Status NVARCHAR(100) DEFAULT 'Scheduled', -- Trạng thái chuyến đi (Scheduled, Completed, Cancelled)
    IsActive BIT DEFAULT 0 not null,
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME,
	AverageRating FLOAT, -- Đánh giá trung bình
    CancellationPolicy NVARCHAR(500) -- Chính sách hủy chuyến
);

-- Bảng Schedule để quản lý lịch trình các chuyến đi qua nhiều trang trại
/*CREATE TABLE Schedule (
    ScheduleID INT PRIMARY KEY IDENTITY(1,1),
    TripID INT NOT NULL, -- Liên kết với bảng Trips
    FarmID INT NOT NULL, -- Liên kết với bảng Farms
    VisitOrder INT NOT NULL, -- Thứ tự ghé thăm trang trại
    VisitDate DATE NOT NULL, -- Ngày đến thăm trang trại
    StartTime TIME NOT NULL, -- Thời gian bắt đầu ghé thăm
    EndTime TIME NOT NULL, -- Thời gian kết thúc ghé thăm
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME,
    FOREIGN KEY (TripID) REFERENCES Trips(TripID),
    FOREIGN KEY (FarmID) REFERENCES Farms(FarmID)
);*/

-- Bảng CheckIns
CREATE TABLE CheckIns (
    CheckInID INT PRIMARY KEY IDENTITY(1,1),
    TripID INT not null,
    CustomerID INT not null,
	ConsultingStaffID INT not null,
    CheckInDate DATETIME DEFAULT GETDATE(),
    CheckInStatus NVARCHAR(100), -- Trạng thái check-in (Checked In, Missed)
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME,
	Notes NVARCHAR(500), -- Ghi chú thêm cho check-in
    FOREIGN KEY (TripID) REFERENCES Trips(TripID),
    FOREIGN KEY (CustomerID) REFERENCES Users(UserID),
	FOREIGN KEY (ConsultingStaffID) REFERENCES Users(UserID)
);

-- Bảng OrderTrips
CREATE TABLE OrderTrips (
    OrderTripID INT PRIMARY KEY IDENTITY(1,1), -- Mã đơn đặt chuyến
    CustomerID INT NOT NULL, -- Liên kết với bảng Users
    TripID INT NOT NULL, -- Liên kết với bảng Trips
    OrderDate DATETIME DEFAULT GETDATE(), -- Ngày đặt chuyến
    TotalPrice MONEY NOT NULL, -- Tổng giá cho chuyến
    Status NVARCHAR(100) DEFAULT 'Pending', -- Trạng thái đơn đặt (Pending, Confirmed, Cancelled)
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME,
	--PaymentStatus NVARCHAR(100) DEFAULT 'Not Paid', -- Tình trạng thanh toán
    CancellationReason NVARCHAR(500), -- Lý do hủy
    SpecialRequests NVARCHAR(500), -- Yêu cầu đặc biệt từ khách hàng
    FOREIGN KEY (CustomerID) REFERENCES Users(UserID),
    FOREIGN KEY (TripID) REFERENCES Trips(TripID)
);

-- Bảng OrderKoiFishes
CREATE TABLE OrderKoiFishes (
    OrderKoiID INT PRIMARY KEY IDENTITY(1,1), -- Mã đơn đặt cá Koi
    CustomerID INT NOT NULL, -- Liên kết với bảng Users
    KoiFishID INT NOT NULL, -- Liên kết với bảng KoiFishes
    OrderDate DATETIME DEFAULT GETDATE(), -- Ngày đặt hàng
    Quantity INT NOT NULL, -- Số lượng cá Koi đặt
    TotalPrice MONEY NOT NULL, -- Tổng giá cho đơn hàng
    Deposit MONEY DEFAULT 0, -- Khoản đặt cọc (nếu có)
	RemainingBalance MONEY NOT NULL, -- Số tiền còn lại cần thanh toán
    DeliveryDate DATE, -- Ngày giao hàng
    Status NVARCHAR(100) DEFAULT 'Pending', -- Trạng thái đơn hàng (Pending, Completed, Cancelled)
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME,
	--PaymentStatus NVARCHAR(100) DEFAULT 'Not Paid', -- Tình trạng thanh toán
    DeliveryMethod NVARCHAR(200), -- Phương thức giao hàng
    SpecialInstructions NVARCHAR(500), -- Hướng dẫn đặc biệt cho giao hàng
    CancellationReason NVARCHAR(500), -- Lý do hủy đơn
    FOREIGN KEY (CustomerID) REFERENCES Users(UserID),
    FOREIGN KEY (KoiFishID) REFERENCES KoiFishes(KoiFishID)
);

-- Bảng Payments
CREATE TABLE Payments (
    PaymentID INT PRIMARY KEY IDENTITY(1,1), -- Mã thanh toán
    CustomerID INT NOT NULL, -- Liên kết với bảng Users
    OrderKoiID INT NULL, -- Liên kết với bảng OrderKoiFishes (nếu thanh toán cho đơn cá Koi)
    OrderTripID INT NULL, -- Liên kết với bảng OrderTrips (nếu thanh toán cho chuyến đi)
    PaymentDate DATETIME DEFAULT GETDATE(), -- Ngày thanh toán
    Amount MONEY NOT NULL, -- Số tiền thanh toán
    PaymentMethod NVARCHAR(100), -- Phương thức thanh toán (Credit Card, Bank Transfer, etc.)
    Status NVARCHAR(100) DEFAULT 'Completed', -- Trạng thái thanh toán (Completed, Pending, Failed)
	PaymentDescription NVARCHAR(500), -- Mô tả nội dung thanh toán
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME,
	Currency NVARCHAR(10), -- Đơn vị tiền tệ (VND, JPY, etc.)
    FOREIGN KEY (CustomerID) REFERENCES Users(UserID),
    FOREIGN KEY (OrderKoiID) REFERENCES OrderKoiFishes(OrderKoiID),
    FOREIGN KEY (OrderTripID) REFERENCES OrderTrips(OrderTripID)
);

-- Bảng OrderHistory
CREATE TABLE OrderHistory (
    OrderHistoryID INT PRIMARY KEY IDENTITY(1,1), -- Mã lịch sử đơn hàng
    CustomerID INT NOT NULL, -- Liên kết với bảng Users
    OrderKoiID INT NULL, -- Liên kết với bảng OrderKoiFishes (nếu có)
    OrderTripID INT NULL, -- Liên kết với bảng OrderTrips (nếu có)
    OrderDate DATETIME DEFAULT GETDATE(), -- Ngày đặt hàng
    TotalPrice MONEY NOT NULL, -- Tổng giá cho đơn hàng
    Status NVARCHAR(100) DEFAULT 'Completed', -- Trạng thái đơn hàng (Completed, Cancelled, etc.)
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME,
    FOREIGN KEY (CustomerID) REFERENCES Users(UserID),
    FOREIGN KEY (OrderKoiID) REFERENCES OrderKoiFishes(OrderKoiID),
    FOREIGN KEY (OrderTripID) REFERENCES OrderTrips(OrderTripID)
);

-- Bảng Feedback
CREATE TABLE Feedback (
    FeedbackID INT PRIMARY KEY IDENTITY(1,1), -- Mã phản hồi
    CustomerID INT NOT NULL, -- Liên kết với bảng Users
    OrderKoiID INT NULL, -- Liên kết với bảng OrderKoiFishes (nếu có)
    OrderTripID INT NULL, -- Liên kết với bảng OrderTrips (nếu có)
    --Rating TINYINT CHECK (Rating >= 1 AND Rating <= 5), -- Đánh giá từ 1 đến 5
	ServiceRating TINYINT CHECK (ServiceRating >= 1 AND ServiceRating <= 5), -- Đánh giá dịch vụ
    ProductRating TINYINT CHECK (ProductRating >= 1 AND ProductRating <= 5), -- Đánh giá sản phẩ
    Comment NVARCHAR(500), -- Bình luận của khách hàng
	Reply NVARCHAR(500), -- Phản hồi từ công ty
    FeedbackDate DATETIME DEFAULT GETDATE(), -- Ngày Feedback
    UpdatedDate DATETIME,
    FOREIGN KEY (CustomerID) REFERENCES Users(UserID),
    FOREIGN KEY (OrderKoiID) REFERENCES OrderKoiFishes(OrderKoiID),
    FOREIGN KEY (OrderTripID) REFERENCES OrderTrips(OrderTripID)
);

--Luồng Quy Trình
--Quy trình hoạt động cho việc đặt chuyến tham quan và đặt cá Koi có thể như sau:

-- + Đặt Chuyến Tham Quan (Book Trip):
--    Khách hàng tra cứu chuyến đi và chọn chuyến mong muốn.
--    Nhân viên kinh doanh xác nhận và gửi thông tin chi tiết về chuyến đi.
--    Khách hàng thực hiện thanh toán và check-in.

---Đặt Mua Cá Koi (Order KoiFish):

-- + Khách hàng lựa chọn con cá Koi cần mua.
--    Nhân viên tư vấn gửi thông tin và báo giá cho khách hàng.
--    Khách hàng xác nhận đơn hàng và thực hiện thanh toán.
--    Nhân viên giao hàng thực hiện giao cá Koi.

INSERT INTO Roles (RoleName, Description, CreatedBy, IsActive)
VALUES 
    ('Admin', 'Quản trị hệ thống', 1, 1),
    ('Customer', 'Khách hàng mua cá Koi hoặc đặt chuyến tham quan', 1, 1),
    ('Staff', 'Nhân viên hỗ trợ bán hàng và tổ chức chuyến đi', 1, 1);

	INSERT INTO Users (FullName, UserName, Password, Email, PhoneNumber, BirthDate, Address, Gender, RoleID, HireDate)
VALUES
    ('Nguyen Van A', 'nguyenvana', 'password123', 'vana@example.com', '0901234567', '1980-01-01', '123 Tokyo', 1, 1, '2023-01-01'),
    ('Tran Thi B', 'tranthib', 'password123', 'thib@example.com', '0902345678', '1990-02-02', '456 Kyoto', 0, 2, NULL),
    ('Le Van C', 'levanc', 'password123', 'vanc@example.com', '0903456789', '1985-03-03', '789 Osaka', 1, 3, '2023-05-01');

	INSERT INTO Farms (FarmName, Location, Description, OwnerName, ContactEmail, ContactPhone, EstablishedYear, AreaSize, Rating, Website)
VALUES
    ('Koi Farm A', 'Tokyo', 'Trang trại cá Koi chất lượng cao', 'Tanaka San', 'ownerA@koifarm.com', '0801234567', 1990, 15.5, 5, 'www.koifarma.com'),
    ('Koi Farm B', 'Kyoto', 'Trang trại nhỏ chuyên về cá Koi quý hiếm', 'Yamada San', 'ownerB@koifarm.com', '0802345678', 2000, 10.2, 4, 'www.koifarmb.com');

	
	INSERT INTO KoiFishVarieties (TypeName, ScientificName, Description, LifespanYears, AverageSize, Habitat, Diet, ColorPattern, IsEndangered, CareDifficulty)
VALUES
    ('Kohaku', 'Cyprinus carpio', 'Loài cá Koi màu trắng với hoa văn đỏ', 30, 75, 'Pond', 'Omnivore', 'Red and White', 0, 'Medium'),
    ('Taisho Sanke', 'Cyprinus carpio', 'Cá Koi màu trắng với hoa văn đỏ và đen', 25, 70, 'River', 'Omnivore', 'Red, White, and Black', 0, 'Hard');

	INSERT INTO KoiFishes (KoiFishVarietyId, FarmID, Weight, Length, Color, Price, Gender, Supplier)
VALUES
    (1, 1, 5.5, 60, 'Red and White', 1000000, 1, 'Supplier A'),
    (2, 2, 6.0, 65, 'Red, White, and Black', 1500000, 0, 'Supplier B');

	INSERT INTO Trips (TripDate, Price, Duration, MaxParticipants, MinParticipants, Transportation, MeetingLocation, SpecialInstructions)
VALUES
    ('2023-12-01', 500000, '1 Day', 20, 5, 'Bus', 'Central Station, Tokyo', 'Mang theo hộ chiếu và nước uống'),
    ('2023-12-10', 600000, '2 Days', 30, 10, 'Train', 'Kyoto Main Station', 'Khởi hành lúc 8h sáng, tập trung đúng giờ');

/*	INSERT INTO Schedule (TripID, FarmID, VisitOrder, VisitDate, StartTime, EndTime)
VALUES
    (1, 1, 1, '2023-12-01', '08:00', '10:00'),
    (1, 2, 2, '2023-12-01', '12:00', '14:00'),
    (2, 2, 1, '2023-12-10', '09:00', '11:00');
*/
	INSERT INTO CheckIns (TripID, CustomerID, ConsultingStaffID, CheckInStatus)
VALUES
    (1, 2, 3, 'Checked In'),
    (2, 1, 3, 'Missed');

	INSERT INTO OrderTrips (CustomerID, TripID, TotalPrice, SpecialRequests)
VALUES
    (1, 1, 500000, 'Yêu cầu chỗ ngồi gần cửa sổ'),
    (2, 2, 600000, 'Có thể mang thú cưng không?');

	INSERT INTO OrderKoiFishes (CustomerID, KoiFishID, Quantity, TotalPrice, RemainingBalance, DeliveryMethod, SpecialInstructions)
VALUES
    (1, 1, 2, 2000000, 1000000, 'Express Delivery', 'Giao hàng trước 12 giờ trưa'),
    (2, 2, 1, 1500000, 0, 'Standard Delivery', 'Không yêu cầu đặc biệt');

	INSERT INTO Payments (CustomerID, OrderKoiID, PaymentDate, Amount, PaymentMethod, Currency)
VALUES
    (1, 1, '2023-12-05', 1000000, 'Credit Card', 'JPY'),
    (2, 2, '2023-12-06', 1500000, 'Bank Transfer', 'JPY');

	INSERT INTO OrderHistory (CustomerID, OrderKoiID, TotalPrice, Status)
VALUES
    (1, 1, 2000000, 'Completed'),
    (2, 2, 1500000, 'Cancelled');

	INSERT INTO Feedback (CustomerID, OrderKoiID, ServiceRating, ProductRating, Comment)
VALUES
    (1, 1, 5, 4, 'Dịch vụ tốt, cá Koi khỏe mạnh'),
    (2, 2, 3, 3, 'Chất lượng không như mong đợi');

	-- Cập nhật bảng Users, đổi kiểu dữ liệu của Gender từ TINYINT sang INT
ALTER TABLE Users
ALTER COLUMN Gender INT;

-- Nếu có bảng khác như KoiFishes cần thay đổi
ALTER TABLE KoiFishes
ALTER COLUMN Gender INT;

DROP TABLE IF EXISTS Schedule;

CREATE TABLE TripSchedules (
    ScheduleID INT PRIMARY KEY IDENTITY(1,1),
    TripID INT NOT NULL,  -- Liên kết với bảng Trips
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    MaxParticipants INT,
    IsActive BIT DEFAULT 1,
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME,
    CreatedBy INT,
    UpdatedBy INT,
    FOREIGN KEY (TripID) REFERENCES Trips(TripID)
);

CREATE TABLE ScheduleFarms (
    ScheduleFarmID INT PRIMARY KEY IDENTITY(1,1),
    ScheduleID INT NOT NULL,  -- Liên kết với bảng TripSchedules
    FarmID INT NOT NULL,      -- Liên kết với bảng Farms
    VisitDate DATE NOT NULL,
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME,
    CreatedBy INT,
    UpdatedBy INT,
    FOREIGN KEY (ScheduleID) REFERENCES TripSchedules(ScheduleID),
    FOREIGN KEY (FarmID) REFERENCES Farms(FarmID)
);

ALTER TABLE OrderTrips
ADD ScheduleID INT,
    FOREIGN KEY (ScheduleID) REFERENCES TripSchedules(ScheduleID);

CREATE TABLE RefundRequests (
    RefundRequestID INT PRIMARY KEY IDENTITY(1,1), -- Mã yêu cầu hoàn tiền
    OrderKoiID INT NOT NULL, -- Liên kết với bảng OrderKoiFishes
    RequestDate DATETIME DEFAULT GETDATE(), -- Ngày yêu cầu hoàn tiền
    RefundAmount MONEY, -- Số tiền yêu cầu hoàn lại
    Reason NVARCHAR(500), -- Lý do yêu cầu hoàn tiền
    Status NVARCHAR(100) DEFAULT 'Pending', -- Trạng thái của yêu cầu (Pending, Approved, Denied)
    ProcessedDate DATETIME, -- Ngày xử lý yêu cầu
    FOREIGN KEY (OrderKoiID) REFERENCES OrderKoiFishes(OrderKoiID)
);

CREATE TABLE InsurancePolicies (
    InsuranceID INT PRIMARY KEY IDENTITY(1,1), -- Mã bảo hiểm
    PolicyName NVARCHAR(200) NOT NULL, -- Tên chính sách bảo hiểm
    CoverageDetails NVARCHAR(500), -- Chi tiết bảo hiểm (những gì được bảo hiểm)
    Price MONEY NOT NULL, -- Chi phí bảo hiểm
    DurationMonths INT NOT NULL, -- Thời hạn bảo hiểm (tính theo tháng)
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME
);

INSERT INTO InsurancePolicies (PolicyName, CoverageDetails, Price, DurationMonths, CreatedDate, UpdatedDate)
VALUES 
    ('Basic Koi Insurance', 'Covers basic health issues and losses due to natural disasters.', 1000.00, 12, GETDATE(), NULL),
    ('Premium Koi Insurance', 'Covers comprehensive health issues, theft, and natural disasters.', 2000.00, 24, GETDATE(), NULL),
    ('Full Coverage Koi Insurance', 'Covers all health issues, theft, and full loss replacement.', 3000.00, 36, GETDATE(), NULL);

ALTER TABLE CheckIns
DROP CONSTRAINT FK__CheckIns__TripID__5AEE82B9;

ALTER TABLE CheckIns
DROP COLUMN TripID;

ALTER TABLE CheckIns
ADD ScheduleID INT,
    FOREIGN KEY (ScheduleID) REFERENCES TripSchedules(ScheduleID);

ALTER TABLE Payments
ADD IsPartialPayment BIT NOT NULL DEFAULT 0;

-- Bước 1: Thêm cột InsuranceID với giá trị NULL
ALTER TABLE OrderKoiFishes
ADD InsuranceID INT NULL;

-- Bước 2: Cập nhật các bản ghi hiện có với giá trị thích hợp
UPDATE OrderKoiFishes
SET InsuranceID = (SELECT TOP 1 InsuranceID FROM InsurancePolicies) -- Chọn giá trị từ bảng InsurancePolicies

-- Bước 3: Thay đổi cột InsuranceID thành NOT NULL
ALTER TABLE OrderKoiFishes
ALTER COLUMN InsuranceID INT NOT NULL;

-- Bước 4: Thêm khóa ngoại cho InsuranceID
ALTER TABLE OrderKoiFishes
ADD CONSTRAINT FK_OrderKoiFishes_InsuranceID FOREIGN KEY (InsuranceID) REFERENCES InsurancePolicies(InsuranceID);
