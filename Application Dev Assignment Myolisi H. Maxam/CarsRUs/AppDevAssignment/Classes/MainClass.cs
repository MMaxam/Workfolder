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
        public string DateRegistered { get; set; }
        public double RentalPerDay { get; set; }
        public bool Available { get; set; }


        public bool Insert(MainClass mc)
        {
            //Code to add a record of data in the database

            //setting the default return type and setting its value to false
            bool isSuccess = false;

            SqlConnection sqlCon = new SqlConnection(myConString);
            try
            {
                string sqlQuery = "INSERT INTO Car(VehicleRegNo, Make, EngineSize, DateRegistered, RentalPerDay, Available) VALUES (@VehicleRegNo, @Make, @EngineSize, @DateRegistered, @RentalPerDay, @Available)";

                SqlCommand cmd = new SqlCommand(sqlQuery, sqlCon);
                //Parameters are created to be added to the data 
                cmd.Parameters.AddWithValue("@VehicleRegNo", mc.VehicleRegNo);
                cmd.Parameters.AddWithValue("@Make", mc.Make);
                cmd.Parameters.AddWithValue("@EngineSize", mc.EngineSize);
                cmd.Parameters.AddWithValue("@DateRegistered", mc.DateRegistered);
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

            //Establishes connection between the database and the application
            SqlConnection sqlCon = new SqlConnection(myConString);
            try
            {
                //create a sql query to Update data that already exist
                string sql = "UPDATE Car SET Make = @Make, EngineSize = @EngineSize, DateRegistered = @DateRegistered, RentalPerDay = @RentalPerDay, Available = @Available WHERE VehicleRegNo = @VehicleRegNo";

                //creatinga sql command using sql and sqlCon
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                //create the Parameters to add data
                cmd.Parameters.AddWithValue("@VehicleRegNo", mc.VehicleRegNo);
                cmd.Parameters.AddWithValue("@Make", mc.Make);
                cmd.Parameters.AddWithValue("@EngineSize", mc.EngineSize);

                cmd.Parameters.AddWithValue("@DateRegistered", mc.DateRegistered);
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
                //create a sql query to Delete Data using the Vehilcle Registration as reference
                string sql = "DELETE FROM Car WHERE VehicleRegNo = @VehicleRegNo";

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

    }

}
