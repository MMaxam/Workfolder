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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        static string myConString = ConfigurationManager.ConnectionStrings["Hire"].ConnectionString;

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string Username = txtUsername.Text;
            string Password = txtPassword.Text;

            if (Username != "" || Password != "")
            {
                Username = Username.ToLower();
                using (SqlConnection con = new SqlConnection(myConString))
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT * FROM Staff WHERE Username = '" + @Username + "' AND Password = '" + @Password + "'";

                        SqlDataAdapter sda = new SqlDataAdapter(cmd);

                        
                       
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Error Loading data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }finally
                    {
                        con.Close();
                        frmCars cars = new frmCars();
                        cars.Show();
                        this.Hide();
                    }
                }
            }
            else
            {
                MessageBox.Show("Enter missing text fields");
            }
        }

        private void btnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
