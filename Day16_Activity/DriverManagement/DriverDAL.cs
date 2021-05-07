using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace DriverDALLibrary
{
    public class DriverDAL
    {
        SqlConnection conn;
        SqlCommand cmd;
        string strConnection;
        public DriverDAL()
        {
            strConnection = "server=LAPTOP-Q1S49BFG;Integrated security=true;Initial catalog = dbSoftTransport";
            conn = new SqlConnection(strConnection);
        }

       
        public bool AddDriver(Driver driver)
        {
            cmd = new SqlCommand("proc_InsertDriver", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@dName", driver.Name);
                cmd.Parameters.AddWithValue("@dPhone", driver.Phone);
                cmd.Parameters.AddWithValue("@dStatus", driver.Status);
                
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool UpdatePhone(Driver driver)
        {
            cmd = new SqlCommand("proc_UpdateDriverPhone", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@did", driver.Id);
                cmd.Parameters.AddWithValue("@dPhone", driver.Phone);

                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool UpdateDriverStatus(Driver driver)
        {
            cmd = new SqlCommand("proc_UpdateDriverStatus", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@did", driver.Id);
                cmd.Parameters.AddWithValue("@dStatus", driver.Status);

                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                conn.Close();
            }
        }
        public ICollection<Driver> SelectAllDrivers()
        {
            List<Driver> drivers = new List<Driver>();
            SqlCommand cmd = new SqlCommand("proc_GetAllDrivers");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            SqlDataAdapter daDriver = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();//collection of datatables
            //datatables collection of rows
            //rows collection of columns
            try
            {
                daDriver.Fill(ds, "Driver");//connect-->fetch the data-->put it in the dataset-->give the name provided-->disconnect from db
                Driver driver;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    driver = new Driver();
                    driver.Id = Convert.ToInt32(dr[0]);
                    driver.Name = dr[1].ToString();
                    driver.Phone = dr[2].ToString();
                    driver.Status = dr[3].ToString();
                    drivers.Add(driver);
                }
                return drivers;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
