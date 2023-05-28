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

namespace BT2_Lab7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void LoadOrders()
        {
            
            string connectionString = "database = RestaurantManagement; Integrated Security = true";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from Bills where CheckoutDate >= '" + dtpTuNgay.Value.ToShortDateString() + "' and CheckoutDate <= '" + dtpDenNgay.Value.ToShortDateString()+"'";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            conn.Open();
            adapter.Fill(dt);
            dgvOrders.DataSource = dt;
            conn.Close();
            conn.Dispose();
            adapter.Dispose();
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadOrders();
           
        }

        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void dtpDenNgay_ValueChanged(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void dgvOrders_DoubleClick(object sender, EventArgs e)
        {
            OrderDetailsForm frm = new OrderDetailsForm();
            frm.ShowDialog();
        }
    }
}
