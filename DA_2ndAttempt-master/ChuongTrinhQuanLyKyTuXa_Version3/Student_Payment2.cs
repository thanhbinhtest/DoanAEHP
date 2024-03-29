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

    public partial class Student_Payment2 : Form
    {
        string username;
        Function fn = new Function();

        public Student_Payment2(string id)
        {
            InitializeComponent();
            this.username = id;

        }

        private void Student_Payment2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lb_tieude_Click(object sender, EventArgs e)
        {

        }

        private void lb_thanhtoan2_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đã ghi nhận thanh toán, hệ thống sẽ kiểm tra.");
            try
            {
                // Mở kết nối
                if (fn.connection.State != ConnectionState.Open)
                    fn.connection.Open();

                // Tạo câu lệnh SQL để truy vấn
                string query = "SELECT mobile FROM Student WHERE username = @username";

                // Tạo đối tượng SqlCommand
                using (SqlCommand command = new SqlCommand(query, fn.connection))
                {
                    // Thêm tham số vào câu lệnh SQL
                    command.Parameters.AddWithValue("@username", username);

                    // Thực thi truy vấn và lấy kết quả
                    object result = command.ExecuteScalar();

                    if (result != null) // Kiểm tra xem có kết quả trả về hay không
                    {
                        // Hiển thị mobile lên TextBox txtMobile
                        string PhoneNumber = result.ToString();

                        // Tạo câu lệnh SQL để cập nhật giá trị cột Amount thành -1 dựa trên số điện thoại
                        string updateQuery = "UPDATE Payment_Student SET Amount = -1 WHERE mobile = @PhoneNumber";

                        // Tạo đối tượng SqlCommand để thực hiện câu lệnh cập nhật
                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, fn.connection))
                        {
                            // Thêm tham số vào câu lệnh SQL
                            updateCommand.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);

                            // Thực thi truy vấn cập nhật
                            int rowsAffected = updateCommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Đã cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Không có dữ liệu nào được cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin mobile cho tên sinh viên này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi truy vấn cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đóng kết nối sau khi sử dụng xong
                fn.connection.Close();
            }
            this.Hide();
        }

    }
}
