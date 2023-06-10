using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Hms.Models
{
    public class AppointmentDbHandle
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["Appoinmentconn"].ToString();
            con = new SqlConnection(constring);
        }
        public bool AddAppointment(Appointment amodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewAppointment", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Pid", amodel.Pid);
            cmd.Parameters.AddWithValue("@Pname", amodel.Pname);
            cmd.Parameters.AddWithValue("@AppointmentDate", amodel.AppointmentDate);
            cmd.Parameters.AddWithValue("@Dname", amodel.Dname);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********** VIEW STUDENT DETAILS ********************
        public List<Appointment> GetAppointment()
        {
            connection();
            List<Appointment> Appointmentlist = new List<Appointment>();

            SqlCommand cmd = new SqlCommand("GetAppointmentDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Appointmentlist.Add(
                    new Appointment
                    {
                        Pid = Convert.ToInt32(dr["Pid"]),
                        Pname = Convert.ToString(dr["Pname"]),
                        AppointmentDate = Convert.ToDateTime(dr["AppointmentDate"]),
                        Dname = Convert.ToString(dr["Dname"])
                    });
            }
            return Appointmentlist;
        }

        // ***************** UPDATE Appointment DETAILS *********************
        public bool UpdateDetails(Appointment amodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateAppointmentDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Pid", amodel.Pid);
            cmd.Parameters.AddWithValue("@Pname", amodel.Pname);
            cmd.Parameters.AddWithValue("@AppointmentDate", amodel.AppointmentDate);
            cmd.Parameters.AddWithValue("@Dname", amodel.Dname);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }



        //**************Delete appointment

        public bool DeleteAppointment(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteAppointment", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Pid", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

    }
}