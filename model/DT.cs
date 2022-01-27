using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_Sarad_C969_SchedulingApp.model
{
    
    class DT
    {
        public static DateTime FormattedDate { get; set; }
        public static DateTime Universal { get; set; }
        
        public static TimeZone LocalZone = TimeZone.CurrentTimeZone;
        public static void FormatDate(string time, string date)
        {
            char[] AMPM = { 'A', 'M', 'P' };
            var formatDate = date + " ";
            var fTime = time.TrimStart();
            var formatTime = fTime.TrimEnd(AMPM);

            string insertDate = formatDate + formatTime;
            FormattedDate = DateTime.Parse(insertDate);
        }
        public static DateTime UniversalTime(string time, string date)
        {
            FormatDate(time, date);
            DateTime universal = LocalZone.ToUniversalTime(FormattedDate);
            return universal;
        }
    }
}
