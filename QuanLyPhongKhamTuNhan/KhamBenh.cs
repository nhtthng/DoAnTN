using BLL;
using DAL;
using DocumentFormat.OpenXml.Spreadsheet;
using DTO;
using QuanLyPhongKham;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class KhamBenh : Form
    {
        private BLL_KhamBenh bllKhamBenh = new BLL_KhamBenh();
        private List<object> _danhSachBenhNhanTrongNgay;
        public KhamBenh()
        {
            InitializeComponent();
            DGVKB.CellClick += DGVKB_CellClick;
            LoadKhamBenhData();
            DataHelper dataHelper = new DataHelper();
            List<DTO_QuanLyBacSi> bacsiList = dataHelper.GetBacSiList();
            cboMaBacSi.DataSource = bacsiList;
            cboMaBacSi.DisplayMember = "TenBS";
            cboMaBacSi.ValueMember = "MaBS";
            List<DTO_QuanLyBenhNhan> benhnhanList = dataHelper.GetBenhNhanList();
            cboMaBenhNhan.DataSource = benhnhanList;
            cboMaBenhNhan.DisplayMember = "HoTenBN";
            cboMaBenhNhan.ValueMember = "MaBN";
            List<DTO_QuanLyPhongKham> phongKhamList = dataHelper.GetPhongKhamList();

            cboMaPK.DataSource = phongKhamList;
            cboMaPK.DisplayMember = "TenPK";
            cboMaPK.ValueMember = "MaPK";
            errorProviderKB.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            DGVKB.Columns["NgayKham"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            DTPNgayKham.Format = DateTimePickerFormat.Custom;
            DTPNgayKham.CustomFormat = "dd/MM/yyyy HH:mm";
            DTPNgayKham.ShowUpDown = true;

            // Đặt giá trị mặc định là giờ hiện tại
            DTPNgayKham.Value = DateTime.Now;
            ConfigureDataGridView();
            LoadDanhSachBenhNhanTrongNgay();
            // Khởi tạo ContextMenuStrip
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            // Tạo các menu item
            ToolStripMenuItem serviceItem = new ToolStripMenuItem("Dịch vụ");
            serviceItem.Click += ServiceItem_Click;
            contextMenu.Items.Add(serviceItem);

            ToolStripMenuItem prescriptionItem = new ToolStripMenuItem("Kê thuốc");
            prescriptionItem.Click += PrescriptionItem_Click;
            contextMenu.Items.Add(prescriptionItem);

            ToolStripMenuItem patientItem = new ToolStripMenuItem("Bệnh nhân");
            patientItem.Click += PatientItem_Click;
            contextMenu.Items.Add(patientItem);

            // Gán ContextMenuStrip cho DataGridView
            DGVKB.ContextMenuStrip = contextMenu;
            //DGVDSBenhNhanChuaKham.RowHeadersVisible = false;
            DGVKB.AllowUserToAddRows = false;
            DGVDSBenhNhanChuaKham.AllowUserToAddRows = false;
        }

        private void ServiceItem_Click(object sender, EventArgs e)
        {
            if (DGVKB.SelectedRows.Count > 0)
            {
                // Lấy mã LSKB từ dòng được chọn
                if (DGVKB.SelectedRows[0].Cells["MaLSKB"].Value != null)
                {
                    int maLSKB = (int)DGVKB.SelectedRows[0].Cells["MaLSKB"].Value;
                    OpenServiceForm(maLSKB);
                }
                else
                {
                    MessageBox.Show("Không thể lấy được mã lịch sử khám bệnh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bệnh nhân từ danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PrescriptionItem_Click(object sender, EventArgs e)
        {
            if (DGVKB.SelectedRows.Count > 0)
            {
                // Lấy mã BN từ dòng được chọn
                if (DGVKB.SelectedRows[0].Cells["MaBN"].Value != null)
                {
                    int maBN = (int)DGVKB.SelectedRows[0].Cells["MaBN"].Value;
                    OpenPrescriptionForm(maBN);
                }
                else
                {
                    MessageBox.Show("Không thể lấy được mã bệnh nhân.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bệnh nhân từ danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PatientItem_Click(object sender, EventArgs e)
        {
            if (DGVKB.SelectedRows.Count > 0)
            {
                // Kiểm tra xem cột "MaBN" có giá trị hay không
                if (DGVKB.SelectedRows[0].Cells["MaBN"].Value != null && !string.IsNullOrEmpty(DGVKB.SelectedRows[0].Cells["MaBN"].Value.ToString()))
                {
                    string patientId = DGVKB.SelectedRows[0].Cells["MaBN"].Value.ToString();
                    OpenPatientForm(patientId);
                }
                else
                {
                    MessageBox.Show("Không thể lấy được mã bệnh nhân.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bệnh nhân từ danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OpenServiceForm(int patientId)
        {
            if (patientId > 0)
            {
                ChiTietSuDungDV serviceForm = new ChiTietSuDungDV();
                serviceForm.SetPatientId(patientId);
                serviceForm.Show();
            }
            else
            {
                MessageBox.Show("Không thể lấy được mã bệnh nhân.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenPrescriptionForm(int patientId)
        {
            // Kiểm tra xem patientId có hợp lệ hay không
            if (patientId > 0) // Kiểm tra nếu patientId là một số dương
            {
                KeThuoc prescriptionForm = new KeThuoc();
                prescriptionForm.SetPatientId(patientId); // Truyền đúng mã bệnh nhân vào form
                prescriptionForm.Show(); // Hiển thị form kê thuốc
            }
            else
            {
                MessageBox.Show("Không thể lấy được mã bệnh nhân.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenPatientForm(string patientId)
        {
            if (!string.IsNullOrEmpty(patientId))
            {
                QuanLyBenhNhan patientForm = new QuanLyBenhNhan();
                patientForm.SetPatientId(patientId);
                patientForm.Show();
            }
            else
            {
                MessageBox.Show("Không thể lấy được mã bệnh nhân.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridView()
        {
            // Vô hiệu hóa tự động sinh cột
            DGVDSBenhNhanChuaKham.AutoGenerateColumns = false;

            // Tạo các cột cho DataGridView
            var columns = new[]
            {
            new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaBN",
                HeaderText = "Mã BN",
                Name = "colMaBN",
                Width = 80
            },
            new DataGridViewTextBoxColumn
            {
                DataPropertyName = "HoTenBN",
                HeaderText = "Họ Tên",
                Name = "colHoTenBN",
                Width = 150
            },
            new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NgaySinh",
                HeaderText = "Ngày Sinh",
                Name = "colNgaySinh",
                Width = 100,
                DefaultCellStyle = { Format = "dd/MM/yyyy" }
            },
            new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SoDT",
                HeaderText = "Số ĐT",
                Name = "colSoDT",
                Width = 100
            },
            new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TrieuChung",
                HeaderText = "Triệu Chứng",
                Name = "colTrieuChung",
                Width = 200
            },
            new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NgayTiepNhan",
                HeaderText = "Ngày Tiếp Nhận",
                Name = "colNgayTiepNhan",
                Width = 120,
                DefaultCellStyle = { Format = "dd/MM/yyyy" }
            }
        };

            // Thêm các cột vào DataGridView
            DGVDSBenhNhanChuaKham.Columns.AddRange(columns);
        }
        private void LoadDanhSachBenhNhanTrongNgay()
        {
            try
            {
                // Lấy danh sách bệnh nhân trong ngày
                _danhSachBenhNhanTrongNgay = bllKhamBenh.GetDanhSachBenhNhanTrongNgay(DateTime.Today);

                // Kiểm tra và hiển thị dữ liệu
                if (_danhSachBenhNhanTrongNgay != null && _danhSachBenhNhanTrongNgay.Count > 0)
                {
                    // Liên kết dữ liệu với DataGridView
                    DGVDSBenhNhanChuaKham.DataSource = _danhSachBenhNhanTrongNgay;

                    // Cập nhật label tổng số bệnh nhân
                    // lblTongSoBenhNhan.Text = $"Tổng số bệnh nhân: {_danhSachBenhNhanTrongNgay.Count}";
                }
                else
                {
                    // Thông báo không có bệnh nhân
                    MessageBox.Show(
                        "Không có bệnh nhân trong ngày hôm nay.",
                        "Thông Báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                MessageBox.Show(
                    $"Lỗi tải danh sách bệnh nhân: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void LoadKhamBenhData()
        {
            DGVKB.DataSource = bllKhamBenh.GetAllKhamBenh();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Đặt lại ErrorProvider
            errorProviderKB.Clear();

            // Kiểm tra các trường và đặt thông báo lỗi nếu cần
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(txtBoxChuanDoan.Text))
            {
                errorProviderKB.SetError(txtBoxChuanDoan, "Vui lòng nhập chuẩn đoán.");
                isValid = false;
            }
            if (cboMaBacSi.SelectedItem == null)
            {
                errorProviderKB.SetError(cboMaBacSi, "Vui lòng chọn bác sĩ.");
                isValid = false;
            }
            if (cboMaBenhNhan.SelectedItem == null)
            {
                errorProviderKB.SetError(cboMaBenhNhan, "Vui lòng chọn bệnh nhân.");
                isValid = false;
            }
            if (cboMaPK.SelectedItem == null)
            {
                errorProviderKB.SetError(cboMaPK, "Vui lòng chọn phòng khám.");
                isValid = false;
            }

            // Kiểm tra nếu tất cả các trường đều hợp lệ
            if (!isValid)
            {
                return; // Dừng hàm nếu còn trường trống
            }

            try
            {
                // Kiểm tra điều kiện ngày khám
                if (DTPNgayKham.Value > DateTime.Now)
                {
                    MessageBox.Show(
                        "Ngày khám không được lớn hơn ngày hiện tại.",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                DTO_KhamBenh khamBenh = new DTO_KhamBenh
                {
                    MaBS = (int)cboMaBacSi.SelectedValue,
                    MaBN = (int)cboMaBenhNhan.SelectedValue,
                    NgayKham = DTPNgayKham.Value,
                    ChuanDoan = txtBoxChuanDoan.Text,
                    MaPK = (int)cboMaPK.SelectedValue
                };

                if (bllKhamBenh.AddKhamBenh(khamBenh))
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadKhamBenhData();
                    LoadDanhSachBenhNhanTrongNgay();
                }
                else
                {
                    MessageBox.Show("Thêm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Bắt và hiển thị mọi ngoại lệ có thể xảy ra
                MessageBox.Show(
                    $"Lỗi: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Đặt lại ErrorProvider
            errorProviderKB.Clear();
            // Kiểm tra các trường và đặt thông báo lỗi nếu cần
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(txtBoxLSKB.Text))
            {
                errorProviderKB.SetError(txtBoxLSKB, "Vui lòng nhập mã lịch sử khám bệnh.");
                isValid = false;
            }
            // Kiểm tra nếu tất cả các trường đều hợp lệ
            if (!isValid)
            {
                return; // Dừng hàm nếu còn trường trống
            }
            int maLSKB = int.Parse(txtBoxLSKB.Text);
            bool isDeleted = bllKhamBenh.DeleteKhamBenh(maLSKB);
            if (isDeleted)
            {
                MessageBox.Show("Xóa thành công!");
                LoadKhamBenhData();
            }
            else
            {
                MessageBox.Show("Xóa không thành công.");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Đặt lại ErrorProvider
            errorProviderKB.Clear();
            // Kiểm tra các trường và đặt thông báo lỗi nếu cần
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(txtBoxLSKB.Text))
            {
                errorProviderKB.SetError(txtBoxLSKB, "Vui lòng nhập mã lịch sử khám bệnh.");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtBoxChuanDoan.Text))
            {
                errorProviderKB.SetError(txtBoxChuanDoan, "Vui lòng nhập chuẩn đoán.");
                isValid = false;
            }
            if (cboMaBacSi.SelectedItem == null)
            {
                errorProviderKB.SetError(cboMaBacSi, "Vui lòng chọn bác sĩ.");
                isValid = false;
            }
            if (cboMaBenhNhan.SelectedItem == null)
            {
                errorProviderKB.SetError(cboMaBenhNhan, "Vui lòng chọn bệnh nhân.");
                isValid = false;
            }
            if (cboMaPK.SelectedItem == null)
            {
                errorProviderKB.SetError(cboMaPK, "Vui lòng chọn phòng khám.");
                isValid = false;
            }
            // Kiểm tra nếu tất cả các trường đều hợp lệ
            if (!isValid)
            {
                return; // Dừng hàm nếu còn trường trống
            }
            DTO_KhamBenh khamBenh = new DTO_KhamBenh
            {
                MaLSKB = int.Parse(txtBoxLSKB.Text),
                MaBS = (int)cboMaBacSi.SelectedValue,
                MaBN = (int)cboMaBenhNhan.SelectedValue,
                NgayKham = DTPNgayKham.Value,
                ChuanDoan = txtBoxChuanDoan.Text,
                MaPK = (int)cboMaPK.SelectedValue
            };

            if (bllKhamBenh.UpdateKhamBenh(khamBenh))
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadKhamBenhData();
            }
            else
            {
                MessageBox.Show("Cập nhật không thành công!");
            }
        }

        private void btnTimLSKB_Click(object sender, EventArgs e)
        {
            // Đặt lại ErrorProvider
            errorProviderKB.Clear();

            // Kiểm tra và validate số điện thoại
            bool isValid = true;
            string soDienThoai = txtBoxTimLSKB.Text.Trim();

            try
            {
                // Validate số điện thoại
                if (string.IsNullOrWhiteSpace(soDienThoai))
                {
                    errorProviderKB.SetError(txtBoxTimLSKB, "Vui lòng nhập số điện thoại.");
                    isValid = false;
                }

                // Nếu không hợp lệ, dừng xử lý
                if (!isValid)
                {
                    return;
                }

                // Gọi phương thức tìm kiếm từ BLL
                List<DTO_KhamBenh> result = bllKhamBenh.SearchBenhNhanInKhamBenhBySDT(soDienThoai);

                // Kiểm tra và hiển thị kết quả
                if (result != null && result.Count > 0)
                {
                    // Cấu hình DataGridView
                    DGVKB.DataSource = null; // Xóa nguồn dữ liệu cũ
                    DGVKB.DataSource = result; // Gán nguồn dữ liệu mới


                    // Thông báo kết quả
                    MessageBox.Show($"Tìm thấy {result.Count} lịch sử khám bệnh!",
                        "Thông Báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (ArgumentException ex)
            {
                // Xử lý lỗi validate số điện thoại
                errorProviderKB.SetError(txtBoxTimLSKB, ex.Message);
            }
            catch (Exception ex)
            {
                // Xử lý các lỗi khác
                if (ex.Message.Contains("Không tìm thấy"))
                {
                    // Trường hợp không tìm thấy bệnh nhân
                    MessageBox.Show(ex.Message,
                        "Thông Báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    // Tải lại dữ liệu gốc
                    LoadKhamBenhData();
                }
                else
                {
                    // Lỗi hệ thống
                    MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void DGVKB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DGVKB.Rows[e.RowIndex];
                txtBoxLSKB.Text = row.Cells["MaLSKB"].Value.ToString();
                cboMaBacSi.SelectedValue = row.Cells["MaBS"].Value;
                cboMaBenhNhan.SelectedValue = row.Cells["MaBN"].Value;
                DTPNgayKham.Value = (DateTime)row.Cells["NgayKham"].Value;
                txtBoxChuanDoan.Text = row.Cells["ChuanDoan"].Value.ToString();
                cboMaPK.SelectedValue = row.Cells["MaPK"].Value;
            }
        }

        private void btnTimSDTBN_Click(object sender, EventArgs e)
        {
            // Lấy số điện thoại từ TextBox
            string soDienThoai = txtBoxSDTBN.Text.Trim();

            // Kiểm tra số điện thoại
            if (string.IsNullOrWhiteSpace(soDienThoai))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra định dạng số điện thoại
            if (!IsValidPhoneNumber(soDienThoai))
            {
                MessageBox.Show("Số điện thoại không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gọi hàm GetThongTinBenhNhanBySDT() để lấy danh sách bệnh nhân
            var danhSachBenhNhan = bllKhamBenh.GetThongTinBenhNhanBySDT(DateTime.Today, soDienThoai);

            // Đổ dữ liệu vào DataGridView
            DGVDSBenhNhanChuaKham.DataSource = danhSachBenhNhan;
        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Mẫu Regex để kiểm tra số điện thoại Việt Nam
            string pattern = @"^0\d{9}$";

            // Sử dụng Regex để kiểm tra số điện thoại
            return Regex.IsMatch(phoneNumber, pattern);
        }
        // Phương thức reset ComboBox Bệnh Nhân
        private void ResetBenhNhanComboBox()
        {
            // Nạp lại danh sách bệnh nhân ban đầu
            DataHelper dataHelper = new DataHelper();
            var benhnhanList = dataHelper.GetBenhNhanList();

            cboMaBenhNhan.DataSource = benhnhanList;
            cboMaBenhNhan.DisplayMember = "HoTenBN";
            cboMaBenhNhan.ValueMember = "MaBN";

            // Bỏ chọn
            cboMaBenhNhan.SelectedIndex = -1;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtBoxTimLSKB.Clear();
            txtBoxSDTBN.Clear();
            txtBoxChuanDoan.Clear();
            txtBoxLSKB.Clear();
            txtBoxSDTBN.Clear();
            cboMaBacSi.SelectedIndex = -1;
            cboMaBenhNhan.SelectedIndex = -1;
            cboMaPK.SelectedIndex = -1;
            LoadKhamBenhData();
        }

        private void DTPNgayKham_ValueChanged(object sender, EventArgs e)
        {
            // Giữ nguyên giờ phút khi chọn ngày mới
            DateTime selectedDateTime = DTPNgayKham.Value;
            DateTime currentTime = DateTime.Now;

            selectedDateTime = new DateTime(
                selectedDateTime.Year,
                selectedDateTime.Month,
                selectedDateTime.Day,
                currentTime.Hour,
                currentTime.Minute,
                0
            );

            DTPNgayKham.Value = selectedDateTime;
        }

        private void DGVDSBenhNhanChuaKham_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DGVDSBenhNhanChuaKham.Rows[e.RowIndex];
                //txtBoxLSKB.Text = row.Cells["MaLSKB"].Value.ToString();
                //cboMaBacSi.SelectedValue = row.Cells["MaBS"].Value;
                cboMaBenhNhan.SelectedValue = row.Cells["colMaBN"].Value;
                //DTPNgayKham.Value = (DateTime)row.Cells["NgayKham"].Value;
                //txtBoxChuanDoan.Text = row.Cells["ChuanDoan"].Value.ToString();
                //cboMaPK.SelectedValue = row.Cells["MaPK"].Value;
            }
        }

        private void btnLocBN_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = DTPLocBN.Value.Date;
            var patients = bllKhamBenh.GetPatientsNotExamined(selectedDate);
            DGVDSBenhNhanChuaKham.DataSource = patients;
        }
    }
}
