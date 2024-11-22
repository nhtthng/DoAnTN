using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using DTO;


namespace GUI
{
    public partial class Thuoc : Form
    {
        public Thuoc()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            SearchThuoc searchForm = new SearchThuoc();

            // Hiển thị form SearchThuoc
            searchForm.StartPosition = FormStartPosition.CenterParent; // Đặt vị trí hiển thị
            searchForm.FormClosed += (s, args) => this.Enabled = true; // Bật lại form Thuoc khi SearchThuoc đóng
            searchForm.Show(); // Hiển thị form SearchThuoc
            this.Enabled = false; // Vô hiệu hóa form Thuoc để tránh tương tác trong khi tìm kiếm
        }


        private void dataGridViewThuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                DTO_Thuoc thuoc = new DTO_Thuoc
                {
                    MaThuoc = int.Parse(txtMaThuoc.Text), // Đảm bảo txtMaThuoc có giá trị hợp lệ
                    TenThuoc = txtTenThuoc.Text,
                    BietDuoc = txtBietDuoc.Text,
                    CongDung = txtCongDung.Text,
                    LuuY = txtLuuY.Text,
                    DonGia = decimal.Parse(txtDonGia.Text), // Đảm bảo txtDonGia có giá trị hợp lệ
                    DonViTinh = txtDVT.Text,
                    SoLuong = int.Parse(txtSoLuong.Text) // Đảm bảo txtSoLuong có giá trị hợp lệ
                };

                DAL_Thuoc dalThuoc = new DAL_Thuoc();
                dalThuoc.AddThuoc(thuoc);

                // Tải lại danh sách thuốc để cập nhật DataGridView
                LoadData();
                MessageBox.Show("Thêm thuốc thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DTO_Thuoc thuoc = new DTO_Thuoc
            {
                MaThuoc = int.Parse(txtMaThuoc.Text), // Đảm bảo txtMaThuoc có giá trị hợp lệ
                TenThuoc = txtTenThuoc.Text,
                BietDuoc = txtBietDuoc.Text,
                CongDung = txtCongDung.Text,
                LuuY = txtLuuY.Text,
                DonGia = decimal.Parse(txtDonGia.Text), // Đảm bảo txtDonGia có giá trị hợp lệ
                DonViTinh = txtDVT.Text,
                SoLuong = int.Parse(txtSoLuong.Text) // Đảm bảo txtSoLuong có giá trị hợp lệ
            };

            DAL_Thuoc dalThuoc = new DAL_Thuoc();
            dalThuoc.UpdateThuoc(thuoc);

            // Tải lại danh sách thuốc để cập nhật DataGridView
            LoadData();
            MessageBox.Show("Sửa thuốc thành công.");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtMaThuoc.Text))
            {
                int maThuoc = int.Parse(txtMaThuoc.Text); // Đảm bảo txtMaThuoc có giá trị hợp lệ
                DAL_Thuoc dalThuoc = new DAL_Thuoc();
                dalThuoc.DeleteThuoc(maThuoc);

                // Tải lại danh sách thuốc để cập nhật DataGridView
                LoadData();
                MessageBox.Show("Xóa thuốc thành công.");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thuốc để xóa.");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Thuoc_Load(object sender, EventArgs e)
        {
            LoadData();
            
        }
        private void LoadData()
        {
            DAL_Thuoc dalThuoc = new DAL_Thuoc();
            List<DTO_Thuoc> danhSachThuoc = dalThuoc.GetAllThuoc();
            dataGridViewThuoc.DataSource = danhSachThuoc;
        }

        private void dataGridViewThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy hàng (row) được chọn
                DataGridViewRow row = dataGridViewThuoc.Rows[e.RowIndex];

                // Hiển thị dữ liệu vào các TextBox
                txtMaThuoc.Text = row.Cells["MaThuoc"].Value.ToString(); // Thay "TenThuoc" bằng tên cột của bạn
                txtTenThuoc.Text = row.Cells["TenThuoc"].Value.ToString(); // Thay "SoLuong" bằng tên cột của bạn
                txtBietDuoc.Text = row.Cells["BietDuoc"].Value.ToString(); // Thay "Gia" bằng tên cột của bạn
                txtCongDung.Text = row.Cells["CongDung"].Value.ToString();
                txtLuuY.Text = row.Cells["LuuY"].Value.ToString();
                txtDonGia.Text = row.Cells["DonGia"].Value.ToString();
                txtDVT.Text = row.Cells["DonViTinh"].Value.ToString();
                txtSoLuong.Text = row.Cells["SoLuong"].Value.ToString();
            }
        }

        private void txtMaThuoc_TextChanged(object sender, EventArgs e)
        {

        }
        

    }
}
