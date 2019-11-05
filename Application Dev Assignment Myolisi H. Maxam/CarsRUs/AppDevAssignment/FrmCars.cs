using AppDevAssignment.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppDevAssignment
{
    public partial class frmCars : Form
    {
        MainClass mc = new MainClass();
        
        public frmCars()
        {
            InitializeComponent();
        }
        int R = 0;

        private void btnUpdate_Click(object sender, EventArgs e)
        { 
            //Code used to update record of data in the database
            mc.VehicleRegNo = txtVRegNumb.Text;
            mc.Make = txtMake.Text;
            mc.EngineSize = txtEngineSize.Text;

            double rent = double.Parse(txtRentPerDay.Text.Replace("R", ""));
            mc.RentalPerDay = rent;
            mc.DateRegistered = txtDateReg.Text;

            if (cbxAvailable.Checked)
            {
                mc.Available = true;
            }
            else
            {
                mc.Available = false;
            }

            bool success = mc.Update(mc);
            if (success)
            {
                MessageBox.Show("Record Successfully updated", "Record Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable dt = mc.Select();
                txtRecord.Text = R + " of " + dt.Rows.Count;

            }
            else
            {
                MessageBox.Show("Record failed to update","Update failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        { 
            //Receiving and sending all data in the textfields to the Insert methods in the MainClass class
            mc.VehicleRegNo = txtVRegNumb.Text;
            mc.Make = txtMake.Text;
            mc.EngineSize = txtEngineSize.Text;

            double rent = double.Parse(txtRentPerDay.Text.Replace("R",""));
            mc.RentalPerDay = rent;

            mc.DateRegistered = txtDateReg.Text;
            
            if (cbxAvailable.Checked)
            {
                mc.Available = true;
            }
            else
            {
                mc.Available = false;
            }
            bool success = mc.Insert(mc);
            if (success)
            {
                MessageBox.Show("Record Successfully added","New Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable dt = mc.Select();
                R = 0;
                txtRecord.Text = (R+1) + " of " + dt.Rows.Count;
                
            }
            else
            {
                MessageBox.Show("Program failed to add new record");
            }
        }

        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Code deletes a record of data in the database by using the VehicleRegNo as reference
            mc.VehicleRegNo = txtVRegNumb.Text;

            bool success = mc.Delete(mc);
            if (success)
            {
                MessageBox.Show("Successfully deleted selected data.");
                DataTable dt = mc.Select();
                txtRecord.Text = 1 + " of " + (dt.Rows.Count + 1);
            }
            else
            {
                MessageBox.Show("Failed to Delete selected data.");
            }


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Hide();
            //Opens a new windows form called frmSearch
            frmSearch search = new frmSearch();
            search.Show(); 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DataTable dt = mc.Select();
            //Data is repopulated by the current record
            txtVRegNumb.Text = dt.Rows[R]["VehicleRegNo"].ToString();
            txtMake.Text = dt.Rows[R]["Make"].ToString();
            txtEngineSize.Text = dt.Rows[R]["EngineSize"].ToString();
            txtDateReg.Text = timeRemove();
            txtRentPerDay.Text = "R " + dt.Rows[R]["RentalPerDay"].ToString();
            cbxAvailable.Checked = (bool)dt.Rows[R]["Available"];
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Closes application
            var result = MessageBox.Show("Are you sure you want to leave?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmCars_Load(object sender, EventArgs e)
        {
            DataTable dt = mc.Select();
            //When app loads data of the first record in the database is automatically displayed
            txtVRegNumb.Text = dt.Rows[R]["VehicleRegNo"].ToString();
            txtMake.Text = dt.Rows[R]["Make"].ToString();
            txtEngineSize.Text = dt.Rows[R]["EngineSize"].ToString();
            txtDateReg.Text = timeRemove();
            txtRentPerDay.Text = "R" + dt.Rows[R]["RentalPerDay"].ToString();
            cbxAvailable.Checked = (bool)dt.Rows[R]["Available"];

            //Displays what record is being displayed
            txtRecord.Text = (R + 1) + " of " + dt.Rows.Count;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            DataTable dt = mc.Select();

            //Code displays the first record in the database
            R = 0;
            txtVRegNumb.Text = dt.Rows[0]["VehicleRegNo"].ToString();
            txtMake.Text = dt.Rows[0]["Make"].ToString();
            txtEngineSize.Text = dt.Rows[0]["EngineSize"].ToString();
            txtDateReg.Text = timeRemove();
            txtRentPerDay.Text = "R" + dt.Rows[0]["RentalPerDay"].ToString();
            cbxAvailable.Checked = (bool)dt.Rows[0]["Available"];

            //Displays what record is being displayed
            txtRecord.Text = (R + 1) + " of " + dt.Rows.Count;
            
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {   //Loads the previous record of data in the database
            DataTable dt = mc.Select();
            if(R > 0)
            { 
                R--;
                txtVRegNumb.Text = dt.Rows[R]["VehicleRegNo"].ToString();
                txtMake.Text = dt.Rows[R]["Make"].ToString();
                txtEngineSize.Text = dt.Rows[R]["EngineSize"].ToString();
                txtDateReg.Text = timeRemove();
                txtRentPerDay.Text = "R" + dt.Rows[R]["RentalPerDay"].ToString();
                cbxAvailable.Checked = (bool)dt.Rows[R]["Available"];
            }
            if (R == 0)
            {
                txtRecord.Text = (R + 1) + " of " + dt.Rows.Count;
            }
            else
            {
                txtRecord.Text = (R + 1) + " of " + dt.Rows.Count;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {   //Loads the next record of data in the database
            DataTable dt = mc.Select();
            if (R >= 0   && R < dt.Rows.Count-1)
            {
                R++;
                txtVRegNumb.Text = dt.Rows[R]["VehicleRegNo"].ToString();
                txtMake.Text = dt.Rows[R]["Make"].ToString();
                txtEngineSize.Text = dt.Rows[R]["EngineSize"].ToString();
                txtDateReg.Text = timeRemove();
                txtRentPerDay.Text = "R" + dt.Rows[R]["RentalPerDay"].ToString();
                cbxAvailable.Checked = (bool)dt.Rows[R]["Available"];

                txtRecord.Text = (R+1) + " of " + dt.Rows.Count;
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {   //Loads the last record of data in the database
            DataTable dt = mc.Select();
        
            R = dt.Rows.Count-1;
            txtVRegNumb.Text = dt.Rows[R]["VehicleRegNo"].ToString();
            txtMake.Text = dt.Rows[R]["Make"].ToString();
            txtEngineSize.Text = dt.Rows[R]["EngineSize"].ToString();
            txtDateReg.Text = timeRemove();
            txtRentPerDay.Text = "R" + dt.Rows[R]["RentalPerDay"].ToString();
            cbxAvailable.Checked = (bool)dt.Rows[R]["Available"];

            txtRecord.Text = (R+1) + " of " + dt.Rows.Count;
            
        }


        public string timeRemove()
        {   
            DataTable dt = mc.Select(); 
            string date = txtDateReg.Text = dt.Rows[R]["DateRegistered"].ToString();
            date = date.Substring(0, date.IndexOf(" "));

            return date;
        }


    }
}
