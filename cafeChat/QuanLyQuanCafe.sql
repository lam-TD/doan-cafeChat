create database CafeDataBase
go

use CafeDataBase
go


create table NhanVien
(
	nv_id varchar(10) primary key,
	nv_ten nvarchar(100) not null default N'Chưa nhập tên',
	nv_diachi nvarchar(200),
	nv_sdt varchar(11),
	nv_taikhoan INT DEFAULT 0,
	nv_trangthai NVARCHAR(20) default '0'
)
go

create table TaiKhoan
(
	nv_id varchar(10) not null,
	tk_matkhau varchar(20) not null,
	tk_quyen int not null default 0,
	tk_trangthai INT DEFAULT 1,
	foreign key (nv_id) references NhanVien(nv_id)
)

create table CaTruc
(
	ct_id int primary key,
	ct_ngaytruc datetime not null,
	ct_buoitruc nvarchar(100) not null,
	nv_id varchar(10) not null,
	foreign key (nv_id) references NhanVien(nv_id)
)
go


create table DanhMuc
(
	dm_id INT IDENTITY(1,1) primary KEY,
	dm_ten nvarchar(100) not null default N'Chưa đặt tên',
	dm_trangthai int default 0,
	dm_ghichu NVARCHAR(200)
)
go

create table ThucUong
(
	tu_id int primary key,
	tu_ten nvarchar(100) not null default N'Chưa đặt tên',
	tu_gia int not null default 0,
	tu_trangthai int default 1,
	dm_id int not null

	foreign key (dm_id) references DanhMuc(dm_id)
)
go

create table KhuVuc
(
	kv_id VARCHAR(10) primary key,
	kv_ten nvarchar(100) not null,
	kv_trangthai nvarchar(100) default N'Đang sử dụng',
	kv_ghichu NVARCHAR(200)
)
GO

create table Ban
(
	ban_id VARCHAR(10) primary key,
	ban_ten nvarchar(100) not null default N'Bàn trống',
	ban_trangthai nvarchar(100) not null default N'Trống',
	kv_id int not null

	foreign key (kv_id) references KhuVuc(kv_id)
)
GO

create table HoaDon
(
	hd_id VARCHAR(10) primary key,
	hd_ngaylap datetime not null default getdate(),
	hd_trangthai int not null default 0,
	hd_tongtien int not null,
	ban_id int not null,
	nv_id varchar(10) not null

	foreign key (ban_id) references Ban(ban_id),
	foreign key (nv_id) references NhanVien(nv_id)
)
go

create table CTHD
(
	cthd_soluong int not null default 0,
	cthd_thanhtien int not null, 
	hd_id VARCHAR(10) not null,
	tu_id int not null

	primary key(hd_id, tu_id),

	foreign key (hd_id) references HoaDon(hd_id),
	foreign key (tu_id) references ThucUong(tu_id)
)
go


-- Them nhanvien
insert into NhanVien(nv_id, nv_ten, nv_diachi, nv_sdt, nv_trangthai) values ( '1',N'Nguyễn Văn A', 'Hau Giang', '42424242', '0');
insert into NhanVien(nv_id, nv_ten, nv_diachi, nv_sdt, nv_trangthai) values ( '2', N'Nguyễn Văn b', 'hihi', '123456', '0');

-- Them Tai Khoan
insert into TaiKhoan values('1','12345',1,1);
insert into TaiKhoan values('2','12345',0,1);

-- Them Ca Truc
insert into CaTruc(ct_id, ct_ngaytruc, ct_buoitruc, nv_id) values ('1', '1-1-2018', N'Sáng', '2');
insert into CaTruc(ct_id, ct_ngaytruc, ct_buoitruc, nv_id) values ('2', '1-1-2018', N'Tối', '1');

-- Them Danh Muc
insert into DanhMuc(dm_ten, dm_trangthai,dm_ghichu) values ( N'Giải Khát',1,'dâdad');
insert into DanhMuc(dm_ten, dm_trangthai, dm_ghichu) values (N'Sinh tố',1,'zddad');

--Them Thuc Uong
insert into ThucUong(tu_id, tu_ten, tu_gia, dm_id, tu_trangthai) values ('1',N'Pepsi','20000', '1',1);
insert into ThucUong(tu_id, tu_ten, tu_gia, dm_id, tu_trangthai) values ('2',N'CoCa','20000', '1',1);

-- Them Khu Vuc
insert into KhuVuc(kv_id, kv_ten, kv_trangthai) values (1, N'Tầng 1', N'Đang sử dụng');
insert into KhuVuc(kv_id, kv_ten, kv_trangthai) values (2, N'Tầng 1', N'Đang sử dụng');

-- Them Ban
insert into Ban(ban_id, ban_ten, ban_trangthai, kv_id) values ('1', 'Bàn 1', '1', '1');
insert into Ban(ban_id, ban_ten, ban_trangthai, kv_id) values ('2', 'Bàn 2', '1', '1');
-- Them Hoa Don
insert into HoaDon(hd_id, hd_ngaylap, hd_tongtien, hd_trangthai, ban_id, nv_id) values ('1', '1-1-2018', '20000', '0', 1, '1');
insert into HoaDon(hd_id, hd_ngaylap, hd_tongtien, hd_trangthai, ban_id, nv_id) values ('2', '1-2-2018', '200000', '0', 2, '1');

--Them Chi Tiet Hoa Don
insert into CTHD( cthd_soluong, cthd_thanhtien, hd_id, tu_id) values ('1', '20000', '1', '1');
insert into CTHD( cthd_soluong, cthd_thanhtien, hd_id, tu_id) values ('1', '200000', '2', '1');

-- Tao proc

-- ================TAI KHOAN================= --
-- Load TaiKhoan
CREATE PROC TaiKhoan_Load
AS
BEGIN
	SELECT * FROM TaiKhoan AS tk WHERE tk.tk_trangthai = 1
END
EXEC TaiKhoan_Load

-- Load Tai Khoan theo nv_id
CREATE PROC TaiKhoan_Load_nv_id
@nv_id VARCHAR(10),
@tk_matkhau VARCHAR(20)
AS
BEGIN
	SELECT * FROM TaiKhoan AS tk WHERE tk.nv_id = @nv_id AND tk.tk_matkhau = @tk_matkhau AND tk.tk_trangthai = 1
END
EXEC TaiKhoan_Load_nv_id '2', '12345'

-- Them Tai Khoan
CREATE PROC TaiKhoan_Them
@nv_id VARCHAR(10),
@tk_matkhau VARCHAR(20),
@tk_quyen INT,
@tk_trangthai INT
AS
BEGIN
	INSERT INTO TaiKhoan
	(
		nv_id,
		tk_matkhau,
		tk_quyen,
		tk_trangthai
	)
	VALUES
	(
		@nv_id,
		@tk_matkhau,
		@tk_quyen,
		@tk_trangthai
	)
END
EXEC TaiKhoan_Them '1','12345',1,1

-- Sua Thai Khoan
CREATE PROC TaiKhoan_Sua
@nv_id VARCHAR(10),
@tk_matkhau VARCHAR(20),
@tk_quyen INT,
@tk_trangthai int
AS
BEGIN
	UPDATE TaiKhoan
	SET
		tk_matkhau = @tk_matkhau,
		tk_quyen = @tk_quyen,
		tk_trangthai = @tk_trangthai
	WHERE
		nv_id = @nv_id
END

EXEC TaiKhoan_Sua '1','12345789',1,1

-- Xoa Tai Khoan
CREATE PROC TaiKhoan_Xoa
@nv_id VARCHAR(10)
AS
BEGIN
	UPDATE TaiKhoan
	SET
		tk_trangthai = 0
	WHERE nv_id = @nv_id
END

EXEC TaiKhoan_Xoa '1'

-- ============ NHAN VIEN =============
-- Load NhanVien
CREATE PROC NhanVien_Load
AS
BEGIN
	SELECT * FROM NhanVien AS nv WHERE nv.nv_trangthai = N'Đang làm việc'
END
EXEC NhanVien_Load

-- Them Nhan Vien
CREATE PROC NhanVien_Them
@nv_id VARCHAR(10),
@nv_ten NVARCHAR(100),
@nv_diachi NVARCHAR(200),
@nv_sdt VARCHAR(11),
@nv_taikhoan INT,
@nv_trangthai NVARCHAR(20) 
AS 
BEGIN
	INSERT INTO NhanVien
	(
		nv_id,
		nv_ten,
		nv_diachi,
		nv_sdt,
		nv_taikhoan,
		nv_trangthai
	)
	VALUES
	(
		@nv_id,
		@nv_ten,
		@nv_diachi,
		@nv_sdt,
		@nv_taikhoan,
		@nv_trangthai
	)
END

EXEC NhanVien_Them 'nv001', N'Trần Văn Trụi',N'Hậu Giang','534535', 0,N'Đang làm việc'

-- Cap Nhat Nhan Vien
CREATE PROC NhanVien_Sua
@nv_id VARCHAR(10),
@nv_ten NVARCHAR(100),
@nv_diachi NVARCHAR(200),
@nv_sdt VARCHAR(11),
@nv_taikhoan INT,
@nv_trangthai NVARCHAR(20) 
AS 
BEGIN
	UPDATE NhanVien
	SET
		nv_ten = @nv_ten,
		nv_diachi = @nv_diachi,
		nv_sdt = @nv_sdt,
		nv_taikhoan = @nv_taikhoan,
		nv_trangthai = @nv_trangthai
	WHERE
		nv_id = @nv_id
END
EXEC NhanVien_Sua 'nv001',N'Trần Văn Chịch',N'Cần Thơ','535535',0,N'Đang làm việc'

-- Xoa Nhan Vien
CREATE PROC NhanVien_Xoa
@nv_id VARCHAR(10)
AS
BEGIN
	UPDATE NhanVien
	SET
		nv_trangthai = N'Nghỉ'
	WHERE nv_id = @nv_id
END
EXEC NhanVien_Xoa 'nv001'

-- ========== THUC UONG ==========
-- Load Thuc Uong
CREATE PROC ThucUong_Load
AS
BEGIN
	SELECT
		tu.tu_id,
		tu.tu_ten,
		tu.tu_gia,
		tu.tu_trangthai,
		tu.dm_id
	FROM
		ThucUong AS tu
	WHERE tu.tu_trangthai = 1
END
EXEC ThucUong_Load

-- Them Thuc Uong
CREATE PROC ThucUong_Them
@tu_id INT,
@tu_ten NVARCHAR(100),
@tu_gia INT,
@tu_trangthai INT,
@dm_id INT
AS
BEGIN
	INSERT INTO ThucUong
	(
		tu_id,
		tu_ten,
		tu_gia,
		tu_trangthai,
		dm_id
	)
	VALUES
	(
		@tu_id,
		@tu_ten,
		@tu_gia,
		@tu_trangthai,
		@dm_id
	)
END
EXEC ThucUong_Them 3,N'Trà đường',12000,1,1

-- Cap nhat Thuc Uong
CREATE PROC ThucUong_Sua
@tu_id INT,
@tu_ten NVARCHAR(100),
@tu_gia INT,
@tu_trangthai INT,
@dm_id INT
AS
BEGIN
	UPDATE ThucUong
	SET
		tu_ten = @tu_ten,
		tu_gia = @tu_gia,
		tu_trangthai = @tu_trangthai,
		dm_id = @dm_id
	WHERE tu_id = @tu_id
END
EXEC ThucUong_Sua 3,N'Trà đường',12000,1,1

-- Xoa Thuc Uong
CREATE PROC ThucUong_Xoa
@tu_id INT
AS
BEGIN
	UPDATE ThucUong
	SET
		tu_trangthai = 0
	WHERE tu_id = @tu_id
END

-- ========== DANH MUC ==========
-- Load Danh Muc
CREATE PROC DanhMuc_Load
AS
BEGIN
	SELECT
		dm.dm_id,
		dm.dm_ten,
		dm.dm_trangthai,
		dm.dm_ghichu
	FROM
		DanhMuc AS dm
	WHERE dm.dm_trangthai = 1
END
EXEC DanhMuc_Load

-- Them Danh Muc
CREATE PROC DanhMuc_Them
@dm_ten NVARCHAR(100),
@dm_trangthai INT,
@dm_ghichu NVARCHAR(200)
AS
BEGIN
	INSERT INTO DanhMuc
	(
		dm_ten,
		dm_trangthai,
		dm_ghichu
	)
	VALUES
	(
		@dm_ten,
		@dm_trangthai,
		@dm_ghichu
	)
END
EXEC DanhMuc_Them N'Sinh Tố',1

-- Cap Nhat Danh Muc
CREATE PROC DanhMuc_Sua
@dm_id INT,
@dm_ten NVARCHAR(100),
@dm_trangthai INT,
@dm_ghichu NVARCHAR(200)
AS
BEGIN
	UPDATE DanhMuc
	SET
		dm_ten		 = @dm_ten,
		dm_trangthai = @dm_trangthai,
		dm_ghichu	 = @dm_ghichu
	WHERE dm_id = @dm_id
END
EXEC DanhMuc_Sua 1,N'Sinh Tố',1

-- Xoa Danh Muc
CREATE PROC DanhMuc_Xoa
@dm_id INT
AS
BEGIN
	UPDATE DanhMuc
	SET
		dm_trangthai = 0
	WHERE dm_id = @dm_id
END

EXEC DanhMuc_Xoa 1

-- ========== BAN ==========
-- Load Ban theo trang thai
CREATE PROC Ban_Load_TrangThai
@trangthai NVARCHAR(20)
AS
BEGIN
	SELECT
		ban_id,
		ban_ten,
		ban_trangthai,
		kv_id
	FROM
		Ban
	WHERE ban_trangthai = @trangthai AND ban_xoa = 0
END
EXEC Ban_Load N'Trống'

-- Load tat ca Ban trừ bàn bị xóa -- ban_xoa = 1(đã xóa) -- 
CREATE PROC Ban_Load
AS
BEGIN
	SELECT
		ban_id,
		ban_ten,
		ban_trangthai,
		kv_id
	FROM
		Ban
	WHERE ban_xoa = 0
END
EXEC Ban_Load

-- Load Ban theo Khu Vuc
CREATE PROC Ban_Load_KhuVuc
@kv_id INT
AS
BEGIN
	SELECT
		b.ban_id,
		b.ban_ten,
		b.ban_trangthai,
		b.kv_id
	FROM
		Ban AS b
	WHERE b.kv_id = @kv_id AND ban_xoa = 0
END
EXEC Ban_Load_KhuVuc 1

-- ========== KHU VUC ==========
-- Load Khu Vuc
CREATE PROC KhucVuc_Load
AS
BEGIN
	SELECT
		kv.kv_id,
		kv.kv_ten,
		kv.kv_trangthai,
		kv.kv_ghichu
	FROM
		KhuVuc AS kv
	WHERE kv.kv_trangthai = N'Đang sử dụng'
END
EXEC KhucVuc_Load




--================= HAM XU LY DAC BIET
-- TIM MA BAN KE TIEP
CREATE PROC Ban_TimIDKeTiep
AS
BEGIN
	DECLARE @ban_id VARCHAR(10) = 'B00001'
	DECLARE @Idx INT
	SET @Idx = 1
	WHILE EXISTS (SELECT ban_id FROM Ban WHERE ban_id = @ban_id)
	BEGIN
		SET @Idx = @Idx + 1
		SET @ban_id = 'B' + REPLICATE('0', 5 - LEN(CAST(@Idx AS VARCHAR ))) + CAST(@Idx AS VARCHAR)
	END
	PRINT @ban_id
END
EXEC Ban_TimIDKeTiep