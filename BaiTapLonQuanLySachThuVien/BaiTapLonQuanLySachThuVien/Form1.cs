using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BaiTapLonQuanLySachThuVien
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        string ketnoisql = @"Data Source=DESKTOP-DSKGOAJ\SQLXPRESS
            ;Initial Catalog=QuanLyThuVien;Integrated Security=True";

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connect = new SqlConnection(ketnoisql);
                connect.Open();
                string sql = "select count(*) from tblQTTV where TenQTTV =@acc and MaQTTV =@pass";
                SqlCommand command = new SqlCommand(sql, connect);
                command.Parameters.Add(new SqlParameter("@acc", txtTaiKhoan.Text));
                command.Parameters.Add(new SqlParameter("@pass", MatKhau.Text));
                int a = (int)command.ExecuteScalar();
                if (a == 1)
                {
                    TrangChu tc = new TrangChu();
                    tc.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng", "Thông báo");
                    MatKhau.Clear();
                    MatKhau.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
