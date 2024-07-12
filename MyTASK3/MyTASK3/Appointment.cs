using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTASK3
{
    public class Appointment
    {
        public DateTime AppointmentTime { get; set; }
        public string PatientName { get; set; }
        public Appointment(DateTime appointmentTime,string patientName) {
            AppointmentTime = appointmentTime;
            PatientName = patientName;
        }

        
    }
}
