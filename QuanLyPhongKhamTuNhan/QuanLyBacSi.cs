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
    public partial class QuanLyBacSi : Form
    {
        private BLL_QuanLyBacSi _QuanLyBacSiBLL = new BLL_QuanLyBacSi();
        public QuanLyBacSi()
        {
            InitializeComponent();
            LoadData();
            DGVBS.CellClick += DGVBS_CellClick;
            DataHelper dbHelper = new DataHelper();
            List<DTO_QuanLyChuyenKhoa> chuyenKhoaList = dbHelper.GetChuyenKhoaList();
            cboChuyenKhoaBS.DataSource = chuyenKhoaList;
            cboChuyenKhoaBS.DisplayMember = "TenCK";
            cboChuyenKhoaBS.ValueMember = "MaCK";
            errorProviderBS.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }
        private void LoadData()
        {
            List<DTO_QuanLyBacSi> danhSachBacSi = _QuanLyBacSiBLL.GetAllBacSi();
            DGVBS.DataSource = danhSachBacSi;
        }

        private void btnThemBS_Click(object sender, EventArgs e)
        {
            try
            {
                // Đặt lại ErrorProvider
                errorProviderBS.Clear();

                // Kiểm tra các trường và đặt thông báo lỗi nếu cần
                bool isValid = true;
                if (string.IsNullOrWhiteSpace(txtBoxTenBS.Text))
                {
                    errorProviderBS.SetError(txtBoxTenBS, "Vui lòng nhập họ tên.");
                    isValid = false;
                }
                if (cboGTBS.SelectedItem == null)
                {
                    errorProviderBS.SetError(cboGTBS, "Vui lòng chọn giới tính.");
                    isValid = false;
                }
                if (string.IsNullOrWhiteSpace(txtBoxEmailBS.Text))
                {
                    errorProviderBS.SetError(txtBoxEmailBS, "Vui lòng nhập email.");
                    isValid = false;
                }
                if (string.IsNullOrWhiteSpace(txtBoxSDTBS.Text))
                {
                    errorProviderBS.SetError(txtBoxSDTBS, "Vui lòng nhập số điện thoại.");
                    isValid = false;
                }
                if (string.IsNullOrWhiteSpace(txtBoxKNBS.Text))
                {
                    errorProviderBS.SetError(txtBoxKNBS, "Vui lòng nhập kinh nghiệm.");
                    isValid = false;
                }

                // Kiểm tra nếu tất cả các trường đều hợp lệ
                if (!isValid)
                {
                    return; // Dừng hàm nếu còn trường trống
                }

                // Kiểm tra định dạng số và email
                if (!int.TryParse(txtBoxKNBS.Text, out int kinhNghiem))
                {
                    errorProviderBS.SetError(txtBoxKNBS, "Kinh nghiệm phải là số.");
                    return;
                }

                DTO_QuanLyBacSi bacSi = new DTO_QuanLyBacSi
                {
                    TenBS = txtBoxTenBS.Text.Trim(),
                    GioiTinh = cboGTBS.Text,
                    Email = txtBoxEmailBS.Text.Trim(),
                    SoDT = txtBoxSDTBS.Text.Trim(),
                    KinhNghiem = kinhNghiem,
                    MaCK = (int)cboChuyenKhoaBS.SelectedValue
                };

                try
                {
                    bool isAdded = _QuanLyBacSiBLL.AddBacSi(bacSi);
                    if (isAdded)
                    {
                        MessageBox.Show("Thêm bác sĩ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        // Xóa các trường sau khi thêm thành công
                        ResetForm();
                    }
                }
                catch (ArgumentException ex)
                {
                    // Hiển thị lỗi cụ thể từ BLL
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    // Bắt các lỗi không mong muốn
                    MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không xác định: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaBS_Click(object sender, EventArgs e)
        {
            // Đặt lại ErrorProvider
            errorProviderBS.Clear();
            // Kiểm tra các trường và đặt thông báo lỗi nếu cần
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(txtBoxMaBS.Text))
            {
                errorProviderBS.SetError(txtBoxMaBS, "Vui lòng nhập mã bác sĩ.");
                isValid = false;
            }
            // Kiểm tra nếu tất cả các trường đều hợp lệ
            if (!isValid)
            {
                return; // Dừng hàm nếu còn trường trống
            }
            int maBS = int.Parse(txtBoxMaBS.Text);
            bool isDeleted = _QuanLyBacSiBLL.DeleteBacSi(maBS);
            if (isDeleted)
            {
                MessageBox.Show("Xóa bác sĩ thành công!");
                LoadData();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi xóa bác sĩ.");
            }
        }

        private void btnSuaBS_Click(object sender, EventArgs e) // fix lại ko được để trống các trường khi nhấn sửa
        {
            if (string.IsNullOrWhiteSpace(txtBoxMaBS.Text) ||
                string.IsNullOrWhiteSpace(txtBoxTenBS.Text) ||
                string.IsNullOrWhiteSpace(txtBoxEmailBS.Text) ||
                string.IsNullOrWhiteSpace(txtBoxKNBS.Text) ||
                string.IsNullOrWhiteSpace(txtBoxSDTBS.Text) ||
                cboGTBS.SelectedIndex == -1 || // Kiểm tra ComboBox giới tính
                cboChuyenKhoaBS.SelectedIndex == -1) // Kiểm tra ComboBox chuyên khoa
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                return;
            }
            DTO_QuanLyBacSi bacSi = new DTO_QuanLyBacSi
            {
                MaBS = int.Parse(txtBoxMaBS.Text),
                TenBS = txtBoxTenBS.Text,
                GioiTinh = cboGTBS.Text,
                Email = txtBoxEmailBS.Text,
                SoDT = txtBoxSDTBS.Text,
                KinhNghiem = int.Parse(txtBoxKNBS.Text),
                MaCK = (int)cboChuyenKhoaBS.SelectedValue
            };

            bool isUpdated = _QuanLyBacSiBLL.UpdateBacSi(bacSi);
            if (isUpdated)
            {
                MessageBox.Show("Sửa bác sĩ thành công!");
                LoadData();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi sửa bác sĩ.");
            }
        }

        private void btnTimBS_Click(object sender, EventArgs e)
        {
            // Đặt lại ErrorProvider
            errorProviderBS.Clear();
            // Kiểm tra các trường và đặt thông báo lỗi nếu cần
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(txtBoxTimBS.Text))
            {
                errorProviderBS.SetError(txtBoxTimBS, "Vui lòng nhập mã bác sĩ.");
                isValid = false;
            }
            // Kiểm tra nếu tất cả các trường đều hợp lệ
            if (!isValid)
            {
                return; // Dừng hàm nếu còn trường trống
            }
            string SDTBS = txtBoxTimBS.Text;
            List<DTO_QuanLyBacSi> bacSiTimThay = _QuanLyBacSiBLL.FindBacSiBySDT(SDTBS);
            DGVBS.DataSource = bacSiTimThay;
        }

        private void DGVBS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu click vào hàng hợp lệ
            if (e.RowIndex >= 0)
            {
                // Lấy hàng được chọn
                DataGridViewRow row = DGVBS.Rows[e.RowIndex];

                txtBoxMaBS.Text = row.Cells["MaBS"].Value.ToString();
                txtBoxTenBS.Text = row.Cells["TenBS"].Value.ToString();

                // Gán giá trị cho ComboBox Giới Tính
                cboGTBS.SelectedItem = row.Cells["GioiTinh"].Value.ToString();

                txtBoxEmailBS.Text = row.Cells["Email"].Value.ToString();
                txtBoxSDTBS.Text = row.Cells["SoDT"].Value.ToString();
                txtBoxKNBS.Text = row.Cells["KinhNghiem"].Value.ToString();

                // Gán giá trị cho ComboBox Mã Chuyên Khoa bằng SelectedValue
                int maCK = Convert.ToInt32(row.Cells["MaCK"].Value);
                cboChuyenKhoaBS.SelectedValue = maCK;
            }
        }

        private void ResetForm()
        {
            txtBoxMaBS.Clear();
            txtBoxTenBS.Clear();
            txtBoxEmailBS.Clear();
            txtBoxSDTBS.Clear();
            txtBoxKNBS.Clear();
            txtBoxTimBS.Clear();
            cboGTBS.SelectedIndex = -1;
            cboChuyenKhoaBS.SelectedIndex = -1;
            LoadData();

        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void QuanLyBacSi_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và các phím điều khiển (Backspace, Delete, vv)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho nhập ký tự
            }
        }
    }
}
