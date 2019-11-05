using AppDevAssignment.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppDevAssignment
{
    public partial class frmSearch : Form
    {
        public frmSearch()
        {
            InitializeComponent();
        }

        static string myConString = ConfigurationManager.ConnectionStrings["Hire"].ConnectionString;
        DataTable dt = new DataTable("Hire");
        DataSet ds = new DataSet();
        MainClass mc = new MainClass();

        private void frmSearch_Load(object sender, EventArgs e)
        {
            //Code populates datagrid table with the Hire database 
            this.carTableAdapter.Fill(this.hireDataSet.Car);
            DataTable dt = mc.Select();
            dgvCarList.DataSource = dt;
            //Code populates all combo boxes with the appropriate combo box items
            cboField.Items.Add("Make");
            cboField.Items.Add("EngineSize");
            cboField.Items.Add("RentalPerDay");
            cboField.Items.Add("Available");

            cboOperator.Items.Add("=");
            cboOperator.Items.Add("<");
            cboOperator.Items.Add(">");
            cboOperator.Items.Add("<=");
            cboOperator.Items.Add(">=");

        }

        private void btnRun_Click(object sender, EventArgs e)
        {   //Code uses the options selected in the combo boxes and the text in the text box to filter through the database to display data that the user wants to see

            ds.Reset();
            if (cboField.Text != "" && cboOperator.Text != "" && txtValue.Text != "")
            {
                string Field = cboField.Text.ToString();
                string Operator = cboOperator.Text.ToString();
                string Value = txtValue.Text;

                string search = Field + " " + Operator + " '" + Value + "'";

                using (SqlConnection con = new SqlConnection(myConString))
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT * FROM Car WHERE " + @search;

                        SqlDataAdapter sqlData = new SqlDataAdapter(cmd);
                        sqlData.Fill(ds);
                        dgvCarList.DataSource = ds.Tables[0];

                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error updating data", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    finally
                    {
                        con.Close();
                    }
                }

            }

            

            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
           var result = MessageBox.Show("Are you sure you want to leave?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
                frmCars cars = new frmCars();
                cars.Show();
            }
            
        }
    }
}
