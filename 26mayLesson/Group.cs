using System;
using System.Text.RegularExpressions;

namespace Task1
{
    public class Group
	{
        private static int id = 1;
        public int Id { get; set; }
        public int Limit { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }

        public Group(string name,int limit)
		{
			Name = name;
            Id = id++;
            Limit = limit;
            Students = new List<Student>();

        }


        public void GetDetails()
        {
             
            Console.WriteLine($"Group Id: {Id},Name: {Name},Limit: {Limit}");
        }
	}
}

