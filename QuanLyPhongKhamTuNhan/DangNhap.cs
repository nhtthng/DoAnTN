using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;

namespace GUI
{
    public partial class DangNhap : Form
    {
        BLL_DangNhap _DangNhapBLL = new BLL_DangNhap();
        public DangNhap()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void txtMauKhau_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
