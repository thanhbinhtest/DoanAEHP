using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ChuongTrinhQuanLyKyTuXa_Version3
{
    public partial class NewEmployee : Form
    {
        Dashboard dashboardForm = new Dashboard();
        function fn = new function();
        String query;
        public NewEmployee()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            fn.close();
        }

        private void NewEmployee_Load(object sender, EventArgs e)
        {
            this.Location = new Point(450, 131);
        }

        public void clearAll()
        {
            txtMobile.Clear();
            txtName.Clear();
            txtFather.Clear();
            txtMother.Clear();
            txtEmaild.Clear();
            txtPernament.Clear();
            txtDesignation.SelectedIndex = -1;
            txtUniqueId.Clear();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtMobile.Text) && !string.IsNullOrWhiteSpace(txtName.Text) && !string.IsNullOrWhiteSpace(txtFather.Text) && !string.IsNullOrWhiteSpace(txtMother.Text) && !string.IsNullOrWhiteSpace(txtEmaild.Text) && !string.IsNullOrWhiteSpace(txtPernament.Text) && !string.IsNullOrWhiteSpace(txtUniqueId.Text) && txtDesignation.SelectedIndex != -1)
            {
                try
                {
                    Int64 mobile = Int64.Parse(txtMobile.Text);
                    string name = txtName.Text;
                    string fname = txtFather.Text;
                    string mname = txtMother.Text;
                    string email = txtEmaild.Text;
                    string address = txtPernament.Text;
                    string designation = txtDesignation.Text;
                    string id = txtUniqueId.Text;

                    // Sử dụng tham số để tránh tấn công SQL Injection
                    string query = "INSERT INTO newEmployee(emobile, ename, efname, emname, eemail, epaddress, eidproof, edesignation) VALUES (@mobile, @name, @fname, @mname, @email, @address, @id, @designation)";

                    // Tạo mảng các đối tượng SqlParameter
                    SqlParameter[] sqlParams =
                    {
                new SqlParameter("@mobile", mobile),
                new SqlParameter("@name", name),
                new SqlParameter("@fname", fname),
                new SqlParameter("@mname", mname),
                new SqlParameter("@email", email),
                new SqlParameter("@address", address),
                new SqlParameter("@id", id),
                new SqlParameter("@designation", designation)
            };

                    // Gọi hàm setData với truy vấn, thông điệp và mảng tham số tương ứng
                    fn.setData(query, "Đã thêm nhân viên mới thành công", sqlParams);

                    // Xóa nội dung của các trường nhập liệu sau khi thêm thành công
                    clearAll();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Số điện thoại không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        /*private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMobile.Text != "" && txtName.Text != "" && txtFather.Text != "" && txtMother.Text != "" && txtEmaild.Text != "" && txtPernament.Text != "" && txtUniqueId.Text != "" && txtDesignation.SelectedIndex != -1)
            {
                Int64 mobile = Int64.Parse(txtMobile.Text);
                String name = txtName.Text;
                String fname = txtFather.Text;
                String mname = txtMother.Text;
                String email = txtEmaild.Text;
                String address = txtPernament.Text;
                String designation = txtDesignation.Text;
                String id = txtUniqueId.Text;

                query = "insert into newEmployee(emobile, ename, efname, emname, eemail, epaddress, eidproof, edesignation) values (" + mobile + ", '" + name + "', '" + fname + "', '" + mname + "', '" + email + "', '" + address + "', '" + id + "', '" + designation + "')";
                fn.setData(query, "Đã thêm nhân viên mới thành công");
                clearAll();
            }
            else
            { 
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }*/

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            fn.back(this, dashboardForm);
        }

        private void txtDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
