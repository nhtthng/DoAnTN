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
    public partial class PhongBan : Form
    {
        private DAL_PhongBan dalPhongBan = new DAL_PhongBan();
        private List<DTO_PhongBan> phongBanList = new List<DTO_PhongBan>();
        public PhongBan()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Collect data from input fields (assuming you have txtMaPB and txtTenPB TextBoxes)
            //int maPB = int.Parse(txtMaPhong.Text);
            string tenPB = txtTenPhongBan.Text;

            DTO_PhongBan newPhongBan = new DTO_PhongBan
            {
                //MaPB = maPB,
                TenPB = tenPB
            };

            if (dalPhongBan.ThemPhongBan(newPhongBan))
            {
                MessageBox.Show("Thêm phòng ban thành công!");
                LoadPhongBanData(); // Reload the data
            }
            else
            {
                MessageBox.Show("Lỗi khi thêm phòng ban.");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int maPB = (int)dataGridView1.SelectedRows[0].Cells["MaPB"].Value;
                string tenPB = txtTenPhongBan.Text; // Get updated name from input field

                DTO_PhongBan updatedPhongBan = new DTO_PhongBan
                {
                    MaPB = maPB,
                    TenPB = tenPB
                };

                if (dalPhongBan.SuaPhongBan(updatedPhongBan))
                {
                    MessageBox.Show("Cập nhật phòng ban thành công!");
                    LoadPhongBanData(); // Reload the data
                }
                else
                {
                    MessageBox.Show("Lỗi khi cập nhật phòng ban.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phòng ban để cập nhật.");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int maPB = (int)dataGridView1.SelectedRows[0].Cells["MaPB"].Value;

                if (dalPhongBan.XoaPhongBan(maPB))
                {
                    MessageBox.Show("Xóa phòng ban thành công!");
                    LoadPhongBanData(); // Reload the data
                }
                else
                {
                    MessageBox.Show("Lỗi khi xóa phòng ban.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phòng ban để xóa.");
            }
        }

        private void PhongBan_Load(object sender, EventArgs e)
        {
            LoadPhongBanData();
        }
        private void LoadPhongBanData()
        {
            phongBanList = dalPhongBan.GetPhongBanList(); // Get departments from DAL
            dataGridView1.DataSource = phongBanList; // Bind the list to DataGridView
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // When a cell is clicked, populate the input fields with the selected department's data
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                txtMaPhong.Text = selectedRow.Cells["MaPB"].Value.ToString(); // Assuming txtMaPB is for MaPB
                txtTenPhongBan.Text = selectedRow.Cells["TenPB"].Value.ToString(); // Assuming txtTenPB is for TenPB
            }
        }
    }
}
