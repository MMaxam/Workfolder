using AppDevAssignment.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

            
        }
    }
}
