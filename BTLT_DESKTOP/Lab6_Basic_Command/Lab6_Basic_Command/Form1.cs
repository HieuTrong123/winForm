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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string connectionString = "database = RestaurantManagement; Integrated Security = true; ";
            SqlConnection SQLconnection = new SqlConnection(connectionString);
            SqlCommand sqlComand=SQLconnection.CreateCommand();
            string query = "SELECT ID, Name, Type From Category";
            sqlComand.CommandText = query;
            SQLconnection.Open();
            SqlDataReader sqlDataReader=sqlComand.ExecuteReader();
            this.DisplayCategory(sqlDataReader);
            SQLconnection.Close();
        }
        private void DisplayCategory(SqlDataReader reader)
        {
            lvCategory.Items.Clear();
            while (reader.Read()) 
            {
                ListViewItem item =new ListViewItem(reader["ID"].ToString());
                item.SubItems.Add(reader["Name"].ToString());
                item.SubItems.Add(reader["Type"].ToString());
                lvCategory.Items.Add(item);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string connectionString = "database = RestaurantManagement; Integrated Security = true; ";
            SqlConnection SQLconnection = new SqlConnection(connectionString);
            SqlCommand sqlComand = SQLconnection.CreateCommand();
            string query = "INSERT INTO Category(Name, [Type])"+"VALUES (N'"+ txtName.Text+"',"+ txtType.Text+")";
            sqlComand.CommandText = query;
            SQLconnection.Open();
            int numOfRowsEffected= sqlComand.ExecuteNonQuery();
            SQLconnection.Close();
            if (numOfRowsEffected == 1)
            {
                MessageBox.Show("Thêm nhóm món ăn thành công");
                btnLoad.PerformClick();
                txtName.Text = "";
                txtType.Text = "";

            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra. vui lòng thử lại");
            }
        }

        private void lvCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvCategory_Click(object sender, EventArgs e)
        {
            ListViewItem item= lvCategory.SelectedItems[0];
            txtID.Text = item.Text;
            txtName.Text = item.SubItems[1].Text;
            txtType.Text=item.SubItems[1].Text=="0"?"Thức uống":"Đồ ăn";
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string connectionString = "database = RestaurantManagement; Integrated Security = true; ";
            SqlConnection SQLconnection = new SqlConnection(connectionString);
            SqlCommand sqlComand = SQLconnection.CreateCommand();
            string query = "UPDATE Category SET Name = N'" + txtName.Text + "', [Type] =" + txtType.Text + "WHERE ID ="+txtID.Text;
            sqlComand.CommandText = query;
            SQLconnection.Open();
            int numOfRowsEffected = sqlComand.ExecuteNonQuery();
            SQLconnection.Close();
            if (numOfRowsEffected == 1)
            {
                ListViewItem item = lvCategory.SelectedItems[0];
                item.SubItems[1].Text = txtName.Text;
                item.SubItems[2].Text=txtType.Text;
                txtID.Text = "";
                txtName.Text = "";
                txtType.Text = "";
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                MessageBox.Show("Cập nhật món ăn thành công");
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra. vui lòng thử lại");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string connectionString = "database = RestaurantManagement; Integrated Security = true; ";
            SqlConnection SQLconnection = new SqlConnection(connectionString);
            SqlCommand sqlComand = SQLconnection.CreateCommand();
            string query = "DELETE FROM Category WHERE ID = "+ txtID.Text;
            sqlComand.CommandText = query;
            SQLconnection.Open();
            int numOfRowsEffected = sqlComand.ExecuteNonQuery();
            SQLconnection.Close();
            if (numOfRowsEffected == 1)
            {
                ListViewItem item = lvCategory.SelectedItems[0];
                lvCategory.Items.Remove(item);
                txtID.Text = "";
                txtName.Text = "";
                txtType.Text = "";
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                MessageBox.Show("Xóa món ăn thành công");
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra. vui lòng thử lại");
            }
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            if(lvCategory.SelectedItems.Count > 0)
            {
                btnDelete.PerformClick();
            }
        }

        private void tsmViewFood_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                frmFood foodForm = new frmFood();
                foodForm.Show(this);
                foodForm.LoadFood(int.Parse(txtID.Text));
            }
        }
    }
}
