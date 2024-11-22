using BLL;
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
    public partial class QuanLyChuyenKhoa : Form
    {
        private BLL_QuanLyChuyenKhoa _QuanLyChuyenKhoaBLL = new BLL_QuanLyChuyenKhoa();
        public QuanLyChuyenKhoa()
        {
            InitializeComponent();
            LoadAllChuyenKhoa();
            DGVCK.CellClick += DGVCK_CellClick; // Đăng ký sự kiện
            errorProviderCK.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }
        private void LoadAllChuyenKhoa()
        {
            List<DTO_QuanLyChuyenKhoa> allChuyenKhoa = _QuanLyChuyenKhoaBLL.GetAllChuyenKhoa();
            DGVCK.DataSource = allChuyenKhoa;
        }
        private void AddChuyenKhoa()
        {
            // Đặt lại ErrorProvider
            errorProviderCK.Clear();

            bool isValid = true;
            if (string.IsNullOrWhiteSpace(txtBoxMaCK.Text))
            {
                errorProviderCK.SetError(txtBoxMaCK, "Vui lòng nhập mã chuyên khoa.");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtBoxTenCK.Text))
            {
                errorProviderCK.SetError(txtBoxTenCK, "Vui lòng nhập tên chuyên khoa.");
                isValid = false;
            }
            if (!isValid)
            {
                return; // Dừng hàm nếu còn trường trống
            }
            if (_QuanLyChuyenKhoaBLL.CheckIdCK(int.Parse(txtBoxMaCK.Text)) == false)
            {
                MessageBox.Show("Mã chuyên khoa bị trùng");
                return;
            }
            int maCK = int.Parse(txtBoxMaCK.Text);
            string tenCK = txtBoxTenCK.Text;



            DTO_QuanLyChuyenKhoa newChuyenKhoa = new DTO_QuanLyChuyenKhoa
            {
                MaCK = maCK,
                TenCK = tenCK,
            };

            bool success = _QuanLyChuyenKhoaBLL.AddChuyenKhoa(newChuyenKhoa);
            if (success)
            {
                MessageBox.Show("Thêm chuyên khoa thành công!");
                LoadAllChuyenKhoa(); // Cập nhật lại danh sách
            }
            else
            {
                MessageBox.Show("Thêm chuyên khoa thất bại.");
            }
        }
        private void DeleteChuyenKhoa()
        {
            // Đặt lại ErrorProvider
            errorProviderCK.Clear();

            // Kiểm tra tính hợp lệ của mã chuyên khoa
            if (string.IsNullOrWhiteSpace(txtBoxMaCK.Text))
            {
                errorProviderCK.SetError(txtBoxMaCK, "Vui lòng nhập mã chuyên khoa.");
                return;
            }
            else if (!int.TryParse(txtBoxMaCK.Text, out int maCK))
            {
                errorProviderCK.SetError(txtBoxMaCK, "Mã chuyên khoa phải là số.");
                return;
            }

            // Xác nhận xóa
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa chuyên khoa này không?",
                                                 "Xác nhận xóa",
                                                 MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.No)
            {
                return; // Dừng hàm nếu người dùng không xác nhận
            }

            int MaCK = int.Parse(txtBoxMaCK.Text);

            // Gọi hàm xóa chuyên khoa từ BLL
            bool success = _QuanLyChuyenKhoaBLL.DeleteChuyenKhoa(MaCK);
            if (success)
            {
                MessageBox.Show("Xóa chuyên khoa thành công!");
                LoadAllChuyenKhoa(); // Cập nhật lại danh sách
            }
            else
            {
                MessageBox.Show("Xóa chuyên khoa thất bại.");
            }
        }
        private void UpdateChuyenKhoa()
        {
            // Đặt lại ErrorProvider
            errorProviderCK.Clear();

            bool isValid = true;

            // Kiểm tra tính hợp lệ của mã chuyên khoa
            if (string.IsNullOrWhiteSpace(txtBoxMaCK.Text))
            {
                errorProviderCK.SetError(txtBoxMaCK, "Vui lòng nhập mã chuyên khoa.");
                isValid = false;
            }
            else if (!int.TryParse(txtBoxMaCK.Text, out int maCK))
            {
                errorProviderCK.SetError(txtBoxMaCK, "Mã chuyên khoa phải là số.");
                isValid = false;
            }

            // Kiểm tra tính hợp lệ của tên chuyên khoa
            if (string.IsNullOrWhiteSpace(txtBoxTenCK.Text))
            {
                errorProviderCK.SetError(txtBoxTenCK, "Vui lòng nhập tên chuyên khoa.");
                isValid = false;
            }

            // Nếu có lỗi, dừng hàm
            if (!isValid)
            {
                return;
            }

            int MaCK = int.Parse(txtBoxMaCK.Text);

            // Tạo đối tượng DTO cho chuyên khoa cần sửa
            DTO_QuanLyChuyenKhoa updatedChuyenKhoa = new DTO_QuanLyChuyenKhoa
            {
                MaCK = MaCK,
                TenCK = txtBoxTenCK.Text.Trim(),
            };

            // Gọi hàm sửa chuyên khoa từ BLL
            bool success = _QuanLyChuyenKhoaBLL.UpdateChuyenKhoa(updatedChuyenKhoa);
            if (success)
            {
                MessageBox.Show("Cập nhật chuyên khoa thành công!");
                LoadAllChuyenKhoa(); // Cập nhật lại danh sách
            }
            else
            {
                MessageBox.Show("Cập nhật chuyên khoa thất bại.");
            }
        }
        private void SearchChuyenKhoa()
        {
            // Đặt lại ErrorProvider
            errorProviderCK.Clear();

            // Lấy từ khóa tìm kiếm

            if (string.IsNullOrWhiteSpace(txtBoxTimCK.Text))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.");
                return;
            }

            int keyword = int.Parse(txtBoxTimCK.Text);
            // Gọi hàm tìm kiếm từ BLL
            var results = _QuanLyChuyenKhoaBLL.GetChuyenKhoaByMaCK(keyword);
            if (results != null)
            {
                DGVCK.DataSource = results; // Cập nhật DataGridView với kết quả tìm kiếm
            }
            else
            {
                MessageBox.Show("Không tìm thấy chuyên khoa nào.");
                LoadAllChuyenKhoa(); // Cập nhật lại danh sách nếu không tìm thấy
            }
        }

        private void btnThemCK_Click(object sender, EventArgs e)
        {
            AddChuyenKhoa();
        }

        private void btnXoaCK_Click(object sender, EventArgs e)
        {
            DeleteChuyenKhoa();
        }

        private void btnSuaCK_Click(object sender, EventArgs e)
        {
            UpdateChuyenKhoa();
        }

        private void btnTimCK_Click(object sender, EventArgs e)
        {
            SearchChuyenKhoa();
        }

        private void DGVCK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng có nhấn vào một dòng hợp lệ không
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DGVCK.Rows[e.RowIndex];

                // Cập nhật các trường nhập liệu từ các ô trong dòng đã chọn
                txtBoxMaCK.Text = row.Cells["MaCK"].Value.ToString(); // Thay "MaBS" bằng tên cột thực tế
                txtBoxTenCK.Text = row.Cells["TenCK"].Value.ToString(); // Thay "TenBS" bằng tên cột thực tế
                
            }
        }
    }
}
