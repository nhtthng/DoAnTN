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
    public partial class SearchThuoc : Form
    {
        public SearchThuoc()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Resize += new EventHandler(Thuoc_Resize);
        }

        private void SearchThuoc_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            DAL_Thuoc dalThuoc = new DAL_Thuoc();
            List<DTO_Thuoc> danhSachThuoc = dalThuoc.GetAllThuoc();
            dataGridViewThuoc.DataSource = danhSachThuoc;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string keyword = txtTenThuoc.Text.Trim(); // Giả sử bạn có một TextBox tên là txtSearch để nhập từ khóa

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DAL_Thuoc dalThuoc = new DAL_Thuoc();
            List<DTO_Thuoc> ketQuaTimKiem = dalThuoc.FindThuoc(keyword); // Gọi phương thức tìm thuốc

            if (ketQuaTimKiem.Count > 0)
            {
                dataGridViewThuoc.DataSource = ketQuaTimKiem; // Cập nhật DataGridView với kết quả tìm kiếm
            }
            else
            {
                MessageBox.Show("Không tìm thấy thuốc nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); // Có thể gọi lại LoadData() để hiển thị lại danh sách thuốc đầy đủ
            }
        }
        private void Thuoc_Resize(object sender, EventArgs e)
        {
            // Đặt kích thước DataGridView tương ứng với kích thước form
            dataGridViewThuoc.Width = this.ClientSize.Width;
            dataGridViewThuoc.Height = this.ClientSize.Height;
        }

    }
}
