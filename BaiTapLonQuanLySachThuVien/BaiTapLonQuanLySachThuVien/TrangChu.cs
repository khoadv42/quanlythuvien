using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

using System.Data.SqlClient;


namespace BaiTapLonQuanLySachThuVien
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }
        #region kết Nối
        string ketnoisql = @"Data Source=DESKTOP-DSKGOAJ\SQLXPRESS
            ;Initial Catalog=QuanLyThuVien;Integrated Security=True";
        private void openconnection()
        {
            SqlConnection kn = new SqlConnection(ketnoisql);
            kn.Open();
        }
        private void closeconnection()
        {
            SqlConnection kn = new SqlConnection(ketnoisql);
            kn.Close();
        }
        private void KetNoi()
        {
            try
            {
                SqlConnection kn = new SqlConnection(ketnoisql);
                kn.Open();
                string sql = "select MaSach as 'Mã Sách',TenSach as 'Tên Sách',MaLoai as 'Mã Loại',TacGia as 'Tác Giả',KeSach as 'Kệ Sách',DonGia as 'Đơn Giá',Status from tblSACH";
                SqlCommand com = new SqlCommand(sql, kn);
                SqlDataAdapter Ad = new SqlDataAdapter(com);
                DataTable table = new DataTable();
                Ad.Fill(table);
                dataGridViewSach.DataSource = table;
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


        private void KetNoiBanDoc()
        {
            try
            {
                SqlConnection kn = new SqlConnection(ketnoisql);
                kn.Open();
                string sql = "select MaBanDoc as 'Mã Bạn Đọc', TenBanDoc as 'Tên Bạn Đọc', NgaySinh as 'Ngày Sinh',Diachi as 'Địa Chỉ', GioiTinh as 'Giới Tính',SDT from tblBANDOC";
                SqlCommand com = new SqlCommand(sql, kn);
                SqlDataAdapter Ad = new SqlDataAdapter(com);
                DataTable table = new DataTable();
                Ad.Fill(table);
                dataGridView2.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error");
            }
            finally
            {
                SqlConnection kn = new SqlConnection(ketnoisql);
                kn.Close();
            }
        }
        /* */
        private void KetNoiQuanLyMuonTra()
        {
            SqlConnection kn = new SqlConnection(ketnoisql);
            kn.Open();
            string sql = "select  MaSach as 'Mã Sách', MaBanDoc as 'Mã Bạn Đọc',NgayMuon as 'Ngày Mượn',NgayTra as 'Hạn Trả' from tblMUONSACH";
            SqlCommand com = new SqlCommand(sql, kn);
            SqlDataAdapter Ad = new SqlDataAdapter(com);
            DataTable table = new DataTable();
            Ad.Fill(table);
            dataGridViewMuonTra.DataSource = table;
        }
        private void KetNoiBaoCao()
        {
            if (radioButton1.Checked)
            {
                try
                {
                    SqlConnection kn = new SqlConnection(ketnoisql);
                    kn.Open();
                    string sql = "select MaBanDoc as 'Mã Bạn Đọc',"
                        +"TenBanDoc as 'Tên Bạn Đọc',"
                        +"MaSach as 'Mã Sách',"
                        +"TenSach as 'Tên Sách',"
                        + "NgayMuon as 'Ngày Mượn',"
                        +"NgayTra as 'Ngày Trả',"
                        +"GhiChu as 'Ghi Chú' from ThongKe where 1=1";
                    if (!string.IsNullOrEmpty(comboBox1.Text))
                        sql += string.Format(" and  MONTH(NgayMuon) = "+ comboBox1.Text );
                    if (!string.IsNullOrEmpty(comboBox2.Text))
                        sql += string.Format(" and year( NgayMuon ) = " + comboBox2.Text );
                    SqlCommand com = new SqlCommand(sql, kn);
                    SqlDataAdapter Ad = new SqlDataAdapter(com);
                    DataTable table = new DataTable();
                    Ad.Fill(table);
                    dataGridView3.DataSource = table;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning");
                }
                finally
                {
                    SqlConnection kn = new SqlConnection(ketnoisql);
                    kn.Close();
                }
            }
            if(radioButton2.Checked )
            {
               try
                {
                    SqlConnection kn = new SqlConnection(ketnoisql);
                    kn.Open();
                    string sql1 = "alter view soLuongThang as select MaBanDoc as 'Mã Bạn Đọc' ,count(*) as SoLuongSachMuon from Thongke where 1=1   ";
                    if (!string.IsNullOrEmpty(comboBox1.Text))
                        sql1 += string.Format(" and  MONTH(NgayMuon) = " + comboBox1.Text);
                    if (!string.IsNullOrEmpty(comboBox2.Text))
                        sql1 += string.Format(" and year( NgayMuon ) = " + comboBox2.Text);
                    sql1 += string.Format("group by MaBanDoc");
                    SqlCommand command1 = new SqlCommand(sql1, kn);
                    command1.ExecuteNonQuery();
                    string sql = " select * from SoLuongBanDocThang";
                    SqlCommand com = new SqlCommand(sql, kn);
                    SqlDataAdapter Ad = new SqlDataAdapter(com);
                    DataTable table = new DataTable();
                    Ad.Fill(table);
                    dataGridView3.DataSource = table;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning");
                }
                finally
                {
                    SqlConnection kn = new SqlConnection(ketnoisql);
                    kn.Close();
                }
            }
        }
        #endregion
        #region Thêm

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string them = "exec InsSach '" + txtMaSach.Text + "',N'" + txtTenSach.Text + "','"
                    + txtMaLoai.Text + "','" + txtKeSach.Text
                    + "',N'" + txtTacGia.Text + "','"
                    + txtDonGia.Text + "','available'";
                SqlConnection kn = new SqlConnection(ketnoisql);
                kn.Open();
                SqlCommand com = new SqlCommand(them, kn);
                com.ExecuteNonQuery();
                TrangChu_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");

            }
            finally
            {
                SqlConnection kn = new SqlConnection(ketnoisql);
                kn.Close();
            }
        }
        #endregion

        private void TrangChu_Load(object sender, EventArgs e)
        {
            KetNoi();
            KetNoiQuanLyMuonTra();
            KetNoiBaoCao();
            KetNoiBanDoc();
            //
            SqlConnection kn = new SqlConnection(ketnoisql);
            kn.Open();
       
            
            

            
        }
        #region nút sửa quản lý kho sách
        string sua;
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection kn = new SqlConnection(ketnoisql);
                kn.Open();
                sua = "Update tblSach set MaSach='" + txtMaSach.Text.ToUpper()
                    + "',TenSach=N'" + txtTenSach.Text + "',MaLoai='" + txtMaLoai.Text.ToUpper() + "',KeSach='" + txtKeSach.Text.ToUpper() + "',TacGia=N'" + txtTacGia.Text + "',DonGia='" + txtDonGia.Text + "',Status ='" + txtStatus.Text + "' where MaSach='" + txtMaSach.Text.ToUpper() + "'";
                SqlCommand commandSua = new SqlCommand(sua, kn);

                if (MessageBox.Show("Bạn Có Muốn Sửa Không", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    commandSua.ExecuteNonQuery();

            }
            catch
            {
                MessageBox.Show("Đơn giá phải nhập giá trị kiểu số .Nhập lại đơn giá", "Lỗi", MessageBoxButtons.OK);
                txtDonGia.Text = "";
            }
            finally
            {

                TrangChu_Load(sender, e);
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-DSKGOAJ\SQLXPRESS;Initial Catalog=QuanLyThuVien;Integrated Security=True");
                kn.Close();
            }
        }
        #endregion 
        //string xoa;
        private void btnXoa_Click(object sender, EventArgs e)
        {

            string xoa = "delete from tblSach Where MaSach='" + txtMaSach.Text + "'";
            SqlConnection kn = new SqlConnection(ketnoisql);
            kn.Open();
            SqlCommand com = new SqlCommand(xoa, kn);

            if (MessageBox.Show("Bạn Có Muốn Xóa mã Sách " + txtMaSach.Text + " Không", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                com.ExecuteNonQuery();
            TrangChu_Load(sender, e);
        }
        int index;
        private void dataGridViewSach_Click(object sender, EventArgs e)
        {
            try
            {
                index = dataGridViewSach.CurrentRow.Index;
                txtMaSach.Text = dataGridViewSach.Rows[index].Cells[0].Value.ToString();
                txtTenSach.Text = dataGridViewSach.Rows[index].Cells[1].Value.ToString();
                txtMaLoai.Text = dataGridViewSach.Rows[index].Cells[2].Value.ToString();
                txtKeSach.Text = dataGridViewSach.Rows[index].Cells[4].Value.ToString();
                txtTacGia.Text = dataGridViewSach.Rows[index].Cells[3].Value.ToString();
                txtDonGia.Text = dataGridViewSach.Rows[index].Cells[5].Value.ToString();
                txtStatus.Text = dataGridViewSach.Rows[index].Cells[6].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Chưa hiển thị cột nào cả");
            }

        }
        int index2 = 0;
        private void dataGridViewMuonTra_Click(object sender, EventArgs e)
        {

            try
            {
                index2 = dataGridViewMuonTra.CurrentRow.Index;
                maSachTextBox.Text = dataGridViewMuonTra.Rows[index2].Cells[0].Value.ToString();
                maBanDocTextBox .Text = dataGridViewMuonTra.Rows[index2].Cells[1].Value.ToString();
                txtMaSachShow .Text= dataGridViewMuonTra.Rows[index2].Cells[0].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Chưa hiển thị cột nào cả");
            }
        }
        private void btnHienThiTatCa_Click(object sender, EventArgs e)
        {
            KetNoi();
        }
        #region
      

        #endregion
        private void btnMuon_Click(object sender, EventArgs e)
        {
            try
            {
               
                    SqlConnection kn = new SqlConnection(ketnoisql);
                    kn.Open();
                    string sql = "insert into tblMUONSACH values('"
                        + maSachTextBox.Text.ToUpper() + "','"
                        + maBanDocTextBox.Text.ToUpper() + "',getdate(),dateadd(dd,"
                        +Convert.ToInt16 (txtGiaHan.Text)+",getdate()))";
                    SqlCommand com = new SqlCommand(sql, kn);
                    com.ExecuteNonQuery();
                    TrangChu_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Warning");
            }
            finally
            {
                SqlConnection kn = new SqlConnection(ketnoisql);
                kn.Close();
            }
        }

     



        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {
            string sql = "select MaSach as 'Mã Sách',TenSach as 'Tên Sách',MaLoai as 'Mã Loại',TacGia as 'Tác Giả',KeSach as 'Kệ Sách',DonGia as 'Đơn Giá',Status  from tblSACH Where 1=1";
            try
            {
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-DSKGOAJ\SQLXPRESS;Initial Catalog=QuanLyThuVien;Integrated Security=True");
                kn.Open();
                if (!string.IsNullOrEmpty(txtMaSach.Text))
                    sql += string.Format(" and MaSach ='{0}' ", txtMaSach.Text);
                if (!string.IsNullOrEmpty(txtTenSach.Text))
                    sql += string.Format(" and TenSach Like N'%{0}%' ", txtTenSach.Text);
                if (!string.IsNullOrEmpty(txtTacGia.Text))
                    sql += string.Format(" and TacGia Like N'%{0}%' ", txtTacGia.Text);
                if (!string.IsNullOrEmpty(txtKeSach.Text))
                    sql += string.Format(" and KeSach='{0}' ", txtKeSach.Text);
                if (!string.IsNullOrEmpty(txtDonGia.Text))
                    sql += string.Format(" and DonGia='{0}' ", txtDonGia.Text);
                if (!string.IsNullOrEmpty(txtMaLoai.Text))
                    sql += string.Format(" and MaLoai='{0}' ", txtMaLoai.Text);
                if (!string.IsNullOrEmpty(txtStatus.Text))
                    sql += string.Format(" and Status='{0}' ", txtStatus.Text);
                SqlCommand commandTimKiem = new SqlCommand(sql, kn);
                SqlDataAdapter tk = new SqlDataAdapter(commandTimKiem);
                DataTable table = new DataTable();
                tk.Fill(table);
                dataGridViewSach.DataSource = table;

            }
            catch
            {
                MessageBox.Show("kiem tra lai ket noi", "lỗi");
            }
            finally
            {
                SqlConnection kn = new SqlConnection(ketnoisql);
                kn.Close();
            }
        }
      
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtStatus.Text = "";
            txtTacGia.Text = "";
            txtTenSach.Text ="";
            txtMaSach.Text = "";
            txtMaLoai.Text = "";
            txtKeSach.Text = "";
            txtDonGia.Text = "";
        }

        private void btnThemBanDocquanlybandoc_Click(object sender, EventArgs e)
        {
            try
            {
                
                string them = "insert into tblBANDOC values ('" + txtMaBanDoc.Text.ToUpper() + "',N'"
                    + txtTenBanDoc.Text + "','" + dateTimePicker1.Value + "',N'" 
                    + 
                    cbGioiTinh.Text + "',N'" + txtDiaChi.Text + "','" + txtSDT.Text + "') ";
                SqlConnection kn = new SqlConnection(ketnoisql);
                kn.Open();
                SqlCommand com = new SqlCommand(them, kn);
                com.ExecuteNonQuery();
                TrangChu_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error Musume");
            }
            finally
            {
                SqlConnection kn = new SqlConnection(ketnoisql);
                kn.Close();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

       
        private void txtTongSachQuaHan_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTra_Click(object sender, EventArgs e)
        {
           try
            {
                string xoa = "delete from tblMUONSACH Where MaSach='" + maSachTextBox.Text.ToUpper() + "'";
                SqlConnection kn = new SqlConnection(ketnoisql);
                kn.Open();
                SqlCommand com = new SqlCommand(xoa, kn);
                if (MessageBox.Show("Xác Nhận Lại Lần Nữa ", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                 com.ExecuteNonQuery();
                TrangChu_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning");
            }
            finally
            {
                SqlConnection kn = new SqlConnection(ketnoisql);
                kn.Close();
            }
        }

        private void ngayTraLabel_Click(object sender, EventArgs e)
        {

        }

        private void btnSuaThongTinBanDocquanlybandoc_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection kn = new SqlConnection(ketnoisql);
                kn.Open();
                sua = "Update tblBANDOC set MaBanDoc='" + txtMaBanDoc.Text.ToUpper()
                    + "',TenBanDoc=N'" + txtTenBanDoc.Text + "',NgaySinh='" + dateTimePicker1.Value + "',GioiTinh=N'" + cbGioiTinh.Text + "',DiaChi=N'" + txtDiaChi.Text + "',SDT='" + txtSDT.Text + "' where MaBanDOc='" + txtMaBanDoc.Text.ToUpper() + "'";
                SqlCommand commandSua = new SqlCommand(sua, kn);

                if (MessageBox.Show("Bạn Có Muốn Sửa Không", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    commandSua.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error");
            }
            finally
            {

                TrangChu_Load(sender, e);
                SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-DSKGOAJ\SQLXPRESS;Initial Catalog=QuanLyThuVien;Integrated Security=True");
                kn.Close();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            KetNoiBaoCao();
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            KetNoiBaoCao();
        }

        private void txtGiaHan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnTimKiemBanDoc_Click(object sender, EventArgs e)
        {
            try
            {
                KetNoiQuanLyMuonTra();
                SqlConnection kn = new SqlConnection(ketnoisql);
                kn.Open();
                string sql = "select  MaSach as 'Mã Sách', MaBanDoc as 'Mã Bạn Đọc',NgayMuon as 'Ngày Mượn',NgayTra as 'Hạn Trả' from tblMUONSACH where 1=1 ";

                if (!string.IsNullOrEmpty(txtTimKiemBanDoc.Text))
                    sql += string.Format(" and (MaBanDoc='{0}' or MaSach='{0}')", txtTimKiemBanDoc.Text.ToUpper());
                SqlCommand cmd = new SqlCommand(sql,kn);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable table = new DataTable ();
                ad.Fill(table);
                dataGridViewMuonTra.DataSource = table;             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning");
            }
            finally
            {
                SqlConnection kn = new SqlConnection(ketnoisql);
                kn.Close();
            }
        }

        private void txtMaSachShow_TextChanged(object sender, EventArgs e)
        {
            
            try
            {
                SqlConnection kn = new SqlConnection(ketnoisql);
                kn.Open();
                string sql = "select MaSach as 'Mã Sách',TenSach as 'Tên Sách',MaLoai as 'Mã Loại',KeSach as 'Kệ Sách',TacGia as 'Tác Giả',DonGia as 'Đơn Giá',Status from tblSACH where 1=1";
                if (!string.IsNullOrEmpty(txtMaSachShow.Text))
                    sql += string.Format(" and (MaSach='{0}')", txtMaSachShow.Text.ToUpper());
                SqlCommand cmd = new SqlCommand(sql, kn);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                ad.Fill(table);
                dataGridView1.DataSource = table;
            }
            catch(Exception  ex)
            {
                MessageBox.Show(ex.Message, "Warning");
            }
            finally
            {
                SqlConnection kn = new SqlConnection(ketnoisql);
                kn.Close();
            }
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            try
            {
                int index2 = dataGridView2.CurrentRow.Index;
                txtMaBanDoc.Text = dataGridView2.Rows[index2].Cells[0].Value.ToString();
                txtTenBanDoc.Text = dataGridView2.Rows[index2].Cells[1].Value.ToString();
                dateTimePicker1.Text  = dataGridView2.Rows[index2].Cells[2].Value.ToString();
                cbGioiTinh.Text = dataGridView2.Rows[index2].Cells[4].Value.ToString();
                txtDiaChi.Text = dataGridView2.Rows[index2].Cells[3].Value.ToString();
                txtSDT.Text = dataGridView2.Rows[index2].Cells[5].Value.ToString();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error");
            }
        }

        private void txtMaBanDoc_TextChanged(object sender, EventArgs e)
        {
            SqlConnection kn = new SqlConnection(ketnoisql);
            kn.Open();
            string sql = "select dbo.count_SachDaMuon('" + txtMaBanDoc.Text + "')";
            SqlCommand command = new SqlCommand(sql,kn);
            txtTongSachDaMuon.Text = command.ExecuteScalar().ToString(); //đưa về colunm đầu tiên mà query tìm thấy
            string sql2 = "select dbo.count_SachDangMuon('" + txtMaBanDoc.Text + "')";
            SqlCommand command2 = new SqlCommand(sql2, kn);
            txtTongSachDangMuon.Text = command2.ExecuteScalar().ToString();
            string sql3 = "select dbo.count_QuaHan('" + txtMaBanDoc.Text + "')";
            SqlCommand commamd3 = new SqlCommand(sql3, kn);
            txtTongSachQuaHan.Text = commamd3.ExecuteScalar().ToString();
        }

        private void btnXoaThongTinBanDoc_Click(object sender, EventArgs e)
        {
            try
            {
                string xoa = "delete from tblBANDOC Where MaBanDoc='" + txtMaBanDoc.Text + "'";
                SqlConnection kn = new SqlConnection(ketnoisql);
                kn.Open();
                SqlCommand com = new SqlCommand(xoa, kn);

                if (MessageBox.Show("Bạn Có Muốn Xóa  " + txtTenBanDoc.Text + " Không", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    com.ExecuteNonQuery();
                TrangChu_Load(sender, e);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning");
            }
            finally
            {
                SqlConnection kn = new SqlConnection(ketnoisql);
                kn.Close();
            }
        }

        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "update tblMUONSACH set NgayTra = dateadd(dd," + txtGiaHan.Text + ",(select NgayTra from tblMUONSACH where MaBanDoc ='"+ maBanDocTextBox.Text +"'))   where MaBanDoc ='" + maBanDocTextBox.Text + "'";
                SqlConnection kn = new SqlConnection(ketnoisql);
                kn.Open();
                SqlCommand command = new SqlCommand(sql, kn);
                command.ExecuteNonQuery();
                TrangChu_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void txtTimKiemBanDoc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                KetNoiQuanLyMuonTra();
                SqlConnection kn = new SqlConnection(ketnoisql);
                kn.Open();
                string sql = "select  MaSach as 'Mã Sách', MaBanDoc as 'Mã Bạn Đọc',NgayMuon as 'Ngày Mượn',NgayTra as 'Hạn Trả' from tblMUONSACH where 1=1 ";

                if (!string.IsNullOrEmpty(txtTimKiemBanDoc.Text))
                    sql += string.Format(" and (MaBanDoc='{0}' or MaSach='{0}')", txtTimKiemBanDoc.Text.ToUpper());
                SqlCommand cmd = new SqlCommand(sql, kn);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                ad.Fill(table);
                dataGridViewMuonTra.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning");
            }
            finally
            {
                SqlConnection kn = new SqlConnection(ketnoisql);
                kn.Close();
            }
        }

        private void dataGridViewSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnThemKeSach_Click(object sender, EventArgs e)
        {
            KeSach ks = new KeSach();
            ks.ShowDialog();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            KetNoiBaoCao();
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            KetNoiBaoCao();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            crtlib cl = new crtlib();
            cl.Show();
        }

        private void txtTongSachDaMuon_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


