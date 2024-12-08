using BLL;
using DAL;
using DTO;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class HoaDon : Form
    {
        private BLL_HoaDon _HoaDonBLL = new BLL_HoaDon();
        public HoaDon()
        {
            InitializeComponent();
            DGVHD.CellClick += DGVHD_CellClick;
            LoadDanhSachHoaDon();
            var dsNhanVien = new DataHelper().GetNhanVienList();
            cboNhanVien.DataSource = dsNhanVien;
            cboNhanVien.DisplayMember = "HoTen";
            cboNhanVien.ValueMember = "MaNV";
            var dsBenhNhan = new DataHelper().GetBenhNhanList();
            cboBenhNhan.DataSource = dsBenhNhan;
            cboBenhNhan.DisplayMember = "HoTenBN";
            cboBenhNhan.ValueMember = "MaBN";
            // Điền dữ liệu vào ComboBox
            cboGiamGia.Items.AddRange(new object[] { 0, 10, 20, 25, 30 });

            // Chọn mặc định
            cboGiamGia.SelectedIndex = 0;
        }
        public void SetPatientId(int patientId)
        {
            cboBenhNhan.SelectedValue = patientId;
        }
        public void SetMedicalHistoryId(int medicalHistoryId)
        {
            txtBoxMaLSKB.Text = medicalHistoryId.ToString(); // Gán giá trị vào TextBox
        }
        private void LoadDanhSachHoaDon()
        {
            try
            {
                DGVHD.DataSource = _HoaDonBLL.LayTatCaHoaDon();
                DGVHD.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra điều kiện
                if (cboNhanVien.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo đối tượng hóa đơn
                DTO_HoaDon hoaDon = new DTO_HoaDon
                {
                    NgayLapHD = DTPNgayLap.Value,
                    MaNV = Convert.ToInt32(cboNhanVien.SelectedValue),
                    GiamGia = Convert.ToInt32(cboGiamGia.SelectedValue),
                    MaBN = Convert.ToInt32(cboBenhNhan.SelectedValue),
                    MaLSKB = Convert.ToInt32(txtBoxMaLSKB.Text),
                    PhuongThucThanhToan = cboPTTT.SelectedItem.ToString()
                };

                // Nếu có chọn bệnh nhân, thêm MaBN
                if (cboBenhNhan.SelectedValue != null)
                {
                    hoaDon.MaBN = Convert.ToInt32(cboBenhNhan.SelectedValue);
                }

                // Thêm hóa đơn
                int maHD = _HoaDonBLL.ThemHoaDon(hoaDon);

                if (maHD > 0)
                {
                    MessageBox.Show("Thêm hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachHoaDon();
                    ResetForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra đã chọn hóa đơn để xóa
                if (string.IsNullOrEmpty(txtBoxMaHoaDon.Text))
                {
                    MessageBox.Show("Vui lòng chọn hóa đơn để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Xác nhận xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int maHD = Convert.ToInt32(txtBoxMaHoaDon.Text);
                    bool ketQua = _HoaDonBLL.XoaHoaDon(maHD);

                    if (ketQua)
                    {
                        MessageBox.Show("Xóa hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachHoaDon();
                        ResetForm();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                // Tìm kiếm theo các tiêu chí
                int tuKhoa = int.Parse(txtBoxTim.Text);

                // Nếu không nhập từ khóa, load lại toàn bộ danh sách
                if (string.IsNullOrEmpty(txtBoxTim.Text))
                {
                    LoadDanhSachHoaDon();
                    return;
                }

                // Tìm kiếm
                DGVHD.DataSource = _HoaDonBLL.TimHoaDonTheoMa(tuKhoa);
                DGVHD.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra đã chọn hóa đơn
                if (string.IsNullOrEmpty(txtBoxMaHoaDon.Text))
                {
                    MessageBox.Show("Vui lòng chọn hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int maHD = Convert.ToInt32(txtBoxMaHoaDon.Text);

                // Cập nhật hóa đơn hoàn thành
                bool ketQua = _HoaDonBLL.CapNhatHoaDonHoanThanh(maHD);

                if (ketQua)
                {
                    MessageBox.Show("Cập nhật hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachHoaDon();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật. Hóa đơn chưa có chi tiết sử dụng dịch vụ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ResetForm()
        {
            txtBoxMaHoaDon.Clear();
            DTPNgayLap.Value = DateTime.Now;
            cboBenhNhan.SelectedIndex = -1;
            cboNhanVien.SelectedIndex = -1;
            cboGiamGia.SelectedIndex = -1;
            txtBoxTim.Clear();
            LoadDanhSachHoaDon();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void DGVHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem có phải click vào header không
            if (e.RowIndex < 0) return;

            try
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = DGVHD.Rows[e.RowIndex];

                // Điền mã hóa đơn
                txtBoxMaHoaDon.Text = selectedRow.Cells["MaHD"].Value?.ToString() ?? "";

                // Điền ngày lập hóa đơn
                if (selectedRow.Cells["NgayLapHD"].Value is DateTime ngayLap)
                {
                    DTPNgayLap.Value = ngayLap;
                }

                // Điền nhân viên
                if (selectedRow.Cells["MaNV"].Value != null)
                {
                    int maNV = Convert.ToInt32(selectedRow.Cells["MaNV"].Value);
                    cboNhanVien.SelectedValue = maNV;
                }

                // Điền bệnh nhân (nếu có)
                if (selectedRow.Cells["MaBN"].Value != null)
                {
                    int maBN = Convert.ToInt32(selectedRow.Cells["MaBN"].Value);
                    cboBenhNhan.SelectedValue = maBN;
                }

                // Điền giảm giá
                if (selectedRow.Cells["GiamGia"].Value != null)
                {
                    int giamGia = Convert.ToInt32(selectedRow.Cells["GiamGia"].Value);
                    cboGiamGia.SelectedItem = giamGia;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chọn hóa đơn: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {

                // Tạo đối tượng Hóa Đơn để cập nhật
                DTO_HoaDon hoaDonCapNhat = new DTO_HoaDon
                {
                    MaHD = int.Parse(txtBoxMaHoaDon.Text),
                    NgayLapHD = DTPNgayLap.Value,
                    MaNV = Convert.ToInt32(cboNhanVien.SelectedValue),
                    MaBN = Convert.ToInt32(cboBenhNhan.SelectedValue),
                    GiamGia = Convert.ToInt32(cboGiamGia.SelectedItem),
                    MaLSKB = Convert.ToInt32(txtBoxMaLSKB.Text),
                    PhuongThucThanhToan = cboPTTT.SelectedItem.ToString()
                };

                // Gọi phương thức cập nhật từ BLL
                bool ketQua = _HoaDonBLL.CapNhatHoaDon(hoaDonCapNhat);

                if (ketQua)
                {
                    MessageBox.Show("Cập nhật hóa đơn thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Đóng form hoặc làm mới danh sách
                    this.DialogResult = DialogResult.OK;
                    LoadDanhSachHoaDon();

                }
                else
                {
                    MessageBox.Show("Cập nhật hóa đơn thất bại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintInvoice(InvoiceDetails invoiceDetails)
        {
            // Tạo đối tượng PrintDocument
            PrintDocument printDoc = new PrintDocument();

            // Đăng ký sự kiện PrintPage
            printDoc.PrintPage += (sender, e) =>
            {
                // Tạo một chuỗi để chứa thông tin hóa đơn
                StringBuilder invoiceText = new StringBuilder();
                invoiceText.AppendLine("HÓA ĐƠN");
                invoiceText.AppendLine("-------------------------");
                invoiceText.AppendLine($"Mã Hóa Đơn: {invoiceDetails.HoaDon.MaHD}");
                invoiceText.AppendLine($"Mã Bệnh Nhân: {invoiceDetails.HoaDon.MaBN}");
                invoiceText.AppendLine($"Mã Nhân Viên: {invoiceDetails.HoaDon.MaNV}");
                invoiceText.AppendLine($"Ngày Lập Hóa Đơn: {invoiceDetails.HoaDon.NgayLapHD}");
                invoiceText.AppendLine($"Giảm Giá: {invoiceDetails.HoaDon.GiamGia}");
                invoiceText.AppendLine($"Trạng Thái: {invoiceDetails.HoaDon.TrangThai}");
                invoiceText.AppendLine($"Mã Lịch Sử Khám Bệnh: {invoiceDetails.HoaDon.MaLSKB}");
                invoiceText.AppendLine($"Tổng Tiền: {invoiceDetails.HoaDon.TongTien}");
                invoiceText.AppendLine($"Họ Tên Bệnh Nhân: {invoiceDetails.HoTenBN}");
                invoiceText.AppendLine($"Ngày Sinh: {invoiceDetails.NgaySinh}");
                invoiceText.AppendLine($"Số Điện Thoại: {invoiceDetails.SoDT}");

                // Vẽ thông tin hóa đơn lên trang in
                e.Graphics.DrawString(invoiceText.ToString(), new Font("Arial", 12), Brushes.Black, new PointF(10, 10));
            };

            // Hiển thị hộp thoại in
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDoc;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDoc.Print();
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {// Tạo đối tượng BLL
            BLL_HoaDon bllHoaDon = new BLL_HoaDon();

            // Lấy mã hóa đơn từ DataGridView
            int maHD = (int)DGVHD.CurrentRow.Cells["MaHD"].Value;

            // Lấy thông tin hóa đơn
            DTO_HoaDon hoaDon = bllHoaDon.GetHoaDonById(maHD);
            DTO_QuanLyBenhNhan benhNhan = bllHoaDon.GetBenhNhanById(hoaDon.MaBN);
            DTO_NhanVien nhanVien = bllHoaDon.GetNhanVienById(hoaDon.MaNV);

            // Lấy chi tiết dịch vụ và tên dịch vụ
            var (chiTietDichVu, tenDichVuList) = bllHoaDon.GetChiTietSuDungDVByMaLSKB(hoaDon.MaLSKB);

            // In hóa đơn
            PrintInvoice(hoaDon, benhNhan, nhanVien, chiTietDichVu, tenDichVuList);
        }

        //private void cboBenhNhan_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Kiểm tra xem có bệnh nhân được chọn không
        //        if (cboBenhNhan.SelectedItem == null)
        //        {
        //            ResetBenhNhanControls();
        //            return;
        //        }

        //        // Lấy bệnh nhân được chọn
        //        DTO_QuanLyBenhNhan benhNhanChon = cboBenhNhan.SelectedItem as DTO_QuanLyBenhNhan;

        //        if (benhNhanChon == null)
        //        {
        //            ResetBenhNhanControls();
        //            return;
        //        }

        //        // Lấy mã bệnh nhân
        //        int maBN = benhNhanChon.MaBN;

        //        // Khởi tạo DataHelper
        //        DataHelper dataHelper = new DataHelper();

        //        // Lấy danh sách Hóa Đơn của Bệnh Nhân
        //        List<DTO_ChiTietSuDungDV> danhSachHoaDon = dataHelper.GetHoaDonByMaBN(maBN);

        //        // Kiểm tra và xử lý hóa đơn
        //        if (danhSachHoaDon != null && danhSachHoaDon.Count > 0)
        //        {
        //            // Hiển thị mã hóa đơn đầu tiên
        //            txtBoxMaHoaDon.Text = danhSachHoaDon[0].MaHD.ToString();
        //        }
        //        else
        //        {
        //            // Nếu không có hóa đơn, xóa mã hóa đơn
        //            txtBoxMaHoaDon.Clear();
        //        }

        //        // Lấy thông tin chi tiết bệnh nhân
        //        DTO_QuanLyBenhNhan benhNhanChiTiet = dataHelper.GetThongTinBenhNhanByMaBN(maBN);

        //        if (benhNhanChiTiet != null)
        //        {
        //            // Điền số điện thoại
        //            txtBoxSDT.Text = benhNhanChiTiet.SoDT;
        //            txtBoxSDT.ReadOnly = true;
        //        }
        //        else
        //        {
        //            // Nếu không tìm thấy thông tin
        //            txtBoxSDT.Clear();
        //            txtBoxSDT.ReadOnly = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Xử lý ngoại lệ
        //        MessageBox.Show($"Lỗi khi chọn bệnh nhân: {ex.Message}",
        //            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        // Reset các control
        //        ResetBenhNhanControls();
        //    }
        //}
        //private void TimKiemBenhNhanTheoSDT()
        //{
        //    // Lấy số điện thoại và loại bỏ khoảng trắng
        //    string soDienThoai = txtBoxTimSDTBN.Text.Trim();

        //    // Kiểm tra số điện thoại có rỗng không
        //    if (string.IsNullOrWhiteSpace(soDienThoai))
        //    {
        //        MessageBox.Show("Vui lòng nhập số điện thoại", "Thông báo",
        //            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        txtBoxTimSDTBN.Focus(); // Đưa con trỏ về ô nhập
        //        return;
        //    }

        //    // Kiểm tra định dạng số điện thoại 
        //    // Bạn có thể điều chỉnh Regex phù hợp với quy tắc số điện thoại của bạn
        //    if (!System.Text.RegularExpressions.Regex.IsMatch(soDienThoai, @"^(0[1-9]|84[1-9])[0-9]{8,9}$"))
        //    {
        //        MessageBox.Show("Số điện thoại không đúng định dạng", "Lỗi",
        //            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        txtBoxTimSDTBN.SelectAll(); // Chọn toàn bộ text để dễ xóa
        //        txtBoxTimSDTBN.Focus();
        //        return;
        //    }

        //    try
        //    {
        //        // Gọi phương thức từ BLL để tìm kiếm bệnh nhân
        //        List<DTO_QuanLyBenhNhan> danhSachBenhNhan = _HoaDonBLL.TimBenhNhanTheoSDT(soDienThoai);

        //        // Kiểm tra kết quả tìm kiếm
        //        if (danhSachBenhNhan == null || danhSachBenhNhan.Count == 0)
        //        {
        //            // Không tìm thấy bệnh nhân
        //            MessageBox.Show("Không tìm thấy bệnh nhân với số điện thoại này",
        //                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //            // Làm sạch ComboBox
        //            cboBenhNhan.DataSource = null;
        //            cboBenhNhan.Items.Clear();

        //            // Reset các control liên quan
        //            txtBoxMaHoaDon.Clear();
        //            txtBoxSDT.Clear();
        //            return;
        //        }

        //        // Cấu hình DataSource cho ComboBox
        //        cboBenhNhan.DataSource = danhSachBenhNhan;
        //        cboBenhNhan.DisplayMember = "HoTenBN"; // Hiển thị tên
        //        cboBenhNhan.ValueMember = "MaBN"; // Giá trị là mã bệnh nhân

        //        // Nếu chỉ có 1 bệnh nhân thì chọn luôn
        //        if (danhSachBenhNhan.Count == 1)
        //        {
        //            cboBenhNhan.SelectedIndex = 0;
        //        }
        //        else
        //        {
        //            // Nếu nhiều bệnh nhân thì mở dropdown
        //            cboBenhNhan.DroppedDown = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Xử lý ngoại lệ
        //        MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi",
        //            MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        // Reset các control
        //        cboBenhNhan.DataSource = null;
        //        txtBoxMaHoaDon.Clear();
        //        txtBoxSDT.Clear();
        //    }
        //}

        //private void btnTimSDTBN_Click(object sender, EventArgs e)
        //{
        //    TimKiemBenhNhanTheoSDT();
        //}
        //private void ResetBenhNhanControls()
        //{
        //    txtBoxMaHoaDon.Clear();
        //    txtBoxSDT.Clear();
        //    txtBoxSDT.ReadOnly = false;
        //}



        private void PrintInvoice(DTO_HoaDon hoaDon, DTO_QuanLyBenhNhan benhNhan, DTO_NhanVien nhanVien, List<DTO_ChiTietSuDungDV> chiTietDichVu, List<string> tenDichVuList)
        {
            // Tạo tài liệu in
            PrintDocument printDocument = new PrintDocument();

            // Gán sự kiện in
            printDocument.PrintPage += (sender, e) =>
            {
                // Font chữ
                Font tieuDeFont = new Font("Arial", 20, FontStyle.Bold);
                Font tieuDeNhoFont = new Font("Arial", 14, FontStyle.Bold);
                Font vanBanFont = new Font("Arial", 12);

                // Vẽ tiêu đề
                e.Graphics.DrawString("HÓA ĐƠN DỊCH VỤ", tieuDeFont, Brushes.Black, new PointF(200, 50));

                // Thông tin bệnh nhân
                e.Graphics.DrawString($"Họ tên: {benhNhan.HoTenBN}", vanBanFont, Brushes.Black, new PointF(100, 100));
                e.Graphics.DrawString($"Ngày sinh: {benhNhan.NgaySinh:dd/MM/yyyy}", vanBanFont, Brushes.Black, new PointF(100, 130));
                e.Graphics.DrawString($"Số điện thoại: {benhNhan.SoDT}", vanBanFont, Brushes.Black, new PointF(100, 160));

                // Thông tin hóa đơn
                e.Graphics.DrawString($"Mã HĐ: {hoaDon.MaHD}", vanBanFont, Brushes.Black, new PointF(100, 200));
                e.Graphics.DrawString($"Ngày lập: {hoaDon.NgayLapHD:dd/MM/yyyy}", vanBanFont, Brushes.Black, new PointF(100, 230));
                e.Graphics.DrawString($"Nhân viên: {nhanVien.HoTen}", vanBanFont, Brushes.Black, new PointF(100, 260));

                // Danh sách dịch vụ
                e.Graphics.DrawString("DANH SÁCH DỊCH VỤ", tieuDeNhoFont, Brushes.Black, new PointF(100, 300));

                float currentY = 330;
                decimal tongTien = 0;

                // Vẽ từng dịch vụ
                for (int i = 0; i < chiTietDichVu.Count; i++)
                {
                    var item = chiTietDichVu[i];
                    string tenDichVu = tenDichVuList[i];
                    decimal thanhTien = item.SoLuong * item.Gia;
                    tongTien += thanhTien;

                    e.Graphics.DrawString(
                        $"{tenDichVu} - SL: {item.SoLuong} - Đơn giá: {item.Gia:N0} VNĐ - Thành tiền: {thanhTien:N0} VNĐ",
                        vanBanFont,
                        Brushes.Black,
                        new PointF(100, currentY)
                    );
                    currentY += 30;
                }

                // Tổng tiền
                e.Graphics.DrawString($"Tổng tiền: {tongTien:N0} VNĐ", tieuDeNhoFont, Brushes.Black, new PointF(100, currentY + 20));

                // Thông tin chuyển khoản
                string tenNganHang = "VIETCOMBANK";
                string soTaiKhoan = "1014647703";
                string tenNguoiNhan = "Cao Hoang Nhat Thang";
                string noiDung = $"Thanh toan HĐ #{hoaDon.MaHD}";

                // Tạo nội dung QR
                string qrContent = $"https://img.vietqr.io/image/{tenNganHang}-{soTaiKhoan}-{tongTien}.png" +
                                   $"?accountName={WebUtility.UrlEncode(tenNguoiNhan)}" +
                                   $"&addInfo={WebUtility.UrlEncode(noiDung)}";

                // Tạo và vẽ QR Code
                try
                {
                    using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                    {
                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrContent, QRCodeGenerator.ECCLevel.M);
                        using (QRCode qrCode = new QRCode(qrCodeData))
                        {
                            Bitmap qrCodeImage = qrCode.GetGraphic(10);

                            // Vẽ chú thích QR
                            e.Graphics.DrawString(
                                "Quét mã QR để thanh toán",
                                vanBanFont,
                                Brushes.Black,
                                new PointF(100, currentY + 100)
                            );

                            // Vẽ QR Code
                            e.Graphics.DrawImage(
                                qrCodeImage,
                                new Rectangle(100, (int)currentY + 130, 200, 200)
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý nếu lỗi tạo QR
                    e.Graphics.DrawString(
                        $"Lỗi tạo QR: {ex.Message}",
                        vanBanFont,
                        Brushes.Red,
                        new PointF(100, currentY + 100)
                    );
                }
            };

            // Hiển thị hộp thoại in
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    printDocument.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi in: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
