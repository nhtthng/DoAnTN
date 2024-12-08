using BLL;
using ClosedXML.Excel;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class KeThuoc : Form
    {
        //private DAL_KeThuoc dal_KeThuoc = new DAL_KeThuoc();
        private BLL_KeThuoc _KeThuocBLL = new BLL_KeThuoc();

        public KeThuoc()
        {
            InitializeComponent();
            //txtTenThuoc.ReadOnly = true; // Khóa ô tên thuốc
            txtBoxMaThuoc.ReadOnly = true;
            txtBietDuoc.ReadOnly = true; // Khóa ô biệt dược
            var danhSachThuoc = _KeThuocBLL.GetAllThuoc();
            cboTenThuoc.DataSource = danhSachThuoc;
            cboTenThuoc.DisplayMember = "TenThuoc";
            cboTenThuoc.ValueMember = "MaThuoc";
            List<DTO_LichSuBenhNhan> danhSachBN = _KeThuocBLL.LayDanhSachBenhNhan();
            dataGridViewDSBenhNhan.DataSource = danhSachBN;
            DataHelper dbHelper = new DataHelper();

            List<DTO_QuanLyBacSi> bacsiList = dbHelper.GetBacSiList();
            cboMaBS.DataSource = bacsiList;
            cboMaBS.DisplayMember = "TenBS";
            cboMaBS.ValueMember = "MaBS";
        }
        private void LoadBenhNhan()
        {
            try
            {
                //_KeThuocBLL bllBenhNhan = new _KeThuocBLL();
                var danhSachBenhNhan = _KeThuocBLL.GetAllBenhNhanFromLichSuKham();

                // Gán danh sách vào DataGridView
                dataGridViewDSBenhNhan.DataSource = danhSachBenhNhan;

                // Đặt tên cột hiển thị trong DataGridView
                dataGridViewDSBenhNhan.Columns["HoTenBN"].HeaderText = "Họ Tên Bệnh Nhân";
                dataGridViewDSBenhNhan.Columns["NgaySinh"].HeaderText = "Ngày Tháng Năm Sinh";
                dataGridViewDSBenhNhan.Columns["SoDT"].HeaderText = "Số Điện Thoại Bệnh Nhân";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách bệnh nhân: {ex.Message}");
            }
        }
        private void LoadData()
        {
            try
            {
                var chiTietToaThuocs = _KeThuocBLL.GetAllChiTietToaThuoc();
                dataGridViewDSToaThuoc.DataSource = chiTietToaThuocs; // Gán danh sách vào DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}");
            }
        }
        public void SetPatientId(string patientId)
        {
            txtMaBenhNhan.Text = patientId;
        }
        //private void LoadData()
        //{
        //    DataTable dtBenhNhan = dalKeThuoc.LayThongTinBenhNhan();
        //    dataGridViewDSBenhNhan.DataSource = dtBenhNhan;

        //    // Đặt lại thứ tự cột cho dataGridViewDSBenhNhan
        //    dataGridViewDSBenhNhan.Columns["MaLSKB"].DisplayIndex = 0;
        //    dataGridViewDSBenhNhan.Columns["MaBS"].DisplayIndex = 1;
        //    dataGridViewDSBenhNhan.Columns["MaBN"].DisplayIndex = 2;
        //    dataGridViewDSBenhNhan.Columns["HoTenBN"].DisplayIndex = 3;

        //    // Tải dữ liệu toa thuốc
        //    DataTable dtToaThuoc = dalKeThuoc.LayDSToaThuoc();
        //    dataGridViewDSToaThuoc.DataSource = dtToaThuoc;

        //    // Đặt lại thứ tự cột cho dataGridViewDSToaThuoc
        //    dataGridViewDSToaThuoc.Columns["MaTT"].DisplayIndex = 0;       // Mã toa thuốc
        //    dataGridViewDSToaThuoc.Columns["MaBS"].DisplayIndex = 1;      // Mã bác sĩ
        //    dataGridViewDSToaThuoc.Columns["MaBN"].DisplayIndex = 2;
        //    dataGridViewDSToaThuoc.Columns["MaThuoc"].DisplayIndex = 3; // Mã bệnh nhân
        //    dataGridViewDSToaThuoc.Columns["HoTenBN"].DisplayIndex = 4;   // Họ tên bệnh nhân
        //                                                                  // Mã thuốc (thêm vào đây)
        //    dataGridViewDSToaThuoc.Columns["TenThuoc"].DisplayIndex = 5;  // Tên thuốc
        //    dataGridViewDSToaThuoc.Columns["BietDuoc"].DisplayIndex = 6;  // Biệt dược
        //    dataGridViewDSToaThuoc.Columns["LieuLuong"].DisplayIndex = 7;  // Liều lượng
        //    dataGridViewDSToaThuoc.Columns["CachDung"].DisplayIndex = 8;   // Cách dùng
        //    dataGridViewDSToaThuoc.Columns["LoiDanBS"].DisplayIndex = 9;   // Lời dặn bác sĩ
        //    dataGridViewDSToaThuoc.Columns["NgayKeToa"].DisplayIndex = 10;  // Ngày kê toa
        //}
        private void KeThuoc_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        //private void LoadToaThuocByMaBN(string maBN)
        //{
        //    // Tải dữ liệu toa thuốc cho bệnh nhân có mã MaBN
        //    DataTable dtToaThuoc = dalKeThuoc.LayDSToaThuocByMaBN(maBN); // Gọi phương thức lấy dữ liệu toa thuốc theo mã bệnh nhân
        //    dataGridViewDSToaThuoc.DataSource = dtToaThuoc; // Gán DataTable cho DataGridView

        //    // Đặt lại thứ tự cột cho dataGridViewDSToaThuoc
        //    dataGridViewDSToaThuoc.Columns["MaTT"].DisplayIndex = 0;       // Mã toa thuốc
        //    dataGridViewDSToaThuoc.Columns["MaBS"].DisplayIndex = 1;      // Mã bác sĩ
        //    dataGridViewDSToaThuoc.Columns["MaBN"].DisplayIndex = 2;      // Mã bệnh nhân
        //    dataGridViewDSToaThuoc.Columns["MaThuoc"].DisplayIndex = 3; // Mã bệnh nhân
        //    dataGridViewDSToaThuoc.Columns["HoTenBN"].DisplayIndex = 4;   // Mã thuốc (thêm vào đây)
        //    dataGridViewDSToaThuoc.Columns["TenThuoc"].DisplayIndex = 5;  // Tên thuốc
        //    dataGridViewDSToaThuoc.Columns["BietDuoc"].DisplayIndex = 6;  // Biệt dược
        //    dataGridViewDSToaThuoc.Columns["LieuLuong"].DisplayIndex = 7;  // Liều lượng
        //    dataGridViewDSToaThuoc.Columns["CachDung"].DisplayIndex = 8;   // Cách dùng
        //    dataGridViewDSToaThuoc.Columns["LoiDanBS"].DisplayIndex = 9;   // Lời dặn bác sĩ
        //    dataGridViewDSToaThuoc.Columns["NgayKeToa"].DisplayIndex = 10;  // Ngày kê toa
        //}
        //private void dataGridViewDSBenhNhan_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0) // Đảm bảo hàng đã nhấp là hợp lệ
        //    {
        //        // Kiểm tra nếu không có hàng nào được chọn
        //        if (dataGridViewDSBenhNhan.SelectedRows.Count > 0)
        //        {
        //            DataGridViewRow row = dataGridViewDSBenhNhan.SelectedRows[0];
        //            string maBN = row.Cells["MaBN"].Value.ToString();

        //            // Cập nhật textbox
        //            txtMaBS.Text = row.Cells["MaBS"].Value.ToString();
        //            txtMaBenhNhan.Text = maBN;
        //            txtTenBenhNhan.Text = row.Cells["HoTenBN"].Value.ToString();

        //            // Tải toa thuốc cho bệnh nhân này
        //            //LoadToaThuocByMaBN(maBN);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Vui lòng chọn một bệnh nhân.");
        //        }
        //    }
        //}

        private void txtMaBenhNhan_TextChanged(object sender, EventArgs e)
        {

        }

        //private void txtTenThuoc_TextChanged(object sender, EventArgs e)
        //{
        //    string maThuoc = txtMaThuoc.Text.Trim();
        //    if (!string.IsNullOrEmpty(maThuoc))
        //    {
        //        DAL_KeThuoc dalKeThuoc = new DAL_KeThuoc();
        //        DataTable dt = dalKeThuoc.LayThongTinThuoc(maThuoc);

        //        if (dt.Rows.Count > 0)
        //        {
        //            txtTenThuoc.Text = dt.Rows[0]["TenThuoc"].ToString();
        //            txtBietDuoc.Text = dt.Rows[0]["BietDuoc"].ToString();

        //            // Khóa 2 TextBox lại
        //            txtTenThuoc.Enabled = false;
        //            txtBietDuoc.Enabled = false;
        //        }
        //        else
        //        {
        //            // Nếu không tìm thấy thuốc, có thể xóa nội dung trong các TextBox
        //            txtTenThuoc.Text = "";
        //            txtBietDuoc.Text = "";
        //        }
        //    }
        //    else
        //    {
        //        // Nếu không có mã thuốc, có thể xóa nội dung trong các TextBox
        //        txtTenThuoc.Text = "";
        //        txtBietDuoc.Text = "";
        //    }
        //}
        private DAL_KeThuoc dalKeThuoc = new DAL_KeThuoc();
        //private void btnLuu_Click(object sender, EventArgs e)
        //{
        //    string maTT = txtBoxMaLSKB.Text; // Lấy mã toa thuốc
        //    string maLSKB = dataGridViewDSBenhNhan.SelectedRows[0].Cells["MaLSKB"].Value.ToString();
        //    DateTime ngayKeToa = dateTimeNgayKee.Value;
        //    string loiDanBS = txtLoiDan.Text;

        //    // Kiểm tra mã toa thuốc có tồn tại không
        //    if (dalKeThuoc.KiemTraMaTT(maTT))
        //    {
        //        MessageBox.Show("Mã toa thuốc đã tồn tại. Vui lòng nhập mã khác.");
        //        return;
        //    }

        //    // Lưu toa thuốc và lấy mã toa thuốc đã lưu
        //    string savedMaTT = dalKeThuoc.LuuToaThuoc(maTT, maLSKB, ngayKeToa, loiDanBS);

        //    if (savedMaTT != null)
        //    {
        //        // Lưu chi tiết toa thuốc
        //        string maThuoc = txtMaThuoc.Text; // Lấy mã thuốc từ textbox
        //        string maBS = txtMaBS.Text;
        //        string cachDung = txtCachDung.Text;
        //        string lieuLuong = txtLieuLuong.Text;
        //        string maBN = txtMaBenhNhan.Text;

        //        bool isChiTietSaved = dalKeThuoc.LuuChiTietToaThuoc(savedMaTT, maThuoc, maBS, cachDung, lieuLuong, maBN, maLSKB);

        //        if (isChiTietSaved)
        //        {
        //            MessageBox.Show("Lưu thành công toa thuốc và chi tiết toa thuốc!");
        //            dataGridViewDSToaThuoc.DataSource = dalKeThuoc.LayDSToaThuoc();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Lưu chi tiết toa thuốc không thành công.");
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Lưu toa thuốc không thành công.");
        //    }
        //}

        private void label11_Click(object sender, EventArgs e)
        {

        }

        //private void dataGridViewDSToaThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0)
        //    {
        //        // Lấy dữ liệu từ hàng đã nhấp
        //        DataGridViewRow row = dataGridViewDSToaThuoc.Rows[e.RowIndex];

        //        // Cập nhật các TextBox với dữ liệu từ hàng đã chọn
        //        txtBoxMaLSKB.Text = row.Cells["MaTT"].Value.ToString(); // Mã toa thuốc
        //        txtMaBS.Text = row.Cells["MaBS"].Value.ToString(); // Mã bác sĩ
        //        txtMaBenhNhan.Text = row.Cells["MaBN"].Value.ToString(); // Mã bệnh nhân
        //        txtTenBenhNhan.Text = row.Cells["HoTenBN"].Value.ToString(); // Tên bệnh nhân
        //        txtMaThuoc.Text = row.Cells["MaThuoc"].Value.ToString(); // Mã thuốc
        //        txtTenThuoc.Text = row.Cells["TenThuoc"].Value.ToString(); // Tên thuốc
        //        txtBietDuoc.Text = row.Cells["BietDuoc"].Value.ToString(); // Biệt dược
        //        txtLieuLuong.Text = row.Cells["LieuLuong"].Value.ToString(); // Liều lượng
        //        txtCachDung.Text = row.Cells["CachDung"].Value.ToString(); // Cách dùng
        //        txtLoiDan.Text = row.Cells["LoiDanBS"].Value.ToString(); // Lời dặn của bác sĩ
        //                                                                 // dateTimeNgayKee.Value = Convert.ToDateTime(row.Cells["NgayKeToa"].Value);
        //    }
        //}

        //private void btnSua_Click(object sender, EventArgs e)
        //{
        //    if (dataGridViewDSBenhNhan.SelectedRows.Count == 0)
        //    {
        //        MessageBox.Show("Vui lòng chọn một bệnh nhân từ danh sách!");
        //        return; // Dừng lại nếu không có hàng nào được chọn
        //    }

        //    // Nếu có hàng được chọn, tiến hành lấy thông tin
        //    DTO_ToaThuoc toaThuoc = new DTO_ToaThuoc
        //    {
        //        MaTT = int.Parse(txtBoxMaLSKB.Text), // Mã toa thuốc
        //        MaLSKB = int.Parse(dataGridViewDSBenhNhan.SelectedRows[0].Cells["MaLSKB"].Value.ToString()), // Mã lần khám
        //        NgayKeToa = dateTimeNgayKee.Value, // Ngày kê toa
        //        LoiDanBS = txtLoiDan.Text // Lời dặn bác sĩ
        //    };

        //    // Tạo danh sách chi tiết toa thuốc
        //    List<DTO_ChiTietToaThuoc> chiTietToaThuocs = new List<DTO_ChiTietToaThuoc>();

        //    // Thêm thông tin chi tiết toa thuốc
        //    chiTietToaThuocs.Add(new DTO_ChiTietToaThuoc
        //    {
        //        MaTT = toaThuoc.MaTT,
        //        MaThuoc = int.Parse(txtMaThuoc.Text), // Mã thuốc
        //        MaBS = int.Parse(txtMaBS.Text), // Mã bác sĩ
        //        CachDung = txtCachDung.Text, // Cách dùng
        //        LieuLuong = txtLieuLuong.Text, // Liều lượng
        //        MaBN = int.Parse(txtMaBenhNhan.Text), // Mã bệnh nhân
        //        MaLSKB = toaThuoc.MaLSKB // Mã lịch sử khám bệnh
        //    });

        //    // Gọi phương thức để cập nhật
        //    bool result = dalKeThuoc.CapNhatToaThuocVaChiTiet(toaThuoc, chiTietToaThuocs);

        //    if (result)
        //    {
        //        MessageBox.Show("Cập nhật thành công!");
        //        LoadData();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Cập nhật không thành công. Vui lòng kiểm tra lại!");
        //    }
        //}

        //private void btnXoa_Click(object sender, EventArgs e)
        //{

        //    if (dataGridViewDSToaThuoc.SelectedRows.Count > 0)
        //    {
        //        // Lấy mã toa thuốc từ hàng được chọn
        //        string maTT = dataGridViewDSToaThuoc.SelectedRows[0].Cells["MaTT"].Value.ToString();

        //        // Gọi phương thức xóa
        //        bool result = dalKeThuoc.XoaToaThuocVaChiTiet(maTT);
        //        if (result)
        //        {
        //            MessageBox.Show("Xóa thành công cả toa thuốc và chi tiết toa thuốc.");
        //            LoadData(); // Tải lại dữ liệu

        //            // Thiết lập lại các trường nhập liệu về trạng thái trống
        //            ClearInputFields();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Xóa không thành công.");
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Vui lòng chọn một dòng để xóa.");
        //    }

        //}
        //private void ClearInputFields()
        //{
        //    txtMaThuoc.Text = string.Empty; // Xóa mã thuốc
        //    txtTenThuoc.Text = string.Empty; // Xóa tên thuốc
        //    txtBietDuoc.Text = string.Empty; // Xóa biệt dược
        //    txtCachDung.Text = string.Empty; // Xóa cách dùng
        //    txtLieuLuong.Text = string.Empty; // Xóa liều lượng
        //    txtLoiDan.Text = string.Empty; // Xóa lời dặn bác sĩ
        //    txtMaTT.Text = string.Empty;


        //}

        private void dataGridViewDSBenhNhan_SelectionChanged(object sender, EventArgs e)
        {

        }

        //private void dateTimeNgayKham_ValueChanged(object sender, EventArgs e)
        //{
        //    DateTime selectedDate = dateTimeNgayKham.Value;

        //    // Gọi phương thức để lấy danh sách bệnh nhân theo ngày khám
        //    DataTable patientHistory = dal_KeThuoc.LayLichSuKhamBenhTheoNgay(selectedDate);

        //    // Hiển thị kết quả trong DataGridView
        //    dataGridViewDSBenhNhan.DataSource = patientHistory;
        //}

        private void btnInToaThuoc_Click(object sender, EventArgs e)
        {
            // Tạo một workbook mới
            using (var workbook = new XLWorkbook())
            {
                // Tạo một worksheet mới với tên là "Toa Thuoc"
                var worksheet = workbook.Worksheets.Add("Toa Thuoc");

                // Định dạng tiêu đề cột
                for (int i = 0; i < dataGridViewDSToaThuoc.Columns.Count; i++)
                {
                    var cell = worksheet.Cell(1, i + 1);
                    cell.Value = dataGridViewDSToaThuoc.Columns[i].HeaderText;
                    cell.Style.Font.Bold = true; // In đậm
                    cell.Style.Fill.BackgroundColor = XLColor.LightGray; // Tô màu nền nhẹ
                    cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center; // Căn giữa
                    cell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center; // Căn giữa dọc
                    cell.Style.Border.BottomBorder = XLBorderStyleValues.Thin; // Đường viền dưới
                }

                // Lặp qua các hàng trong DataGridView và chép dữ liệu vào Excel
                for (int i = 0; i < dataGridViewDSToaThuoc.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewDSToaThuoc.Columns.Count; j++)
                    {
                        var cell = worksheet.Cell(i + 2, j + 1);
                        // Kiểm tra nếu dữ liệu ô có giá trị
                        if (dataGridViewDSToaThuoc.Rows[i].Cells[j].Value != null)
                        {
                            cell.Value = dataGridViewDSToaThuoc.Rows[i].Cells[j].Value.ToString();
                        }

                        // Định dạng các ô dữ liệu
                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        cell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin; // Đường viền ngoài
                        cell.Style.Border.InsideBorder = XLBorderStyleValues.Thin; // Đường viền trong
                    }
                }

                // Căn chỉnh kích thước cột tự động
                worksheet.Columns().AdjustToContents();

                // Lưu file Excel
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    FileName = "ToaThuoc_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Tạo đối tượng DTO_ChiTietToaThuoc từ các điều khiển trên form
                DTO_ChiTietToaThuoc chiTiet = new DTO_ChiTietToaThuoc
                {
                    MaLSKB = int.Parse(txtBoxMaLSKB.Text), // Chuyển đổi từ TextBox
                    MaThuoc = int.Parse(txtBoxMaThuoc.Text), // Chuyển đổi từ TextBox
                    CachDung = txtCachDung.Text, // Lấy giá trị từ TextBox
                    LieuLuong = txtLieuLuong.Text, // Lấy giá trị từ TextBox
                    NgayKeToa = dateTimeNgayKee.Value, // Lấy giá trị từ DateTimePicker
                    LoiDanBS = txtLoiDan.Text, // Lấy giá trị từ TextBox
                    MaBS = int.Parse(cboMaBS.SelectedValue.ToString()) // Chuyển đổi từ TextBox
                };

                // Gọi phương thức BLL để thêm chi tiết toa thuốc
                string message = _KeThuocBLL.AddChiTietToaThuoc(chiTiet);

                // Hiển thị thông báo cho người dùng
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Tải lại dữ liệu nếu cần thiết (nếu bạn có một bảng để hiển thị danh sách chi tiết toa thuốc)
                LoadData();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng cho các trường số.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            try
            {
                var chiTietToaThuoc = new DTO_ChiTietToaThuoc
                {
                    MaLSKB = int.Parse(txtBoxMaLSKB.Text),
                    MaThuoc = int.Parse(txtBoxMaThuoc.Text),
                    CachDung = txtCachDung.Text,
                    LieuLuong = txtLieuLuong.Text,
                    NgayKeToa = dateTimeNgayKee.Value,
                    MaBS = (int)cboMaBS.SelectedValue,
                    LoiDanBS = txtLoiDan.Text

                };

                _KeThuocBLL.UpdateChiTietToaThuoc(chiTietToaThuoc);
                MessageBox.Show("Cập nhật chi tiết toa thuốc thành công!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            try
            {
                int maLSKB = int.Parse(txtBoxMaLSKB.Text);
                int maThuoc = int.Parse(txtBoxMaThuoc.Text);
                _KeThuocBLL.DeleteChiTietToaThuoc(maLSKB, maThuoc);
                MessageBox.Show("Xóa chi tiết toa thuốc thành công!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void dataGridViewDSToaThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu nhấp vào hàng hợp lệ
            if (e.RowIndex >= 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow row = dataGridViewDSToaThuoc.Rows[e.RowIndex];

                // Cập nhật các trường với dữ liệu từ dòng được chọn
                txtBoxMaLSKB.Text = row.Cells["MaLSKB"].Value.ToString();
                txtBoxMaThuoc.Text = row.Cells["MaThuoc"].Value.ToString();
                txtCachDung.Text = row.Cells["CachDung"].Value.ToString();
                txtLieuLuong.Text = row.Cells["LieuLuong"].Value.ToString();
                dateTimeNgayKee.Value = Convert.ToDateTime(row.Cells["NgayKeToa"].Value);
                cboMaBS.SelectedValue = row.Cells["MaBS"].Value;
            }
        }

        private void cboTenThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTenThuoc.SelectedItem is DTO_Thuoc selectedThuoc)
            {
                txtBoxMaThuoc.Text = selectedThuoc.MaThuoc.ToString(); // Cập nhật mã thuốc
                txtBietDuoc.Text = selectedThuoc.BietDuoc;
            }
        }

        private void dataGridViewDSBenhNhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng đã nhấn vào một dòng hợp lệ
            if (e.RowIndex >= 0) // e.RowIndex >= 0 đảm bảo rằng bạn không nhấn vào tiêu đề cột
            {
                // Lấy dòng đã chọn
                DataGridViewRow row = dataGridViewDSBenhNhan.Rows[e.RowIndex];

                // Gán giá trị từ dòng vào các trường tương ứng
                txtBoxMaLSKB.Text = row.Cells["MaLSKB"].Value.ToString();
                txtMaBenhNhan.Text = row.Cells["MaBN"].Value.ToString(); // Thay "MaBN" bằng tên cột thực tế trong DataGridView
                txtTenBenhNhan.Text = row.Cells["HoTenBN"].Value.ToString(); // Thay "HoTenBN" bằng tên cột thực tế

            }
        }

        private void btnInToaThuoc_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewDSToaThuoc.SelectedRows.Count > 0)
            {
                int maLSKB = (int)dataGridViewDSToaThuoc.SelectedRows[0].Cells["MaLSKB"].Value;
                var (chiTietToaThuoc, bacSi, benhNhan) = _KeThuocBLL.GetToaThuocByMaLSKB(maLSKB);

                // Tạo chuỗi thông tin để in
                string thongTinToaThuoc = $"Tên Bác Sĩ: {bacSi.TenBS}\n" +
                                           $"Họ Tên Bệnh Nhân: {benhNhan.HoTenBN}\n" +
                                           $"Số Điện Thoại: {benhNhan.SoDT}\n" +
                                           $"Ngày Giờ Kê Toa: {DateTime.Now:dd/MM/yyyy HH:mm} CH\n\n" +
                                           "Chi Tiết Toa Thuốc:\n";

                int thuocIndex = 1; // Đếm số thuốc
                foreach (var chiTiet in chiTietToaThuoc)
                {
                    thongTinToaThuoc += $"- Thuốc {thuocIndex}:\n" +
                                        $"  - Tên Thuốc: {chiTiet.TenThuoc}\n" +
                                        $"  - Biệt Dược: {chiTiet.BietDuoc}\n" +
                                        $"  - Cách Dùng: {chiTiet.ChiTietToaThuoc.CachDung}\n" +
                                        $"  - Liều Lượng: {chiTiet.ChiTietToaThuoc.LieuLuong}\n" +
                                        $"  - Lời Dặn: {chiTiet.ChiTietToaThuoc.LoiDanBS}\n\n";
                    thuocIndex++;
                }

                // Khởi tạo PrintDocument
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrintPage += (s, ev) =>
                {
                    ev.Graphics.DrawString(thongTinToaThuoc, new Font("Arial", 12), Brushes.Black, new PointF(100, 100));
                };

                // Hiển thị hộp thoại in
                PrintDialog printDialog = new PrintDialog
                {
                    Document = printDocument
                };

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng trong bảng để in thông tin toa thuốc.",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }
    }
}
