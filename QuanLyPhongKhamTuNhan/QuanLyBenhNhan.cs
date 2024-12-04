using BLL;
using DTO;
using GUI;
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
            this.StartPosition = FormStartPosition.CenterScreen;
            DGVBN.CellClick += DGVBN_CellClick;
            LoadAllPatients();
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            ToolStripMenuItem receiveItem = new ToolStripMenuItem("Tiếp nhận");
            receiveItem.Click += ReceiveItem_Click;
            contextMenu.Items.Add(receiveItem);

            ToolStripMenuItem invoiceItem = new ToolStripMenuItem("Hóa đơn");
            invoiceItem.Click += InvoiceItem_Click;
            contextMenu.Items.Add(invoiceItem);

            ToolStripMenuItem appointmentItem = new ToolStripMenuItem("Lịch hẹn");
            appointmentItem.Click += AppointmentItem_Click;
            contextMenu.Items.Add(appointmentItem);

            DGVBN.ContextMenuStrip = contextMenu;
        }

        public void SetPatientId(string patientId)
        {
            txtboxMaBenhNhan.Text = patientId;
        }

        // Xử lý sự kiện click trên các menu item
        private void ReceiveItem_Click(object sender, EventArgs e)
        {
            if (DGVBN.SelectedRows.Count > 0)
            {
                int patientId = int.Parse(DGVBN.SelectedRows[0].Cells["MaBN"].Value.ToString());
                OpenReceiveForm(patientId);
            }
        }
        private void InvoiceItem_Click(object sender, EventArgs e)
        {
            if (DGVBN.SelectedRows.Count > 0)
            {
                int patientId = int.Parse(DGVBN.SelectedRows[0].Cells["MaBN"].Value.ToString());
                OpenInvoiceForm(patientId);
            }
        }

        private void AppointmentItem_Click(object sender, EventArgs e)
        {
            if (DGVBN.SelectedRows.Count > 0)
            {
                int patientId = int.Parse(DGVBN.SelectedRows[0].Cells["MaBN"].Value.ToString());
                OpenAppointmentForm(patientId);
            }
        }
        // Mở các form tương ứng và truyền mã bệnh nhân vào ComboBox
        private void OpenReceiveForm(int patientId)
        {
            TiepNhan receiveForm = new TiepNhan();
            receiveForm.SetPatientId(patientId);
            receiveForm.Show();
        }

        private void OpenInvoiceForm(int patientId)
        {
            BLL_QuanLyBenhNhan _PatientBLL = new BLL_QuanLyBenhNhan();
            int latestMedicalHistoryId = _PatientBLL.GetLatestMedicalHistoryId(patientId);
            HoaDon invoiceForm = new HoaDon();
            invoiceForm.SetPatientId(patientId);
            invoiceForm.SetMedicalHistoryId(latestMedicalHistoryId);
            invoiceForm.Show();
        }

        private void OpenAppointmentForm(int patientId)
        {
            QuanLyLichHen appointmentForm = new QuanLyLichHen();
            appointmentForm.SetPatientId(patientId);
            appointmentForm.Show();
        }
        private void LoadAllPatients()
        {
            var bll = new BLL_QuanLyBenhNhan(); // Tạo đối tượng BLL
            var patients = bll.GetAllPatients(); // Lấy danh sách bệnh nhân

            DGVBN.DataSource = null; // Đặt DataSource về null trước
            DGVBN.DataSource = patients; // Gán danh sách bệnh nhân vào DataGridView
        }

        private void btnThemBN_Click(object sender, EventArgs e)
        {
            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrWhiteSpace(txtBoxHoTenBN.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên bệnh nhân.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBoxHoTenBN.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtBoxSDTBN.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBoxSDTBN.Focus();
                return;
            }

            if (cboGioiTinhBN.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn giới tính.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboGioiTinhBN.Focus();
                return;
            }
            try
            {
                var patient = new DTO_QuanLyBenhNhan
                {
                    HoTenBN = txtBoxHoTenBN.Text.Trim(),
                    NgaySinh = DTPNgaySinhBN.Value,
                    GioiTinh = cboGioiTinhBN.SelectedItem.ToString(),
                    Email = txtBoxEmaiBN.Text.Trim(),
                    SoBHYT = txtBoxBHYTBN.Text.Trim(),
                    SoDT = txtBoxSDTBN.Text.Trim(),
                    DiaChi = txtBoxDiaChiBN.Text.Trim()
                };

                BLL_QuanLyBenhNhan _PatientBLL = new BLL_QuanLyBenhNhan();

                if (_PatientBLL.ThemBenhNhan(patient))
                {
                    MessageBox.Show("Thêm bệnh nhân thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllPatients();
                    ResetForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thêm bệnh nhân thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnXoaBN_Click(object sender, EventArgs e)
        {
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
            // Kiểm tra mã bệnh nhân
            if (string.IsNullOrWhiteSpace(txtboxMaBenhNhan.Text))
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân cần sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrWhiteSpace(txtBoxHoTenBN.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên bệnh nhân.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBoxHoTenBN.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtBoxSDTBN.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBoxSDTBN.Focus();
                return;
            }

            if (cboGioiTinhBN.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn giới tính.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboGioiTinhBN.Focus();
                return;
            }

            try
            {
                var patient = new DTO_QuanLyBenhNhan
                {
                    MaBN = int.Parse(txtboxMaBenhNhan.Text),
                    HoTenBN = txtBoxHoTenBN.Text.Trim(),
                    NgaySinh = DTPNgaySinhBN.Value,
                    GioiTinh = cboGioiTinhBN.SelectedItem.ToString(),
                    Email = txtBoxEmaiBN.Text.Trim(),
                    SoBHYT = txtBoxBHYTBN.Text.Trim(),
                    SoDT = txtBoxSDTBN.Text.Trim(),
                    DiaChi = txtBoxDiaChiBN.Text.Trim()
                };

                BLL_QuanLyBenhNhan bll = new BLL_QuanLyBenhNhan();

                if (bll.UpdatePatient(patient))
                {
                    MessageBox.Show("Cập nhật bệnh nhân thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllPatients();
                    ResetForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Cập nhật bệnh nhân thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimBN_Click(object sender, EventArgs e)
        {
            // Lấy số điện thoại từ TextBox
            string soDienThoai = txtBoxTimKiemBN.Text.Trim();

            // Kiểm tra tính hợp lệ của số điện thoại
            if (string.IsNullOrWhiteSpace(txtBoxTimKiemBN.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.");
                return;
            }

            // Kiểm tra định dạng số điện thoại (nếu cần)
            if (!IsValidPhoneNumber(soDienThoai))
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập lại.");
                return;
            }

            // Khởi tạo BLL
            BLL_QuanLyBenhNhan bll = new BLL_QuanLyBenhNhan();

            // Tìm kiếm bệnh nhân theo số điện thoại
            DTO_QuanLyBenhNhan patient = bll.SearchPatientBySDT(soDienThoai);

            if (patient != null)
            {
                // Hiển thị thông tin bệnh nhân vào DataGridView
                DGVBN.DataSource = new List<DTO_QuanLyBenhNhan> { patient };

                // Nếu muốn load lại danh sách sau khi tìm kiếm
                
            }
            else
            {
                // Thông báo nếu không tìm thấy bệnh nhân
                MessageBox.Show("Không tìm thấy bệnh nhân có số điện thoại này.");

                // Có thể reset DataGridView
                DGVBN.DataSource = null;
            }
        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Ví dụ đơn giản: kiểm tra độ dài và ký tự
            return !string.IsNullOrWhiteSpace(phoneNumber) &&
                   phoneNumber.Length >= 10 &&
                   phoneNumber.Length <= 11 &&
                   phoneNumber.All(char.IsDigit);
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

        private void txtBoxSDTBN_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và các phím điều khiển (Backspace, Delete, vv)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho nhập ký tự
            }
        }
        private void ResetForm()
        {
            txtboxMaBenhNhan.Clear();
            txtBoxHoTenBN.Clear();
            txtBoxEmaiBN.Clear();
            txtBoxBHYTBN.Clear();
            txtBoxSDTBN.Clear();
            txtBoxDiaChiBN.Clear();
            DTPNgaySinhBN.Value = DateTime.Now;
            cboGioiTinhBN.SelectedIndex = -1;
            txtBoxTimKiemBN.Clear();
            LoadAllPatients();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
