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
    public partial class Reply_st : Form
    {
        Dashboard dashboardForm = new Dashboard();

        function fn = new function();
        String query;
        public Reply_st()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
       
            txtNd.Clear();
            txtID.Clear();
            txtName.Clear();
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Trích xuất tiêu đề, nội dung, ID, và tên từ TextBox
              
                string noidung = txtNd.Text;
                string id = txtID.Text;
                string name = txtName.Text;
                string time = monthDateTime.Text;
                // Tạo câu lệnh SQL INSERT để chèn dữ liệu mới vào bảng Feedback
                string queryInsert = "INSERT INTO Feedback (StudentID, Name, FeedbackText,FeedbackDate) VALUES (@id, @name, @noidung,@time)";

                // Khởi tạo mảng các tham số SqlParameter
                SqlParameter[] parameters = new SqlParameter[]
                {
        new SqlParameter("@id", SqlDbType.Int) { Value = id, Direction = ParameterDirection.Input },
      
        new SqlParameter("@name", SqlDbType.NVarChar, 100) { Value = name, Direction = ParameterDirection.Input },
        new SqlParameter("@noidung", SqlDbType.NVarChar, 500) { Value = noidung, Direction = ParameterDirection.Input },
         new SqlParameter("@time", SqlDbType.DateTime) { Value = time, Direction = ParameterDirection.Input }
                };

                // Gọi phương thức setData từ đối tượng fn để thực thi câu lệnh SQL INSERT
                fn.setData(queryInsert, "Gửi  thành công!", parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
