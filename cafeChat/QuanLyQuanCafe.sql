create database CafeChat
go

use CafeChat
go


create table NhanVien
(
	nv_id int primary key,
	nv_ten nvarchar(100) not null default N'Chưa nhập tên',
	nv_diachi nvarchar(200),
	nv_sdt varchar(11),
	nv_trangthai int default 0
)
go

create table TaiKhoan
(
	tk_taikhoan varchar(20) not null primary key,
	tk_matkhau varchar(20) not null,
	nv_id int not null,
	tk_quyen int not null default 0
	foreign key (nv_id) references NhanVien(nv_id)
)

create table CaTruc
(
	ct_id int primary key,
	ct_ngaytruc datetime not null,
	ct_buoitruc nvarchar(100) not null,
	nv_id int not null,
	foreign key (nv_id) references NhanVien(nv_id)
)
go


create table DanhMuc
(
	dm_id int primary key,
	dm_ten nvarchar(100) not null default N'Chưa đặt tên',
	dm_trangthai int default 0
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
	kv_id int primary key,
	kv_ten nvarchar(100) not null,
	kv_trangthai nvarchar(100) default N'Đang sử dụng'
)
GO

create table Ban
(
	ban_id int primary key,
	ban_ten nvarchar(100) not null default N'Bàn trống',
	ban_trangthai nvarchar(100) not null default N'Trống',
	kv_id int not null

	foreign key (kv_id) references KhuVuc(kv_id)
)
GO

create table HoaDon
(
	hd_id int primary key,
	hd_ngaylap datetime not null default getdate(),
	hd_trangthai int not null default 0,
	hd_tongtien int not null,
	ban_id int not null,
	nv_id int not null

	foreign key (ban_id) references Ban(ban_id),
	foreign key (nv_id) references NhanVien(nv_id)
)
go

create table CTHD
(
	cthd_soluong int not null default 0,
	cthd_thanhtien int not null, 
	hd_id int not null,
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
insert into TaiKhoan values('admin','12345',1,1);
insert into TaiKhoan values('nhanvien1','12345',1,0);

-- Them Ca Truc
insert into CaTruc(ct_id, ct_ngaytruc, ct_buoitruc, nv_id) values ('1', '1-1-2018', N'Sáng', '2');
insert into CaTruc(ct_id, ct_ngaytruc, ct_buoitruc, nv_id) values ('2', '1-1-2018', N'Tối', '1');

-- Them Danh Muc
insert into DanhMuc(dm_id, dm_ten, dm_trangthai) values ('1', N'Giải Khát',1);
insert into DanhMuc(dm_id, dm_ten, dm_trangthai) values ('2', N'Sinh tố',1);

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