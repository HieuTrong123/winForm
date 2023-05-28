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
    public partial class frmAddFood : Form
    {
        public frmAddFood()
        {
            InitializeComponent();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            //string connectionString = "database = RestaurantManagement; Integrated Security = true; ";
            //SqlConnection SQLconnection = new SqlConnection(connectionString);
            //SqlCommand sqlComand = SQLconnection.CreateCommand();
            //string query = "INSERT INTO Category(Name, [Type])" + "VALUES (N'" + txtFoodCategoryID.Text + "'," + txtLoai.Text + ")";
            //sqlComand.CommandText = query;
            //SQLconnection.Open();
            //int numOfRowsEffected = sqlComand.ExecuteNonQuery();
            //SQLconnection.Close();
            //if (numOfRowsEffected == 1)
            //{

            //    MessageBox.Show("Thêm nhóm món ăn thành công");
            //    Form1 frm = (Form1)Application.OpenForms["Form1"];
            //    FoodInfoForm frm1 = (FoodInfoForm)Application.OpenForms["FoodInfoForm"];
            //    frm1.InitValues();
            //    frm.LoadCategory();
            //    this.Close();

            //}
            //else
            //{
            //    MessageBox.Show("Đã có lỗi xảy ra. vui lòng thử lại");
            //}


            try
            {
                string connectionString = "database = RestaurantManagement; Integrated Security = true";
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "execute AddCategory @id output,@name,@Loai";

                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 1000);
                cmd.Parameters.Add("@Loai", SqlDbType.Int);

                cmd.Parameters["@id"].Direction = ParameterDirection.Output;
                cmd.Parameters["@name"].Value = txtFoodCategoryID.Text;
                cmd.Parameters["@Loai"].Value = txtLoai.Text;

                conn.Open();
                int numOfRowAffected = cmd.ExecuteNonQuery();
                if (numOfRowAffected > 0)
                {
                    string foodID = cmd.Parameters["@id"].Value.ToString();
                    MessageBox.Show("Succesfully adding new Category. FoodID = " + foodID, "Message");
                    Form1 frm = (Form1)Application.OpenForms["Form1"];
                    FoodInfoForm frm1 = (FoodInfoForm)Application.OpenForms["FoodInfoForm"];
                    frm1.InitValues();
                    frm.LoadCategory();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Adding food failed!");
                }
                conn.Close();
                conn.Dispose();
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message, "SQL Error");
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
            }
        }
    }
}
