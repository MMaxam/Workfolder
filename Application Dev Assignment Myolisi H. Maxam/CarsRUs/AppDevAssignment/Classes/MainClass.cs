using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppDevAssignment.Classes
{
    public class MainClass
    {
        static string myConString = ConfigurationManager.ConnectionStrings["Hire"].ConnectionString;
        public string VehicleRegNo { get; set; }
        public string Make { get; set; }
        public string EngineSize { get; set; }
        public string DateRigistered { get; set; }
        public string RentalPerDay { get; set; }
        public int Available { get; set; }

        public string Field { get; set; }
        public string Operator { get; set; }
        public string Value { get; set; }


        public bool Insert(MainClass mc)
        {
            bool isSuccess = false;

            SqlConnection sqlCon = new SqlConnection(myConString);
            try
            {
                string sqlQuery = "INSERT INTO Car() VALUE()";

                SqlCommand cmd = new SqlCommand(sqlQuery, sqlCon);

                cmd.Parameters.AddWithValue("@VehicleRegNo", mc.VehicleRegNo);
                cmd.Parameters.AddWithValue("@Make", mc.Make);
                cmd.Parameters.AddWithValue("@EngineSize", mc.EngineSize);
                cmd.Parameters.AddWithValue("@DateRegistered", mc.DateRigistered);
                cmd.Parameters.AddWithValue("@RentalPerDay", mc.RentalPerDay);
                cmd.Parameters.AddWithValue("@Available", mc.Available);

                sqlCon.Open();

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Error inserting data", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                sqlCon.Close();
            }

            return isSuccess;
        }

        public bool Update(MainClass mc)
        {
            //setting the default return type and setting its value to false
            bool isSuccess = false;

            //connect to data
            SqlConnection sqlCon = new SqlConnection(myConString);
            try
            {
                //create a sql query to Insert Data
                string sql = "UPDATE  Car SET Vehicle = @Vehicle, Make = @Make, EngineSize = @EngineSize, DateRigistered = @DateRigistered, RentalPerDay = @RentalPerDay, Available = @Available WHERE Vehicle = @Vehicle";

                //creatinga sql command using sql and sqlCon
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                //create the Parameters to add data
                cmd.Parameters.AddWithValue("@Vehicle", mc.VehicleRegNo);
                cmd.Parameters.AddWithValue("@Make", mc.Make);
                cmd.Parameters.AddWithValue("@EngineSize", mc.EngineSize);
                cmd.Parameters.AddWithValue("@DateRigistered", mc.DateRigistered);
                cmd.Parameters.AddWithValue("@RentalPerDay", mc.RentalPerDay);
                cmd.Parameters.AddWithValue("@Available", mc.Available);

                //Open the connection
                sqlCon.Open();


                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Error updating data", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                sqlCon.Close();


            }

            return isSuccess;

        }

        public bool Delete(MainClass mc)
        {
            //setting the default return type and setting its value to false
            bool isSuccess = false;

            //connect to data
            SqlConnection sqlCon = new SqlConnection(myConString);
            try
            {
                //create a sql query to Insert Data
                string sql = "DELETE Car WHERE VehicleRegNo = @VehicleRegNo";

                //creatinga sql command using sql and sqlCon
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                //create the Parameters to add data
                cmd.Parameters.AddWithValue("@VehicleRegNo", mc.VehicleRegNo);


                //Open the connection
                sqlCon.Open();


                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error Deleting data", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                sqlCon.Close();

            }

            return isSuccess;

        }

        public DataTable Select()
        {
            //connect to the database
            SqlConnection sqlCon = new SqlConnection(myConString);
            DataTable dt = new DataTable();
            try
            {
                //write the sql query
                string sql = "SELECT * FROM Car";
                //creating a command using 'sql' and 'sqlCon'
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                //Creating a sql adapter using 'cmd'
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sqlCon.Open();
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Loading data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //disconnecting connection
                sqlCon.Close();
            }

            return dt;
        }

        public DataTable Run()
        {
            SqlConnection connection = new SqlConnection(myConString);
            DataTable dt = new DataTable();

            try
            {

                string sql = "SELECT * WHERE @Field @Operator Value";
                //creating a command using 'sql' and 'sqlCon'
                SqlCommand cmd = new SqlCommand(sql, connection);
                //Creating a sql adapter using 'cmd'
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                connection.Open();
                sda.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Loading data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //disconnecting connection
                connection.Close();
            }

            return dt;

        }

    }

}
