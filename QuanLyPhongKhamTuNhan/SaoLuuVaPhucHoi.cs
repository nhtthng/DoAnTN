using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class SaoLuuVaPhucHoi : Form
    {
        private string defaultBackupPath = @"C:\QLPhongKham_Backup\";
        public SaoLuuVaPhucHoi()
        {
            InitializeComponent();
        }

        private void btnChonTM_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folder = new FolderBrowserDialog())
            {
                folder.Description = "Chọn thư mục sao lưu";
                if (folder.ShowDialog() == DialogResult.OK)
                {
                    txtBoxDuongDan.Text = folder.SelectedPath;
                }
            }
        }

        private void btnSaoLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra đường dẫn
                string backupPath = txtBoxDuongDan.Text;
                if (string.IsNullOrEmpty(backupPath))
                {
                    backupPath = defaultBackupPath;
                }

                // Tạo thư mục nếu chưa tồn tại
                Directory.CreateDirectory(backupPath);

                // Tên file backup
                string fileName = $"QuanLyPKTN_Backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
                string fullPath = Path.Combine(backupPath, fileName);

                // Thực hiện sao lưu
                using (SqlConnection conn = SqlConnectionData.GetConnection())
                {
                    conn.Open();
                    string query = $"BACKUP DATABASE [QuanLyPKTN_Final_2] TO DISK = '{fullPath}'";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    SqlConnectionData.CloseConnection(conn);
                }

                MessageBox.Show($"Sao lưu thành công!\nTệp: {fileName}",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi sao lưu: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPhucHoi_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFile = new OpenFileDialog())
                {
                    openFile.Filter = "Backup Files (*.bak)|*.bak";
                    openFile.Title = "Chọn file phục hồi";
                    openFile.InitialDirectory = defaultBackupPath;

                    if (openFile.ShowDialog() == DialogResult.OK)
                    {
                        // Xác nhận phục hồi
                        var confirm = MessageBox.Show(
                            "Bạn có chắc muốn phục hồi? Dữ liệu hiện tại sẽ bị thay thế!",
                            "Xác nhận",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning
                        );

                        if (confirm == DialogResult.Yes)
                        {
                            using (SqlConnection conn = SqlConnectionData.GetConnection())
                            {
                                conn.Open();

                                // Các truy vấn phục hồi
                                string killQuery = @"
                            USE master;
                            ALTER DATABASE [QuanLyPKTN_Final_2] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                        ";

                                string restoreQuery = $@"
                            RESTORE DATABASE [QuanLyPKTN_Final_2] 
                            FROM DISK = '{openFile.FileName}' 
                            WITH REPLACE
                        ";

                                string multiUserQuery = @"
                            ALTER DATABASE [QuanLyPKTN_Final_2] SET MULTI_USER;
                        ";

                                using (SqlCommand cmd = new SqlCommand(killQuery + restoreQuery + multiUserQuery, conn))
                                {
                                    cmd.ExecuteNonQuery();
                                }

                                SqlConnectionData.CloseConnection(conn);
                            }

                            MessageBox.Show("Phục hồi thành công!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi phục hồi: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
