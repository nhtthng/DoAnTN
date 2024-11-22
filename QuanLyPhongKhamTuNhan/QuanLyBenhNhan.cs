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
            this.StartPosition = FormStartPosition.CenterScreen;
            DGVBN.CellClick += DGVBN_CellClick;
            LoadAllPatients();
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
            int maBN;
            if (int.TryParse(txtboxMaBenhNhan.Text, out maBN))
            {
                BLL_QuanLyBenhNhan bll = new BLL_QuanLyBenhNhan();
                DTO_QuanLyBenhNhan patient = bll.SearchPatientByMaBN(maBN);

                if (patient != null)
                {
                    // Hiển thị thông tin bệnh nhân vào DataGridView
                    DGVBN.DataSource = new List<DTO_QuanLyBenhNhan> { patient };
                    LoadAllPatients();
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
