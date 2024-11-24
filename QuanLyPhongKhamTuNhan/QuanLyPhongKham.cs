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
    public partial class Quanlyphongkham : Form
    {
        private BLL_QuanLyPhongKham _QuanLyPhongKhamBLL = new BLL_QuanLyPhongKham();
        public Quanlyphongkham()
        {
            InitializeComponent();
            DataHelper dbHelper = new DataHelper();
            List<DTO_QuanLyChuyenKhoa> chuyenKhoaList = dbHelper.GetChuyenKhoaList();
            cboMaCK.DataSource = chuyenKhoaList;
            cboMaCK.DisplayMember = "TenCK";
            cboMaCK.ValueMember = "MaCK";
            LoadDataGridView();
            DGVPK.CellClick += DGVPK_CellClick;

        }
        private void LoadDataGridView()
        {
            var phongKhams = _QuanLyPhongKhamBLL.GetAllPhongKham();
            DGVPK.DataSource = phongKhams;
        }

        private void btnThemPK_Click(object sender, EventArgs e)
        {
            // Đặt lại ErrorProvider
            errorProviderPK.Clear();
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(txtBoxTenPK.Text))
            {
                errorProviderPK.SetError(txtBoxTenPK, "Vui lòng nhập tên phòng khám.");
                isValid = false;
            }
            if (cboMaCK.SelectedItem == null)
            {
                errorProviderPK.SetError(cboMaCK, "Vui lòng chọn mã chuyên khoa.");
                isValid = false;
            }
            // Kiểm tra nếu tất cả các trường đều hợp lệ
            if (!isValid)
            {
                return; // Dừng hàm nếu còn trường trống
            }
            if (_QuanLyPhongKhamBLL.checkTenClinic(txtBoxMaPK.Text) == false)
            {
                MessageBox.Show("Tên phòng khám bị trùng");
                return;
            }
            DTO_QuanLyPhongKham phongKham = new DTO_QuanLyPhongKham
            {
                TenPK = txtBoxTenPK.Text,
                MaCK = (int)cboMaCK.SelectedValue
            };

            if (_QuanLyPhongKhamBLL.AddPhongKham(phongKham))
            {
                MessageBox.Show("Thêm phòng khám thành công!");
                LoadDataGridView(); // Tải lại danh sách
            }
            else
            {
                MessageBox.Show("Thêm phòng khám thất bại!");
            }
        }

        private void btnXoaPK_Click(object sender, EventArgs e)
        {
            // Đặt lại ErrorProvider
            errorProviderPK.Clear();
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(txtBoxMaPK.Text))
            {
                errorProviderPK.SetError(txtBoxMaPK, "Vui lòng nhập mã phòng khám.");
                isValid = false;
            }
            // Kiểm tra nếu tất cả các trường đều hợp lệ
            if (!isValid)
            {
                return; // Dừng hàm nếu còn trường trống
            }
            int maPK = int.Parse(txtBoxMaPK.Text);
            if (_QuanLyPhongKhamBLL.DeletePhongKham(maPK))
            {
                MessageBox.Show("Xóa phòng khám thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGridView(); // Tải lại danh sách
            }
            else
            {
                MessageBox.Show("Xóa phòng khám không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSuaPK_Click(object sender, EventArgs e)
        {
            // Đặt lại ErrorProvider
            errorProviderPK.Clear();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtBoxMaPK.Text))
            {
                errorProviderPK.SetError(txtBoxMaPK, "Vui lòng nhập mã phòng khám.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtBoxTenPK.Text))
            {
                errorProviderPK.SetError(txtBoxTenPK, "Vui lòng nhập tên phòng khám.");
                isValid = false;
            }


            if (cboMaCK.SelectedItem == null)
            {
                errorProviderPK.SetError(cboMaCK, "Vui lòng chọn mã chuyên khoa.");
                isValid = false;
            }

            // Kiểm tra nếu tất cả các trường đều hợp lệ
            if (!isValid)
            {
                return; // Dừng hàm nếu còn trường trống
            }

            DTO_QuanLyPhongKham phongKham = new DTO_QuanLyPhongKham
            {
                MaPK = int.Parse(txtBoxMaPK.Text),
                TenPK = txtBoxTenPK.Text,
                MaCK = (int)cboMaCK.SelectedValue
            };

            if (_QuanLyPhongKhamBLL.UpdatePhongKham(phongKham))
            {
                MessageBox.Show("Cập nhật phòng khám thành công!");
                LoadDataGridView(); // Tải lại danh sách
            }
            else
            {
                MessageBox.Show("Cập nhật phòng khám thất bại!");
            }
        }

        private void btnTimPK_Click(object sender, EventArgs e)
        {
            // Đặt lại ErrorProvider
            errorProviderPK.Clear();
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(txtBoxTimPK.Text))
            {
                errorProviderPK.SetError(txtBoxTimPK, "Vui lòng nhập tên phòng khám.");
                isValid = false;
            }
            // Kiểm tra nếu tất cả các trường đều hợp lệ
            if (!isValid)
            {
                return; // Dừng hàm nếu còn trường trống
            }

            string tenPK = txtBoxTimPK.Text.Trim();

            // Tìm kiếm phòng khám theo tên
            DTO_QuanLyPhongKham phongkham = _QuanLyPhongKhamBLL.GetPhongKhamByTenPK(tenPK);

            // Nếu tìm thấy, hiển thị thông tin vào các trường
            if (phongkham != null)
            {
                // Tạo danh sách để chứa kết quả tìm kiếm
                List<DTO_QuanLyPhongKham> searchResult = new List<DTO_QuanLyPhongKham> { phongkham };
                DGVPK.DataSource = searchResult; // Đổ dữ liệu vào DataGridView
            }
            else
            {
                MessageBox.Show("Không tìm thấy phòng khám!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadDataGridView(); // Tải lại danh sách đầy đủ nếu không tìm thấy
            }
        }

        private void DGVPK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng không nhấn vào tiêu đề cột
            if (e.RowIndex >= 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow row = DGVPK.Rows[e.RowIndex];

                // Gán giá trị từ các ô trong dòng vào các trường tương ứng
                txtBoxMaPK.Text = row.Cells["MaPK"].Value.ToString(); // Thay "MaPK" bằng tên cột thực tế
                txtBoxTenPK.Text = row.Cells["TenPK"].Value.ToString(); // Thay "TenPK" bằng tên cột thực tế
                cboMaCK.SelectedValue = row.Cells["MaCK"].Value; // Thay "MaCK" bằng tên cột thực tế
            }
        }
    }
}
