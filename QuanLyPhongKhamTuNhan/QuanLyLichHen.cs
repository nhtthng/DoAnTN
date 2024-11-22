using BLL;
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
    public partial class QuanLyLichHen : Form
    {
        private DataHelper dataHelper = new DataHelper();
        private BLL_QuanLyLichHen _QuanLyLichHenBLL = new BLL_QuanLyLichHen();
        private List<DTO_LichHen> lichHenList;
        public QuanLyLichHen()
        {
            InitializeComponent();
            LoadComboBoxBacSi();
            LoadComboBoxBenhNhan();
            LoadLichHenList();
            DGVLichHen.CellClick += DGVLichHen_CellClick;
            errorProviderLH.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }
        private void LoadComboBoxBacSi()
        {
            var bacSiList = dataHelper.GetBacSiList();
            cboMaBS.DataSource = bacSiList;
            cboMaBS.DisplayMember = "TenBS"; // Hiển thị tên bác sĩ
            cboMaBS.ValueMember = "MaBS"; // Giá trị là mã bác sĩ
        }
        private void LoadComboBoxBenhNhan()
        {
            var benhNhanList = dataHelper.GetBenhNhanList();
            cboMaBN.DataSource = benhNhanList;
            cboMaBN.DisplayMember = "HoTenBN"; // Hiển thị tên bệnh nhân
            cboMaBN.ValueMember = "MaBN"; // Giá trị là mã bệnh nhân
        }
        private void LoadLichHenList()
        {
            lichHenList = _QuanLyLichHenBLL.GetAllLichHen();
            DGVLichHen.DataSource = lichHenList;
        }



        private void btnThem_Click(object sender, EventArgs e)
        {
            // Đặt lại ErrorProvider
            errorProviderLH.Clear();
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(txtBoxMaLH.Text))
            {
                errorProviderLH.SetError(txtBoxMaLH, "Vui lòng nhập mã lịch hẹn.");
                isValid = false;
            }
            if (cboMaBS.SelectedItem == null)
            {
                errorProviderLH.SetError(cboMaBS, "Vui lòng chọn bác sĩ.");
                isValid = false;
            }
            if (cboMaBN.SelectedItem == null)
            {
                errorProviderLH.SetError(cboMaBN, "Vui lòng chọn bệnh nhân.");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtBoxTinhTrang.Text))
            {
                errorProviderLH.SetError(txtBoxTinhTrang, "Vui lòng nhập tình trạng.");
                isValid = false;
            }
            // Kiểm tra nếu tất cả các trường đều hợp lệ
            if (!isValid)
            {
                return; // Dừng hàm nếu còn trường trống
            }
            try
            {
                if (_QuanLyLichHenBLL.checkIdAppointment(int.Parse(txtBoxMaLH.Text)) == false)
                {
                    MessageBox.Show("Mã lịch hẹn bị trùng");
                    return;
                }
                DTO_LichHen lichHen = new DTO_LichHen
                {
                    MaLH = int.Parse(txtBoxMaLH.Text),
                    MaBS = (int)cboMaBS.SelectedValue,
                    MaBN = (int)cboMaBN.SelectedValue,
                    ThoiGianHen = DTPThoiGianHen.Value,
                    NgayHen = DTPNgayHen.Value,
                    TinhTrang = txtBoxTinhTrang.Text
                };

                if (_QuanLyLichHenBLL.AddLichHen(lichHen))
                {
                    MessageBox.Show("Thêm lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadLichHenList(); // Tải lại danh sách
                }
                else
                {
                    MessageBox.Show("Thêm lịch hẹn không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm lịch hẹn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Đặt lại ErrorProvider
            errorProviderLH.Clear();
            // Kiểm tra các trường và đặt thông báo lỗi nếu cần
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(txtBoxMaLH.Text))
            {
                errorProviderLH.SetError(txtBoxMaLH, "Vui lòng nhập mã lịch hẹn.");
                isValid = false;
            }
            // Kiểm tra nếu tất cả các trường đều hợp lệ
            if (!isValid)
            {
                return; // Dừng hàm nếu còn trường trống
            }
            try
            {
                int maLH = int.Parse(txtBoxMaLH.Text);
                if (_QuanLyLichHenBLL.DeleteLichHen(maLH))
                {
                    MessageBox.Show("Xóa lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadLichHenList(); // Tải lại danh sách
                }
                else
                {
                    MessageBox.Show("Xóa lịch hẹn không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi xóa lịch hẹn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Đặt lại ErrorProvider
            errorProviderLH.Clear();
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(txtBoxMaLH.Text))
            {
                errorProviderLH.SetError(txtBoxMaLH, "Vui lòng nhập mã lịch hẹn.");
                isValid = false;
            }
            if (cboMaBS.SelectedItem == null)
            {
                errorProviderLH.SetError(cboMaBS, "Vui lòng chọn bác sĩ.");
                isValid = false;
            }
            if (cboMaBN.SelectedItem == null)
            {
                errorProviderLH.SetError(cboMaBN, "Vui lòng chọn bệnh nhân.");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtBoxTinhTrang.Text))
            {
                errorProviderLH.SetError(txtBoxTinhTrang, "Vui lòng nhập tình trạng.");
                isValid = false;
            }
            // Kiểm tra nếu tất cả các trường đều hợp lệ
            if (!isValid)
            {
                return; // Dừng hàm nếu còn trường trống
            }
            try
            {
                DTO_LichHen lichHen = new DTO_LichHen
                {
                    MaLH = int.Parse(txtBoxMaLH.Text),
                    MaBS = (int)cboMaBS.SelectedValue,
                    MaBN = (int)cboMaBN.SelectedValue,
                    ThoiGianHen = DTPThoiGianHen.Value,
                    NgayHen = DTPNgayHen.Value,
                    TinhTrang = txtBoxTinhTrang.Text
                };

                if (_QuanLyLichHenBLL.UpdateLichHen(lichHen))
                {
                    MessageBox.Show("Cập nhật lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadLichHenList(); // Tải lại danh sách
                }
                else
                {
                    MessageBox.Show("Cập nhật lịch hẹn không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi cập nhật lịch hẹn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGVLichHen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng nhấp vào một dòng hợp lệ
            if (e.RowIndex >= 0)
            {
                // Lấy dòng đã chọn
                DataGridViewRow row = DGVLichHen.Rows[e.RowIndex];

                // Điền các giá trị vào các trường tương ứng
                txtBoxMaLH.Text = row.Cells["MaLH"].Value.ToString();
                cboMaBS.SelectedValue = row.Cells["MaBS"].Value; // Mã bác sĩ
                cboMaBN.SelectedValue = row.Cells["MaBN"].Value; // Mã bệnh nhân
                DTPThoiGianHen.Value = (DateTime)row.Cells["ThoiGianHen"].Value; // Thời gian hẹn
                DTPNgayHen.Value = (DateTime)row.Cells["NgayHen"].Value; // Ngày hẹn
                txtBoxTinhTrang.Text = row.Cells["TinhTrang"].Value.ToString(); // Tình trạng
            }
        }

        private void btnTimLH_Click(object sender, EventArgs e)
        {
            // Đặt lại ErrorProvider
            errorProviderLH.Clear();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtBoxTimMaLH.Text))
            {
                errorProviderLH.SetError(txtBoxTimMaLH, "Vui lòng nhập mã lịch hẹn.");
                isValid = false;
            }
            if (!isValid)
            {
                return; // Dừng hàm nếu còn trường trống
            }
            try
            {
                // Lấy mã lịch hẹn từ TextBox
                int maLH;
                if (int.TryParse(txtBoxTimMaLH.Text, out maLH))
                {
                    // Tìm kiếm lịch hẹn theo mã
                    DTO_LichHen lichHen = _QuanLyLichHenBLL.GetLichHenByMaLH(maLH);

                    // Nếu tìm thấy, hiển thị thông tin vào các trường
                    if (lichHen != null)
                    {
                        // Tạo danh sách để chứa kết quả tìm kiếm
                        List<DTO_LichHen> searchResult = new List<DTO_LichHen> { lichHen };
                        DGVLichHen.DataSource = searchResult; // Đổ dữ liệu vào DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy lịch hẹn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        LoadLichHenList(); // Tải lại danh sách đầy đủ nếu không tìm thấy
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập mã lịch hẹn hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi tìm kiếm lịch hẹn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
