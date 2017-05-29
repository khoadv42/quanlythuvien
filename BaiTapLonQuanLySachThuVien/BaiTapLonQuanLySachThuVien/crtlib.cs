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
    public partial class crtlib : Form
    {
        public crtlib()
        {
            InitializeComponent();
        }
        string ketnoisql = @"Data Source=DESKTOP-DSKGOAJ\SQLXPRESS
            ;Initial Catalog=QuanLyThuVien;Integrated Security=True";
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connect = new SqlConnection(ketnoisql);
                connect.Open();
                string sql = "insert into tblQTTV values ('" + textBox2.Text + "','" + textBox1.Text + "')";
                SqlCommand command = new SqlCommand(sql, connect);
                if (MessageBox.Show("Xác nhận", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK);
                }
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
