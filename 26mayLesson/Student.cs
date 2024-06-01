using System;
using System.Collections.Generic;

namespace Task1
{
	public class Student
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public DateTime BirthDate { get; set; }
		public List<decimal> Grades { get; set; }
        private static int id = 1;
        public int Id { get; set; }

        public Student(string name,string surname,DateTime birthday)
		{
			Name = name;
            Id = id++;
            Surname = surname;
			BirthDate = birthday;
			Grades = new List<decimal>();
        }
        public void GetDetails()
		{
            Console.WriteLine($"Name: {Name},Surname {Surname}, BirthDate{BirthDate}");
        }
	}
}

