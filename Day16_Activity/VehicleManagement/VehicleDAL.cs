using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace VehicleDALLibrary
{
    public class VehicleDAL
    {
        SqlConnection conn;
        SqlCommand cmd;
        string strConnection;
        public VehicleDAL()
        {
            strConnection = "server=LAPTOP-Q1S49BFG;Integrated security=true;Initial catalog = dbSoftTransport";
            conn = new SqlConnection(strConnection);
        }


        public bool AddVehicle(Vehicle vehicle)
        {
            cmd = new SqlCommand("proc_InsertVehicle", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@vVehicleNumber", vehicle.VechicleNumber);
                cmd.Parameters.AddWithValue("@vType", vehicle.Type);
                cmd.Parameters.AddWithValue("@vCapacity", vehicle.Capacity);
                cmd.Parameters.AddWithValue("@vDriverId", vehicle.DriverID);
                cmd.Parameters.AddWithValue("@vFilledStatus", vehicle.FilledStatus);
                cmd.Parameters.AddWithValue("@vStatus", vehicle.Status);

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
        public bool UpdateCapacity(Vehicle vehicle)
        {
            cmd = new SqlCommand("proc_UpdateVehicleCapacity", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@vVehicleNumber", vehicle.VechicleNumber);
                cmd.Parameters.AddWithValue("@vCapacity", vehicle.Capacity);

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
        public bool UpdateDriverId(Vehicle vehicle)
        {
            cmd = new SqlCommand("proc_UpdateDriverId", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@vVehicleNumber", vehicle.VechicleNumber);
                cmd.Parameters.AddWithValue("@vDriverId", vehicle.DriverID);

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
        public bool UpdateVehicleFilledStatus(Vehicle vehicle)
        {
            cmd = new SqlCommand("proc_UpdateVehicleFilledStatus", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@vVehicleNumber", vehicle.VechicleNumber);
                cmd.Parameters.AddWithValue("@vFilledStatus", vehicle.FilledStatus);

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
        public bool UpdateVehicleStatus(Vehicle vehicle)
        {
            cmd = new SqlCommand("proc_UpdateVehicleStatus", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@vVehicleNumber", vehicle.VechicleNumber);
                cmd.Parameters.AddWithValue("@vStatus", vehicle.Status);

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
        public ICollection<Vehicle> SelectAllVehicles()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            SqlCommand cmd = new SqlCommand("proc_GetAllVehicles");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            SqlDataAdapter daVehicle = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();//collection of datatables
            //datatables collection of rows
            //rows collection of columns
            try
            {
                daVehicle.Fill(ds, "Vehicle");//connect-->fetch the data-->put it in the dataset-->give the name provided-->disconnect from db
                Vehicle vehicle;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    vehicle = new Vehicle();
                    vehicle.VechicleNumber = dr[0].ToString();
                    vehicle.Type = dr[1].ToString();
                    vehicle.Capacity = Convert.ToInt32(dr[2]);
                    vehicle.DriverID = Convert.ToInt32(dr[3]);
                    vehicle.FilledStatus = Convert.ToInt32(dr[4]);
                    vehicle.Status = dr[3].ToString();
                    vehicles.Add(vehicle);
                }
                return vehicles;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
