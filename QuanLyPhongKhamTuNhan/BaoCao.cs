using DAL;
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
    public partial class BaoCao : Form
    {
        public BaoCao()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePickerTuNgay_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerDenNgay_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewBaoCao_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BaoCao_Load(object sender, EventArgs e)
        {
            btnInDoanhThu.Enabled = false;
        }

        private void btnXemDoanhThu_Click(object sender, EventArgs e)
        {
            DateTime tungay = dateTimePickerTuNgay.Value;
            DateTime denngay = dateTimePickerDenNgay.Value;
            if (tungay > denngay)
            {
                // Thông báo lỗi nếu ngày bắt đầu lớn hơn ngày kết thúc
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Dừng thực thi nếu có lỗi
            }
            else
            {
                DataTable baoCao = DAL_BaoCao.GetBaoCao(tungay, denngay);

                // Hiển thị dữ liệu trong DataGridView
                dataGridViewBaoCao.DataSource = baoCao;
                btnInDoanhThu.Enabled = true;
            }

            // Gọi hàm từ DAL để lấy báo cáo
            
        }

        private void btnInDoanhThu_Click(object sender, EventArgs e)
        {
            // Lấy ngày bắt đầu và ngày kết thúc từ các control DateTimePicker
            DateTime tungay = dateTimePickerTuNgay.Value; // dtpStartDate là tên của DateTimePicker cho ngày bắt đầu
            DateTime denngay = dateTimePickerDenNgay.Value; // dtpEndDate là tên của DateTimePicker cho ngày kết thúc

            try
            {
                // Lấy dữ liệu báo cáo từ cơ sở dữ liệu
                DataTable reportData = DAL_BaoCao.GetBaoCao(tungay, denngay);

                // Kiểm tra xem có dữ liệu hay không
                if (reportData != null && reportData.Rows.Count > 0)
                {
                    // Tạo SaveFileDialog cho người dùng chọn nơi lưu tệp
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx"; // Chỉ cho phép chọn file Excel
                    saveFileDialog.FileName = $"DoanhThu_{tungay.ToString("yyyyMMdd")}_{denngay.ToString("yyyyMMdd")}.xlsx"; // Đặt tên file mặc định

                    // Nếu người dùng chọn nơi lưu và nhấn Save
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName; // Lấy đường dẫn tệp đã chọn

                        // Xuất dữ liệu ra Excel
                        DAL_BaoCao.ExportToExcel(reportData, filePath);

                        // Thông báo cho người dùng
                        MessageBox.Show($"Báo cáo doanh thu đã được xuất ra: {filePath}", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu cho khoảng thời gian này!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi nếu có
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
