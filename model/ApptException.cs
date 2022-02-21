using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace J_Sarad_C969_SchedulingApp.model
{

    class ApptException : ApplicationException
    {
        public void OutsideBusinessHours()
        {
            MessageBox.Show("\r\n The Appointment you are trying to set is outside of business hours." +
                       "\r\nBusiness Hours are 8:00 AM to 5:00 PM Monday through Friday.",
                      "Appointment Outside of Business Hours");
        }
        public void OverlappingAppointment()
        {
            MessageBox.Show($"There is an overlapping appointment for {DB.currentUser} during the appointment" +
                $"time that you have slected", "Overlapping Appointment");
        }

        public void HoursOutOfRange()
        {
            MessageBox.Show("The appointment start time can not be after the appointment end time");
        }

}
}
