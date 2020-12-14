using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
namespace GUI_Tier
{
    public partial class frmBanHang : Form
    {
        public frmBanHang()
        {
            InitializeComponent();
        }
        public string str;
        public string STR
        {
            get { return str; }
            set { str = value; }
        }
        KhachHangDTO KhachHang = new KhachHangDTO();
        PhieuDatHangDTO pdh = new PhieuDatHangDTO();
        HoaDonDTO hd = new HoaDonDTO();
        SanPhamDTO sp = new SanPhamDTO();
        double thanhtien = 0;
        double thanhtienhd = 0;
        double TongTien = 0;
        int soluong=0;
        private void frmBanHang_Load(object sender, EventArgs e)
        {
            load_data();
        }

        //load du lieu
        private void load_data()
        {
            dgvDMSanPham_PDH.DataSource = dgvDanhMucSP_HD.DataSource = SanPhamBUS.Load_DSSP();
            dgvKhachHang.DataSource = KhachHangBUS.Load_DSKH();
            cbxNhanvien.DataSource = NhanVienBUS.GetDSNV();
            cbxNhanvien.DisplayMember = "ten_nv";
            cbxNhanvien.ValueMember = "ma_nv";
            cbxNVLHD.DataSource = NhanVienBUS.GetDSNV();
            cbxNVLHD.DisplayMember = "ten_nv";
            cbxNVLHD.ValueMember = "ma_nv";
            dgvCTPDH.DataSource = PhieuDatHangBUS.Load_DSTheoMaPDH(pdh);
            dgvCTHD.DataSource = HoaDonBUS.Load_DSTheoMaHD(hd);
            cbxLoaiSP.DataSource = LoaiSanPhamBUS.Load_DSLSP();
            cbxLoaiSP.DisplayMember = "ten_loai_sp";
            cbxLoaiSP.ValueMember = "ma_loai";
            cbxlsp.DataSource = LoaiSanPhamBUS.Load_DSLSP();
            cbxlsp.DisplayMember = "ten_loai_sp";
            cbxlsp.ValueMember = "ma_loai";
        }
        #region Khach hang
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTimKhachHang.SelectedIndex == 0)
                lblKhachHang.Text = "Nhập mã khách hàng";
            if (cbxTimKhachHang.SelectedIndex == 1)
                lblKhachHang.Text = "Nhập tên khách hàng";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                KhachHangDTO kh = new KhachHangDTO();
                if (cbxTimKhachHang.SelectedIndex == 0)
                {
                    kh.ma_kh = txtTimKhachHang.Text;
                    if (KhachHangBUS.Search_MaKH(kh).Rows.Count == 0)
                    {
                        MessageBox.Show("Không có thông tin bạn cần tìm", "Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                    dgvKhachHang.DataSource = KhachHangBUS.Search_MaKH(kh);
                }
                if (cbxTimKhachHang.SelectedIndex == 1)
                {
                    kh.ten_kh = txtTimKhachHang.Text;
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

        private void btn_ThemKH_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaKH.Text=="")
                {
                    txtMaKH.Focus();
                }
                else
                {

                    KhachHangDTO kh = new KhachHangDTO();
                    KhachHang.ten_kh = kh.ten_kh = txtTenKH.Text;
                    KhachHang.ma_kh = kh.ma_kh = txtMaKH.Text;
                    kh.sdt = txtDTKH.Text;
                    kh.diachi = txtDCKH.Text;
                    KhachHangBUS.Insert_KH(kh);
                    load_data();
                    txtMaKhachHang_PDH.Text=txtTenKHHD.Text = txtTenKH.Text;
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
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
                kh.ten_kh = txtTenKH.Text;
                kh.ma_kh = txtMaKH.Text;
                kh.sdt = txtDTKH.Text;
                kh.diachi = txtDCKH.Text;
                KhachHangBUS.Update_KH(kh);
                load_data();
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
                
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
                txtMaKH.Text = dgvKhachHang.CurrentRow.Cells[0].Value.ToString();
                txtTenKH.Text = dgvKhachHang.CurrentRow.Cells[1].Value.ToString();
                txtDCKH.Text = dgvKhachHang.CurrentRow.Cells[2].Value.ToString();
                txtDTKH.Text = dgvKhachHang.CurrentRow.Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #endregion

        private void dgvDMSanPham_PDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMaSanPham.Text = dgvDMSanPham_PDH.CurrentRow.Cells[0].Value.ToString();
                txtTenSanPham.Text = dgvDMSanPham_PDH.CurrentRow.Cells[2].Value.ToString();
                txtDG.Text = dgvDMSanPham_PDH.CurrentRow.Cells[4].Value.ToString();
                cbxLoaiSP.Text = dgvDMSanPham_PDH.CurrentRow.Cells[1].Value.ToString();
                sp.ma_sp = dgvDMSanPham_PDH.CurrentRow.Cells[0].Value.ToString();
                sp.ten_sp = dgvDMSanPham_PDH.CurrentRow.Cells[2].Value.ToString();
                sp.ma_loai = cbxLoaiSP.SelectedValue.ToString();
                sp.don_vi_tinh = dgvDMSanPham_PDH.CurrentRow.Cells[3].Value.ToString();
                sp.gia = double.Parse(dgvDMSanPham_PDH.CurrentRow.Cells[4].Value.ToString());
                sp.thoi_gian_bh = int.Parse(dgvDMSanPham_PDH.CurrentRow.Cells[5].Value.ToString());
                soluong = int.Parse(dgvDMSanPham_PDH.CurrentRow.Cells[6].Value.ToString());
                sp.hang_san_xuat = dgvDMSanPham_PDH.CurrentRow.Cells[7].Value.ToString();
                txtTT.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSoLuong.Text != "")
                {
                    if (int.Parse(txtSoLuong.Text) > int.Parse(dgvDMSanPham_PDH.CurrentRow.Cells[6].Value.ToString()))
                    {
                        MessageBox.Show("Bạn nhập quá số lượng !", "Thông báo", MessageBoxButtons.OK);
                        txtSoLuong.Focus();
                    }
                    else
                    {
                        double s = double.Parse(txtDG.Text) * double.Parse(txtSoLuong.Text);
                        txtTT.Text = s.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bạn phải nhập số nguyên !", "Thông báo", MessageBoxButtons.OK);
                txtSoLuong.Focus();
            }
        }

        private void btnTimPDH_Click(object sender, EventArgs e)
        {
            try
            {
                SanPhamDTO Sp = new SanPhamDTO();
                Sp.ma_sp = txtMaSanPham_PDH.Text;
                dgvDMSanPham_PDH.DataSource = SanPhamBUS.Search_MaSP(Sp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMa_PDH.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã phiếu !", "Thông báo");
                    txtMa_PDH.Focus();
                }
                else
                {
                    pdh.ma_pdh = txtMa_PDH.Text;
                    thanhtien += double.Parse(txtTT.Text);
                    ChiTietPDHDTO ctpdh = new ChiTietPDHDTO();
                    ctpdh.ma_pdh = txtMa_PDH.Text;
                    ctpdh.ma_sp = txtMaSanPham.Text;
                    ctpdh.soluong = int.Parse(txtSoLuong.Text);
                    ctpdh.thanhtien = double.Parse(txtTT.Text);
                    PhieuDatHangBUS.insert_CTPDH(ctpdh);
                    sp.soluong = soluong - int.Parse(txtSoLuong.Text);
                    SanPhamBUS.Update_SP(sp);
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK);

                    TongTien = TongTien + double.Parse(txtTT.Text.Trim());
                    txtTongthanhtoan.Text = ""+TongTien+"";

                    load_data();
                    txtMaSP.Clear();
                    txtTT.Clear();
                    txtTenSP_PDH.Clear();
                    txtSoLuong.Clear();
                    txtDG.Clear();
                    txtTenSP_PDH.Clear();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnThemCTHD_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMHD.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã phiếu !", "Thông báo");
                    txtMHD.Focus();
                }
                else
                {
                    hd.ma_hd = txtMHD.Text;
                    thanhtienhd += double.Parse(txtThanhTien.Text);
                    ChiTietHoaDonDTO cthd = new ChiTietHoaDonDTO();
                    cthd.ma_hd = txtMHD.Text;
                    cthd.ma_sp = sp.ma_sp = txtMaSP.Text;
                    cthd.soluong = sp.soluong = int.Parse(txtSL.Text);
                    cthd.thanhtien = double.Parse(txtThanhTien.Text);
                    HoaDonBUS.insert_CTHD(cthd);
                    sp.soluong = soluong - int.Parse(txtSL.Text);
                    SanPhamBUS.Update_SP(sp);
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK);

                    TongTien = TongTien + double.Parse(txtThanhTien.Text.Trim());
                    txtTTTHD.Text = "" + TongTien + "";

                    load_data();
                    txtMaSP.Clear();
                    txtThanhTien.Clear();
                    txtTenSP.Clear();
                    txtSL.Clear();
                    txtDonGia.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvDanhMucSP_HD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMaSP.Text = dgvDanhMucSP_HD.CurrentRow.Cells[0].Value.ToString();
                txtTenSP.Text = dgvDanhMucSP_HD.CurrentRow.Cells[2].Value.ToString();
                txtDonGia.Text = dgvDanhMucSP_HD.CurrentRow.Cells[4].Value.ToString();
                cbxlsp.Text = dgvDMSanPham_PDH.CurrentRow.Cells[1].Value.ToString();
                sp.ma_sp = dgvDMSanPham_PDH.CurrentRow.Cells[0].Value.ToString();
                sp.ten_sp = dgvDMSanPham_PDH.CurrentRow.Cells[2].Value.ToString();
                sp.ma_loai = cbxLoaiSP.SelectedValue.ToString();
                sp.don_vi_tinh = dgvDMSanPham_PDH.CurrentRow.Cells[3].Value.ToString();
                sp.gia = double.Parse(dgvDMSanPham_PDH.CurrentRow.Cells[4].Value.ToString());
                sp.thoi_gian_bh = int.Parse(dgvDMSanPham_PDH.CurrentRow.Cells[5].Value.ToString());
                soluong = int.Parse(dgvDMSanPham_PDH.CurrentRow.Cells[6].Value.ToString());
                sp.hang_san_xuat = dgvDMSanPham_PDH.CurrentRow.Cells[7].Value.ToString();
                txtThanhTien.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSL_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSL.Text != "")
                {
                    if (int.Parse(txtSL.Text) > int.Parse(dgvDanhMucSP_HD.CurrentRow.Cells[6].Value.ToString()))
                    {
                        MessageBox.Show("Bạn nhập quá số lượng !", "Thông báo", MessageBoxButtons.OK);
                        txtSoLuong.Focus();
                    }
                    else
                    {
                        double s = double.Parse(txtDonGia.Text) * double.Parse(txtSL.Text);
                        txtThanhTien.Text = s.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bạn phải nhập số nguyên !", "Thông báo", MessageBoxButtons.OK);
                txtSoLuong.Focus();
            }
        }

        private void btnThem_HD_Click(object sender, EventArgs e)
        {
            try
            {
                TongTien = 0;
                HoaDonDTO hd = new HoaDonDTO();
                hd.year = dtpNgayLapHD.Value.Year;
                hd.month = dtpNgayLapHD.Value.Month;
                hd.day = dtpNgayLapHD.Value.Day;
                hd.ma_hd = txtMHD.Text;

                string ma = txtTenKHHD.Text;
                KhachHangDTO kHang = new KhachHangDTO();
                kHang = KhachHangBUS.Search_KH(ma);
                hd.ma_kh = kHang.ma_kh;

                hd.ma_nv = cbxNVLHD.SelectedValue.ToString();
                HoaDonBUS.insert_HD(hd);
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK);
                load_data();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtTongthanhtoan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                pdh.tonggiatri = double.Parse(txtTongthanhtoan.Text);
                PhieuDatHangBUS.Update_gia(pdh);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtTTTHD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                hd.tonggiatri = double.Parse(txtTTTHD.Text);
                HoaDonBUS.update_gia(hd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThemPDH_Click(object sender, EventArgs e)
        {
            try
            {
                TongTien = 0;

                PhieuDatHangDTO pdh = new PhieuDatHangDTO();
                pdh.year = dtpNgayLap_PDH.Value.Year;
                pdh.month = dtpNgayLap_PDH.Value.Month;
                pdh.day = dtpNgayLap_PDH.Value.Day;
                pdh.ma_pdh = txtMa_PDH.Text;
                
                string ma = txtMaKhachHang_PDH.Text;
                KhachHangDTO kHang = new KhachHangDTO();
                kHang = KhachHangBUS.Search_KH(ma);
                pdh.ma_kh = kHang.ma_kh;
                
                pdh.ma_nv = cbxNhanvien.SelectedValue.ToString();
                PhieuDatHangBUS.Insert_PDH(pdh);
                load_data();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void btnxoaspn_Click(object sender, EventArgs e)
        {
            try
            {
                SanPhamDTO sp = new SanPhamDTO();
                txtMaSanPham.Text = dgvCTPDH.CurrentRow.Cells[1].Value.ToString();
                sp.ma_sp = txtMaSanPham.Text;
                PhieuDatHangDTO pdhn = new PhieuDatHangDTO();
                pdhn.ma_pdh = txtMa_PDH.Text;
                PhieuDatHangBUS.delete_sppdh(sp,pdhn);
                load_data();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SanPhamDTO sp = new SanPhamDTO();
                txtMaSP.Text = dgvCTHD.CurrentRow.Cells[1].Value.ToString();
                sp.ma_sp = txtMaSP.Text;
                HoaDonDTO hdm = new HoaDonDTO();
                hdm.ma_hd = txtMHD.Text;
                HoaDonBUS.delete_sphd(sp,hdm);
                load_data();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnInPDH_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printDocument1.DocumentName = txtMa_PDH.Text+dtpNgayLap_PDH.Text;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                string ma = txtMaKhachHang_PDH.Text;
                KhachHangDTO kHang = new KhachHangDTO();
                kHang = KhachHangBUS.Search_KH(ma);

                int x = 10,y=30;
                e.Graphics.DrawString("PHIẾU ĐẶT HÀNG",new Font("Times New Roman",20),Brushes.Black,new Point(250,x));
                e.Graphics.DrawString("Mã phiếu:" + txtMa_PDH.Text, new Font("Times New Roman", 13), Brushes.Black, new Point(30, x+=20));
                e.Graphics.DrawString("Tên nhân viên:" + cbxNhanvien.Text, new Font("Times New Roman", 13), Brushes.Black, new Point(30, x += 20));
                e.Graphics.DrawString("Mã khách hàng:" + txtMaKhachHang_PDH.Text, new Font("Times New Roman", 13), Brushes.Black, new Point(30, x += 20));
                e.Graphics.DrawString("Tên khách hàng:" + kHang.ten_kh, new Font("Times New Roman", 13), Brushes.Black, new Point(30, x += 20));
                e.Graphics.DrawString("Ngày lập" + dtpNgayLap_PDH.Text, new Font("Times New Roman", 13), Brushes.Black, new Point(30, x += 20));

                e.Graphics.DrawString("Tên sản phẩm", new Font("Times New Roman", 13), Brushes.Black, new Point(30, x += 20));

                e.Graphics.DrawString("Mã sản phẩm -- ", new Font("Times New Roman", 13), Brushes.Black, new Point(30, x += 20));
                e.Graphics.DrawString("Số lượng -- ", new Font("Times New Roman", 13), Brushes.Black, new Point(150, x));
                e.Graphics.DrawString("Giá -- ", new Font("Times New Roman", 13), Brushes.Black, new Point(270, x));
                e.Graphics.DrawString("Thành tiền", new Font("Times New Roman", 13), Brushes.Black, new Point(400, x));

                for (int i = 0; i < dgvCTPDH.RowCount-1; i++)
                {
                    e.Graphics.DrawString(dgvCTPDH.Rows[i].Cells[2].Value.ToString(), new Font("Times New Roman", 13), Brushes.Black, new Point(30, x += 20));

                    e.Graphics.DrawString(dgvCTPDH.Rows[i].Cells[1].Value.ToString() + " -- ", new Font("Times New Roman", 13), Brushes.Black, new Point(30, x += 20));
                    e.Graphics.DrawString(dgvCTPDH.Rows[i].Cells[3].Value.ToString() + " -- ", new Font("Times New Roman", 13), Brushes.Black, new Point(150, x));
                    e.Graphics.DrawString(dgvCTPDH.Rows[i].Cells[4].Value.ToString() + " -- ", new Font("Times New Roman", 13), Brushes.Black, new Point(270, x));
                    e.Graphics.DrawString(dgvCTPDH.Rows[i].Cells[5].Value.ToString(), new Font("Times New Roman", 13), Brushes.Black, new Point(400, x));

                    e.Graphics.DrawString("", new Font("Times New Roman", 13), Brushes.Black, new Point(30, x += 20));
                }
                e.Graphics.DrawString("Tổng: " + txtTongthanhtoan.Text, new Font("Times New Roman", 13), Brushes.Black, new Point(500, x += 20));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnIn_HD_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument2;
            printDocument2.DocumentName = txtMHD.Text+dtpNgayLapHD.Text;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                string ma = txtTenKHHD.Text;
                KhachHangDTO kHang = new KhachHangDTO();
                kHang = KhachHangBUS.Search_KH(ma);

                int x = 10, y = 30;
                e.Graphics.DrawString("HÓA ĐƠN", new Font("Times New Roman", 20), Brushes.Black, new Point(250, x));
                e.Graphics.DrawString("Mã phiếu:" + txtMa_PDH.Text, new Font("Times New Roman", 13), Brushes.Black, new Point(30, x += 20));
                e.Graphics.DrawString("Tên nhân viên:" + cbxNhanvien.Text, new Font("Times New Roman", 13), Brushes.Black, new Point(30, x += 20));
                e.Graphics.DrawString("Mã khách hàng:" + txtMaKhachHang_PDH.Text, new Font("Times New Roman", 13), Brushes.Black, new Point(30, x += 20));
                e.Graphics.DrawString("Tên khách hàng:" + kHang.ten_kh, new Font("Times New Roman", 13), Brushes.Black, new Point(30, x += 20));
                e.Graphics.DrawString("Ngày lập" + dtpNgayLap_PDH.Text, new Font("Times New Roman", 13), Brushes.Black, new Point(30, x += 20));

                e.Graphics.DrawString("Tên sản phẩm", new Font("Times New Roman", 13), Brushes.Black, new Point(30, x += 20));

                e.Graphics.DrawString("Mã sản phẩm -- ", new Font("Times New Roman", 13), Brushes.Black, new Point(30, x += 20));
                e.Graphics.DrawString("Số lượng -- ", new Font("Times New Roman", 13), Brushes.Black, new Point(150, x));
                e.Graphics.DrawString("Giá -- ", new Font("Times New Roman", 13), Brushes.Black, new Point(270, x));
                e.Graphics.DrawString("Thành tiền", new Font("Times New Roman", 13), Brushes.Black, new Point(400, x));
                for (int i = 0; i < dgvCTHD.RowCount - 1; i++)
                {
                    e.Graphics.DrawString(dgvCTHD.Rows[i].Cells[2].Value.ToString(), new Font("Times New Roman", 13), Brushes.Black, new Point(30, x += 20));

                    e.Graphics.DrawString(dgvCTHD.Rows[i].Cells[1].Value.ToString() + " -- ", new Font("Times New Roman", 13), Brushes.Black, new Point(30, x += 20));
                    e.Graphics.DrawString(dgvCTHD.Rows[i].Cells[3].Value.ToString() + " -- ", new Font("Times New Roman", 13), Brushes.Black, new Point(150, x));
                    e.Graphics.DrawString(dgvCTHD.Rows[i].Cells[4].Value.ToString() + " -- ", new Font("Times New Roman", 13), Brushes.Black, new Point(270, x));
                    e.Graphics.DrawString(dgvCTHD.Rows[i].Cells[5].Value.ToString(), new Font("Times New Roman", 13), Brushes.Black, new Point(400, x));

                    e.Graphics.DrawString("", new Font("Times New Roman", 13), Brushes.Black, new Point(30, x += 20));
                }
                e.Graphics.DrawString("Tổng: " + txtTTTHD.Text, new Font("Times New Roman", 13), Brushes.Black, new Point(500, x += 20));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
