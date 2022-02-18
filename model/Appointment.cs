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
        //global DataTables
        public static DataTable dtAppointments { get; set; }

        //public static DateTime FormattedDate { get; set; }
        //public static DateTime Universal { get; set; }

        //public static List<Appointment> schedule { get; set; }

        public static TimeZone LocalZone = TimeZone.CurrentTimeZone;

        //global Properites
        public static DataRow CurrentApptObj { get; set; }
       
        public static string CurrentApptID {get; set;}
        //public static string UserID { get; set; }
       
        //public static string UserName { get; set; }
        //public static string CustomerID { get; set; }
        //public static string CustomerName { get; set; }
        //public static string Type { get; set; }
        //public static DateTime Date { get; set; }
        public static DateTime StartTime { get; set; }
        public static DateTime EndTime { get; set; }


        

        public static bool isOverlap { get; set; }
        public static bool isBusinessHours { get; set; }

        public static List<Schedule> FillSchedule()
        {
            List<Schedule> output = new List<Schedule>();
            //foreach (DataRow row in dtAppt.Rows)
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
            DB.OpenConnection();
            string query =
                "select appointmentId as 'Appointment ID', type as 'Appointment Type', userId as 'User ID'," +
                "userName as 'User Name', customerId as 'Customer ID', customerName as 'Customer Name', " +
                "start as 'Date', start as 'Start Time', end as 'End Time' from user inner join appointment using(userId) inner join customer using(customerId)";
            DB.Query(query);
            dtAppointments = new DataTable();
            DB.adp.Fill(dtAppointments);
            DB.CloseConnection();
            
            DisplayLocalTime(dtAppointments);
        }

        public static void FillAppointmentsByDate(DateTime startDate, DateTime endDate)
        {
            string query =
               "select appointmentId as 'Appointment ID', userId as 'User ID', customerId as 'Customer ID', " +
               "start as 'Date', start as 'Start Time', end as 'End Time', type as 'Appointment Type', " +
               "customerName as 'Customer Name', userName as 'User Name'" +
               "from user inner join appointment using(userId) inner join customer using(customerId)" +
               "where start BETWEEN @start AND @end order by start";
            DB.Query(query);
            DB.cmd.Parameters.AddWithValue("@start", startDate);
            DB.cmd.Parameters.AddWithValue("@end", endDate);
            dtAppointments = new DataTable();
            DB.adp.Fill(dtAppointments);

            DB.CloseConnection();
            DisplayLocalTime(dtAppointments);
        }
        public static void DisplayLocalTime(DataTable table) { 
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

        public static void UpdateAppointment(string id)
        {
            foreach (DataRow row in dtAppointments.Rows)
            {
                if (row["Appointment ID"].ToString() == id)
                {
                    //Type = row["Appointment Type"].ToString();
                    //UserID = row["User ID"].ToString();
                    //UserName = row["User Name"].ToString();
                    //CustomerID = row["Customer ID"].ToString();
                    //CustomerName = row["Customer Name"].ToString();
                    //Date = (DateTime)row["Date"];
                    //StartTime = (DateTime)row["Start Time"];
                    //EndTime = (DateTime)row["End Time"];
                    CurrentApptObj = row;

                }
            }
        }
        public static DateTime UniversalTime(DateTime date, TimeSpan time)
        {
            //appends time to date, formats resulting DateTime to seconds = 00, converts resulting DateTime from
            //local to universal time, and returns universal DateTime value
            DateTime formatDate = date.Add(time);
            DateTime formatDT = formatDate.AddSeconds(-formatDate.Second);
            DateTime universal = LocalZone.ToUniversalTime(formatDT);
            return universal;
        }

        public static void IsBusinessHours(DateTime date, DateTime start, DateTime end)
        {
            //sets business hours from 8 AM to 5PM Monday through Friday and returns bool value of isBusinessHours 
            //property
            TimeSpan open = new TimeSpan(08, 00, 00);
            TimeSpan close = new TimeSpan(17, 00, 00);

            //if day of week is a weekend or start time before open or end time after close appointment is outside of
            //business hours. Update isBusinessHours
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

        public static bool IsOverlap(DateTime start, DateTime end, string userId)
        {
            //FIX ME !!!start and end being formatted to seconds = 00 before being sent to method, might want to make
            //a seperate method for this

            //for (int i = 0; i < dtAppointments.Rows.Count; i++)
            //{
            foreach(DataRow row in dtAppointments.Rows) 
            {
                //Start and End collumns from dtAppointmnet are in seconds = 00 on insert to database
                StartTime = (DateTime)row["Start Time"];
                EndTime = (DateTime)row["End Time"];
                //MessageBox.Show($"{row["Appointment ID"]}, {Appointment.CurrentApptObj["Appointment ID"]}");
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
                        //UserName = dtAppointments.Rows[i]["User Name"].ToString();
                        //CustomerName = dtAppointments.Rows[i]["Customer Name"].ToString();
                        CurrentApptObj = row;
                        CurrentApptID = row["Appointment ID"].ToString();
                        isOverlap = true;
                    }
                }
                //else
                //{
                //    isOverlap = false;
                //}
            }
            return isOverlap;
        }
    }
}
   

