using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

using BUS;
using DTO;
namespace GUI_Tier
{
    public partial class QuanLy : Form
    {
        public QuanLy()
        {
            InitializeComponent();
        }

        public string str;
        public string STR
        {
            get { return str; }
            set { str = value; }
        }//dùng để giử username của 1 tài khoản

        private void QuanLy_Load(object sender, EventArgs e)
        {
            load_data();
        }
        //load dữ liệu lên form
        private void load_data()
        {
            dgvNhanvien.DataSource = NhanVienBUS.GetDSNV();
            cbxCongViec.DataSource = CongViecBUS.Load_DSCV();
            dgvSanPham.DataSource = SanPhamBUS.Load_DSSP();
            cbxLoaiSP.DataSource = LoaiSanPhamBUS.Load_DSLSP();
            dgvKhachHang.DataSource = KhachHangBUS.Load_DSKH();
            dgvSPN.DataSource = dgvPhieuNhap.DataSource = PhieuNhapBUS.Load_DSPN();
            dgvChitietPN.DataSource = PhieuNhapBUS.Load_DSCTPN();
            dgvSPX.DataSource = dgvDSHD.DataSource = HoaDonBUS.Load_DSHD();
            dgvCTHD.DataSource = HoaDonBUS.Load_DSCTHD();
            dgvCTPDH.DataSource = PhieuDatHangBUS.Load_DSCTPDH();
            dgvDSPDH.DataSource = PhieuDatHangBUS.Load_DSPDH();
            dgvDSSPX.DataSource = ThongKeBUS.Load_DSCTHD();
            dgvDSSPN.DataSource = ThongKeBUS.Load_DSCTPN();
            dgvNCC.DataSource = NhaCCBUS.Load_DSNCC();
            txtMaLoaisp.Clear();
            cbxLoaiSP.DisplayMember = "ten_loai_sp";
            cbxLoaiSP.ValueMember = "ma_loai";
            cbxCongViec.DisplayMember = "ten_cv";
            cbxCongViec.ValueMember = "ma_cv";
            txtTongChi.Text = ThongKeBUS.SumPN().ToString();
            txtTongThu.Text = ThongKeBUS.SumHD().ToString();
            txtTT.Text = ThongKeBUS.SumGTHD().ToString();
            txtTC.Text = ThongKeBUS.SumGTPN().ToString();
            txtThue.Text = ((ThongKeBUS.SumGTHD() - ThongKeBUS.SumGTPN()) * 1 / 10).ToString();
            txtLN.Text = (ThongKeBUS.SumGTHD() - ThongKeBUS.SumGTPN()).ToString();
            txtLN2.Text = ((ThongKeBUS.SumGTHD() - ThongKeBUS.SumGTPN()) - ((ThongKeBUS.SumGTHD() - ThongKeBUS.SumGTPN()) * 1 / 10)).ToString();
        }
        //kiểm tra ô textbox trống hay không
        private bool RB(string str)
        {
            if (str == "")
                return false;
            return true;
        }
        /// <summary>
        /// đưa ô dữ liệu đang chọn lê các textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Nhân viên
        private void dgvNhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtManv.Text = Convert.ToString(dgvNhanvien.CurrentRow.Cells[0].Value);
                txtTennv.Text = Convert.ToString(dgvNhanvien.CurrentRow.Cells[1].Value);
                dateNgaysinh.Text = Convert.ToString(dgvNhanvien.CurrentRow.Cells[2].Value);
                if (Convert.ToString(dgvNhanvien.CurrentRow.Cells[3].Value) == "Nam")
                {
                    rdbNam.Checked = true;
                    rdbNu.Checked = false;
                }
                else
                {
                    rdbNam.Checked = false;
                    rdbNu.Checked = true;
                }
                txtSdtnv.Text = Convert.ToString(dgvNhanvien.CurrentRow.Cells[4].Value);
                txtDcnv.Text = Convert.ToString(dgvNhanvien.CurrentRow.Cells[5].Value);
                txtEmailnv.Text = Convert.ToString(dgvNhanvien.CurrentRow.Cells[6].Value);
                cbxCongViec.Text = Convert.ToString(dgvNhanvien.CurrentRow.Cells[7].Value);
            }
            catch (Exception ex)
            {

            }
        }
        //xóa các ô textbox
        private void button3_Click(object sender, EventArgs e)
        {
            txtManv.Focus();
            txtManv.Clear();
            txtDcnv.Clear();
            txtEmailnv.Clear();
            txtSdtnv.Clear();
            txtTennv.Clear();
            rdbNu.Checked = rdbNam.Checked = false;
        }
        /// <summary>
        /// Thêm sinh viên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThemnv_Click(object sender, EventArgs e)
        {
            try
            {
                if (!RB(txtManv.Text))
                {
                    txtManv.Focus();
                    errorProvider1.SetError(txtManv, "Erorr !");
                }
                else
                {
                    NhanVienDTO nv = new NhanVienDTO();
                    nv.ten_nv = txtTennv.Text;
                    nv.ma_nv = txtManv.Text;
                    nv.year = dateNgaysinh.Value.Year;
                    nv.month = dateNgaysinh.Value.Month;
                    nv.day = dateNgaysinh.Value.Day;
                    if (rdbNam.Checked)
                        nv.gioi_tinh = "Nam";
                    else
                        nv.gioi_tinh = "Nữ";
                    nv.dia_chi_nv = txtDcnv.Text;
                    nv.ma_cv = cbxCongViec.SelectedValue.ToString();
                    nv.sdt_nv = txtSdtnv.Text;
                    nv.email = txtEmailnv.Text;
                    NhanVienBUS.Insert(nv);
                    load_data();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Thoát ứng dụng và đăng xuất tài khoản
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <summary>
        /// sửa thông tin 1 nhân viên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSuanv_Click(object sender, EventArgs e)
        {
            try
            {
                NhanVienDTO nv = new NhanVienDTO();
                nv.ten_nv = txtTennv.Text;
                nv.ma_nv = txtManv.Text;
                nv.year = dateNgaysinh.Value.Year;
                nv.month = dateNgaysinh.Value.Month;
                nv.day = dateNgaysinh.Value.Day;
                if (rdbNam.Checked)
                    nv.gioi_tinh = "Nam";
                else
                    nv.gioi_tinh = "Nữ";
                nv.dia_chi_nv = txtDcnv.Text;
                nv.ma_cv = cbxCongViec.SelectedValue.ToString();
                nv.sdt_nv = txtSdtnv.Text;
                nv.email = txtEmailnv.Text;
                NhanVienBUS.Update(nv);
                load_data();
                MessageBox.Show("Update dữ liệu thành công !", "Thông báo", MessageBoxButtons.OKCancel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// xóa thông tin 1 nhân viên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXoanv_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rs = new DialogResult();
                MessageBox.Show("Bạn chắc chắn muốn xóa ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    NhanVienDTO nv = new NhanVienDTO();
                    nv.ma_nv = dgvNhanvien.CurrentRow.Cells[0].Value.ToString();
                    NhanVienBUS.Delete(nv);
                    load_data();
                    MessageBox.Show("Delete thành công !", "Thông báo", MessageBoxButtons.OK);
                }
                
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// xuất chuỗi label ra form tương ứng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxTimkiem_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbxTimkiem.SelectedIndex == 0)
            {
                label11.Text = "Nhập họ và tên nhân viên:";
            }
            if (cbxTimkiem.SelectedIndex == 1)
            {
                label11.Text = "Nhập mã nhân viên:";
            }
            if (cbxTimkiem.SelectedIndex == 2)
            {
                label11.Text = "Nhập công việc nhân viên:";
            }
        }
        /// <summary>
        /// tìm kiếm 1 nhân viên theo mã, theo tên, theo công việc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                NhanVienDTO nv = new NhanVienDTO();
                CongViecDTO cv = new CongViecDTO();
                if (cbxTimkiem.SelectedIndex == 0)
                {
                    nv.ten_nv = txtTimkiem.Text;
                    dgvNhanvien.DataSource = NhanVienBUS.Search_tenNV(nv);
                    if (dgvNhanvien.RowCount < 2)
                        MessageBox.Show("Không có dữ liệu bạn cần tìm", "Thông báo", MessageBoxButtons.OK);
                }
                if (cbxTimkiem.SelectedIndex == 1)
                {
                    nv.ma_nv = txtTimkiem.Text;
                    dgvNhanvien.DataSource = NhanVienBUS.Search_MaNV(nv);
                    if (dgvNhanvien.RowCount < 2)
                        MessageBox.Show("Không có dữ liệu bạn cần tìm", "Thông báo", MessageBoxButtons.OK);
                }
                if (cbxTimkiem.SelectedIndex == 2)
                {
                    cv.ten_cv = txtTimkiem.Text;
                    dgvNhanvien.DataSource = NhanVienBUS.Search_tenCV(cv);
                    if (dgvNhanvien.RowCount < 2)
                        MessageBox.Show("Không có dữ liệu bạn cần tìm", "Thông báo", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //mở form đăng ký tài khoản mới
        private void đăngKýNhânViênMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDangky dk = new frmDangky();
            dk.Show();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult rs = new DialogResult();
            rs = MessageBox.Show("Bạn muốn quay lại màn hình đăng nhập ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                TaiKhoanDTO tk = new TaiKhoanDTO();
                tk.username = str;
                TaiKhoanBUS.Dang_xuat(tk);
                QuanLy ql = new QuanLy();
                this.Hide();
                frmDangnhap dn = new frmDangnhap();
                dn.Show();
            }
            else
            {
                Application.Exit();
            }
        }
#endregion
        #region Sản phẩm
        /// <summary>
        /// Thêm 1 sản phẩm 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThemSP_Click(object sender, EventArgs e)
        {
            try
            {
                if (!RB(txtMasp.Text))
                {
                    txtMasp.Focus();
                    errorProvider1.SetError(txtMasp, "Error");
                }
                else
                {
                    SanPhamDTO sp = new SanPhamDTO();
                    sp.ma_sp = txtMasp.Text;
                    sp.ten_sp = txtTenSP.Text;
                    sp.soluong = int.Parse(txtSLSP.Text);
                    sp.ma_loai = cbxLoaiSP.SelectedValue.ToString();
                    sp.thoi_gian_bh = int.Parse(txtTGBH.Text);
                    sp.gia = long.Parse(txtGiasp.Text);
                    sp.don_vi_tinh = txtDVT.Text;
                    sp.hang_san_xuat = txtHSX.Text;
                    SanPhamBUS.Insert_SP(sp);
                    load_data();
                    MessageBox.Show("Thêm thành công !", "Thông báo", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm không thành công !", "Thông báo", MessageBoxButtons.OK);
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// load sản phẩm lên các ô text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMasp.Text = dgvSanPham.CurrentRow.Cells[0].Value.ToString();
                txtTenSP.Text = dgvSanPham.CurrentRow.Cells[2].Value.ToString();
                cbxLoaiSP.Text = dgvSanPham.CurrentRow.Cells[1].Value.ToString();
                txtDVT.Text = dgvSanPham.CurrentRow.Cells[3].Value.ToString();
                txtGiasp.Text = dgvSanPham.CurrentRow.Cells[4].Value.ToString();
                txtTGBH.Text = dgvSanPham.CurrentRow.Cells[5].Value.ToString();
                txtSLSP.Text = dgvSanPham.CurrentRow.Cells[6].Value.ToString();
                txtHSX.Text = dgvSanPham.CurrentRow.Cells[7].Value.ToString();
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// sửa thông tin của 1 sản phẩm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            try
            {
                SanPhamDTO sp = new SanPhamDTO();
                sp.ma_sp = txtMasp.Text;
                sp.ten_sp = txtTenSP.Text;
                sp.soluong = int.Parse(txtSLSP.Text);
                sp.ma_loai = cbxLoaiSP.SelectedValue.ToString();
                sp.thoi_gian_bh = int.Parse(txtTGBH.Text);
                sp.gia = long.Parse(txtGiasp.Text);
                sp.don_vi_tinh = txtDVT.Text;
                sp.hang_san_xuat = txtHSX.Text;
                SanPhamBUS.Update_SP(sp);
                load_data();
                MessageBox.Show("Sửa thành công !", "Thông báo", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa không thành công !", "Thông báo", MessageBoxButtons.OK);
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// xóa 1 sản phẩm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rs = new DialogResult();
                rs = MessageBox.Show("Bạn chắc chắn muốn xóa ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    SanPhamDTO sp = new SanPhamDTO();
                    sp.ma_sp = txtMasp.Text;
                    
                    HoaDonBUS.delete_sphd(sp);
                    PhieuDatHangBUS.delete_sppdh(sp);
                    PhieuNhapBUS.delete_sppn(sp);
                    SanPhamBUS.Delete_SP(sp);
                    load_data();
                    MessageBox.Show("Xóa thành công !", "Thông báo", MessageBoxButtons.OK);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa không thành công !", "Thông báo", MessageBoxButtons.OK);
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// load danh mục tim kiếm tương ứng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxTimTheoSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxTimTheoSP.SelectedIndex==0)
                lblTimSP.Text="Nhập mã sản phẩm:";
            if(cbxTimTheoSP.SelectedIndex==1)
                lblTimSP.Text="Nhập loại sản phẩm:";
            if(cbxTimTheoSP.SelectedIndex==2)
                lblTimSP.Text="Nhập tên sản phẩm:";
            if(cbxTimTheoSP.SelectedIndex==3)
                lblTimSP.Text = "Nhập hãng sản xuất sản phẩm:";
        }
        /// <summary>
        /// thực biện tìm kiếm sản phẩm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #endregion
        #region Loại sản phẩm
        private void btnTimsp_Click(object sender, EventArgs e)
        {
            try
            {
                SanPhamDTO sp = new SanPhamDTO();
                LoaiSanPhamDTO loaisp = new LoaiSanPhamDTO();
                if (cbxTimTheoSP.SelectedIndex == 0)
                {
                    sp.ma_sp = txtTimTheosp.Text;
                    if (SanPhamBUS.Search_MaSP(sp).Rows.Count==0)
                        MessageBox.Show("Không có thông tin bạn cần tìm", "Thông báo", MessageBoxButtons.OK);
                    else
                        dgvSanPham.DataSource = SanPhamBUS.Search_MaSP(sp);
                }
                if (cbxTimTheoSP.SelectedIndex == 1)
                {
                    loaisp.ten_loai_sp = txtTimTheosp.Text;
                    if (SanPhamBUS.Search_LoaiSP(loaisp).Rows.Count == 0)
                        MessageBox.Show("Không có thông tin bạn cần tìm", "Thông báo", MessageBoxButtons.OK);
                    else
                        dgvSanPham.DataSource = SanPhamBUS.Search_LoaiSP(loaisp);
                }
                if (cbxTimTheoSP.SelectedIndex == 2)
                {
                    sp.ten_sp = txtTimTheosp.Text;
                    if (SanPhamBUS.Search_TenSP(sp).Rows.Count == 0)
                        MessageBox.Show("Không có thông tin bạn cần tìm", "Thông báo", MessageBoxButtons.OK);
                    else
                        dgvSanPham.DataSource = SanPhamBUS.Search_TenSP(sp);
                }
                if (cbxTimTheoSP.SelectedIndex == 3)
                {
                    sp.hang_san_xuat = txtTimTheosp.Text;
                    if (SanPhamBUS.Search_HSXSP(sp).Rows.Count == 0)
                        MessageBox.Show("Không có thông tin bạn cần tìm", "Thông báo", MessageBoxButtons.OK);
                    else
                        dgvSanPham.DataSource = SanPhamBUS.Search_HSXSP(sp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThemLoaisp_Click(object sender, EventArgs e)
        {
            try
            {
                LoaiSanPhamDTO loaisp = new LoaiSanPhamDTO();
                if (!RB(txtMaLoaisp.Text))
                {
                    txtMaLoaisp.Focus();
                    errorProvider1.SetError(txtMaLoaisp, "Error!");
                }
                else
                {
                    loaisp.ma_loai = txtMaLoaisp.Text;
                    loaisp.ten_loai_sp = txtTenLoaiSP.Text;
                    LoaiSanPhamBUS.Insert_LSP(loaisp);
                    MessageBox.Show("Thêm thành công !", "Thông báo", MessageBoxButtons.OK);
                    load_data();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoaLoaisp_Click(object sender, EventArgs e)
        {
            try
            {
                LoaiSanPhamDTO loaisp = new LoaiSanPhamDTO();
                loaisp.ma_loai = cbxLoaiSP.SelectedValue.ToString();
                LoaiSanPhamBUS.Delete_LSP(loaisp);
                load_data();
                MessageBox.Show("Xóa thành công !", "Thông báo", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSuaLoaisp_Click(object sender, EventArgs e)
        {
            try
            {
                LoaiSanPhamDTO loaisp = new LoaiSanPhamDTO();
                loaisp.ma_loai = txtMaLoaisp.Text;
                loaisp.ten_loai_sp = txtTenLoaiSP.Text;
                LoaiSanPhamBUS.Update_LSP(loaisp);
                load_data();
                MessageBox.Show("Sửa thành công !", "Thông báo", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbxLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMaLoaisp.Text = cbxLoaiSP.SelectedValue.ToString();
        }
        #endregion
        #region Khách hàng
        private void btnThemKH_Click(object sender, EventArgs e)
        {
            try
            {
                if (!RB(txtMaKhachhang.Text))
                {
                    txtMaKhachhang.Focus();
                    errorProvider1.SetError(txtMaKhachhang,"Error!");
                }
                else
                {

                    KhachHangDTO kh = new KhachHangDTO();
                    kh.ten_kh = txtTenKhachHang.Text;
                    kh.ma_kh = txtMaKhachhang.Text;
                    kh.sdt = txtsdtKH.Text;
                    kh.diachi = txtDiaChi.Text;
                    KhachHangBUS.Insert_KH(kh);
                    load_data();
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rs = new DialogResult();
                rs = MessageBox.Show("Bạn chắc chắn muốn xóa ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    KhachHangDTO kh = new KhachHangDTO();
                    kh.ma_kh = dgvKhachHang.CurrentRow.Cells[0].Value.ToString();
                    KhachHangBUS.Delete_KH(kh);
                    load_data();
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            try
            {
                KhachHangDTO kh = new KhachHangDTO();
                kh.ten_kh = txtTenKhachHang.Text;
                kh.ma_kh = txtMaKhachhang.Text;
                kh.sdt = txtsdtKH.Text;
                kh.diachi = txtDiaChi.Text;
                KhachHangBUS.Update_KH(kh);
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
                load_data();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMaKhachhang.Text = dgvKhachHang.CurrentRow.Cells[0].Value.ToString();
                txtTenKhachHang.Text = dgvKhachHang.CurrentRow.Cells[1].Value.ToString();
                txtDiaChi.Text = dgvKhachHang.CurrentRow.Cells[2].Value.ToString();
                txtsdtKH.Text = dgvKhachHang.CurrentRow.Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void cbxKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxKhachHang.SelectedIndex == 0)
                lblTimKH.Text = "Nhập mã khách hàng";
            if (cbxKhachHang.SelectedIndex == 1)
                lblTimKH.Text = "Nhập tên khách hàng";
        }


        private void btnTimKH_Click(object sender, EventArgs e)
        {
            try
            {
                KhachHangDTO kh = new KhachHangDTO();
                if (cbxKhachHang.SelectedIndex == 0)
                {
                    kh.ma_kh = txtTimKH.Text;
                    if (KhachHangBUS.Search_MaKH(kh).Rows.Count==0)
                    {
                        MessageBox.Show("Không có thông tin bạn cần tìm", "Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                    dgvKhachHang.DataSource=KhachHangBUS.Search_MaKH(kh);
                }
                if (cbxKhachHang.SelectedIndex == 1)
                {
                    kh.ten_kh = txtTimKH.Text;
                    if (KhachHangBUS.Serch_TenKH(kh).Rows.Count == 0)
                    {
                        MessageBox.Show("Không có thông tin bạn cần tìm", "Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                    dgvKhachHang.DataSource = KhachHangBUS.Serch_TenKH(kh);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            btnThoat_Click(sender, e);
        }
        #endregion
        #region Phiếu nhập
        private void button5_Click(object sender, EventArgs e)
        {
            btnThoat_Click(sender, e);
        }
        /// <summary>
        /// load thong tin phieu nhap len o text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                PhieuNhapDTO pn = new PhieuNhapDTO();
                pn.ma_phieu_nhap = txtMaPN.Text = dgvPhieuNhap.CurrentRow.Cells[0].Value.ToString();
                dgvChitietPN.DataSource = PhieuNhapBUS.Load_DSMaPN(pn);
                txtNVLPN.Text = dgvPhieuNhap.CurrentRow.Cells[1].Value.ToString();
                txtNCC.Text = dgvPhieuNhap.CurrentRow.Cells[2].Value.ToString();
                dtpPN.Text = dgvPhieuNhap.CurrentRow.Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Lưu thay đổi tổng giá trị PN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvChitietPN_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ChiTietPNDTO ctpn = new ChiTietPNDTO();
                PhieuNhapDTO pn = new PhieuNhapDTO();
                ctpn.id = int.Parse(dgvChitietPN.CurrentRow.Cells[0].Value.ToString());
                pn.ma_phieu_nhap = dgvChitietPN.CurrentRow.Cells[1].Value.ToString();
                ctpn.ma_sp = dgvChitietPN.CurrentRow.Cells[2].Value.ToString();
                ctpn.gianhap = long.Parse(dgvChitietPN.CurrentRow.Cells[5].Value.ToString());
                ctpn.soluong = int.Parse(dgvChitietPN.CurrentRow.Cells[4].Value.ToString());
                ctpn.tong = ctpn.gianhap * ctpn.soluong;
                pn.tongtien = ThongKeBUS.SumCTPN_theoma(pn);
                PhieuNhapBUS.Update_CTPN(ctpn);
                PhieuNhapBUS.Update_PN(pn);
                btnSuaPN_Click(sender, e);
                load_data();
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// sua thong tin phieu nhap
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSuaPN_Click(object sender, EventArgs e)
        {
            try
            {
                ChiTietPNDTO ctpn = new ChiTietPNDTO();
                PhieuNhapDTO pn = new PhieuNhapDTO();
                ctpn.id = int.Parse(dgvChitietPN.CurrentRow.Cells[0].Value.ToString());
                pn.ma_phieu_nhap = dgvChitietPN.CurrentRow.Cells[1].Value.ToString();
                ctpn.ma_sp = dgvChitietPN.CurrentRow.Cells[2].Value.ToString();
                ctpn.gianhap = long.Parse(dgvChitietPN.CurrentRow.Cells[5].Value.ToString());
                ctpn.soluong = int.Parse(dgvChitietPN.CurrentRow.Cells[4].Value.ToString());
                ctpn.tong = ctpn.gianhap * ctpn.soluong;
                pn.tongtien = ThongKeBUS.SumCTPN_theoma(pn);
                PhieuNhapBUS.Update_CTPN(ctpn);
                PhieuNhapBUS.Update_PN(pn);

                load_data();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbxTimPN_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtpTimNgayLPN.Visible = false;
            txtTimPN.Visible = true;
            if (cbxTimPN.SelectedIndex == 0)
            {
                lblTimPN.Text = "Nhập mã phiếu nhập:";
            }
            if (cbxTimPN.SelectedIndex == 1)
            {
                lblTimPN.Text = "Nhập tên nhân viên lập phiếu nhập:";
            }
            if (cbxTimPN.SelectedIndex == 2)
            {
                lblTimPN.Text = "Nhập ngày lập phiếu nhập:";
                dtpTimNgayLPN.Visible = true;
                txtTimPN.Visible = false;
            }
            if (cbxTimPN.SelectedIndex == 3)
            {
                lblTimPN.Text = "Nhập nhà cung cấp:";
            }
        }
        /// <summary>
        /// tìm kiếm phiếu nhập
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimPN_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxTimPN.SelectedIndex == 0)
                {
                    PhieuNhapDTO pn = new PhieuNhapDTO();
                    pn.ma_phieu_nhap = txtTimPN.Text;
                    if (PhieuNhapBUS.Search_MaPN(pn).Rows.Count == 0)
                    {
                        MessageBox.Show("Không có thông tin bạn cần tìm", "Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                    dgvPhieuNhap.DataSource = PhieuNhapBUS.Search_MaPN(pn);
                }
                if (cbxTimPN.SelectedIndex == 1)
                {
                    NhanVienDTO nv = new NhanVienDTO();
                    nv.ten_nv = txtTimPN.Text;
                    if (PhieuNhapBUS.Search_TenNVLPN(nv).Rows.Count == 0)
                    {
                        MessageBox.Show("Không có thông tin bạn cần tìm", "Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                    dgvPhieuNhap.DataSource = PhieuNhapBUS.Search_TenNVLPN(nv);
                }
                if (cbxTimPN.SelectedIndex == 2)
                {
                    PhieuNhapDTO pn = new PhieuNhapDTO();
                    pn.year = dtpTimNgayLPN.Value.Year;
                    pn.month = dtpTimNgayLPN.Value.Month;
                    pn.day = dtpTimNgayLPN.Value.Day;
                    if (PhieuNhapBUS.Search_NgayLPN(pn).Rows.Count == 0)
                    {
                        MessageBox.Show("Không có thông tin bạn cần tìm", "Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                    dgvPhieuNhap.DataSource = PhieuNhapBUS.Search_NgayLPN(pn);
                }
                if (cbxTimPN.SelectedIndex == 3)
                {
                    NhaCCDTO ncc = new NhaCCDTO();
                    ncc.ten_ncc = txtTimPN.Text;
                    if (PhieuNhapBUS.Search_NCC(ncc).Rows.Count == 0)
                    {
                        MessageBox.Show("Không có thông tin bạn cần tìm", "Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                    dgvPhieuNhap.DataSource = PhieuNhapBUS.Search_NCC(ncc);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// xóa 1 phiếu nhập được chọn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXoaPN_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rs = new DialogResult();
                rs = MessageBox.Show("Bạn chắc chắn muốn xóa ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    PhieuNhapDTO pn = new PhieuNhapDTO();
                    pn.ma_phieu_nhap = dgvChitietPN.CurrentRow.Cells[0].Value.ToString();
                    PhieuNhapBUS.Delete_PN(pn);
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                    load_data();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region Hóa đơn
        private void cbxTimHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtbTimHD.Visible = false;
            txtTimHD.Visible = true;
            if (cbxTimHD.SelectedIndex == 0)
            {
                lblTimHD.Text = "Nhập mã hóa đơn:";
            }
            if (cbxTimHD.SelectedIndex == 1)
            {
                lblTimHD.Text = "Nhập tên nhân viên lập hóa đơn:";
            }
            if (cbxTimHD.SelectedIndex == 2)
            {
                lblTimHD.Text = "Nhập ngày lập hóa đơn:";
                dtbTimHD.Visible = true;
                txtTimHD.Visible = false;
            }
            if (cbxTimHD.SelectedIndex == 3)
            {
                lblTimHD.Text = "Nhập tên khách hàng:";

            }
        }
       
        /// <summary>
        /// load dữ liệu hóa đơn lên các ô text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                HoaDonDTO hd = new HoaDonDTO();
                txtMaHD.Text = hd.ma_hd = dgvDSHD.CurrentRow.Cells[0].Value.ToString();
                dgvCTHD.DataSource = HoaDonBUS.Load_DSTheoMaHD(hd);
                txtTenKH_HD.Text = dgvDSHD.CurrentRow.Cells[1].Value.ToString();
                txtNVLHD.Text = dgvDSHD.CurrentRow.Cells[2].Value.ToString();
                dtpLapHD.Text = dgvDSHD.CurrentRow.Cells[3].Value.ToString();
                txtDaThanhToan.Text = dgvDSHD.CurrentRow.Cells[4].Value.ToString();
                txtConLai.Text = dgvDSHD.CurrentRow.Cells[5].Value.ToString();
                txtTongtien.Text = dgvDSHD.CurrentRow.Cells[6].Value.ToString();
                if (bool.Parse(dgvDSHD.CurrentRow.Cells[7].Value.ToString()) == true)
                {
                    rdbThanhToan.Checked = true;
                    rdbChuaThanhToan.Checked = false;
                }
                else
                {
                    rdbThanhToan.Checked = false;
                    rdbChuaThanhToan.Checked = true;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            btnThoat_Click(sender, e);
        }
        
        /// <summary>
        /// xóa hóa đơn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rs = new DialogResult();
                rs = MessageBox.Show("Bạn chắc chắn muốn xóa ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    HoaDonDTO hd = new HoaDonDTO();
                    hd.ma_hd = txtMaHD.Text;
                    HoaDonBUS.Delete_HD(hd);
                    load_data();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// sửa hóa đơn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSuaHD_Click(object sender, EventArgs e)
        {
            try
            {
                ChiTietHoaDonDTO cthd = new ChiTietHoaDonDTO();
                HoaDonDTO hd = new HoaDonDTO();
                
                cthd.id = int.Parse(dgvCTHD.CurrentRow.Cells[0].Value.ToString());
                cthd.ma_hd = hd.ma_hd = dgvCTHD.CurrentRow.Cells[1].Value.ToString();
                cthd.ma_sp = dgvCTHD.CurrentRow.Cells[2].Value.ToString();
                cthd.soluong = int.Parse(dgvCTHD.CurrentRow.Cells[4].Value.ToString());
                cthd.thanhtien = cthd.soluong * long.Parse(dgvCTHD.CurrentRow.Cells[5].Value.ToString());
                HoaDonBUS.Update_CTHD(cthd);
                hd.tonggiatri = ThongKeBUS.SumHD_theoma(hd);
                HoaDonBUS.update_gia(hd);
                load_data();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //tìm hóa đơn
        private void btnTimHD_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxTimHD.SelectedIndex == 0)
                {
                    HoaDonDTO hd = new HoaDonDTO();
                    hd.ma_hd = txtTimHD.Text;
                    if (HoaDonBUS.Search_MaHD(hd).Rows.Count == 0)
                        MessageBox.Show("Không có thông tin bạn cần tìm", "Thông báo", MessageBoxButtons.OK);
                    dgvDSHD.DataSource = HoaDonBUS.Search_MaHD(hd);
                }
                if (cbxTimHD.SelectedIndex == 1)
                {
                    NhanVienDTO nv = new NhanVienDTO();
                    nv.ten_nv = txtTimHD.Text;
                    if (HoaDonBUS.Search_TenNVLHD(nv).Rows.Count == 0)
                        MessageBox.Show("Không có thông tin bạn cần tìm", "Thông báo", MessageBoxButtons.OK);
                    dgvDSHD.DataSource = HoaDonBUS.Search_TenNVLHD(nv);
                }
                if (cbxTimHD.SelectedIndex == 2)
                {
                    HoaDonDTO hd = new HoaDonDTO();
                    hd.year = dtbTimHD.Value.Year;
                    hd.month = dtbTimHD.Value.Month;
                    hd.day = dtbTimHD.Value.Day;
                    if (HoaDonBUS.Search_NgayLapHD(hd).Rows.Count == 0)
                        MessageBox.Show("Không có thông tin bạn cần tìm", "Thông báo", MessageBoxButtons.OK);
                    dgvDSHD.DataSource = HoaDonBUS.Search_NgayLapHD(hd);
                }
                if (cbxTimHD.SelectedIndex == 3)
                {
                    KhachHangDTO kh = new KhachHangDTO();
                    kh.ten_kh = txtTimHD.Text;
                    if (HoaDonBUS.Search_TenKHinHD(kh).Rows.Count == 0)
                        MessageBox.Show("Không có thông tin bạn cần tìm", "Thông báo", MessageBoxButtons.OK);
                    dgvDSHD.DataSource = HoaDonBUS.Search_TenKHinHD(kh);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region Phiếu đặt hàng
        private void button8_Click(object sender, EventArgs e)
        {
            btnThoat_Click(sender, e);
        }
        

        private void cbxTimPDH_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTimPDH.Visible = true;
            dtpTimPDH.Visible = false;
            if(cbxTimPDH.SelectedIndex==0)
                lblTimPDH.Text="Nhập mã phiếu đặt hàng";
            if(cbxTimPDH.SelectedIndex==1)
                lblTimPDH.Text="Nhập tên nhân viên lập đặt hàng";
            if (cbxTimPDH.SelectedIndex == 2)
            {
                lblTimPDH.Text = "Nhập ngày lập phiếu đặt hàng";
                txtTimPDH.Visible = false;
                dtpTimPDH.Visible = true;
            }
            if(cbxTimPDH.SelectedIndex==3)
                lblTimPDH.Text = "Nhập tên khách hàng";
        }
        

        private void XoaPDH_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rs = new DialogResult();
                rs = MessageBox.Show("Bạn chắc chắn muốn xóa ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    PhieuDatHangDTO pdh = new PhieuDatHangDTO();
                    pdh.ma_pdh = dgvDSPDH.CurrentRow.Cells[0].Value.ToString();
                    PhieuDatHangBUS.Delete_PDH(pdh);
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                    load_data();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvDSPDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMaPDH.Text = dgvDSPDH.CurrentRow.Cells[0].Value.ToString();
                txtNVLPDH.Text = dgvDSPDH.CurrentRow.Cells[1].Value.ToString();
                txtKhachDH.Text = dgvDSPDH.CurrentRow.Cells[2].Value.ToString();
                dtpNgayLPDH.Text = dgvDSPDH.CurrentRow.Cells[3].Value.ToString();
                txtTongTienPDH.Text = dgvDSPDH.CurrentRow.Cells[4].Value.ToString();
                PhieuDatHangDTO pdh = new PhieuDatHangDTO();
                pdh.ma_pdh = dgvDSPDH.CurrentRow.Cells[0].Value.ToString();
                dgvCTPDH.DataSource = PhieuDatHangBUS.Load_DSTheoMaPDH(pdh);
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
        }

        private void btnSuaPDH_Click(object sender, EventArgs e)
        {
            try
            {
                ChiTietPDHDTO ctpdh = new ChiTietPDHDTO();
                PhieuDatHangDTO pdh = new PhieuDatHangDTO();
                ctpdh.id = int.Parse(dgvCTPDH.CurrentRow.Cells[0].Value.ToString());
                pdh.ma_pdh = dgvCTPDH.CurrentRow.Cells[1].Value.ToString();
                ctpdh.ma_sp = dgvCTPDH.CurrentRow.Cells[2].Value.ToString();
                ctpdh.soluong = int.Parse(dgvCTPDH.CurrentRow.Cells[4].Value.ToString());
                ctpdh.thanhtien = ctpdh.soluong*long.Parse(dgvCTPDH.CurrentRow.Cells[5].Value.ToString());
                PhieuDatHangBUS.Update_CTPDH(ctpdh);
                pdh.tonggiatri = ThongKeBUS.SumPDH_theoma(pdh);
                PhieuDatHangBUS.Update_gia(pdh);
                load_data();
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TìmPDH_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxTimPDH.SelectedIndex == 0)
                {
                    PhieuDatHangDTO pdh = new PhieuDatHangDTO();
                    pdh.ma_pdh = txtTimPDH.Text;
                    if (PhieuDatHangBUS.Search_Ma(pdh).Rows.Count == 0)
                    {
                        MessageBox.Show("Không có thông tin bạn cần tìm", "Thông báo", MessageBoxButtons.OK);
                    }
                    dgvDSPDH.DataSource = PhieuDatHangBUS.Search_Ma(pdh);
                }
                if (cbxTimPDH.SelectedIndex == 1)
                {
                    NhanVienDTO nv = new NhanVienDTO();
                    nv.ten_nv = txtTimPDH.Text;
                    if (PhieuDatHangBUS.Search_TenNVLPDH(nv).Rows.Count == 0)
                    {
                        MessageBox.Show("Không có thông tin bạn cần tìm", "Thông báo", MessageBoxButtons.OK);
                    }
                    dgvDSPDH.DataSource = PhieuDatHangBUS.Search_TenNVLPDH(nv);
                }
                if (cbxTimPDH.SelectedIndex == 2)
                {
                    PhieuDatHangDTO pdh = new PhieuDatHangDTO();
                    pdh.year = dtpNgayLPDH.Value.Year;
                    pdh.month = dtpNgayLPDH.Value.Month;
                    pdh.day = dtpNgayLPDH.Value.Day;
                    if (PhieuDatHangBUS.Search_NgayLPDH(pdh).Rows.Count == 0)
                    {
                        MessageBox.Show("Không có thông tin bạn cần tìm", "Thông báo", MessageBoxButtons.OK);
                    }
                    dgvDSPDH.DataSource = PhieuDatHangBUS.Search_NgayLPDH(pdh);
                }
                if (cbxTimPDH.SelectedIndex == 3)
                {
                    KhachHangDTO kh = new KhachHangDTO();
                    kh.ten_kh = txtTimPDH.Text;
                    if (PhieuDatHangBUS.Search_TenKH(kh).Rows.Count == 0)
                    {
                        MessageBox.Show("Không có thông tin bạn cần tìm", "Thông báo", MessageBoxButtons.OK);
                    }
                    dgvDSPDH.DataSource = PhieuDatHangBUS.Search_TenKH(kh);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region Thống kê
        private void button2_Click(object sender, EventArgs e)
        {
            btnThoat_Click(sender, e);
        }
        
        /// <summary>
        /// xem chi tiet thong ke theo ngay cua san pham xuat va nhap
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                PhieuNhapDTO pn1 = new PhieuNhapDTO();
                PhieuNhapDTO pn2 = new PhieuNhapDTO();
                pn1.year = dtbbetween1.Value.Year;
                pn1.month = dtbbetween1.Value.Month;
                pn1.day = dtbbetween1.Value.Day;
                pn2.year = dtbbetween2.Value.Year;
                pn2.month = dtbbetween2.Value.Month;
                pn2.day = dtbbetween2.Value.Day;
                if (ThongKeBUS.Load_DSNgayPN(pn1, pn2).Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy !", "Thông báo", MessageBoxButtons.OK); return;
                }
                dgvDSSPN.DataSource = ThongKeBUS.Load_DSNgayPN(pn1,pn2);
                txtTongChi.Text = ThongKeBUS.SumPN_theongay(pn1, pn2).ToString();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void btnXem2_Click(object sender, EventArgs e)
        {
            try
            {
                HoaDonDTO hd1 = new HoaDonDTO();
                HoaDonDTO hd2 = new HoaDonDTO();
                hd1.year = dtpHD1.Value.Year;
                hd1.month = dtpHD1.Value.Month;
                hd1.day = dtpHD1.Value.Day;
                hd2.year = dtpHD2.Value.Year;
                hd2.month = dtpHD2.Value.Month;
                hd2.day = dtpHD2.Value.Day;
                if (ThongKeBUS.Load_DSNgayLapHD(hd1, hd2).Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy !", "Thông báo", MessageBoxButtons.OK); return;
                }
                dgvDSSPN.DataSource = ThongKeBUS.Load_DSNgayLapHD(hd1, hd2);
                txtTongThu.Text = ThongKeBUS.SumHD_theongay(hd1, hd2).ToString();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        /// <summary>
        /// xem chi tiet thong ke theo ngay
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                PhieuNhapDTO pn1 = new PhieuNhapDTO();
                PhieuNhapDTO pn2 = new PhieuNhapDTO();
                HoaDonDTO hd1 = new HoaDonDTO();
                HoaDonDTO hd2 = new HoaDonDTO();
                hd1.year = pn1.year = dtpDT1.Value.Year;
                hd1.month = pn1.month = dtpDT1.Value.Month;
                hd1.day = pn1.day = dtpDT1.Value.Day;
                hd2.year = pn2.year = dtpDT2.Value.Year;
                hd2.month = pn2.month = dtpDT2.Value.Month;
                hd2.day = pn2.day = dtpDT2.Value.Day;
                if (ThongKeBUS.Load_DSTheoNgayLapPN(pn1, pn2).Rows.Count == 0&&ThongKeBUS.Load_TheoNgayLapHD(hd1,hd2).Rows.Count==0)
                {
                    MessageBox.Show("Không tìm thấy !", "Thông báo", MessageBoxButtons.OK); return;
                }
                dgvSPN.DataSource = ThongKeBUS.Load_DSTheoNgayLapPN(pn1, pn2);
                dgvSPX.DataSource = ThongKeBUS.Load_TheoNgayLapHD(hd1, hd2);
                txtTT.Text = ThongKeBUS.SumGTHD_theongay(hd1, hd2).ToString();
                txtTC.Text = ThongKeBUS.SumGTPN_theongay(pn1, pn2).ToString();
                txtThue.Text = ((ThongKeBUS.SumGTHD_theongay(hd1, hd2) - ThongKeBUS.SumGTPN_theongay(pn1, pn2)) * 1 / 10).ToString();
                txtLN.Text = (ThongKeBUS.SumGTHD_theongay(hd1, hd2) - ThongKeBUS.SumGTPN_theongay(pn1, pn2)).ToString();
                txtLN2.Text = ((ThongKeBUS.SumGTHD_theongay(hd1, hd2) - ThongKeBUS.SumGTPN_theongay(pn1, pn2)) - ((ThongKeBUS.SumGTHD_theongay(hd1, hd2) - ThongKeBUS.SumGTPN_theongay(pn1, pn2)) * 1 / 10)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTimNCC.SelectedIndex == 0)
            {
                lblTimNCC.Text = "Nhập mã nhà cung cấp:";
            }
            if (cbxTimNCC.SelectedIndex == 1)
            {
                lblTimNCC.Text = "Nhập tên nhà cung cấp:";
            }
        }
        /// <summary>
        /// thêm mới nhà cung cấp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                NhaCCDTO ncc = new NhaCCDTO();
                ncc.ten_ncc = txtTenNCC.Text;
                ncc.ma_ncc = txtMaNCC.Text;
                ncc.email = txtEmailNCC.Text;
                ncc.sdt_ncc = txtSDTNCC.Text;
                NhaCCBUS.Insert_NCC(ncc);
                MessageBox.Show("Thêm thành công !", "Thông báo", MessageBoxButtons.OKCancel);
                load_data();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// xóa nhà cung cấp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click_1(object sender, EventArgs e)
        {
            
            try
            {
                NhaCCDTO ncc = new NhaCCDTO();
                ncc.ma_ncc = dgvNCC.CurrentRow.Cells[0].Value.ToString();
                NhaCCBUS.Delete_NCC(ncc);
                MessageBox.Show("Xóa thành công !", "Thông báo", MessageBoxButtons.OKCancel);
                load_data();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// sửa nhà cung cấp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click_1(object sender, EventArgs e)
        {
            try
            {
                NhaCCDTO ncc = new NhaCCDTO();
                ncc.ten_ncc = txtTenNCC.Text;
                ncc.ma_ncc = txtMaNCC.Text;
                ncc.email = txtEmailNCC.Text;
                ncc.sdt_ncc = txtSDTNCC.Text;
                NhaCCBUS.Update_NCC(ncc);
                MessageBox.Show("Lưu thành công !", "Thông báo", MessageBoxButtons.OKCancel);
                load_data();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMaNCC.Text = dgvNCC.CurrentRow.Cells[0].Value.ToString();
                txtTenNCC.Text = dgvNCC.CurrentRow.Cells[1].Value.ToString();
                txtEmailNCC.Text = dgvNCC.CurrentRow.Cells[3].Value.ToString();
                txtSDTNCC.Text = dgvNCC.CurrentRow.Cells[2].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (cbxTimNCC.SelectedIndex == 0)
                {
                    NhaCCDTO ncc = new NhaCCDTO();
                    ncc.ma_ncc = txtTimNCC.Text;
                    if (NhaCCBUS.Search_MaNCC(ncc).Rows.Count == 0)
                    {
                        MessageBox.Show("Không có thông tin cần tìm", "Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                    dgvNCC.DataSource = NhaCCBUS.Search_MaNCC(ncc);
                }
                if (cbxTimNCC.SelectedIndex == 1)
                {
                    NhaCCDTO ncc = new NhaCCDTO();
                    ncc.ten_ncc = txtTimNCC.Text;
                    if (NhaCCBUS.Search_tenNCC(ncc).Rows.Count == 0)
                    {
                        MessageBox.Show("Không có thông tin cần tìm", "Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                    dgvNCC.DataSource = NhaCCBUS.Search_tenNCC(ncc);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            load_data();
        }

        private void saoLưuDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog file = new FolderBrowserDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                string str = "Server=localhost;Database=banthietbidientu;Port=3307;User ID=root;Password=; CHARSET=utf8";
                MySqlConnection cnn = new MySqlConnection(str);
                if (cnn.State == ConnectionState.Closed)
                    cnn.Open();
                string backup = "BACKUP DATABASE banthietbidientu TO DISK ='" + file.SelectedPath + "\\banthietbidientu-" + DateTime.Now.Ticks.ToString()+".bak'";
                MySqlCommand cmd = new MySqlCommand(backup, cnn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sao lưu thành công !", "Thông báo", MessageBoxButtons.OK);
                cnn.Close();
            }
        }

    }        
}
