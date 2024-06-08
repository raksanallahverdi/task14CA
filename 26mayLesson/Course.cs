using System;
namespace Task1
{
    public class Course
	{
		private static int id = 1;
		public int Id { get; set; }
		public string Name { get; set; }
		public CustomList<Group> Groups { get; }
        

        public Course(string name)
		{
			Name = name;
			Id = id++;
			Groups = new CustomList<Group>();

		}

		public void AddGroup(Group group)
		{
			Groups.Add(group);
		}
       
    }
}

