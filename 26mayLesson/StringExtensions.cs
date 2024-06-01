
using System.Text.RegularExpressions;

namespace Task1
{
	public static class StringExtensions
	{
		public static bool isValidGroupName(this string name)
		{
			if (!string.IsNullOrWhiteSpace(name) && name.Length > 1)
			{
				return true;
			}
			return false;
		}
		public static bool IsValidStudentName(this string name)
		{
			if (!string.IsNullOrWhiteSpace(name) && name.Length > 2 && Regex.IsMatch(name, "^[A-Z][a-zA-Z]*$"))
			{
				return true;
			}
			return false;

		}
        public static bool IsValidStudentSurname(this string surname)
        {
            if (!string.IsNullOrWhiteSpace(surname) && surname.Length > 6 && Regex.IsMatch(surname, "^[A-Z][a-zA-Z]*$"))
            {
                return true;
            }
            return false;

        }
    }
}

