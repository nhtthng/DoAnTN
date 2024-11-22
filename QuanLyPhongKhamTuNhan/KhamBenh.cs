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
    public partial class KhamBenh : Form
    {
        private BLL_KhamBenh bllKhamBenh = new BLL_KhamBenh();
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
            if (bllKhamBenh.CheckIdLSKB(int.Parse(txtBoxLSKB.Text)) == false)
            {
                MessageBox.Show("Mã lịch sử khám bệnh bị trùng");
                return;
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

            if (bllKhamBenh.AddKhamBenh(khamBenh))
            {
                MessageBox.Show("Thêm thành công!");
                LoadKhamBenhData();
            }
            else
            {
                MessageBox.Show("Thêm không thành công!");
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
            // Kiểm tra các trường và đặt thông báo lỗi nếu cần
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(txtBoxTimLSKB.Text))
            {
                errorProviderKB.SetError(txtBoxTimLSKB, "Vui lòng nhập mã lịch sử khám bệnh.");
                isValid = false;
            }
            // Kiểm tra nếu tất cả các trường đều hợp lệ
            if (!isValid)
            {
                return; // Dừng hàm nếu còn trường trống
            }
            int keyword = int.Parse(txtBoxTimLSKB.Text.Trim());
            List<DTO_KhamBenh> result = bllKhamBenh.SearchKhamBenhByMaBN(keyword);

            if (result.Count > 0)
            {
                DGVKB.DataSource = result;
                MessageBox.Show("Tìm kiếm thành công!");
            }
            else
            {
                MessageBox.Show("Không tìm thấy kết quả!");
                LoadKhamBenhData(); // Tải lại dữ liệu gốc nếu không tìm thấy
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
    }
}
