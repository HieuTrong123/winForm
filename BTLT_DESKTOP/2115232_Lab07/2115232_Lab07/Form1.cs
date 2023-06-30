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


namespace _2115232_Lab07
{
    public partial class Form1 : Form
    {
        private DataTable foodTable;
        public Form1()
        {
            InitializeComponent();
        }

        public void LoadCategory()
        {
            string connectionString = "database = RestaurantManagement; Integrated Security = true";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select ID, Name from Category";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            conn.Open();
            adapter.Fill(dt);
            conn.Close();
            conn.Dispose();
            cbbCategory.DataSource = dt;
            cbbCategory.DisplayMember = "Name";
            cbbCategory.ValueMember = "ID";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.LoadCategory();
        }

        private void cbbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbCategory.SelectedIndex == -1) return;
            string connectionString = "database = RestaurantManagement; Integrated Security = true";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from Food where FoodCategoryID = @categoryID";
            cmd.Parameters.Add("@categoryID", SqlDbType.Int);

            if (cbbCategory.SelectedValue is DataRowView)
            {
                DataRowView rowView = cbbCategory.SelectedValue as DataRowView;
                cmd.Parameters["@categoryId"].Value = rowView["ID"];
            }
            else
            {
                cmd.Parameters["@categoryId"].Value = cbbCategory.SelectedValue;
            }
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            foodTable = new DataTable();
            conn.Open();
            adapter.Fill(foodTable);
            conn.Close();
            conn.Dispose();
            dgvFoodList.DataSource = foodTable;
            lbQuantity.Text = foodTable.Rows.Count.ToString();
            lbCatName.Text = cbbCategory.Text;
        }

        private void cbbCategory_Click(object sender, EventArgs e)
        {
            
        }

        private void tsmCalculateQuantity_Click(object sender, EventArgs e)
        {
            string connectionString = "database = RestaurantManagement; Integrated Security = true";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select @numSaleFood = sum(Quantity) from BillDetails where FoodID = @foodId";
            if(dgvFoodList.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvFoodList.SelectedRows[0];
                DataRowView rowView = selectedRow.DataBoundItem as DataRowView;

                cmd.Parameters.Add("@foodId", SqlDbType.Int);
                cmd.Parameters["@foodId"].Value = rowView["ID"];

                cmd.Parameters.Add("@numSaleFood", SqlDbType.Int);
                cmd.Parameters["@numSaleFood"].Direction = ParameterDirection.Output;

                conn.Open();

                cmd.ExecuteNonQuery();

                string result = cmd.Parameters["@numSaleFood"].Value.ToString();
                MessageBox.Show("Tổng số lượng món " + rowView["Name"] + " đã bán là: " + result + " " + rowView["Unit"]);
                
                conn.Close();
            }
            cmd.Dispose();
            conn.Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void thêmMónĂnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FoodInfoForm foodForm = new FoodInfoForm();
            foodForm.FormClosed += new FormClosedEventHandler(foodForm_FormClosed);
            foodForm.ShowDialog();
        }

        void foodForm_FormClosed(object sender,FormClosedEventArgs e)
        {
            int index=cbbCategory.SelectedIndex;
            cbbCategory.SelectedIndex = -1;
            cbbCategory.SelectedIndex = index;
        }
        private void tsmUpdataFood_Click(object sender, EventArgs e)
        {
            if(dgvFoodList.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow=dgvFoodList.SelectedRows[0];
                DataRowView rowView = selectedRow.DataBoundItem as DataRowView;
                FoodInfoForm foodForm = new FoodInfoForm();
                foodForm.FormClosed+=new FormClosedEventHandler(foodForm_FormClosed);
                foodForm.Show(this);
                foodForm.DisplayFoodInfo(rowView);
            }
        }

        private void txtSeachByName_TextChanged(object sender, EventArgs e)
        {
            if (foodTable == null) return;
            string filterExpression = "Name like '%" + txtSeachByName.Text + "%'";
            string sortExpression = "Price DESC";
            DataViewRowState rowStateFilter = DataViewRowState.OriginalRows;
            DataView foodView =new DataView(foodTable,filterExpression,sortExpression,rowStateFilter);
            dgvFoodList.DataSource = foodView;
        }
    }
}
