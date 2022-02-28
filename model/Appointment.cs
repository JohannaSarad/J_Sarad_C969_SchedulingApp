using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace J_Sarad_C969_SchedulingApp.model
{
    public class Appointment
    {
        //static DataTable -- shared table needs to be accessed in MainMenu.cs, Appointments.cs
        //UpdateAppts.cs, and AddAppt.cs
        public static DataTable dtAppointments { get; set; }
        
        //static Properites
        
        //shared CurrentApptObj needs to be accessed in MainMenu.cs. Appointments.cs, UpdateAppt.cs
        //and AddAppt.cs
        public static DataRow CurrentApptObj { get; set; }

        //global properties
        public string CurrentApptID {get; set;}
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool isOverlap { get; set; }
        public bool isBusinessHours { get; set; }

        //get local timezone
        public static TimeZone LocalZone = TimeZone.CurrentTimeZone;

        public static List<Schedule> FillSchedule()
        {
            List<Schedule> output = new List<Schedule>();
            
            //fill output List with dtAppointments DataTable 
            foreach(DataRow row in dtAppointments.Rows)
            {
                    DateTime date = (DateTime)row["Start Time"];
                    DateTime end = (DateTime)row["End Time"];
                    Schedule schedule = new Schedule();
                    schedule.schedDate = date.ToShortDateString();
                    schedule.schedStart = date.ToShortTimeString();
                    schedule.schedEnd = end.ToShortTimeString();
                    schedule.schedCust = row["Customer Name"].ToString();
                    schedule.schedUserId = row["User ID"].ToString();
                    schedule.schedType = row["Appointment Type"].ToString();
                    output.Add(schedule);
            }
            return output;
        }

        public static void FillAppointments()
        {
            //fill Appointments data table from database an display in local time
            try
            {
                DB.OpenConnection();
                string query =
                    "select appointmentId as 'Appointment ID', type as 'Appointment Type', userId as 'User ID'," +
                    "userName as 'User Name', customerId as 'Customer ID', customerName as 'Customer Name', " +
                    "start as 'Date', start as 'Start Time', end as 'End Time' from user inner join appointment " +
                    "using(userId) inner join customer using(customerId) order by start";
                DB.Query(query);
                dtAppointments = new DataTable();
                DB.adp.Fill(dtAppointments);
                DisplayLocalTime(dtAppointments);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!" + ex.Message);
            }
            finally
            {
                DB.CloseConnection();
            }
        }

        public static void FillAppointmentsByDate(DateTime startDate, DateTime endDate)
        {
            dtAppointments = new DataTable();
            //fill dtAppointments based on selected dates
            try
            {
                DB.OpenConnection();
                string query =
                   "select appointmentId as 'Appointment ID', userId as 'User ID', customerId as 'Customer ID', " +
                   "start as 'Date', start as 'Start Time', end as 'End Time', type as 'Appointment Type', " +
                   "customerName as 'Customer Name', userName as 'User Name'" +
                   "from user inner join appointment using(userId) inner join customer using(customerId)" +
                   "where start BETWEEN @start AND @end order by start";
                DB.Query(query);
                DB.cmd.Parameters.AddWithValue("@start", startDate);
                DB.cmd.Parameters.AddWithValue("@end", endDate);
                DB.adp.Fill(dtAppointments);
                DisplayLocalTime(dtAppointments);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!" + ex.Message);
            }
            finally
            {
                DB.CloseConnection();
            }
            
        }
        
        public static void DisplayLocalTime(DataTable table) { 
            //convert UTC time to local time and timezone
            for (int i = 0; i < table.Rows.Count; i++)
            {
                table.Rows[i]["Date"] =
                    TimeZoneInfo.ConvertTimeFromUtc((DateTime)table.Rows[i]["Date"],
                    TimeZoneInfo.Local);
                table.Rows[i]["Start Time"] =
                    TimeZoneInfo.ConvertTimeFromUtc((DateTime)table.Rows[i]["Start Time"],
                    TimeZoneInfo.Local);
                table.Rows[i]["End Time"] =
                    TimeZoneInfo.ConvertTimeFromUtc((DateTime)table.Rows[i]["End Time"],
                    TimeZoneInfo.Local);
            }
        }

        public void UpdateAppointment(string id)
        {
            //update CurrentApptObj with selected row id
            foreach (DataRow row in dtAppointments.Rows)
            {
                if (row["Appointment ID"].ToString() == id)
                {
                    CurrentApptObj = row;
                }
            }
        }
        public DateTime UniversalTime(DateTime date)
            //TimeSpan time)
        {
            //append time to date, format resulting DateTime to seconds = 00, convert resulting DateTime from
            //local to universal time, and returns universal DateTime value
            //DateTime formatDate = date.Add(time);
            //DateTime formatDT = formatDate.AddSeconds(-formatDate.Second);
            DateTime universal = LocalZone.ToUniversalTime(date);
                //(formatDT);
            return universal;
        }

        public void IsBusinessHours(DateTime date, DateTime start, DateTime end)
        {
            //sets business hours from 8 AM to 5PM Monday through Friday and returns bool value of isBusinessHours 
            //property
            TimeSpan open = new TimeSpan(08, 00, 00);
            TimeSpan close = new TimeSpan(17, 00, 00);

            //if day of week is a weekend or start time before open or end time after close appointment is outside
            //of business hours. Update isBusinessHours
            if (date.DayOfWeek.ToString() == "Saturday" || date.DayOfWeek.ToString() == "Sunday"
                || start.TimeOfDay < open || end.TimeOfDay > close)
            {
                isBusinessHours = false;
            }
            else
            {
                isBusinessHours = true;
            }
        }

        //Method to check for overlapping appointments
        public bool IsOverlap(DateTime start, DateTime end, string userId)
        {
            //traverse dtAppointments data table to check for overlapping appointments
            foreach(DataRow row in dtAppointments.Rows) 
            {
                //Start and End collumns from dtAppointmnet are in seconds = 00 on insert to database
                StartTime = (DateTime)row["Start Time"];
                EndTime = (DateTime)row["End Time"];
                
                //check for overlapping appointment if appointment is not the current appointment
                if (Appointment.CurrentApptObj != null)
                {
                    if (row["Appointment ID"].ToString() == Appointment.CurrentApptObj["Appointment ID"].ToString())
                    {
                        isOverlap = false;
                    }
                }
                else if (userId == row["User ID"].ToString())
                {
                    if ((start <= StartTime && end >= StartTime) || (start <= EndTime && end >= EndTime)
                        || (start == EndTime) || (end == StartTime))
                    {
                        //update appointment object
                        CurrentApptObj = row;
                        CurrentApptID = row["Appointment ID"].ToString();
                        isOverlap = true;
                    }
                }
            }
            return isOverlap;
        }
    }
}
   

