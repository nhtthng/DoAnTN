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
    public partial class QuanLyNhanVien : Form
    {
        private BLL_QuanLyNhanVien bllNhanVien = new BLL_QuanLyNhanVien();
        private DTO_NhanVien currentNhanVien;
        public QuanLyNhanVien()
        {
            InitializeComponent();
            LoadDanhSachNhanVien();
            var dsPhongBan = new DataHelper().GetPhongBanList();
            cboMaPhongBan.DataSource = dsPhongBan;
            cboMaPhongBan.DisplayMember = "HoTen";
            cboMaPhongBan.ValueMember = "MaNV";
        }
        private void LoadDanhSachNhanVien()
        {
            try
            {
                var danhSachNhanVien = bllNhanVien.GetAllNhanVien();
                DGVQuanLyNV.DataSource = danhSachNhanVien;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                DTO_NhanVien nhanVien = new DTO_NhanVien
                {
                    HoTen = txtBoxHoTen.Text,
                    GioiTinh = cboGioiTinh.SelectedItem?.ToString(),
                    NgaySinh = DTPNgaySinh.Value,
                    SoDT = txtBoxSDT.Text,
                    MaPB = (int)cboMaPhongBan.SelectedValue,
                    Quyen = 1 // Quyền mặc định
                };

                if (bllNhanVien.AddNhanVien(nhanVien))
                {
                    MessageBox.Show("Thêm nhân viên thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachNhanVien();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentNhanVien == null)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên để xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (bllNhanVien.DeleteNhanVien(currentNhanVien.MaNV))
                    {
                        MessageBox.Show("Xóa nhân viên thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachNhanVien();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentNhanVien == null)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên để sửa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                currentNhanVien.HoTen = txtBoxHoTen.Text;
                currentNhanVien.GioiTinh = cboGioiTinh.SelectedItem?.ToString();
                currentNhanVien.NgaySinh = DTPNgaySinh.Value;
                currentNhanVien.SoDT = txtBoxSDT.Text;
                currentNhanVien.MaPB = (int)cboMaPhongBan.SelectedValue;

                if (bllNhanVien.UpdateNhanVien(currentNhanVien))
                {
                    MessageBox.Show("Cập nhật nhân viên thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachNhanVien();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string tuKhoa = txtBoxTimKiem.Text.Trim();
                var ketQua = bllNhanVien.SearchNhanVienBySDT(tuKhoa);

                if (ketQua.Count > 0)
                {
                    DGVQuanLyNV.DataSource = ketQua;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtBoxHoTen.Clear();
            txtBoxMaNV.Clear();
            txtBoxSDT.Clear();
            txtBoxTimKiem.Clear();
            cboGioiTinh.SelectedIndex = -1;
            cboMaPhongBan.SelectedIndex = -1;
        }
    }
}
