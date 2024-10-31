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

namespace QuanLyPhongKham
{
    public partial class QuanLyBenhNhan : Form
    {
        public QuanLyBenhNhan()
        {
            InitializeComponent();
            DGVBN.CellClick += DGVBN_CellClick;
            LoadAllPatients();
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink; // loại bỏ X nhấp nháy
        }
        private void LoadAllPatients()
        {
            var bll = new BLL_QuanLyBenhNhan(); // Tạo đối tượng BLL
            var patients = bll.GetAllPatients(); // Lấy danh sách bệnh nhân
            Console.WriteLine("Số lượng bệnh nhân: " + patients.Count); // Kiểm tra số lượng bệnh nhân
            DGVBN.DataSource = null; // Đặt DataSource về null trước
            DGVBN.DataSource = patients; // Gán danh sách bệnh nhân vào DataGridView
        }
        private void LoadOnePatient(int ID)
        {
            var bll = new BLL_QuanLyBenhNhan();
            var patitent = bll.GetPatientById(ID);
            DGVBN.DataSource = null ;
            DGVBN.DataSource = patitent;
        }

        private void btnThemBN_Click(object sender, EventArgs e)
        {
            // Đặt lại ErrorProvider
            errorProvider.Clear();
            // Kiểm tra các trường và đặt thông báo lỗi nếu cần
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(txtboxMaBenhNhan.Text))
            {
                errorProvider.SetError(txtboxMaBenhNhan, "Vui lòng nhập mã bệnh nhân.");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtBoxHoTenBN.Text))
            {
                errorProvider.SetError(txtBoxHoTenBN, "Vui lòng nhập họ tên.");
                isValid = false;
            }
            if (cboGioiTinhBN.SelectedItem == null)
            {
                errorProvider.SetError(cboGioiTinhBN, "Vui lòng chọn giới tính.");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtBoxEmaiBN.Text))
            {
                errorProvider.SetError(txtBoxEmaiBN, "Vui lòng nhập email.");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtBoxBHYTBN.Text))
            {
                errorProvider.SetError(txtBoxBHYTBN, "Vui lòng nhập số BHYT.");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtBoxSDTBN.Text))
            {
                errorProvider.SetError(txtBoxSDTBN, "Vui lòng nhập số điện thoại.");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtBoxDiaChiBN.Text))
            {
                errorProvider.SetError(txtBoxDiaChiBN, "Vui lòng nhập địa chỉ.");
                isValid = false;
            }

            // Kiểm tra nếu tất cả các trường đều hợp lệ
            if (!isValid)
            {
                return; // Dừng hàm nếu còn trường trống
            }
            var patient = new DTO_QuanLyBenhNhan
            {
                MaBN = int.Parse(txtboxMaBenhNhan.Text),
                HoTenBN = txtBoxHoTenBN.Text,
                NgaySinh = DTPNgaySinhBN.Value,
                GioiTinh = cboGioiTinhBN.SelectedItem.ToString(),
                Email = txtBoxEmaiBN.Text,
                SoBHYT = txtBoxBHYTBN.Text,
                SoDT = txtBoxSDTBN.Text,
                DiaChi = txtBoxDiaChiBN.Text
            };
            BLL_QuanLyBenhNhan _PatientBLL = new BLL_QuanLyBenhNhan();
            if (_PatientBLL.AddPatient(patient))
            {
                MessageBox.Show("Thêm bệnh nhân thành công!");
                LoadAllPatients();
            }
            else
            {
                MessageBox.Show("Thêm bệnh nhân thất bại.");
            }

        }

        private void btnXoaBN_Click(object sender, EventArgs e)
        {
            // Đặt lại ErrorProvider
            errorProvider.Clear();
            // Kiểm tra các trường và đặt thông báo lỗi nếu cần
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(txtboxMaBenhNhan.Text)) 
            {
                errorProvider.SetError(txtboxMaBenhNhan, "Vui lòng nhập mã bệnh nhân.");
                isValid = false;
            }
            // Kiểm tra nếu tất cả các trường đều hợp lệ
            if (!isValid)
            {
                return; // Dừng hàm nếu còn trường trống
            }
            int maBN = int.Parse(txtboxMaBenhNhan.Text);
            BLL_QuanLyBenhNhan _PatientBLL = new BLL_QuanLyBenhNhan();
            if (_PatientBLL.DeletePatient(maBN))
            {
                MessageBox.Show("Xóa bệnh nhân thành công!");
                LoadAllPatients();
            }
            else
            {
                MessageBox.Show("Xóa bệnh nhân thất bại.");
            }

        }

        private void btnSuaBN_Click(object sender, EventArgs e)
        {
            var patient = new DTO_QuanLyBenhNhan
            {
                MaBN = int.Parse(txtboxMaBenhNhan.Text),
                HoTenBN = txtBoxHoTenBN.Text,
                NgaySinh = DTPNgaySinhBN.Value,
                GioiTinh = cboGioiTinhBN.SelectedItem.ToString(),
                Email = txtBoxEmaiBN.Text,
                SoBHYT = txtBoxBHYTBN.Text,
                SoDT = txtBoxSDTBN.Text,
                DiaChi = txtBoxDiaChiBN.Text
            };

            BLL_QuanLyBenhNhan bll = new BLL_QuanLyBenhNhan();
            if (bll.UpdatePatient(patient))
            {
                MessageBox.Show("Cập nhật bệnh nhân thành công!");
                LoadAllPatients();
            }
            else
            {
                MessageBox.Show("Cập nhật bệnh nhân thất bại.");
            }
        }

        private void btnTimBN_Click(object sender, EventArgs e)
        {
            // Đặt lại ErrorProvider
            errorProvider.Clear();
            // Kiểm tra các trường và đặt thông báo lỗi nếu cần
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(txtBoxTimKiemBN.Text))
            {
                errorProvider.SetError(txtBoxTimKiemBN, "Vui lòng nhập mã bệnh nhân.");
                isValid = false;
            }
            // Kiểm tra nếu tất cả các trường đều hợp lệ
            if (!isValid)
            {
                return; // Dừng hàm nếu còn trường trống
            }
            int maBN;
            if (int.TryParse(txtBoxTimKiemBN.Text.Trim(), out maBN)) // Loại bỏ khoảng trắng trước khi chuyển đổi
            {
                BLL_QuanLyBenhNhan bll = new BLL_QuanLyBenhNhan();
                DTO_QuanLyBenhNhan patient = bll.SearchPatientByMaBN(maBN);

                if (patient != null)
                {
                    // Hiển thị thông tin bệnh nhân vào DataGridView
                    DGVBN.DataSource = new List<DTO_QuanLyBenhNhan> { patient }; // Hiển thị bệnh nhân dưới dạng danh sách
                }
                else
                {
                    MessageBox.Show("Không tìm thấy bệnh nhân với mã này.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã bệnh nhân hợp lệ.");
            }
        }

        private void QuanLyBenhNhan_Load(object sender, EventArgs e)
        {
            LoadAllPatients();
        }

        private void DGVBN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra xem có hàng nào được chọn không
            {
                // Lấy hàng được chọn
                DataGridViewRow selectedRow = DGVBN.Rows[e.RowIndex];

                // Hiển thị dữ liệu vào các trường
                txtboxMaBenhNhan.Text = selectedRow.Cells["MaBN"].Value.ToString();
                txtBoxHoTenBN.Text = selectedRow.Cells["HoTenBN"].Value.ToString();
                DTPNgaySinhBN.Value = Convert.ToDateTime(selectedRow.Cells["NgaySinh"].Value);
                cboGioiTinhBN.SelectedItem = selectedRow.Cells["GioiTinh"].Value.ToString();
                txtBoxDiaChiBN.Text = selectedRow.Cells["DiaChi"].Value.ToString();
                txtBoxSDTBN.Text = selectedRow.Cells["SoDT"].Value.ToString();
                txtBoxEmaiBN.Text = selectedRow.Cells["Email"].Value.ToString();
                txtBoxBHYTBN.Text = selectedRow.Cells["SoBHYT"].Value.ToString();
            }
        }
    }
}
