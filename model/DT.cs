using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data;

namespace J_Sarad_C969_SchedulingApp.model
{
    
    class DT
    {
        public static DateTime FormattedDate { get; set; }
        public static DateTime Universal { get; set; }
        
        public static TimeZone LocalZone = TimeZone.CurrentTimeZone;

        public static bool isOverlap { get; set; }
        public static bool isBusinessHours { get; set; }
        

        public static DateTime UniversalTime(DateTime date, TimeSpan time)
        {
            
            DateTime formatDate = date.Add(time);
            DateTime formatDT = formatDate.AddSeconds(-formatDate.Second);
            DateTime universal = LocalZone.ToUniversalTime(formatDT);
            return universal;
        }

        public static void IsBusinessHours (DateTime date, DateTime start, DateTime end)
        {
            TimeSpan open = new TimeSpan(08, 00, 00);
            TimeSpan close = new TimeSpan(17, 00, 00);
            if (date.DayOfWeek.ToString() == "Saturday" || date.DayOfWeek.ToString() == "Sunday"
                || start.TimeOfDay < open || end.TimeOfDay > close)
            {
                MessageBox.Show("Appointment on " + date.ToLongDateString() + " from " +
                        start.ToShortTimeString() + " to " + end.ToShortTimeString() +
                        "\nis outside of business hours and can not be set." +
                        "\n\nBusiness Hours are 8:00 AM to 5:00 PM Monday through Friday.",
                        "Appointment Outside of Business Hours");
                isBusinessHours = false;

            }
            else
            {
                isBusinessHours =  true;
            }
        }

        public static void IsOverlap (DateTime start, DateTime end)
        {
            DB.OpenConnection();
            string query = "select start as 'Start', end as 'End', userName as 'User', customerName as 'Customer'" +
                "from user inner join appointment on user.userId = appointment.userID inner join customer using(customerId)";
            DB.Query(query);
            DataTable dt = new DataTable();
            DB.adp.Fill(dt);
            DB.CloseConnection();
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["Start"] =
                    TimeZoneInfo.ConvertTimeFromUtc((DateTime)dt.Rows[i]["Start"],
                    TimeZoneInfo.Local);
                dt.Rows[i]["End"] =
                    TimeZoneInfo.ConvertTimeFromUtc((DateTime)dt.Rows[i]["End"],
                    TimeZoneInfo.Local);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateTime checkStart = (DateTime)dt.Rows[i]["Start"];
                DateTime checkEnd = (DateTime)dt.Rows[i]["End"];
                if ((start <= checkStart && end >= checkStart) || (start <= checkEnd && end >= checkEnd)
                    || (start == checkEnd) || (end == checkStart))
                {
                    string user = dt.Rows[i]["User"].ToString();
                    string customer = dt.Rows[i]["Customer"].ToString();
                    isOverlap = true;
                    
                    MessageBox.Show($"There is an overlapping appointment for {user} with {customer} from \n " +
                        $"{checkStart} to {checkEnd}", "Overlapping Appointment");
                }
                else
                {
                    isOverlap = false;
                }
            }
        }
    }
}
