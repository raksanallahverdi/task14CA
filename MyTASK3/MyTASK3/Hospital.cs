using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTASK3
{


    public class Hospital
    {
        public List<Doctor> Doctors { get; private set; }
        public Hospital()
        {
           Doctors = new List<Doctor>();
        }
        public void AddDoctor(Doctor doctor)
        {
            Doctors.Add(doctor);
            Console.WriteLine("Həkim əlavə olundu");
        }
        public void ViewAllDoctors()
        {
            if (Doctors.Count == 0)
            {
                Console.WriteLine("Hech bir hekim tapilmadi..");
            }
            foreach (Doctor doctor in Doctors)
            {
                Console.WriteLine($"Ad: {doctor.Name}, Soyad: {doctor.Surname}, Yaş: {doctor.Age}");
            }
        }
        public void ScheduleAppointment()
        {
            Console.WriteLine("Hekimin adını daxil edin");
            string doctorName = Console.ReadLine();
            var doctor = Doctors.FirstOrDefault(d => d.Name == doctorName);
            if (doctor == null)
            {
                Console.WriteLine("Hekim tapilmadi");
                return;
            }

            Console.WriteLine("Pasiyentin adını daxil edin");
            string patientName=Console.ReadLine();
            Console.WriteLine("Görüş üçün saat təyin edin. Format:yyyy-mm-dd hh:mm");
            DateTime newAppointmentTime=Convert.ToDateTime(Console.ReadLine());
            if (doctor.Appointments.Any())
            {
                foreach (var existedAppointment in doctor.Appointments)
                {
                    DateTime existedAppointmentEndTime = existedAppointment.AppointmentTime.AddHours(1);
                    if (existedAppointmentEndTime< newAppointmentTime && existedAppointment.AppointmentTime>newAppointmentTime)
                    {
                        Appointment newAppointment = new Appointment(newAppointmentTime, patientName);
                        doctor.Appointments.Add(newAppointment);
                        Console.WriteLine("Görüş təyin edildi");
                    }
                    else
                    {
                        Console.WriteLine("Təəssüfki, Bu saat aralığı artıq doludur");
                    }
                }
            }
            else
            {
                Appointment newAppointment = new Appointment(newAppointmentTime, patientName);
                doctor.Appointments.Add(newAppointment);
                Console.WriteLine("Görüş təyin edildi");
            }
         
    }
        public void SeeAllAppointmentsOfDoctor()
        {
            Console.WriteLine("Hekimin adını daxil edin");
            string doctorName = Console.ReadLine();
            var doctor = Doctors.FirstOrDefault(d => d.Name == doctorName);
            if (doctor == null)
            {
                Console.WriteLine("Hekim tapilmadi");
                return;
            }

            foreach (var appointment in doctor.Appointments) {
                Console.WriteLine(appointment.PatientName, appointment.AppointmentTime);
            }

        }
    }
   
}
