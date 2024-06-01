using System;
namespace Task3
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
        }
    }
}

