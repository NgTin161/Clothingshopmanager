
namespace SANPHAM
{
    partial class sanpham
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grbThongTin1 = new System.Windows.Forms.GroupBox();
            this.grbChonGia = new System.Windows.Forms.GroupBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.txtMaLoai = new System.Windows.Forms.TextBox();
            this.txtGiaLe = new System.Windows.Forms.TextBox();
            this.txttenNCC = new System.Windows.Forms.TextBox();
            this.txttenSP = new System.Windows.Forms.TextBox();
            this.txtmaSP = new System.Windows.Forms.TextBox();
            this.lblGiaBanSi = new System.Windows.Forms.Label();
            this.lblGiaBanLe = new System.Windows.Forms.Label();
            this.lblMaLoai = new System.Windows.Forms.Label();
            this.lblNCC = new System.Windows.Forms.Label();
            this.lblTenSP = new System.Windows.Forms.Label();
            this.lblMaSanPham = new System.Windows.Forms.Label();
            this.grbThongTin2 = new System.Windows.Forms.GroupBox();
            this.cbotrangthai = new System.Windows.Forms.ComboBox();
            this.lbldvt = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.lblDonViTinh = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.grbThemAnh = new System.Windows.Forms.GroupBox();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.lblHinhAnh = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbltenbang = new System.Windows.Forms.Label();
            this.grbThongTin1.SuspendLayout();
            this.grbChonGia.SuspendLayout();
            this.grbThongTin2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // grbThongTin1
            // 
            this.grbThongTin1.Controls.Add(this.grbChonGia);
            this.grbThongTin1.Controls.Add(this.txtMaLoai);
            this.grbThongTin1.Controls.Add(this.txtGiaLe);
            this.grbThongTin1.Controls.Add(this.txttenNCC);
            this.grbThongTin1.Controls.Add(this.txttenSP);
            this.grbThongTin1.Controls.Add(this.txtmaSP);
            this.grbThongTin1.Controls.Add(this.lblGiaBanSi);
            this.grbThongTin1.Controls.Add(this.lblGiaBanLe);
            this.grbThongTin1.Controls.Add(this.lblMaLoai);
            this.grbThongTin1.Controls.Add(this.lblNCC);
            this.grbThongTin1.Controls.Add(this.lblTenSP);
            this.grbThongTin1.Controls.Add(this.lblMaSanPham);
            this.grbThongTin1.Location = new System.Drawing.Point(0, 109);
            this.grbThongTin1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbThongTin1.Name = "grbThongTin1";
            this.grbThongTin1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbThongTin1.Size = new System.Drawing.Size(434, 576);
            this.grbThongTin1.TabIndex = 0;
            this.grbThongTin1.TabStop = false;
            this.grbThongTin1.Text = "Thông Tin Sản Phẩm";
            this.grbThongTin1.Enter += new System.EventHandler(this.grbThongTin1_Enter);
            // 
            // grbChonGia
            // 
            this.grbChonGia.Controls.Add(this.checkedListBox1);
            this.grbChonGia.ForeColor = System.Drawing.Color.DarkGreen;
            this.grbChonGia.Location = new System.Drawing.Point(194, 368);
            this.grbChonGia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbChonGia.Name = "grbChonGia";
            this.grbChonGia.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbChonGia.Size = new System.Drawing.Size(198, 180);
            this.grbChonGia.TabIndex = 11;
            this.grbChonGia.TabStop = false;
            this.grbChonGia.Text = "Chọn Giá Sỉ";
            this.grbChonGia.Enter += new System.EventHandler(this.grbChonGia_Enter);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "giá sỉ 1",
            "giá sỉ 2",
            "giá sỉ 3"});
            this.checkedListBox1.Location = new System.Drawing.Point(21, 26);
            this.checkedListBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(169, 119);
            this.checkedListBox1.TabIndex = 0;
            // 
            // txtMaLoai
            // 
            this.txtMaLoai.BackColor = System.Drawing.Color.Silver;
            this.txtMaLoai.Location = new System.Drawing.Point(209, 246);
            this.txtMaLoai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaLoai.Name = "txtMaLoai";
            this.txtMaLoai.ReadOnly = true;
            this.txtMaLoai.Size = new System.Drawing.Size(198, 26);
            this.txtMaLoai.TabIndex = 10;
            this.txtMaLoai.TextChanged += new System.EventHandler(this.txtMaLoai_TextChanged);
            // 
            // txtGiaLe
            // 
            this.txtGiaLe.BackColor = System.Drawing.Color.Silver;
            this.txtGiaLe.Location = new System.Drawing.Point(209, 320);
            this.txtGiaLe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtGiaLe.Name = "txtGiaLe";
            this.txtGiaLe.ReadOnly = true;
            this.txtGiaLe.Size = new System.Drawing.Size(198, 26);
            this.txtGiaLe.TabIndex = 9;
            this.txtGiaLe.TextChanged += new System.EventHandler(this.txtGiaLe_TextChanged);
            this.txtGiaLe.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGiaLe_KeyPress);
            // 
            // txttenNCC
            // 
            this.txttenNCC.BackColor = System.Drawing.Color.Silver;
            this.txttenNCC.Location = new System.Drawing.Point(209, 185);
            this.txttenNCC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txttenNCC.Name = "txttenNCC";
            this.txttenNCC.ReadOnly = true;
            this.txttenNCC.Size = new System.Drawing.Size(198, 26);
            this.txttenNCC.TabIndex = 8;
            this.txttenNCC.TextChanged += new System.EventHandler(this.txttenNCC_TextChanged);
            // 
            // txttenSP
            // 
            this.txttenSP.BackColor = System.Drawing.Color.Silver;
            this.txttenSP.Location = new System.Drawing.Point(209, 123);
            this.txttenSP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txttenSP.Name = "txttenSP";
            this.txttenSP.ReadOnly = true;
            this.txttenSP.Size = new System.Drawing.Size(198, 26);
            this.txttenSP.TabIndex = 7;
            this.txttenSP.TextChanged += new System.EventHandler(this.txttenSP_TextChanged);
            // 
            // txtmaSP
            // 
            this.txtmaSP.BackColor = System.Drawing.Color.Silver;
            this.txtmaSP.Location = new System.Drawing.Point(209, 64);
            this.txtmaSP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtmaSP.Name = "txtmaSP";
            this.txtmaSP.ReadOnly = true;
            this.txtmaSP.Size = new System.Drawing.Size(198, 26);
            this.txtmaSP.TabIndex = 6;
            this.txtmaSP.Click += new System.EventHandler(this.txtmaSP_Click);
            this.txtmaSP.TextChanged += new System.EventHandler(this.txtmaSP_TextChanged);
            // 
            // lblGiaBanSi
            // 
            this.lblGiaBanSi.AutoSize = true;
            this.lblGiaBanSi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiaBanSi.Location = new System.Drawing.Point(7, 368);
            this.lblGiaBanSi.Name = "lblGiaBanSi";
            this.lblGiaBanSi.Size = new System.Drawing.Size(114, 25);
            this.lblGiaBanSi.TabIndex = 5;
            this.lblGiaBanSi.Text = "Giá Bán Sỉ";
            this.lblGiaBanSi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGiaBanLe
            // 
            this.lblGiaBanLe.AutoSize = true;
            this.lblGiaBanLe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiaBanLe.Location = new System.Drawing.Point(7, 306);
            this.lblGiaBanLe.Name = "lblGiaBanLe";
            this.lblGiaBanLe.Size = new System.Drawing.Size(119, 25);
            this.lblGiaBanLe.TabIndex = 4;
            this.lblGiaBanLe.Text = "Giá Bán Lẻ";
            this.lblGiaBanLe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaLoai
            // 
            this.lblMaLoai.AutoSize = true;
            this.lblMaLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaLoai.Location = new System.Drawing.Point(7, 245);
            this.lblMaLoai.Name = "lblMaLoai";
            this.lblMaLoai.Size = new System.Drawing.Size(89, 25);
            this.lblMaLoai.TabIndex = 3;
            this.lblMaLoai.Text = "Mã Loại";
            this.lblMaLoai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNCC
            // 
            this.lblNCC.AutoSize = true;
            this.lblNCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNCC.Location = new System.Drawing.Point(7, 184);
            this.lblNCC.Name = "lblNCC";
            this.lblNCC.Size = new System.Drawing.Size(196, 25);
            this.lblNCC.TabIndex = 2;
            this.lblNCC.Text = "Tên Nhà Cung Cấp";
            this.lblNCC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTenSP
            // 
            this.lblTenSP.AutoSize = true;
            this.lblTenSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenSP.Location = new System.Drawing.Point(7, 122);
            this.lblTenSP.Name = "lblTenSP";
            this.lblTenSP.Size = new System.Drawing.Size(154, 25);
            this.lblTenSP.TabIndex = 1;
            this.lblTenSP.Text = "Tên Sản Phẩm";
            this.lblTenSP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaSanPham
            // 
            this.lblMaSanPham.AutoSize = true;
            this.lblMaSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaSanPham.Location = new System.Drawing.Point(7, 61);
            this.lblMaSanPham.Name = "lblMaSanPham";
            this.lblMaSanPham.Size = new System.Drawing.Size(147, 25);
            this.lblMaSanPham.TabIndex = 0;
            this.lblMaSanPham.Text = "Mã Sản Phẩm";
            this.lblMaSanPham.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMaSanPham.Click += new System.EventHandler(this.lblMaSanPham_Click);
            // 
            // grbThongTin2
            // 
            this.grbThongTin2.Controls.Add(this.cbotrangthai);
            this.grbThongTin2.Controls.Add(this.lbldvt);
            this.grbThongTin2.Controls.Add(this.btnThoat);
            this.grbThongTin2.Controls.Add(this.btnSua);
            this.grbThongTin2.Controls.Add(this.btnLuu);
            this.grbThongTin2.Controls.Add(this.btnHuy);
            this.grbThongTin2.Controls.Add(this.btnXoa);
            this.grbThongTin2.Controls.Add(this.btnThem);
            this.grbThongTin2.Controls.Add(this.txtSoLuong);
            this.grbThongTin2.Controls.Add(this.lblSoLuong);
            this.grbThongTin2.Controls.Add(this.lblDonViTinh);
            this.grbThongTin2.Controls.Add(this.txtMoTa);
            this.grbThongTin2.Controls.Add(this.grbThemAnh);
            this.grbThongTin2.Controls.Add(this.lblMoTa);
            this.grbThongTin2.Controls.Add(this.lblHinhAnh);
            this.grbThongTin2.Controls.Add(this.lblTrangThai);
            this.grbThongTin2.Location = new System.Drawing.Point(441, 109);
            this.grbThongTin2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbThongTin2.Name = "grbThongTin2";
            this.grbThongTin2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbThongTin2.Size = new System.Drawing.Size(456, 576);
            this.grbThongTin2.TabIndex = 2;
            this.grbThongTin2.TabStop = false;
            this.grbThongTin2.Text = "Thông Tin Sản Phẩm ";
            this.grbThongTin2.Enter += new System.EventHandler(this.grbThongTin2_Enter);
            // 
            // cbotrangthai
            // 
            this.cbotrangthai.FormattingEnabled = true;
            this.cbotrangthai.Items.AddRange(new object[] {
            "hoạt động",
            "ngưng hoạt động"});
            this.cbotrangthai.Location = new System.Drawing.Point(187, 184);
            this.cbotrangthai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbotrangthai.Name = "cbotrangthai";
            this.cbotrangthai.Size = new System.Drawing.Size(136, 28);
            this.cbotrangthai.TabIndex = 13;
            // 
            // lbldvt
            // 
            this.lbldvt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbldvt.Location = new System.Drawing.Point(183, 61);
            this.lbldvt.Name = "lbldvt";
            this.lbldvt.Size = new System.Drawing.Size(112, 29);
            this.lbldvt.TabIndex = 12;
            // 
            // btnThoat
            // 
            this.btnThoat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnThoat.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnThoat.Location = new System.Drawing.Point(278, 515);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(178, 32);
            this.btnThoat.TabIndex = 11;
            this.btnThoat.Text = "&Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnSua
            // 
            this.btnSua.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSua.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSua.Location = new System.Drawing.Point(7, 515);
            this.btnSua.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(178, 32);
            this.btnSua.TabIndex = 11;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLuu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLuu.Location = new System.Drawing.Point(279, 479);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(178, 32);
            this.btnLuu.TabIndex = 11;
            this.btnLuu.Text = "&Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnHuy.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnHuy.Location = new System.Drawing.Point(279, 442);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(178, 32);
            this.btnHuy.TabIndex = 11;
            this.btnHuy.Text = "&Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnXoa.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnXoa.Location = new System.Drawing.Point(8, 479);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(178, 32);
            this.btnXoa.TabIndex = 11;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnThem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnThem.Location = new System.Drawing.Point(8, 442);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(178, 32);
            this.btnThem.TabIndex = 11;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(183, 122);
            this.txtSoLuong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(224, 26);
            this.txtSoLuong.TabIndex = 10;
            this.txtSoLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoLuong_KeyPress);
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuong.Location = new System.Drawing.Point(25, 122);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(104, 25);
            this.lblSoLuong.TabIndex = 8;
            this.lblSoLuong.Text = "Số Lượng";
            this.lblSoLuong.Click += new System.EventHandler(this.lblSoLuong_Click);
            // 
            // lblDonViTinh
            // 
            this.lblDonViTinh.AutoSize = true;
            this.lblDonViTinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonViTinh.Location = new System.Drawing.Point(25, 61);
            this.lblDonViTinh.Name = "lblDonViTinh";
            this.lblDonViTinh.Size = new System.Drawing.Size(124, 25);
            this.lblDonViTinh.TabIndex = 7;
            this.lblDonViTinh.Text = "Đơn Vị Tính";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(187, 384);
            this.txtMoTa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(224, 26);
            this.txtMoTa.TabIndex = 6;
            this.txtMoTa.TextChanged += new System.EventHandler(this.txtMoTa_TextChanged);
            // 
            // grbThemAnh
            // 
            this.grbThemAnh.Location = new System.Drawing.Point(187, 236);
            this.grbThemAnh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbThemAnh.Name = "grbThemAnh";
            this.grbThemAnh.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbThemAnh.Size = new System.Drawing.Size(235, 131);
            this.grbThemAnh.TabIndex = 5;
            this.grbThemAnh.TabStop = false;
            this.grbThemAnh.Text = "Thêm Hình Ảnh";
            this.grbThemAnh.Enter += new System.EventHandler(this.grbThemAnh_Enter);
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoTa.Location = new System.Drawing.Point(25, 384);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(73, 25);
            this.lblMoTa.TabIndex = 2;
            this.lblMoTa.Text = "Mô Tả";
            // 
            // lblHinhAnh
            // 
            this.lblHinhAnh.AutoSize = true;
            this.lblHinhAnh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHinhAnh.Location = new System.Drawing.Point(25, 245);
            this.lblHinhAnh.Name = "lblHinhAnh";
            this.lblHinhAnh.Size = new System.Drawing.Size(100, 25);
            this.lblHinhAnh.TabIndex = 1;
            this.lblHinhAnh.Text = "Hình Ảnh";
            this.lblHinhAnh.Click += new System.EventHandler(this.lblHinhAnh_Click);
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThai.Location = new System.Drawing.Point(25, 184);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(116, 25);
            this.lblTrangThai.TabIndex = 0;
            this.lblTrangThai.Text = "Trạng Thái";
            this.lblTrangThai.Click += new System.EventHandler(this.lblTrangThai_Click);
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10});
            this.dgvDanhSach.Location = new System.Drawing.Point(14, 692);
            this.dgvDanhSach.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.RowHeadersWidth = 51;
            this.dgvDanhSach.RowTemplate.Height = 24;
            this.dgvDanhSach.Size = new System.Drawing.Size(884, 208);
            this.dgvDanhSach.TabIndex = 3;
            this.dgvDanhSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSach_CellClick);
            this.dgvDanhSach.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSach_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "tensp";
            this.Column1.HeaderText = "Tên SP";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "masp";
            this.Column2.HeaderText = "Mã SP";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "tenncc";
            this.Column3.HeaderText = "Tên NCC";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "maloai";
            this.Column4.HeaderText = "Mã Loại";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "giale";
            this.Column5.HeaderText = "Giá Lẻ";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 125;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "giasi";
            this.Column6.HeaderText = "Giá Sỉ";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 125;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "dvtinh";
            this.Column7.HeaderText = "Đơn Vị Tính";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Width = 125;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "soluong";
            this.Column8.HeaderText = "Số Lượng";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.Width = 125;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "trangthai";
            this.Column9.HeaderText = "Trạng Thái";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.Width = 125;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "mota";
            this.Column10.HeaderText = "Mô Tả";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.Width = 125;
            // 
            // lbltenbang
            // 
            this.lbltenbang.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltenbang.Location = new System.Drawing.Point(308, 28);
            this.lbltenbang.Name = "lbltenbang";
            this.lbltenbang.Size = new System.Drawing.Size(305, 58);
            this.lbltenbang.TabIndex = 4;
            this.lbltenbang.Text = "SẢN PHẨM";
            this.lbltenbang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sanpham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 952);
            this.Controls.Add(this.lbltenbang);
            this.Controls.Add(this.dgvDanhSach);
            this.Controls.Add(this.grbThongTin2);
            this.Controls.Add(this.grbThongTin1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "sanpham";
            this.Text = "Sản Phẩm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grbThongTin1.ResumeLayout(false);
            this.grbThongTin1.PerformLayout();
            this.grbChonGia.ResumeLayout(false);
            this.grbThongTin2.ResumeLayout(false);
            this.grbThongTin2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbThongTin1;
        private System.Windows.Forms.GroupBox grbThongTin2;
        private System.Windows.Forms.TextBox txtGiaLe;
        private System.Windows.Forms.TextBox txttenNCC;
        private System.Windows.Forms.TextBox txttenSP;
        private System.Windows.Forms.TextBox txtmaSP;
        private System.Windows.Forms.Label lblGiaBanSi;
        private System.Windows.Forms.Label lblGiaBanLe;
        private System.Windows.Forms.Label lblMaLoai;
        private System.Windows.Forms.Label lblNCC;
        private System.Windows.Forms.Label lblTenSP;
        private System.Windows.Forms.Label lblMaSanPham;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Label lblHinhAnh;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.TextBox txtMaLoai;
        private System.Windows.Forms.GroupBox grbThemAnh;
        private System.Windows.Forms.GroupBox grbChonGia;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label lblDonViTinh;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.Label lbldvt;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.ComboBox cbotrangthai;
        private System.Windows.Forms.Label lbltenbang;
    }
}

