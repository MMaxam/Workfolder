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
    public partial class FrmSearch : Form
    {
        public FrmSearch()
        {
            InitializeComponent();

            
        }
        DataTable dt = new DataTable("Hire");
        MainClass mc = new MainClass();

        private void FrmSearch_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Car' table. You can move, or remove it, as needed.
            this.carTableAdapter.Fill(this.dataSet1.Car);
            DataTable dt = mc.Select();
            dgvCarList.DataSource = dt;

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
        {

            mc.Field = cboField.Text.ToString();
            mc.Operator = cboOperator.Text.ToString();
            mc.Value = txtValue.Text;

            DataTable dt = mc.Run();
            DataView dv = dt.DefaultView;
            dgvCarList.DataSource = dv.ToTable();




        }
    }
}
