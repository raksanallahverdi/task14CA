using System;
namespace Task3
{
	public class Doctor
    {
        public string Name { get; set; }
        public List<Appointment> Appointments { get; private set; }

        public Doctor()
        {
            Appointments = new List<Appointment>();
        }
    }
}

