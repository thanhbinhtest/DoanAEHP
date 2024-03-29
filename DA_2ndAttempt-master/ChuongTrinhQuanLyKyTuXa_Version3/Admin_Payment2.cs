using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuongTrinhQuanLyKyTuXa_Version3
{
    public partial class Admin_Payment2 : Form
    {
        private Function fn = new Function();

        public Admin_Payment2()
        {
            InitializeComponent();
        }

        private void DataGridView_adminpayment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý sự kiện khi ô trong DataGridView được nhấp
        }

        private void btn_ChuaThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo câu lệnh SQL
                string query = "SELECT StudentName, RoomNo FROM Payment_Student WHERE Amount <> @Amount";

                // Tạo đối tượng SqlCommand
                SqlCommand command = new SqlCommand(query, fn.connection);

                // Thêm tham số vào truy vấn
                command.Parameters.AddWithValue("@Amount", -1);

                // Khai báo SqlDataAdapter để lấy dữ liệu
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                // Khai báo DataTable để lưu trữ dữ liệu
                DataTable dt = new DataTable();

                // Mở kết nối
                fn.connection.Open();

                // Đổ dữ liệu từ SqlDataAdapter vào DataTable
                adapter.Fill(dt);

                // Đóng kết nối
                fn.connection.Close();

                // Hiển thị dữ liệu lên DataGridView
                guna2DataGridView_Adminpayment2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy số điện thoại từ TextBox
                string PhoneNumber = txt_SDT.Text;

                // Mở kết nối
                fn.connection.Open();

                // Tạo câu lệnh SQL để kiểm tra số điện thoại và trạng thái thanh toán
                string query = "SELECT StudentName, RoomNo, " +
                               "CASE " +
                               "    WHEN Amount = -1 THEN N'Đã thanh toán' " +
                               "    ELSE N'Chưa thanh toán' " +
                               "END AS 'Trạng thái' " +
                               "FROM Payment_Student " +
                               "WHERE mobile = @PhoneNumber";

                // Tạo đối tượng SqlCommand
                using (SqlCommand command = new SqlCommand(query, fn.connection))
                {
                    // Thêm tham số vào câu lệnh SQL
                    command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);

                    // Khai báo SqlDataAdapter để lấy dữ liệu
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    // Khai báo DataTable để lưu trữ dữ liệu
                    DataTable dt = new DataTable();

                    // Đổ dữ liệu từ SqlDataAdapter vào DataTable
                    adapter.Fill(dt);

                    // Đóng kết nối
                    fn.connection.Close();

                    // Hiển thị dữ liệu lên DataGridView
                    guna2DataGridView_Adminpayment2.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Btn_DaThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo câu lệnh SQL
                string query = "SELECT StudentName, RoomNo FROM Payment_Student WHERE Amount = @Amount";

                // Tạo đối tượng SqlCommand
                SqlCommand command = new SqlCommand(query, fn.connection);

                // Thêm tham số vào truy vấn
                command.Parameters.AddWithValue("@Amount", -1);

                // Khai báo SqlDataAdapter để lấy dữ liệu
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                // Khai báo DataTable để lưu trữ dữ liệu
                DataTable dt = new DataTable();

                // Mở kết nối
                fn.connection.Open();

                // Đổ dữ liệu từ SqlDataAdapter vào DataTable
                adapter.Fill(dt);

                // Đóng kết nối
                fn.connection.Close();

                // Hiển thị dữ liệu lên DataGridView
                guna2DataGridView_Adminpayment2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý sự kiện khi ô trong DataGridView được nhấp
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý sự kiện khi ô trong DataGridView được nhấp
        }

        private void guna2DataGridView_Adminpayment2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý sự kiện khi ô trong DataGridView được nhấp
        }

        private void Admin_Payment2_Load(object sender, EventArgs e)
        {

        }
    }


}
