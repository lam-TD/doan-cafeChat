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
	tu_id INT IDENTITY(1,1) primary key,
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
	hd_phuthu INT,
	hd_giamgia INT,
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
insert into HoaDon(hd_id, hd_ngaylap, hd_tongtien, hd_trangthai, ban_id, nv_id, hd_phuthu, hd_giamgia) values ('13', '1-1-2018', '20000', '0', 1, '1',1234,12345);
insert into HoaDon(hd_id, hd_ngaylap, hd_tongtien, hd_trangthai, ban_id, nv_id, hd_phuthu, hd_giamgia) values ('13', '1-1-2018', '20000', '0', 1, '1',34567,76543);
--Them Chi Tiet Hoa Don
insert into CTHD( cthd_soluong, hd_id, tu_id) values ('1', '1', '1');
insert into CTHD( cthd_soluong, hd_id, tu_id) values ('1', '2', '1');

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

-- Lấy ra quyền truy cập của tài khoản
CREATE PROC TaiKhoan_LayQuyenTruyCap
@tk_ma VARCHAR(10)
AS
BEGIN
	 SELECT
	 	tk.tk_quyen
	 FROM
	 	*
	 WHERE tk.nv_id = @tk_ma
END
EXEC TaiKhoan_LayQuyenTruyCap 'NV0001'


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

-- Load Nhan Vien chua co Tai Khoan
CREATE PROC NhanVien_LoadNVChuaCoTaiKhoan
AS
BEGIN
	SELECT
		nv.nv_id,
		nv.nv_ten,
		nv.nv_diachi,
		nv.nv_sdt,
		nv.nv_taikhoan,
		nv.nv_trangthai
	FROM
		NhanVien AS nv
	WHERE nv.nv_trangthai = N'Đang làm việc' AND nv.nv_taikhoan = 0
END
EXEC NhanVien_LoadNVChuaCoTaiKhoan

-- Cập nhật lại Nhân Viên có tài khoản
CREATE PROC NhanVien_CapNhatNhanVienCoTaiKhoan
@nv_id VARCHAR(10),
@nv_taikhoan INT
AS
BEGIN
	UPDATE NhanVien
	SET
		nv_taikhoan = @nv_taikhoan
	WHERE nv_id = @nv_id
END
EXEC NhanVien_CapNhatNhanVienCoTaiKhoan 'NV0001',1

-- Load Nhan Vien theo mã NV
CREATE PROC NhanVien_LoadNhanVienTheoMa
@manv VARCHAR(10)
AS
BEGIN
	SELECT
		nv.nv_id,
		nv.nv_ten,
		nv.nv_diachi,
		nv.nv_sdt,
		nv.nv_taikhoan,
		nv.nv_trangthai
	FROM
		NhanVien AS nv
	WHERE nv.nv_id = @manv
END
EXEC NhanVien_LoadNhanVienTheoMa 'NV0001'

-- ========== THUC UONG ==========
-- Load Thuc Uong
CREATE PROC ThucUong_Load
AS
BEGIN
	SELECT
		*
	FROM
		ThucUong AS tu INNER JOIN DanhMuc AS dm ON dm.dm_id = tu.dm_id
	WHERE tu.tu_trangthai = 1
END
EXEC ThucUong_Load

-- Load Thuc Uong theo ID danh muc
CREATE PROC ThucUong_Load_IDDanhMuc
@dm_id INT
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
	WHERE tu.tu_trangthai = 1 AND tu.dm_id = @dm_id
END
EXEC ThucUong_Load_IDDanhMuc 1

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

-- Tìm kiếm Thức Uống
CREATE PROC ThucUong_TimKiem
@tukhoa NVARCHAR(20)
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
	WHERE tu.tu_trangthai = 1 AND tu.tu_ten LIKE @tukhoa OR tu.tu_gia LIKE @tukhoa
END
EXEC ThucUong_TimKiem N'%ca cao%'
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
EXEC DanhMuc_Them N'Đồ chơi',1,N'FFDFFFDFDFDFDFDFDFD'

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
EXEC Ban_Load_TrangThai N'Trống'

-- Load tat ca Ban trừ bàn bị xóa -- ban_xoa = 1(đã xóa) -- 
CREATE PROC Ban_Load
AS
BEGIN
	SELECT
		Ban.ban_id,Ban.ban_ten,Ban.ban_trangthai,kv.kv_ten,kv.kv_id
	FROM
		Ban INNER JOIN KhuVuc AS kv ON kv.kv_id = Ban.kv_id
	WHERE ban_xoa = 0 AND ban_trangthai <> N'Xóa'
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

-- Cap nhat trang thai ban
CREATE PROC Ban_CapNhatTrangThaiBan
@ban_id VARCHAR(10),
@trangthai NVARCHAR(20)
AS
BEGIN
	UPDATE Ban
	SET
		ban_trangthai = @trangthai
	WHERE ban_id = @ban_id
END
EXEC Ban_CapNhatTrangThaiBan B01,N'Trống'

-- Load Ban loai tru 1 ban trùng
CREATE PROC Ban_Load_LoaiTru1BanTrung_TrangThaiCoKhach
@maban VARCHAR(10)
AS
BEGIN
	SELECT
	*
	FROM
		Ban AS b
	WHERE b.ban_id <> @maban AND b.ban_trangthai <> N'Xóa' AND b.ban_trangthai = N'Có khách'
END
EXEC Ban_Load_LoaiTru1BanTrung_TrangThaiCoKhach 'B08'


CREATE PROC Ban_Load_BanTrangThaiCoKhach
AS
BEGIN
	SELECT
	*
	FROM
		Ban AS b
	WHERE b.ban_trangthai <> N'Xóa' AND b.ban_trangthai = N'Có khách'
END
EXEC Ban_Load_BanTrangThaiCoKhach

-- Thêm Bàn
CREATE PROC Ban_Them
@ban_id VARCHAR(10),
@ban_ten NVARCHAR(100),
@ban_trangthai NVARCHAR(100),
@kv_id NVARCHAR(200),
@ban_xoa INT
AS
BEGIN
	INSERT INTO Ban
	(
		ban_id,
		ban_ten,
		ban_trangthai,
		kv_id,
		ban_xoa
	)
	VALUES
	(
		@ban_id,
		@ban_ten,
		@ban_trangthai,
		@kv_id,
		@ban_xoa
	)
END
EXEC Ban_Them 'B11',N'Bàn 16',N'Trống',3,0
--Sửa Bàn
CREATE PROC Ban_Sua
@ban_id VARCHAR(10),
@ban_ten NVARCHAR(100),
@ban_trangthai NVARCHAR(100),
@kv_id NVARCHAR(200)
AS
BEGIN
	UPDATE Ban
	SET
		ban_ten		 = @ban_ten,
		ban_trangthai = @ban_trangthai,
		kv_id	 = @kv_id
	WHERE ban_id = @ban_id
END
EXEC Ban_Sua 3,N'Bàn 3',N'Đang sử dụng', 2,0

-- Xóa Bàn
CREATE PROC Ban_Xoa
@ban_id VARCHAR(10)
AS
BEGIN
	UPDATE Ban
	SET
		ban_trangthai = N'Xóa',
		ban_xoa = 1
	WHERE ban_id = @ban_id
END

-- Kiểm tra tên bàn có bị trùng hay không
CREATE PROC Ban_KiemTraTenBanTrung
@ban_ten NVARCHAR(20)
AS
BEGIN
	SELECT
		b.ban_id,
		b.ban_ten,
		b.ban_trangthai,
		b.kv_id
	FROM
		Ban AS b
	WHERE b.ban_ten = @ban_ten AND b.ban_xoa = 0 AND b.ban_trangthai <> N'Xóa'
END
EXEC Ban_KiemTraTenBanTrung N'Bàn 1'
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

-- Load Khu Vực theo trạng thái
CREATE PROC KhuVuc_LoadTheoTrangThai
@trangthai NVARCHAR(20)
AS
BEGIN
	SELECT
		kv.kv_id,
		kv.kv_ten,
		kv.kv_trangthai,
		kv.kv_ghichu
	FROM
		KhuVuc AS kv
	WHERE kv.kv_trangthai = @trangthai
END
EXEC KhuVuc_LoadTheoTrangThai N'Đang sử dụng'

-- Thêm Khu Vực
CREATE PROC KhuVuc_Them
@kv_ten NVARCHAR(100),
@kv_trangthai NVARCHAR(100),
@kv_ghichu NVARCHAR(200)
AS
BEGIN
	INSERT INTO KhuVuc
	(
		kv_ten,
		kv_trangthai,
		kv_ghichu
	)
	VALUES
	(
		@kv_ten,
		@kv_trangthai,
		@kv_ghichu
	)
END
EXEC KhuVuc_Them N'Tầng 3',N'Đang sử dụng', 'hfusahu'

--Sua khu vuc 
CREATE PROC KhuVuc_Sua
@kv_id INT,
@kv_ten NVARCHAR(100),
@kv_trangthai NVARCHAR(100),
@kv_ghichu NVARCHAR(200)
AS
BEGIN
	UPDATE KhuVuc
	SET
		kv_ten		 = @kv_ten,
		kv_trangthai = @kv_trangthai,
		kv_ghichu	 = @kv_ghichu
	WHERE kv_id = @kv_id
END
EXEC KhuVuc_Sua 3,N'Tầng 3',N'Đang sử dụng', 'hfusafhu'
-- Xoa khu vuc
CREATE PROC KhuVuc_Xoa
@kv_id INT
AS
BEGIN
	UPDATE KhuVuc
	SET
		kv_trangthai = N'Ngưng sử dụng'
	WHERE kv_id = @kv_id
END







-- =========== HOA DON ==========
-- Hóa Đơn
CREATE PROC HoaDon_Load
AS
BEGIN
	SELECT
		hd.hd_id,
		hd.hd_ngaylap,
		hd.hd_trangthai,
		hd.hd_phuthu,
		hd.hd_giamgia,
		hd.hd_tongtien,
		hd.ban_id,
		hd.nv_id
	FROM
		HoaDon AS hd
	ORDER BY hd.hd_ngaylap DESC 
END
EXEC HoaDon_Load

-- Thống kê Hóa Đơn theo ngày lập
CREATE PROC HoaDon_ThongKeTheoNgayLap
@tungay DATE,
@denngay DATE
AS
BEGIN
	SELECT
	hd.hd_id,
	hd.hd_ngaylap,
	hd.hd_phuthu,
	hd.hd_giamgia,
	hd.hd_tongtien,
	hd.hd_trangthai,
	hd.ban_id,
	hd.nv_id
	FROM
		HoaDon AS hd
	WHERE hd.hd_ngaylap >= '01-26-2018' AND hd.hd_ngaylap <= '01-26-2018'
	ORDER BY hd.hd_ngaylap DESC
END
EXEC HoaDon_ThongKeTheoNgayLap '01-18-2018','01-26-2018'

-- Thống kê Hóa Đơn theo nhân viên
CREATE PROC HoaDon_ThongKeTheoNhanVien
@manv VARCHAR(10)
AS
BEGIN
	SELECT
		hd.hd_id,
		hd.hd_ngaylap,
		hd.hd_trangthai,
		hd.hd_phuthu,
		hd.hd_giamgia,
		hd.hd_tongtien,
		hd.ban_id,
		hd.nv_id
	FROM
		HoaDon AS hd
	WHERE hd.nv_id = @manv
	ORDER BY hd.hd_ngaylap DESC
END
EXEC HoaDon_ThongKeTheoNhanVien 'NV0001'

-- Thống kê Hóa Đơn theo nhân viên và ngay lập
CREATE PROC HoaDon_ThongKeTheoNhanVienTheoNgayLap
@manv VARCHAR(10),
@tungay DATE,
@denngay DATE
AS
BEGIN
	SELECT
		hd.hd_id,
		hd.hd_ngaylap,
		hd.hd_trangthai,
		hd.hd_phuthu,
		hd.hd_giamgia,
		hd.hd_tongtien,
		hd.ban_id,
		hd.nv_id
	FROM
		HoaDon AS hd
	WHERE hd.nv_id = @manv AND hd.hd_ngaylap >= @tungay AND hd.hd_ngaylap <= @denngay
	ORDER BY hd.hd_ngaylap DESC
END
EXEC HoaDon_ThongKeTheoNhanVienTheoNgayLap 'NV0001','1-26-2018','1-26-2018'

-- Load Hoa Don theo ma Ban và trang thai Hoa Don = 0
CREATE PROC HoaDon_Load_IDBan_TrangThaiHD
@ban_id VARCHAR(10)
AS
BEGIN
	SELECT
		hd.hd_id,
		hd.hd_ngaylap,
		hd.hd_trangthai,
		hd.hd_phuthu,
		hd.hd_giamgia,
		hd.hd_tongtien,
		hd.ban_id,
		hd.nv_id
	FROM
		HoaDon AS hd
	WHERE hd.ban_id = @ban_id AND hd.hd_trangthai = 0
END
EXEC HoaDon_Load_IDBan_TrangThaiHD 'B01'

-- Them Hoa Don
CREATE PROC HoaDon_Them
		@hd_id VARCHAR(10),
		@hd_ngaylap DATETIME,
		@hd_trangthai INT,
		@hd_phuthu INT,
		@hd_giamgia INT,
		@hd_tongtien FLOAT,
		@ban_id VARCHAR(10),
		@nv_id VARCHAR(10)
AS
BEGIN
	INSERT INTO HoaDon
	(
		hd_id,
		hd_ngaylap,
		hd_trangthai,
		hd_phuthu,
		hd_giamgia,
		hd_tongtien,
		ban_id,
		nv_id
	)
	VALUES
	(
		@hd_id,
		@hd_ngaylap,
		@hd_trangthai,
		@hd_phuthu,
		@hd_giamgia,
		@hd_tongtien,
		@ban_id,
		@nv_id
	)
END
EXEC HoaDon_Them 'HD00005','1-1-2018',1,10000,5000,200000,'B06','NV0001'

-- Cap Nhat Hoa Don
CREATE PROC HoaDon_Sua
		@hd_id VARCHAR(10),
		@hd_ngaylap DATETIME,
		@hd_trangthai INT,
		@hd_phuthu INT,
		@hd_giamgia INT,
		@hd_tongtien FLOAT,
		@ban_id VARCHAR(10),
		@nv_id VARCHAR(10)
AS
BEGIN
	UPDATE HoaDon
	SET
		hd_ngaylap = @hd_ngaylap,
		hd_trangthai = @hd_trangthai,
		hd_phuthu = @hd_phuthu,
		hd_giamgia = @hd_giamgia,
		hd_tongtien = @hd_tongtien,
		ban_id = @ban_id,
		nv_id = @nv_id
	WHERE hd_id = @hd_id
END
EXEC HoaDon_Sua 'HD00003','10-10-2018',0,10000,0,500000,'B09','NV0001'

-- Xoa Hoa Don
CREATE PROC HoaDon_Xoa
@hd_ma VARCHAR(10)
AS
BEGIN
	UPDATE HoaDon
	SET
		hd_trangthai = 1
	WHERE hd_id = @hd_ma
END
EXEC HoaDon_Xoa 'HD00003'

-- Huy Hoa Don khi hủy Bàn
CREATE PROC HoaDon_HuyBan
@hd_id VARCHAR(10)
AS
BEGIN
	DELETE FROM HoaDon WHERE hd_id = @hd_id
END
EXEC HoaDon_HuyBan 'HD00003'

-- Lấy Hóa Đơn theo Mã Bàn
CREATE PROC HoaDon_LayHoaDonTheoMaBan
@maban VARCHAR(10)
AS
BEGIN
	SELECT
		hd.hd_id,
		hd.hd_ngaylap,
		hd.hd_trangthai,
		hd.hd_phuthu,
		hd.hd_giamgia,
		hd.hd_tongtien,
		hd.ban_id,
		hd.nv_id
	FROM
		HoaDon AS hd
	WHERE hd.ban_id = @maban AND hd.hd_trangthai = 0
END
EXEC HoaDon_LayHoaDonTheoMaBan 'B08'

-- Đổi bàn cập nhật lại Bàn của Hóa Đơn
CREATE PROC HoaDon_DoiBan
@mabanChon VARCHAR(10),
@mabanDoi VARCHAR(10)
AS
BEGIN
	DECLARE @mahd VARCHAR(10)
	SELECT
		@mahd = hd.hd_id
	FROM
		HoaDon AS hd
	WHERE hd.ban_id = @mabanChon
	UPDATE HoaDon
	SET
		ban_id = @mabanDoi
	WHERE hd_id = @mahd
END
EXEC HoaDon_DoiBan 'B01','B04'

-- In Hóa Đơn
CREATE PROC HoaDon_In
@mahd VARCHAR(10)
AS
BEGIN
	SELECT * FROM HoaDon_InThongKe WHERE hd_id = @mahd
END
EXEC HoaDon_In 'HD00001'

-- In báo cáo Hóa Đơn
CREATE PROC HoaDon_InBaoCaoTheoTuyChon
@tungay DATETIME,
@denngay DATETIME
AS
BEGIN
	SELECT * FROM HoaDon_InBaoCao WHERE hd_ngaylap >= @tungay AND hd_ngaylap <= @denngay
END

EXEC HoaDon_InBaoCaoTheoTuyChon '1-26-2018','1-28-2018'

-- ========== CHI TIET HOA DON ==========
-- Load CTHD theo ma Hoa Don
CREATE PROC CTHD_Load_IDHoaDon
@hd_ma VARCHAR(10)
AS
BEGIN
	SELECT
		c.cthd_soluong,
		c.hd_id,
		c.tu_id
	FROM
		CTHD AS c
	WHERE c.hd_id = @hd_ma
END
EXEC CTHD_Load_IDHoaDon 'HD00001'

-- Them CTHD
CREATE PROC CTHD_Them
		@cthd_soluong INT,
		@hd_id VARCHAR(10),
		@tu_id INT
AS
BEGIN
	INSERT INTO CTHD
	(
		cthd_soluong,
		hd_id,
		tu_id
	)
	VALUES
	(
		@cthd_soluong,
		@hd_id,
		@tu_id
	)
END
EXEC CTHD_Them 3,'HD00001',6

-- Cap nhat CTHD
CREATE PROC CTHD_Sua
		@cthd_soluong INT,
		@cthd_thanhtien FLOAT,
		@hd_id VARCHAR(10),
		@tu_id INT
AS
BEGIN
	UPDATE CTHD
	SET
		cthd_soluong = @cthd_soluong,
		cthd_thanhtien = @cthd_thanhtien
	WHERE hd_id = @hd_id AND tu_id = @tu_id
END
EXEC CTHD_Sua 12,50000,'HD00003',1

-- Xoa CTHD
CREATE PROC CTHD_Xoa
@hd_id VARCHAR(10),
@tu_id INT
AS
BEGIN
	DELETE FROM CTHD WHERE hd_id = @hd_id AND tu_id = @tu_id
END
EXEC CTHD_Xoa 'HD00003',1

-- Xoa CTHD theo ID Hoa Don -- su dung cho viec Huy Ban
CREATE PROC CTHD_HuyBan
@hd_id VARCHAR(10)
AS
BEGIN
	DELETE FROM CTHD WHERE hd_id = @hd_id
END
EXEC CTHD_HuyBan 'HD00003'

-- Load CTHD kèm theo đơn giá và tính thành tiền
CREATE PROC CTHD_Load_DonGia_TinhThanhTien
@hd_id VARCHAR(10)
AS
BEGIN
	SELECT c.tu_id,tu.tu_ten, c.cthd_soluong,tu.tu_gia, c.cthd_soluong * tu.tu_gia AS ThanhTien 
	FROM CTHD AS c 
	INNER JOIN ThucUong AS tu ON c.tu_id = tu.tu_id 
	WHERE c.hd_id = @hd_id
	GROUP BY c.tu_id,tu.tu_ten,c.cthd_soluong,tu.tu_gia
END

EXEC CTHD_Load_DonGia_TinhThanhTien 'HD00003'

-- Kiem Tra Thuc Uong có tồn tại trong CTHD hay chưa
CREATE PROC CTHD_KiemTraThucUongCoTrongCTHD
@tu_id INT,
@hd_id VARCHAR(10)
AS
BEGIN
	SELECT
		c.cthd_soluong,
		c.hd_id,
		c.tu_id
	FROM
		CTHD AS c
	WHERE c.hd_id = @hd_id AND c.tu_id = @tu_id
END
EXEC CTHD_KiemTraThucUongCoTrongCTHD 1,'HD00003'


--============ TẠO VIEW ==========
CREATE VIEW HoaDon_InThongKe
AS 
SELECT hd.hd_id,nv.nv_ten,hd2.hd_ngaylap,hd.hd_phuthu,hd.hd_giamgia,tu.tu_ten,tu.tu_gia,c.cthd_soluong
  FROM HoaDon AS hd INNER JOIN CTHD AS c ON c.hd_id = hd.hd_id INNER JOIN HoaDon AS hd2
  ON hd2.hd_id = c.hd_id INNER JOIN NhanVien AS nv
  ON nv.nv_id = hd2.nv_id INNER JOIN ThucUong AS tu ON tu.tu_id = c.tu_id

SELECT * FROM HoaDon_InThongKe

-- In báo cáo
CREATE VIEW HoaDon_InBaoCao
AS
SELECT
	hd.hd_id,
	hd.hd_ngaylap,
	hd.hd_phuthu,
	hd.hd_giamgia,
	hd.hd_tongtien,
	hd.hd_trangthai,
	hd.ban_id,
	nv.nv_ten
FROM
	HoaDon AS hd INNER JOIN NhanVien AS nv
	                       ON nv.nv_id = hd.nv_id


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

CREATE PROC [dbo].[TimIDKeTiep] -- b tim id ke tiep cua table Ban
@table VARCHAR(100)				-- hd tim id ke tiep cua table HoaDon
AS								-- nv tim id ke tiep cua table NhanVien
BEGIN
	DECLARE @Idx INT
	SET @Idx = 1
	IF	@table = 'b'
		BEGIN
			DECLARE @id VARCHAR(10) = 'B01'
			WHILE EXISTS (SELECT ban_id FROM Ban WHERE ban_id = @id)
			BEGIN
				SET @Idx = @Idx + 1
				SET @id = 'B' + REPLICATE('0', 2 - LEN(CAST(@Idx AS VARCHAR ))) + CAST(@Idx AS VARCHAR)
			END
			UPDATE ThamSo SET ban_id = @id WHERE id = 1
		END
	ELSE IF @table = 'hd'
		BEGIN
			DECLARE @id2 VARCHAR(10) = 'HD00001'
			WHILE EXISTS (SELECT hd_id FROM HoaDon WHERE hd_id = @id2)
			BEGIN
				SET @Idx = @Idx + 1
				SET @id2 = 'HD' + REPLICATE('0', 5 - LEN(CAST(@Idx AS VARCHAR ))) + CAST(@Idx AS VARCHAR)
			END
			UPDATE ThamSo SET hd_id = @id2 WHERE id = 1
		END
	ELSE IF @table = 'nv'
		BEGIN
			DECLARE @id3 VARCHAR(10) = 'NV0001'
			WHILE EXISTS (SELECT nv_id FROM NhanVien WHERE nv_id = @id3)
			BEGIN
				SET @Idx = @Idx + 1
				SET @id2 = 'NV' + REPLICATE('0', 4 - LEN(CAST(@Idx AS VARCHAR ))) + CAST(@Idx AS VARCHAR)
			END
			UPDATE ThamSo SET nv_id = @id3 WHERE id = 1
		END  
END

EXEC TimIDKeTiep 'b'

CREATE PROC LayIDKeTiep
AS
BEGIN
	SELECT
		ts.ban_id,
		ts.hd_id,
		ts.nv_id,
		ts.id
	FROM
		ThamSo AS ts WHERE id = 1
END

EXEC LayIDKeTiep