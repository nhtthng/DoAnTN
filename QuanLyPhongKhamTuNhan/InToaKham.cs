using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class InToaKham : Form
    {
        public DTO_InToaKham toaKhamdata { get; set; }
        public InToaKham()
        {
            InitializeComponent();
        }

        private void InToaKham_Load(object sender, EventArgs e)
        {
            if (toaKhamdata != null)
            {
                txtTenBS.Text = toaKhamdata.TenBacSi;
                txtTenBN.Text = toaKhamdata.TenBenhNhan;
                DTPNgayKham.Value = toaKhamdata.NgayKham;
                txtChuanDoan.Text = toaKhamdata.ChuanDoan;
            }
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng Graphics để vẽ lên form
            using (PrintDocument printDocument = new PrintDocument())
            {
                printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
                PrintDialog printDialog = new PrintDialog
                {
                    Document = printDocument
                };

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                }
            }
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Thiết lập font và brush
            Font font = new Font("Arial", 12);
            Brush brush = Brushes.Black;

            e.Graphics.DrawString("Phòng Khám TPT", new Font("Arial", 16, FontStyle.Bold), brush, 100, 60);
            // Vẽ các thông tin lên trang in
            e.Graphics.DrawString("Phiếu Khám", new Font("Arial", 16, FontStyle.Bold), brush, 100, 100);
            e.Graphics.DrawString("Tên Bác Sĩ: " + txtTenBS.Text, font, brush, 100, 150);
            e.Graphics.DrawString("Tên Bệnh Nhân: " + txtTenBN.Text, font, brush, 100, 180);
            e.Graphics.DrawString("Ngày Khám: " + DTPNgayKham.Value.ToString("dd/MM/yyyy"), font, brush, 100, 210);
            e.Graphics.DrawString("Chuẩn Đoán: " + txtChuanDoan.Text, font, brush, 100, 240);
            e.Graphics.DrawString("Kết Luận: " + RtxtBoxKetLuan.Text, font, brush, 100, 270);
        }
    }
}
