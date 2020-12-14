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
    public partial class NhapHang : Form
    {
        public NhapHang()
        {
            InitializeComponent();
        }
        //tạo biến kiểm tra dang nhap va dang xuat
        public string str;
        public string STR
        {
            get { return str; }
            set { str = value; }
        }
        private bool RB(string str)
        {
            if (str == "")
                return false;
            return true;
        }
        //biến tính tổng giá trị của 1 phiếu nhập
        double thanhtien = 0;
        double TongTien = 0;
        //biến dùng để tạo 1 phiếu nhập mới
        bool check = true;

        //DTO
        PhieuNhapDTO pnh = new PhieuNhapDTO();

        private void button2_Click_2(object sender, EventArgs e)
        {
            try
            {
                TongTien = 0;
                PhieuNhapDTO PN = new PhieuNhapDTO();
                PN.year = dtpPN.Value.Year;
                PN.month = dtpPN.Value.Month;
                PN.day = dtpPN.Value.Day;
                PN.ma_phieu_nhap = txtMaPN.Text;
                /*
                string ma = txtTenKHHD.Text;
                KhachHangDTO kHang = new KhachHangDTO();
                kHang = KhachHangBUS.Search_KH(ma);
                hd.ma_kh = kHang.ma_kh;
                */
                PN.ma_ncc = cbxNCC.SelectedValue.ToString();
                PN.ma_nv = cbxNVLPN.SelectedValue.ToString();
                PhieuNhapBUS.Insert_PN(PN);
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK);
                load_data();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThemsp_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaPN.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã phiếu !", "Thông báo");
                    txtMaPN.Focus();
                }
                else
                { 
                    pnh.ma_phieu_nhap = txtMaPN.Text;
                    ChiTietPNDTO ctpn = new ChiTietPNDTO();
                    ctpn.ma_phieu_nhap = txtMaPN.Text;
                    ctpn.ma_sp = txtMSP.Text;
                    ctpn.soluong = int.Parse(txtSL.Text);
                    ctpn.gianhap = double.Parse(txtGSP.Text);
                    ctpn.tong = ctpn.soluong * ctpn.gianhap;

                    PhieuNhapBUS.Insert_CTPN(ctpn);
                    SanPhamDTO sp = new SanPhamDTO();
                    sp = SanPhamBUS.Search_SP(ctpn.ma_sp);
                    sp.soluong = sp.soluong + ctpn.soluong;
                    txtDVT.Text = sp.ma_loai;
                    SanPhamBUS.Update_SP(sp);
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK);

                    TongTien = TongTien + ctpn.tong;
                    txtTongthanhtoan.Text = "" + TongTien + "";

                    load_data();
                }
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
                PhieuNhapDTO pn = new PhieuNhapDTO();
                pn.ma_phieu_nhap = txtMaPN.Text;
                pn.tongtien = long.Parse(txtTongthanhtoan.Text);
                PhieuNhapBUS.Update_PN(pn);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NhapHang_Load(object sender, EventArgs e)
        {
            load_data();
        }
        void load_data()
        {
            PhieuNhapDTO pn = new PhieuNhapDTO();
            pn.ma_phieu_nhap = txtMaPN.Text;
            dgvSanPham.DataSource= SanPhamBUS.Load_DSSP();
            cbxLSP.DataSource = cbxLoaiSP.DataSource = LoaiSanPhamBUS.Load_DSLSP();
            dgvChitietPN.DataSource = PhieuNhapBUS.Load_DSMaPN(pnh);
            cbxLSP.DisplayMember = cbxLoaiSP.DisplayMember = "ten_loai_sp";
            cbxLSP.ValueMember = cbxLoaiSP.ValueMember = "ma_loai";
            cbxNVLPN.DataSource = NhanVienBUS.GetDSNV();
            cbxNVLPN.DisplayMember = "ten_nv";
            cbxNVLPN.ValueMember = "ma_nv";
            cbxNCC.DataSource = NhaCCBUS.Load_DSNCC();
            cbxNCC.DisplayMember = "ten_ncc";
            cbxNCC.ValueMember = "ma_ncc";
            groupBox2.Enabled = false;
        }
        #region Sản phẩm
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
            /// <summary>
            /// thực biện tìm kiếm sản phẩm
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
        
        }

        private void btnSuaSP_Click_1(object sender, EventArgs e)
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
                sp.don_vi_tinh = txtDVTSP.Text;
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

        private void btnTimsp_Click(object sender, EventArgs e)
        {
            try
            {
                SanPhamDTO sp = new SanPhamDTO();
                LoaiSanPhamDTO loaisp = new LoaiSanPhamDTO();
                if (cbxTimTheoSP.SelectedIndex == 0)
                {
                    sp.ma_sp = txtTimTheosp.Text;
                    if (SanPhamBUS.Search_MaSP(sp).Rows.Count == 0)
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

        private void cbxTimTheoSP_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbxTimTheoSP.SelectedIndex == 0)
                lblTimSP.Text = "Nhập mã sản phẩm:";
            if (cbxTimTheoSP.SelectedIndex == 1)
                lblTimSP.Text = "Nhập loại sản phẩm:";
            if (cbxTimTheoSP.SelectedIndex == 2)
                lblTimSP.Text = "Nhập tên sản phẩm:";
            if (cbxTimTheoSP.SelectedIndex == 3)
                lblTimSP.Text = "Nhập hãng sản xuất sản phẩm:";
        }
        #endregion

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMasp.Text = dgvSanPham.CurrentRow.Cells[0].Value.ToString();
                txtTenSP.Text = dgvSanPham.CurrentRow.Cells[2].Value.ToString();
                cbxLoaiSP.Text = dgvSanPham.CurrentRow.Cells[1].Value.ToString();
                txtDVTSP.Text = dgvSanPham.CurrentRow.Cells[3].Value.ToString();
                txtGiasp.Text = dgvSanPham.CurrentRow.Cells[4].Value.ToString();
                txtTGBH.Text = dgvSanPham.CurrentRow.Cells[5].Value.ToString();
                txtSLSP.Text = dgvSanPham.CurrentRow.Cells[6].Value.ToString();
                txtHSXSP.Text = dgvSanPham.CurrentRow.Cells[7].Value.ToString();
            }
            catch (Exception ex)
            {
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                groupBox2.Enabled = true;
            else
                groupBox2.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void btn_xoaspn_Click(object sender, EventArgs e)
        {
            try
            {
                SanPhamDTO sp = new SanPhamDTO();
                txtMSP.Text = dgvChitietPN.CurrentRow.Cells[1].Value.ToString();
                sp.ma_sp = txtMSP.Text;
                PhieuNhapDTO pnm = new PhieuNhapDTO();
                pnm.ma_phieu_nhap = txtMaPN.Text;
                PhieuNhapBUS.delete_sppn(sp, pnm);
                load_data();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printDocument1.DocumentName = txtMaPN.Text + dtpPN.Text;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                int x = 10, y = 30;
                e.Graphics.DrawString("PHIẾU ĐẶT HÀNG", new Font("Times New Roman", 20), Brushes.Black, new Point(250, x));
                e.Graphics.DrawString("Mã phiếu:" + txtMaPN.Text, new Font("Times New Roman", 13), Brushes.Black, new Point(30, x += 20));
                e.Graphics.DrawString("Tên nhân viên:" + cbxNVLPN.Text, new Font("Times New Roman", 13), Brushes.Black, new Point(30, x += 20));
                if (checkBox1.Checked)
                {
                    e.Graphics.DrawString("Tên nhà cung cấp:" + txtTenNCC.Text, new Font("Times New Roman", 13), Brushes.Black, new Point(30, x += 20));
                }
                else
                    e.Graphics.DrawString("Tên nhà cung cấp:" + cbxNCC.Text, new Font("Times New Roman", 13), Brushes.Black, new Point(30, x += 20));
                e.Graphics.DrawString("Ngày lập" + dtpPN.Text, new Font("Times New Roman", 13), Brushes.Black, new Point(30, x += 20));
                e.Graphics.DrawString("Tên sản phẩm", new Font("Times New Roman", 13), Brushes.Black, new Point(30, x += 20));

                e.Graphics.DrawString("Mã sản phẩm -- ", new Font("Times New Roman", 13), Brushes.Black, new Point(30, x += 20));
                e.Graphics.DrawString("Số lượng -- ", new Font("Times New Roman", 13), Brushes.Black, new Point(150, x));
                e.Graphics.DrawString("Giá -- ", new Font("Times New Roman", 13), Brushes.Black, new Point(270, x));
                e.Graphics.DrawString("Thành tiền -- ", new Font("Times New Roman", 13), Brushes.Black, new Point(400, x));
                e.Graphics.DrawString("", new Font("Times New Roman", 13), Brushes.Black, new Point(30, x += 20));
                for (int i = 0; i < dgvChitietPN.RowCount - 1; i++)
                {
                    e.Graphics.DrawString(dgvChitietPN.Rows[i].Cells[2].Value.ToString(), new Font("Times New Roman", 13), Brushes.Black, new Point(30, x +=20));

                    e.Graphics.DrawString(dgvChitietPN.Rows[i].Cells[1].Value.ToString() + " -- ", new Font("Times New Roman", 13), Brushes.Black, new Point(30, x += 20));
                    e.Graphics.DrawString(dgvChitietPN.Rows[i].Cells[3].Value.ToString() + " -- ", new Font("Times New Roman", 13), Brushes.Black, new Point(150, x));
                    e.Graphics.DrawString(dgvChitietPN.Rows[i].Cells[4].Value.ToString() + " -- ", new Font("Times New Roman", 13), Brushes.Black, new Point(270, x));
                    e.Graphics.DrawString(dgvChitietPN.Rows[i].Cells[5].Value.ToString(), new Font("Times New Roman", 13), Brushes.Black, new Point(400, x));
                    e.Graphics.DrawString("", new Font("Times New Roman", 13), Brushes.Black, new Point(30, x += 20));
                }
                e.Graphics.DrawString("Tổng: " + txtTongthanhtoan.Text, new Font("Times New Roman", 13), Brushes.Black, new Point(500, x += 20));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            NhaCCDTO ncc = new NhaCCDTO();
            ncc.ma_ncc = txtMaNCC.Text;
            ncc.ten_ncc = txtTenNCC.Text;
            ncc.email = txtEmailNCC.Text;
            ncc.sdt_ncc = txtSDTNCC.Text;
            NhaCCBUS.Insert_NCC(ncc);
            txtMaNCC.Clear();
            txtTenNCC.Clear();
            txtEmailNCC.Clear();
            txtSDTNCC.Clear();
            load_data();
        }
    }
}
