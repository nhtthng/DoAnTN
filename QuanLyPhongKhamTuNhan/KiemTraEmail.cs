using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using BLL;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
namespace GUI
{
    public partial class KiemTraEmail : Form
    {
        private string generatedToken; // Mã xác nhận
        private DateTime tokenExpiration; // Thời gian hết hạn
        private BLL_QuenMatKhau _BLLQuenMatKhau = new BLL_QuenMatKhau();
        public KiemTraEmail()
        {
            InitializeComponent();
        }

        private void SendEmail(string toEmail, string token)
        {
            string fromEmail = "nhatthang2812@gmail.com"; // Địa chỉ email gửi
            string fromPassword = "ThangNhat28122003"; // Mật khẩu email gửi
            string subject = "Mã xác nhận";
            string body = $"Mã xác nhận của bạn là: {token}. Vui lòng nhập mã này để xác nhận.";

            try
            {
                // Tạo một đối tượng MimeMessage
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Tên của bạn", fromEmail));
                message.To.Add(new MailboxAddress("Người nhận", toEmail));
                message.Subject = subject;
                message.Body = new TextPart("plain") { Text = body };

                // Gửi email
                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    client.Authenticate(fromEmail, fromPassword);
                    client.Send(message);
                    client.Disconnect(true);
                }
            }
            catch (SmtpCommandException ex) // Xử lý lỗi SMTP
            {
                MessageBox.Show($"Lỗi gửi email: {ex.StatusCode} - {ex.Message}"); // Hiển thị thông báo lỗi
            }
            catch (Exception ex) // Xử lý các lỗi khác
            {
                MessageBox.Show($"Lỗi: {ex.Message}"); // Hiển thị thông báo lỗi chung
            }
        }

        private void btnGuiEmail_Click(object sender, EventArgs e)
        {
            string email = txtBoxEmail.Text;
            if (_BLLQuenMatKhau.IsEmailExists(email))
            {
                // Tạo mã xác nhận ngẫu nhiên
                Random random = new Random();
                generatedToken = random.Next(100000, 999999).ToString(); // Mã 6 chữ số

                // Thiết lập thời gian hết hạn cho mã xác nhận
                tokenExpiration = DateTime.Now.AddMinutes(5); // Mã có hiệu lực trong 5 phút

                SendEmail(email, generatedToken);
                MessageBox.Show("Mã xác nhận đã được gửi đến email của bạn.");
            }
            else
            {
                MessageBox.Show("Email không tồn tại.");
            }
        }

        private void btnGuiMa_Click(object sender, EventArgs e)
        {
            string code = txtBoxMa.Text;
            // Kiểm tra mã và thời gian hết hạn
            if (code == generatedToken)
            {
                if (DateTime.Now <= tokenExpiration)
                {
                    // Mở form đặt lại mật khẩu
                    TaoMatKhau tmk = new TaoMatKhau(txtBoxEmail.Text);
                    tmk.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Mã xác nhận đã hết hạn.");
                }
            }
            else
            {
                MessageBox.Show("Mã xác nhận không hợp lệ.");
            }
        }
    }
}
