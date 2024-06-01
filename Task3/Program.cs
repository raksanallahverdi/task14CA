using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Task3
{
    class Program
    {
        static void Main()
        {
            Hospital hospital = new Hospital();

            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add doctor");
                Console.WriteLine("2. View all doctors");
                Console.WriteLine("3. Schedule appointment");
                Console.WriteLine("4. View appointments of doctor");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Enter your choice:");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddDoctor(hospital);
                        break;
                    case "2":
                        ViewAllDoctors(hospital);
                        break;
                    case "3":
                        ScheduleAppointment(hospital);
                        break;
                    case "4":
                        ViewAppointmentsOfDoctor(hospital);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Tekrar secim edin.");
                        break;
                }
            }
        }

        static void AddDoctor(Hospital hospital)
        {
            Console.WriteLine("Hekimin adini daxil edin:");
            string name = Console.ReadLine();

            hospital.AddDoctor(new Doctor { Name = name });
            Console.WriteLine($"Hekim {name} elave olundu.");
        }

        static void ViewAllDoctors(Hospital hospital)
        {
            if (hospital.Doctors.Count == 0)
            {
                Console.WriteLine("Uygun hekim yoxdur,teessuf .");
                return;
            }

            Console.WriteLine("Hekimler:");
            foreach (var doctor in hospital.Doctors)
            {
                Console.WriteLine($"- {doctor.Name}");
            }
        }

        static void ScheduleAppointment(Hospital hospital)
        {
            Console.WriteLine("Hekimin adi:");
            string doctorName = Console.ReadLine();
            var doctor = hospital.Doctors.FirstOrDefault(d => d.Name == doctorName);

            if (doctor == null)
            {
                Console.WriteLine("Hekim tapilmadi.");
                return;
            }

            Console.WriteLine("Xestenin adi:");
            string patientName = Console.ReadLine();

            Console.WriteLine("Gorush tarixini girin (yyyy-MM-dd HH:mm):");
            DateTime appointmentDate;
            if (!DateTime.TryParse(Console.ReadLine(), out appointmentDate))
            {
                Console.WriteLine("Tarix formati sehvdir.");
                return;
            }
            TimeSpan appointmentDuration = TimeSpan.FromHours(1);
            if (doctor.Appointments.Any(a => a.Date < appointmentDate + appointmentDuration && a.Date + appointmentDuration > appointmentDate))
            {
                Console.WriteLine("Bu vaxt araligi artiq uygun deyil.");
                return;
            }


            doctor.Appointments.Add(new Appointment { PatientName = patientName, Date = appointmentDate });
            Console.WriteLine("Gorush planlandi.");
        }

        static void ViewAppointmentsOfDoctor(Hospital hospital)
        {
            Console.WriteLine("Hekimin adi?:");
            string doctorName = Console.ReadLine();
            var doctor = hospital.Doctors.FirstOrDefault(d => d.Name == doctorName);

            if (doctor == null)
            {
                Console.WriteLine("Hekim tapilmadi.");
                return;
            }

            if (doctor.Appointments.Count == 0)
            {
                Console.WriteLine("bu hekim uchun gorush tapilmadi");
                return;
            }

            Console.WriteLine($" Dr. {doctor.Name} uchun Gorushler:");
            foreach (var appointment in doctor.Appointments)
            {
                Console.WriteLine($"- {appointment.PatientName} at {appointment.Date}");
            }
        }
    }
}