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
    public partial class QuanLyDichVu : Form
    {
        private BLL_QuanLyDichVu _QuanLyDichVuBLL = new BLL_QuanLyDichVu();
        public QuanLyDichVu()
        {
            InitializeComponent();
            LoadAllServices();
            DGVDV.CellClick += DGVDV_CellClick;
            errorProviderDV.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }
        private void LoadAllServices()
        {
            List<DTO_QuanLyDichVu> services = _QuanLyDichVuBLL.GetAllServices();
            DGVDV.DataSource = services;
        }
        private void AddService()
        {
            // Đặt lại ErrorProvider
            errorProviderDV.Clear();

            bool isValid = true;
            if (string.IsNullOrWhiteSpace(txtBoxMaDV.Text))
            {
                errorProviderDV.SetError(txtBoxMaDV, "Vui lòng nhập mã dịch vụ.");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtBoxTenDV.Text))
            {
                errorProviderDV.SetError(txtBoxTenDV, "Vui lòng nhập tên dịch vụ.");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtGiaDV.Text))
            {
                errorProviderDV.SetError(txtGiaDV, "Vui lòng nhập giá.");
                isValid = false;
            }
            if (!isValid)
            {
                return; // Dừng hàm nếu còn trường trống
            }
            if (_QuanLyDichVuBLL.CheckIdDv(int.Parse(txtBoxMaDV.Text)) == false)
            {
                MessageBox.Show("Mã dịch vụ bị trùng");
                return;
            }
            int maDV = int.Parse(txtBoxMaDV.Text);
            string tenDV = txtBoxTenDV.Text;
            decimal gia = decimal.Parse(txtGiaDV.Text);

            

            DTO_QuanLyDichVu newService = new DTO_QuanLyDichVu
            {
                MaDV = maDV,
                TenDV = tenDV,
                Gia = gia
            };

            bool success = _QuanLyDichVuBLL.AddService(newService);
            if (success)
            {
                MessageBox.Show("Thêm dịch vụ thành công!");
                LoadAllServices(); // Cập nhật lại danh sách
            }
            else
            {
                MessageBox.Show("Thêm dịch vụ thất bại.");
            }
        }
        private void DeleteService()
        {
            // Đặt lại ErrorProvider
            errorProviderDV.Clear();

            bool isValid = true;
            if (string.IsNullOrWhiteSpace(txtBoxMaDV.Text))
            {
                errorProviderDV.SetError(txtBoxMaDV, "Vui lòng nhập mã dịch vụ.");
                isValid = false;
            }
            if (!isValid)
            {
                return; // Dừng hàm nếu còn trường trống
            }
            int maDV = int.Parse(txtBoxMaDV.Text);

            bool success = _QuanLyDichVuBLL.DeleteService(maDV);
            if (success)
            {
                MessageBox.Show("Xóa dịch vụ thành công!");
                LoadAllServices(); // Cập nhật lại danh sách
            }
            else
            {
                MessageBox.Show("Xóa dịch vụ thất bại.");
            }
        }
        private void UpdateService()
        {
            // Đặt lại ErrorProvider
            errorProviderDV.Clear();

            bool isValid = true;
            if (string.IsNullOrWhiteSpace(txtBoxMaDV.Text))
            {
                errorProviderDV.SetError(txtBoxMaDV, "Vui lòng nhập mã dịch vụ.");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtBoxTenDV.Text))
            {
                errorProviderDV.SetError(txtBoxTenDV, "Vui lòng nhập tên dịch vụ.");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtGiaDV.Text))
            {
                errorProviderDV.SetError(txtGiaDV, "Vui lòng nhập giá.");
                isValid = false;
            }
            if (!isValid)
            {
                return; // Dừng hàm nếu còn trường trống
            }
            int maDV = int.Parse(txtBoxMaDV.Text);
            string tenDV = txtBoxTenDV.Text;
            decimal gia = decimal.Parse(txtGiaDV.Text);

            DTO_QuanLyDichVu updatedService = new DTO_QuanLyDichVu
            {
                MaDV = maDV,
                TenDV = tenDV,
                Gia = gia
            };

            bool success = _QuanLyDichVuBLL.UpdateService(updatedService);
            if (success)
            {
                MessageBox.Show("Sửa dịch vụ thành công!");
                LoadAllServices(); // Cập nhật lại danh sách
            }
            else
            {
                MessageBox.Show("Sửa dịch vụ thất bại.");
            }
        }
        private void SearchService()
        {
            // Đặt lại ErrorProvider
            errorProviderDV.Clear();

            bool isValid = true;
            if (string.IsNullOrWhiteSpace(txtBoxTimKiemDV.Text))
            {
                errorProviderDV.SetError(txtBoxTimKiemDV, "Vui lòng nhập mã dịch vụ.");
                isValid = false;
            }
            if (!isValid)
            {
                return; // Dừng hàm nếu còn trường trống
            }
            int maDV = int.Parse(txtBoxTimKiemDV.Text);
            DTO_QuanLyDichVu service = _QuanLyDichVuBLL.FindServiceById(maDV);

            if (service != null)
            {
                List<DTO_QuanLyDichVu> result = new List<DTO_QuanLyDichVu> { service };
                DGVDV.DataSource = result;
            }
            else
            {
                MessageBox.Show("Không tìm thấy dịch vụ.");
            }
        }

        private void btnThemDV_Click(object sender, EventArgs e)
        {
            AddService();
        }

        private void btnXoaDV_Click(object sender, EventArgs e)
        {
            DeleteService();
        }

        private void btnSuaDV_Click(object sender, EventArgs e)
        {
            UpdateService();
        }

        private void btnTimKiemDV_Click(object sender, EventArgs e)
        {
            SearchService();
        }

        private void DGVDV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra nếu click vào hàng hợp lệ
            {
                DataGridViewRow row = DGVDV.Rows[e.RowIndex];

                // Điền giá trị vào các trường tương ứng
                txtBoxMaDV.Text = row.Cells["MaDV"].Value.ToString(); 
                txtBoxTenDV.Text = row.Cells["TenDV"].Value.ToString(); 
                txtGiaDV.Text = row.Cells["Gia"].Value.ToString(); 
            }
        }
    }
}
