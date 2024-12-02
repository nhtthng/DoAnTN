using BLL;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class TiepNhan : Form
    {
        private BLL_QuanLyTiepNhan _QuanLyTiepNhanBLL = new BLL_QuanLyTiepNhan();
        public TiepNhan()
        {
            InitializeComponent();
            DataHelper dbhelper = new DataHelper();
            List<DTO_QuanLyBenhNhan> benhNhanList = dbhelper.GetBenhNhanList();
            cboMaBenhNhan.DataSource = benhNhanList;
            cboMaBenhNhan.DisplayMember = "HoTenBN";
            cboMaBenhNhan.ValueMember = "MaBN";
            List<DTO_QuanLyPhongKham> phongKhamList = dbhelper.GetPhongKhamList();
            cboPhongKham.DataSource = phongKhamList;
            cboPhongKham.DisplayMember = "TenPK";
            cboPhongKham.ValueMember = "MaPK";
        }
        // Hiển thị danh sách tất cả các bệnh nhân đã tiếp nhận

        public void SetPatientId(int patientId)
        {
            cboMaBenhNhan.SelectedValue = patientId;
        }

        private void LoadAllTiepNhan()
        {
            try
            {
                var tiepNhanList = _QuanLyTiepNhanBLL.GetAllTiepNhan();
                DGVTiepNhan.DataSource = tiepNhanList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy danh sách tiếp nhận: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var tiepNhan = new DTO_QuanLyTiepNhan
                {
                    MaBenhNhan = (int)cboMaBenhNhan.SelectedValue,
                    NgayTiepNhan = DTPNgayTiepNhan.Value,
                    GioTiepNhan = DTPGioTiepNhan.Value.TimeOfDay,
                    TrieuChung = txtBoxTrieuChung.Text,
                    MaPK = (int)cboPhongKham.SelectedValue,
                };

                if (_QuanLyTiepNhanBLL.ThemTiepNhan(tiepNhan))
                {
                    MessageBox.Show("Thêm tiếp nhận thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllTiepNhan();
                }
                else
                {
                    MessageBox.Show("Thêm tiếp nhận thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Lỗi khi thêm tiếp nhận: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int maTiepNhan = int.Parse(txtBoxMaTN.Text);

                if (_QuanLyTiepNhanBLL.XoaTiepNhan(maTiepNhan))
                {
                    MessageBox.Show("Xóa tiếp nhận thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllTiepNhan();
                }
                else
                {
                    MessageBox.Show("Xóa tiếp nhận thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Lỗi khi xóa tiếp nhận: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                var tiepNhan = new DTO_QuanLyTiepNhan
                {
                    MaTiepNhan = int.Parse(txtBoxMaTN.Text),
                    MaBenhNhan = (int)cboMaBenhNhan.SelectedValue,
                    NgayTiepNhan = DTPNgayTiepNhan.Value,
                    GioTiepNhan = DTPGioTiepNhan.Value.TimeOfDay,
                    TrieuChung = txtBoxTrieuChung.Text,
                    MaPK = (int)cboPhongKham.SelectedValue
                };

                if (_QuanLyTiepNhanBLL.SuaTiepNhan(tiepNhan))
                {
                    MessageBox.Show("Sửa tiếp nhận thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllTiepNhan();
                }
                else
                {
                    MessageBox.Show("Sửa tiếp nhận thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Lỗi khi sửa tiếp nhận: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtBoxMaTN.Clear();
            txtBoxTimKiem.Clear();
            txtBoxTrieuChung.Clear();
            cboMaBenhNhan.SelectedIndex = -1;
            cboPhongKham.SelectedIndex = -1;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                string soDienThoai = txtBoxTimKiem.Text;
                var tiepNhanList = _QuanLyTiepNhanBLL.TimKiemThongTinTiepNhanTheoDienThoai(soDienThoai);
                DGVTiepNhan.DataSource = tiepNhanList;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
