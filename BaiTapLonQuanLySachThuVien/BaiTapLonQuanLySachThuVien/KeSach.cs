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
    public partial class KeSach : Form
    {
        public KeSach()
        {
            InitializeComponent();
        }
        string ketnoisql = @"Data Source=DESKTOP-DSKGOAJ\SQLXPRESS
            ;Initial Catalog=QuanLyThuVien;Integrated Security=True";
        int b =0;
        private void KetNoi()
        {
            try
            {
                SqlConnection kn = new SqlConnection(ketnoisql);
                kn.Open();
                string sql = "select * from tblKESACH";
                SqlCommand com = new SqlCommand(sql, kn);
                SqlDataAdapter Ad = new SqlDataAdapter(com);
                DataTable table = new DataTable();
                Ad.Fill(table);
                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Chương Trình " + ex.InnerException);
            }
            finally
            {
                SqlConnection kn = new SqlConnection(ketnoisql);
                kn.Close();
            }
        }
        private void KeSach_Load(object sender, EventArgs e)
        {
            KetNoi();
            btnHuy.Enabled = btnLuu.Enabled = false;
            txtKeSach.Enabled = txtMoTa.Enabled =false;
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = btnSua.Enabled= false;
            btnHuy.Enabled = btnLuu.Enabled = true;
            txtKeSach.Enabled = txtMoTa.Enabled = true;
            b = 1;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (b == 1)
            {
                try
                {
                    SqlConnection kn = new SqlConnection(ketnoisql);
                    kn.Open();
                    string sql = "insert into tblKESACH values ('"+txtKeSach.Text+"',N'"+txtMoTa.Text+"')";
                    SqlCommand com = new SqlCommand(sql, kn);
                    SqlDataAdapter Ad = new SqlDataAdapter(com);
                    DataTable table = new DataTable();
                    Ad.Fill(table);
                    dataGridView1.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                finally
                {
                    SqlConnection kn = new SqlConnection(ketnoisql);
                    kn.Close();
                    b = 0;
                    txtKeSach.Enabled=txtMoTa.Enabled = false;
                    btnSua.Enabled = btnThem.Enabled = true;
                    KeSach_Load(sender, e);
                   
                }
            }
            else if (b==2)
            {
                txtKeSach.Enabled = false;
                txtMoTa.Enabled = true;
                try
                {
                    SqlConnection kn = new SqlConnection(ketnoisql);
                    kn.Open();
                    string sql = "update tblKESACH set MoTa =N'"+txtMoTa.Text +"' where KeSach ='"+txtKeSach.Text+"'";
                    SqlCommand com = new SqlCommand(sql, kn);
                    SqlDataAdapter Ad = new SqlDataAdapter(com);
                    DataTable table = new DataTable();
                    Ad.Fill(table);
                    dataGridView1.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                finally
                {
                    SqlConnection kn = new SqlConnection(ketnoisql);
                    kn.Close();
                    b = 0;
                    txtMoTa.Enabled = false;
                    btnSua.Enabled = btnThem.Enabled = true;
                    KeSach_Load(sender, e);
                }
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView1.CurrentRow.Index;
                txtKeSach.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
                txtMoTa.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            b = 2;
            txtMoTa.Enabled = true;
            btnThem.Enabled = btnSua.Enabled = false;
            btnHuy.Enabled = btnLuu.Enabled = true;
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            KeSach_Load(sender, e);
            txtKeSach.Text = txtMoTa.Text = "";
            btnThem.Enabled = btnSua.Enabled = true;
            b = 0;
        }
    }
}
