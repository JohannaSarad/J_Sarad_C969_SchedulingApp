using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace J_Sarad_C969_SchedulingApp.model
{
    class Appointment
    {
        public static DataTable dtAppointment { get; set; }

        public static DateTime FormattedDate { get; set; }
        public static DateTime Universal { get; set; }

        public static TimeZone LocalZone = TimeZone.CurrentTimeZone;
        public static DateTime StartTime { get; set; } 
        public static DateTime EndTime { get; set; }
        public static string UserName { get; set; }
        public static string CustomerName { get; set; }

        public static bool isOverlap { get; set; }
        public static bool isBusinessHours { get; set; }


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
            //business hours
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

        public static void IsOverlap(DateTime start, DateTime end)
        {
            //FIX ME !!!start and end being formatted to seconds = 00 before being sent to method, might want to make
            //a seperate method for this

            //start = start.AddSeconds(-start.Second);
            //end = end.AddSeconds(-end.Second);
            DB.OpenConnection();
            string query = "select start as 'Start', end as 'End', userName as 'User', customerName as 'Customer'" +
                "from user inner join appointment on user.userId = appointment.userID inner join customer " +
                "using(customerId)";
            DB.Query(query);
            dtAppointment = new DataTable();
            DB.adp.Fill(dtAppointment);
            DB.CloseConnection();

            //FIX ME!!! Make a seperate method to convert dt rows to local time
            for (int i = 0; i < dtAppointment.Rows.Count; i++)
            {
                dtAppointment.Rows[i]["Start"] =
                    TimeZoneInfo.ConvertTimeFromUtc((DateTime)dtAppointment.Rows[i]["Start"],
                    TimeZoneInfo.Local);
                dtAppointment.Rows[i]["End"] =
                    TimeZoneInfo.ConvertTimeFromUtc((DateTime)dtAppointment.Rows[i]["End"],
                    TimeZoneInfo.Local);
            }
            for (int i = 0; i < dtAppointment.Rows.Count; i++)
            {
                //Start and End collumns from dtAppointmnet are in seconds = 00 on insert to database
                StartTime = (DateTime)dtAppointment.Rows[i]["Start"];
                EndTime = (DateTime)dtAppointment.Rows[i]["End"];
                
                if ((start <= StartTime && end >= StartTime) || (start <= EndTime && end >= EndTime)
                    || (start == EndTime) || (end == StartTime))
                {
                    UserName = dtAppointment.Rows[i]["User"].ToString();
                    CustomerName = dtAppointment.Rows[i]["Customer"].ToString();
                    isOverlap = true;
                }
                else
                {
                    isOverlap = false;
                }
            }
        }
    }
}
   

