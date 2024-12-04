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
    public partial class KeThuoc : Form
    {
        private DAL_KeThuoc dal_KeThuoc = new DAL_KeThuoc();

        public KeThuoc()
        {
            InitializeComponent();
            txtTenThuoc.ReadOnly = true; // Khóa ô tên thuốc
            txtBietDuoc.ReadOnly = true; // Khóa ô biệt dược


        }
        public void SetPatientId(int patientId)
        {
            txtMaBenhNhan.Text = patientId.ToString();
        }
        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewDSBenhNhan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadData()
        {
            DataTable dtBenhNhan = dalKeThuoc.LayThongTinBenhNhan();
            dataGridViewDSBenhNhan.DataSource = dtBenhNhan;

            // Đặt lại thứ tự cột cho dataGridViewDSBenhNhan
            dataGridViewDSBenhNhan.Columns["MaLSKB"].DisplayIndex = 0;
            dataGridViewDSBenhNhan.Columns["MaBS"].DisplayIndex = 1;
            dataGridViewDSBenhNhan.Columns["MaBN"].DisplayIndex = 2;
            dataGridViewDSBenhNhan.Columns["HoTenBN"].DisplayIndex = 3;

            // Tải dữ liệu toa thuốc
            DataTable dtToaThuoc = dalKeThuoc.LayDSToaThuoc();
            dataGridViewDSToaThuoc.DataSource = dtToaThuoc;

            // Đặt lại thứ tự cột cho dataGridViewDSToaThuoc
            dataGridViewDSToaThuoc.Columns["MaTT"].DisplayIndex = 0;       // Mã toa thuốc
            dataGridViewDSToaThuoc.Columns["MaBS"].DisplayIndex = 1;      // Mã bác sĩ
            dataGridViewDSToaThuoc.Columns["MaBN"].DisplayIndex = 2;
            dataGridViewDSToaThuoc.Columns["MaThuoc"].DisplayIndex = 3; // Mã bệnh nhân
            dataGridViewDSToaThuoc.Columns["HoTenBN"].DisplayIndex = 4;   // Họ tên bệnh nhân
                                                                          // Mã thuốc (thêm vào đây)
            dataGridViewDSToaThuoc.Columns["TenThuoc"].DisplayIndex = 5;  // Tên thuốc
            dataGridViewDSToaThuoc.Columns["BietDuoc"].DisplayIndex = 6;  // Biệt dược
            dataGridViewDSToaThuoc.Columns["LieuLuong"].DisplayIndex = 7;  // Liều lượng
            dataGridViewDSToaThuoc.Columns["CachDung"].DisplayIndex = 8;   // Cách dùng
            dataGridViewDSToaThuoc.Columns["LoiDanBS"].DisplayIndex = 9;   // Lời dặn bác sĩ
            dataGridViewDSToaThuoc.Columns["NgayKeToa"].DisplayIndex = 10;  // Ngày kê toa
        }
        private void KeThuoc_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadToaThuocByMaBN(string maBN)
        {
            // Tải dữ liệu toa thuốc cho bệnh nhân có mã MaBN
            DataTable dtToaThuoc = dalKeThuoc.LayDSToaThuocByMaBN(maBN); // Gọi phương thức lấy dữ liệu toa thuốc theo mã bệnh nhân
            dataGridViewDSToaThuoc.DataSource = dtToaThuoc; // Gán DataTable cho DataGridView

            // Đặt lại thứ tự cột cho dataGridViewDSToaThuoc
            dataGridViewDSToaThuoc.Columns["MaTT"].DisplayIndex = 0;       // Mã toa thuốc
            dataGridViewDSToaThuoc.Columns["MaBS"].DisplayIndex = 1;      // Mã bác sĩ
            dataGridViewDSToaThuoc.Columns["MaBN"].DisplayIndex = 2;      // Mã bệnh nhân
            dataGridViewDSToaThuoc.Columns["MaThuoc"].DisplayIndex = 3; // Mã bệnh nhân
            dataGridViewDSToaThuoc.Columns["HoTenBN"].DisplayIndex = 4;   // Mã thuốc (thêm vào đây)
            dataGridViewDSToaThuoc.Columns["TenThuoc"].DisplayIndex = 5;  // Tên thuốc
            dataGridViewDSToaThuoc.Columns["BietDuoc"].DisplayIndex = 6;  // Biệt dược
            dataGridViewDSToaThuoc.Columns["LieuLuong"].DisplayIndex = 7;  // Liều lượng
            dataGridViewDSToaThuoc.Columns["CachDung"].DisplayIndex = 8;   // Cách dùng
            dataGridViewDSToaThuoc.Columns["LoiDanBS"].DisplayIndex = 9;   // Lời dặn bác sĩ
            dataGridViewDSToaThuoc.Columns["NgayKeToa"].DisplayIndex = 10;  // Ngày kê toa
        }
        private void dataGridViewDSBenhNhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo hàng đã nhấp là hợp lệ
            {
                // Kiểm tra nếu không có hàng nào được chọn
                if (dataGridViewDSBenhNhan.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dataGridViewDSBenhNhan.SelectedRows[0];
                    string maBN = row.Cells["MaBN"].Value.ToString();

                    // Cập nhật textbox
                    txtMaBS.Text = row.Cells["MaBS"].Value.ToString();
                    txtMaBenhNhan.Text = maBN;
                    txtTenBenhNhan.Text = row.Cells["HoTenBN"].Value.ToString();

                    // Tải toa thuốc cho bệnh nhân này
                    LoadToaThuocByMaBN(maBN);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một bệnh nhân.");
                }
            }
        }

        private void txtMaBenhNhan_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenBenhNhan_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenThuoc_TextChanged(object sender, EventArgs e)
        {
            string maThuoc = txtMaThuoc.Text.Trim();
            if (!string.IsNullOrEmpty(maThuoc))
            {
                DAL_KeThuoc dalKeThuoc = new DAL_KeThuoc();
                DataTable dt = dalKeThuoc.LayThongTinThuoc(maThuoc);

                if (dt.Rows.Count > 0)
                {
                    txtTenThuoc.Text = dt.Rows[0]["TenThuoc"].ToString();
                    txtBietDuoc.Text = dt.Rows[0]["BietDuoc"].ToString();

                    // Khóa 2 TextBox lại
                    txtTenThuoc.Enabled = false;
                    txtBietDuoc.Enabled = false;
                }
                else
                {
                    // Nếu không tìm thấy thuốc, có thể xóa nội dung trong các TextBox
                    txtTenThuoc.Text = "";
                    txtBietDuoc.Text = "";
                }
            }
            else
            {
                // Nếu không có mã thuốc, có thể xóa nội dung trong các TextBox
                txtTenThuoc.Text = "";
                txtBietDuoc.Text = "";
            }
        }

        private void txtBietDuoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLieuLuong_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCachDung_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLoiDan_TextChanged(object sender, EventArgs e)
        {

        }



        private void dataGridViewDSToaThuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private DAL_KeThuoc dalKeThuoc = new DAL_KeThuoc();
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maTT = txtMaTT.Text; // Lấy mã toa thuốc
            string maLSKB = dataGridViewDSBenhNhan.SelectedRows[0].Cells["MaLSKB"].Value.ToString();
            DateTime ngayKeToa = dateTimeNgayKee.Value;
            string loiDanBS = txtLoiDan.Text;

            // Kiểm tra mã toa thuốc có tồn tại không
            if (dalKeThuoc.KiemTraMaTT(maTT))
            {
                MessageBox.Show("Mã toa thuốc đã tồn tại. Vui lòng nhập mã khác.");
                return;
            }

            // Lưu toa thuốc và lấy mã toa thuốc đã lưu
            string savedMaTT = dalKeThuoc.LuuToaThuoc(maTT, maLSKB, ngayKeToa, loiDanBS);

            if (savedMaTT != null)
            {
                // Lưu chi tiết toa thuốc
                string maThuoc = txtMaThuoc.Text; // Lấy mã thuốc từ textbox
                string maBS = txtMaBS.Text;
                string cachDung = txtCachDung.Text;
                string lieuLuong = txtLieuLuong.Text;
                string maBN = txtMaBenhNhan.Text;

                bool isChiTietSaved = dalKeThuoc.LuuChiTietToaThuoc(savedMaTT, maThuoc, maBS, cachDung, lieuLuong, maBN, maLSKB);

                if (isChiTietSaved)
                {
                    MessageBox.Show("Lưu thành công toa thuốc và chi tiết toa thuốc!");
                    dataGridViewDSToaThuoc.DataSource = dalKeThuoc.LayDSToaThuoc();
                }
                else
                {
                    MessageBox.Show("Lưu chi tiết toa thuốc không thành công.");
                }
            }
            else
            {
                MessageBox.Show("Lưu toa thuốc không thành công.");
            }
        }

        private void dateTimeNgayKee_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewDSToaThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dữ liệu từ hàng đã nhấp
                DataGridViewRow row = dataGridViewDSToaThuoc.Rows[e.RowIndex];

                // Cập nhật các TextBox với dữ liệu từ hàng đã chọn
                txtMaTT.Text = row.Cells["MaTT"].Value.ToString(); // Mã toa thuốc
                txtMaBS.Text = row.Cells["MaBS"].Value.ToString(); // Mã bác sĩ
                txtMaBenhNhan.Text = row.Cells["MaBN"].Value.ToString(); // Mã bệnh nhân
                txtTenBenhNhan.Text = row.Cells["HoTenBN"].Value.ToString(); // Tên bệnh nhân
                txtMaThuoc.Text = row.Cells["MaThuoc"].Value.ToString(); // Mã thuốc
                txtTenThuoc.Text = row.Cells["TenThuoc"].Value.ToString(); // Tên thuốc
                txtBietDuoc.Text = row.Cells["BietDuoc"].Value.ToString(); // Biệt dược
                txtLieuLuong.Text = row.Cells["LieuLuong"].Value.ToString(); // Liều lượng
                txtCachDung.Text = row.Cells["CachDung"].Value.ToString(); // Cách dùng
                txtLoiDan.Text = row.Cells["LoiDanBS"].Value.ToString(); // Lời dặn của bác sĩ
                                                                         // dateTimeNgayKee.Value = Convert.ToDateTime(row.Cells["NgayKeToa"].Value);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridViewDSBenhNhan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một bệnh nhân từ danh sách!");
                return; // Dừng lại nếu không có hàng nào được chọn
            }

            // Nếu có hàng được chọn, tiến hành lấy thông tin
            DTO_ToaThuoc toaThuoc = new DTO_ToaThuoc
            {
                MaTT = int.Parse(txtMaTT.Text), // Mã toa thuốc
                MaLSKB = int.Parse(dataGridViewDSBenhNhan.SelectedRows[0].Cells["MaLSKB"].Value.ToString()), // Mã lần khám
                NgayKeToa = dateTimeNgayKee.Value, // Ngày kê toa
                LoiDanBS = txtLoiDan.Text // Lời dặn bác sĩ
            };

            // Tạo danh sách chi tiết toa thuốc
            List<DTO_ChiTietToaThuoc> chiTietToaThuocs = new List<DTO_ChiTietToaThuoc>();

            // Thêm thông tin chi tiết toa thuốc
            chiTietToaThuocs.Add(new DTO_ChiTietToaThuoc
            {
                MaTT = toaThuoc.MaTT,
                MaThuoc = int.Parse(txtMaThuoc.Text), // Mã thuốc
                MaBS = int.Parse(txtMaBS.Text), // Mã bác sĩ
                CachDung = txtCachDung.Text, // Cách dùng
                LieuLuong = txtLieuLuong.Text, // Liều lượng
                MaBN = int.Parse(txtMaBenhNhan.Text), // Mã bệnh nhân
                MaLSKB = toaThuoc.MaLSKB // Mã lịch sử khám bệnh
            });

            // Gọi phương thức để cập nhật
            bool result = dalKeThuoc.CapNhatToaThuocVaChiTiet(toaThuoc, chiTietToaThuocs);

            if (result)
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadData();
            }
            else
            {
                MessageBox.Show("Cập nhật không thành công. Vui lòng kiểm tra lại!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (dataGridViewDSToaThuoc.SelectedRows.Count > 0)
            {
                // Lấy mã toa thuốc từ hàng được chọn
                string maTT = dataGridViewDSToaThuoc.SelectedRows[0].Cells["MaTT"].Value.ToString();

                // Gọi phương thức xóa
                bool result = dalKeThuoc.XoaToaThuocVaChiTiet(maTT);
                if (result)
                {
                    MessageBox.Show("Xóa thành công cả toa thuốc và chi tiết toa thuốc.");
                    LoadData(); // Tải lại dữ liệu

                    // Thiết lập lại các trường nhập liệu về trạng thái trống
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Xóa không thành công.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.");
            }

        }
        private void ClearInputFields()
        {
            txtMaThuoc.Text = string.Empty; // Xóa mã thuốc
            txtTenThuoc.Text = string.Empty; // Xóa tên thuốc
            txtBietDuoc.Text = string.Empty; // Xóa biệt dược
            txtCachDung.Text = string.Empty; // Xóa cách dùng
            txtLieuLuong.Text = string.Empty; // Xóa liều lượng
            txtLoiDan.Text = string.Empty; // Xóa lời dặn bác sĩ
            txtMaTT.Text = string.Empty;
           
                                         
        }

        private void dataGridViewDSBenhNhan_SelectionChanged(object sender, EventArgs e)
        {
           
        }
    }
}
