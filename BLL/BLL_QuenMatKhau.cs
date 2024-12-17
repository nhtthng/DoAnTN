using DAL;
using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_QuenMatKhau
    {
        private DAL_QuenMatKhau DAL_QuenMatKhau = new DAL_QuenMatKhau();
        public bool IsEmailExists(string email)
        {
            return DAL_QuenMatKhau.CheckEmailInDatabase(email);
        }

        public bool ChangePassword(string email, string newPassword)
        {
            // Gọi phương thức từ DAL để đặt lại mật khẩu
            return DAL_QuenMatKhau.ResetPassword(email, newPassword);
        }
    }
}
