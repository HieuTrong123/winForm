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

namespace Lab6_Basic_Command
{
    public partial class frmFood : Form
    {
        public frmFood()
        {
            InitializeComponent();
        }
        public void LoadFood(int categoryID)
        {
 
            string connectionString = "database = RestaurantManagement; Integrated Security = true; ";
            SqlConnection SQLconnection = new SqlConnection(connectionString);
            SqlCommand sqlComand = SQLconnection.CreateCommand();
            string query = "SELECT Name FROM Category WHERE ID = " + categoryID;
            sqlComand.CommandText = query;
            SQLconnection.Open();
            string catName = sqlComand.ExecuteScalar().ToString();
            this.Text = "Danh sách các món ăn thuộc nhóm: " + catName;
            sqlComand.CommandText = "SELECT * FROM Food WHERE FoodCategoryID = " + categoryID;
            SqlDataAdapter da = new SqlDataAdapter(sqlComand);
            DataTable dt = new DataTable("Food");
            da.Fill(dt);
            dgvFood.DataSource = dt;
            SQLconnection.Close();
            SQLconnection.Dispose();
            da.Dispose();

        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString = "database = RestaurantManagement; Integrated Security = true; ";
            SqlConnection SQLconnection = new SqlConnection(connectionString);
            SqlCommand sqlComand = SQLconnection.CreateCommand();
            string idFood = ((dgvFood.CurrentRow.Cells[0].Value).ToString());
            if (idFood!="")
            {
                sqlComand.CommandText = "UPDATE Food SET Name = N'" + dgvFood.CurrentRow.Cells[1].Value.ToString() + "'," +
                    " Unit = N'" + dgvFood.CurrentRow.Cells[2].Value.ToString() + "'," +
                    " FoodCategoryID = " + $"{int.Parse((dgvFood.CurrentRow.Cells[3].Value).ToString())}" + "," +
                    " Price = " + $"{int.Parse((dgvFood.CurrentRow.Cells[4].Value).ToString())}" + "," +
                    " Notes = N'" + dgvFood.CurrentRow.Cells[5].Value.ToString() +
                    "' WHERE ID = " + $"{idFood}";
                SQLconnection.Open();
                int numOfRowsEffected = sqlComand.ExecuteNonQuery();
                SQLconnection.Close();
                if (numOfRowsEffected == 1)
                {
                    LoadFood(int.Parse(dgvFood.CurrentRow.Cells[3].Value.ToString()));
                    MessageBox.Show("Cập nhật món ăn thành công");

                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra. vui lòng thử lại");
                }

            }
            else
            {
                sqlComand.CommandText = "insert into Food values( " +
                    "N'" + dgvFood.CurrentRow.Cells[1].Value.ToString() + "'," +
                   " N'" + dgvFood.CurrentRow.Cells[2].Value.ToString() + "'," 
                   + $"{int.Parse((dgvFood.CurrentRow.Cells[3].Value).ToString())}" + "," 
                   + $"{int.Parse((dgvFood.CurrentRow.Cells[4].Value).ToString())}" + "," +
                   " N'" + dgvFood.CurrentRow.Cells[5].Value.ToString()+"')";
                SQLconnection.Open();
                int numOfRowsEffected = sqlComand.ExecuteNonQuery();
                SQLconnection.Close();
                if (numOfRowsEffected == 1)
                {
                    LoadFood(int.Parse(dgvFood.CurrentRow.Cells[3].Value.ToString()));
                    MessageBox.Show("Thêm món ăn thành công");

                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra. vui lòng thử lại");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string connectionString = "database = RestaurantManagement; Integrated Security = true; ";
            SqlConnection SQLconnection = new SqlConnection(connectionString);
            SqlCommand sqlComand = SQLconnection.CreateCommand();
            string query = "DELETE FROM Food WHERE ID = " + $"{int.Parse((dgvFood.CurrentRow.Cells[0].Value).ToString())}";
            
            sqlComand.CommandText = query;
            SQLconnection.Open();
            int numOfRowsEffected = sqlComand.ExecuteNonQuery();
            SQLconnection.Close();
            if (numOfRowsEffected == 1)
            {
                LoadFood(int.Parse(dgvFood.CurrentRow.Cells[3].Value.ToString()));
                MessageBox.Show("Xóa món ăn thành công");
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra. vui lòng thử lại");
            }
        }
    }
}
