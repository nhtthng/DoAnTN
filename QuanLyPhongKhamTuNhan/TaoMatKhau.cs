using BLL;
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
    public partial class TaoMatKhau : Form
    {
        private string email; // Biến để lưu email
        private BLL_QuenMatKhau _QuenMatKhau = new BLL_QuenMatKhau();
        public TaoMatKhau()
        {
            InitializeComponent();
        }

        public TaoMatKhau(string Email)
        {
            InitializeComponent();
            this.email = email; // Lưu email vào biến
            txtBoxEmail.Text = email; // Hiển thị email trong TextBox (nếu cần)
            txtBoxEmail.Enabled = false; // Khóa TextBox nếu không muốn người dùng chỉnh sửa
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy mật khẩu mới và mật khẩu xác nhận từ TextBox
                string newPassword = txtBoxMatKhauMoi.Text; // TextBox nhập mật khẩu mới
                string confirmPassword = txtBoxXacNhanMK.Text; // TextBox xác nhận mật khẩu mới

                // Kiểm tra xem mật khẩu mới có hợp lệ không (ví dụ: không rỗng)
                if (string.IsNullOrWhiteSpace(newPassword))
                {
                    MessageBox.Show("Mật khẩu mới không được để trống.");
                    return;
                }

                // Kiểm tra xem mật khẩu xác nhận có khớp với mật khẩu mới không
                if (newPassword != confirmPassword)
                {
                    MessageBox.Show("Mật khẩu xác nhận không khớp với mật khẩu mới. Vui lòng kiểm tra lại.");
                    return;
                }

                // Gọi phương thức trong BLL để đặt lại mật khẩu
                bool result = _QuenMatKhau.ChangePassword(email, newPassword);

                // Thông báo cho người dùng về kết quả
                if (result)
                {
                    MessageBox.Show("Đổi mật khẩu thành công.");
                    this.Close(); // Đóng form sau khi thành công
                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu không thành công. Vui lòng kiểm tra lại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
    }
}
