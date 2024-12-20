using BLL;
using GUI;
using QuanLyPhongKham;

namespace QuanLyPhongKhamTuNhan
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new DangNhap());
        }
    }
}