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
    public partial class frmCars : Form
    {
        MainClass mc = new MainClass();

        DataTable dt = new DataTable("Car");
        public frmCars()
        {
            InitializeComponent();
        }

        private void TxtUpdate_Click(object sender, EventArgs e)
        {

            mc.VehicleRegNo = txtVRegNumb.Text;
            mc.Make = txtMake.Text;
            mc.EngineSize = txtEngineSize.Text;

            String rent = txtRentPerDay.Text;
            mc.RentalPerDay = rent.Replace("R", "");

            mc.DateRigistered = txtDateReg.Text;
            if (cbxAvailable.Checked)
            {
                mc.Available = 1;
            }
            else
            {
                mc.Available = 0;
            }

           bool success = mc.Update(mc);
            if (success)
            {
                MessageBox.Show("Record Successfully updated");
            }
            else
            {
                MessageBox.Show("Record to update");
            }
        }

        private void txtadd_Click(object sender, EventArgs e)
        {
            mc.VehicleRegNo = txtVRegNumb.Text;
            mc.Make = txtMake.Text;
            mc.EngineSize = txtEngineSize.Text;
            String rent = txtRentPerDay.Text;
            mc.RentalPerDay = rent.Replace("R", "");

            mc.DateRigistered = txtDateReg.Text;
            if (cbxAvailable.Checked)
            {
                mc.Available = 1;
            }
            else
            {
                mc.Available = 0;
            }
            bool success = mc.Insert(mc);
            if (success)
            {
                MessageBox.Show("Record Successfully updated");
            }
            else
            {
                MessageBox.Show("Record to update");
            }

        }

        private void txtDelete_Click(object sender, EventArgs e)
        {
            mc.VehicleRegNo = txtVRegNumb.Text;

            //Load the data on the database
            //connect to the database
            bool success = mc.Delete(mc);
            if (success)
            {
                MessageBox.Show("Successfully deleted selected data.");
            }
            else
            {
                MessageBox.Show("Failed to Delete selected data.");
            }

            
        }

        private void txtExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            FrmSearch search = new FrmSearch();
            search.Show();
        }

        int R = 0;

        private void frmCars_Load(object sender, EventArgs e)
        {
            DataTable dt = mc.Select();

            txtVRegNumb.Text = dt.Rows[R]["VehicleRegNo"].ToString();
            txtMake.Text = dt.Rows[R]["Make"].ToString();
            txtEngineSize.Text = dt.Rows[R]["EngineSize"].ToString();
            txtDateReg.Text = dt.Rows[R]["DateRegistered"].ToString();
            txtRentPerDay.Text = dt.Rows[R]["RentalPerDay"].ToString();
            cbxAvailable.Checked = (bool)dt.Rows[R]["Available"];

            //Displays what record is being displayed
            txtRecord.Text = (R+1) + " of " + dt.Rows.Count;
        }
                
        private void BtnFirst_Click(object sender, EventArgs e)
        {
            DataTable dt = mc.Select();
           R = 0;

            txtVRegNumb.Text = dt.Rows[R]["VehicleRegNo"].ToString();
            txtMake.Text = dt.Rows[R]["Make"].ToString();
            txtEngineSize.Text = dt.Rows[R]["EngineSize"].ToString();
            txtDateReg.Text = dt.Rows[R]["DateRegistered"].ToString();
            txtRentPerDay.Text = dt.Rows[R]["RentalPerDay"].ToString();
            cbxAvailable.Checked = (bool)dt.Rows[R]["Available"];

            //Displays what record is being displayed
            txtRecord.Text = (R + 1) + " of " + dt.Rows.Count;

        }

        private void BtnLast_Click(object sender, EventArgs e)
        {
            DataTable dt = mc.Select();
            R = dt.Rows.Count;
            txtVRegNumb.Text = dt.Rows[dt.Rows.Count-1].ToString();
            txtMake.Text = dt.Rows[dt.Rows.Count-1].ToString();
            txtEngineSize.Text = dt.Rows[dt.Rows.Count-1].ToString();
            txtDateReg.Text = dt.Rows[dt.Rows.Count-1].ToString();
            txtRentPerDay.Text = dt.Rows[dt.Rows.Count-1]["RentalPerDay"].ToString();
            cbxAvailable.Checked = (bool)dt.Rows[dt.Rows.Count-1]["Available"];

            txtRecord.Text = dt.Rows.Count + " of " + dt.Rows.Count;
        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            DataTable dt = mc.Select();
            if (R > 0)
            {
                R--;
                txtVRegNumb.Text = dt.Rows[R]["VehicleRegNo"].ToString();
                txtMake.Text = dt.Rows[R]["Make"].ToString();
                txtEngineSize.Text = dt.Rows[R]["EngineSize"].ToString();
                txtDateReg.Text = dt.Rows[R]["DateRegistered"].ToString();
                txtRentPerDay.Text = dt.Rows[R]["RentalPerDay"].ToString();
                cbxAvailable.Checked = (bool)dt.Rows[R]["Available"];

                txtRecord.Text = R + " of " + dt.Rows.Count;
            }
            
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            DataTable dt = mc.Select();
            if (R < (dt.Rows.Count))
            {
                R++;
                txtVRegNumb.Text = dt.Rows[R]["VehicleRegNo"].ToString();
                txtMake.Text = dt.Rows[R]["Make"].ToString();
                txtEngineSize.Text = dt.Rows[R]["EngineSize"].ToString();
                txtDateReg.Text = dt.Rows[R]["DateRegistered"].ToString();
                txtRentPerDay.Text = dt.Rows[R]["RentalPerDay"].ToString();
                cbxAvailable.Checked = (bool)dt.Rows[R]["Available"];

                txtRecord.Text = R + " of " + dt.Rows.Count;
            }
        }
    }
}
