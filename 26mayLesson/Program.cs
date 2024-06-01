using System.Globalization;

namespace Task1
{
    public class Program
    {
        public static void Main()
        {
            Course course = new Course("Code Academy");
            int count = 0;
            while (true)
            {
                menu:
                Console.WriteLine(" -- MENU -- ");
                Console.WriteLine("1.Qrup elave et");
                Console.WriteLine("2.Qruplari gor");
                Console.WriteLine("3.Qrup update ");
                Console.WriteLine("4.Qrup sil");
                Console.WriteLine("5.Qrupa student elave et ");
                Console.WriteLine("6.Qrupdaki Studentleri gor ");
                Console.WriteLine("7.Kursdaki butun Studentleri gor");
                Console.WriteLine("8.Studentlerin icinde axtarish");
                Console.WriteLine("9.Studenti sil");
                Console.WriteLine("10.Studenti update et");
                Console.WriteLine("11.Exit");
                Console.WriteLine();
                Console.WriteLine("MENU'DAN SECHIM ET:");
                

                string input=Console.ReadLine();
                int answer;
                int limit;
                
                bool isTrue = int.TryParse(input, out answer);

                if (isTrue)
                {
                    switch ((Operations)answer)
                    {
                        case Operations.AddGroup:

                            Console.WriteLine("Elave etmek istediyiniz qrupun adini daxil edin");
                            string groupName = Console.ReadLine();
                            if (groupName.isValidGroupName()){
                                if (!course.Groups.Any(g => g.Name.ToLower() == groupName.ToLower()))
                                {
                                    Console.WriteLine("Qrupa Limit'e elave edin");
                                    input = Console.ReadLine();
                                    isTrue = int.TryParse(input, out limit);
                                    if (isTrue)
                                    {
                                        course.AddGroup(new Group(groupName, limit));
                                        count += 1;
                                        Console.WriteLine($"{groupName} Qrupu,limit {limit},Kursa ugurla elave olundu");
                                        goto menu;
                                    }
                                    
                                };
                            }
                        break;
                        case Operations.GetGroups:
                            if (count > 0)
                            {
                                foreach (var group in course.Groups)
                                {
                                    group.GetDetails();
                                }
                                goto menu;
                            }
                            else
                            {
                                Console.WriteLine("Teessufki Kursda Qrup yoxdur! ");
                                goto menu;
                            }
                            
                            break;

                        case Operations.UpdateGroup:
                            Console.WriteLine("Update etmek istediyiniz qrupun Id-si?");
                            int id;
                            input=Console.ReadLine();
                            isTrue = int.TryParse(input, out id);
                            if (isTrue)
                            {
                                var changedGroup = course.Groups.FirstOrDefault(g => g.Id == id);
                                if (changedGroup != null)
                                {
                                    Console.WriteLine("Qrupun yeni adini daxil edin");
                                    string name = Console.ReadLine();
                                    changedGroup.Name = name;
                                    Console.WriteLine("Qrup adi ugurla deyishdirildi");
                                    goto menu;
                                }
                            }
                            break;
                        case Operations.DeleteGroup:
                            Console.WriteLine("Delete etmek istediyiniz qrupun Id-si?");
                            input = Console.ReadLine();                  
                            isTrue = int.TryParse(input, out id);
                            var existedGroup = course.Groups.FirstOrDefault(g => g.Id == id);
                            if (isTrue)
                            {
                                course.Groups.Remove(existedGroup);
                                count -= 1;
                                Console.WriteLine("Qrup ugurla silindi");
                                goto menu;
                            }
                            break;
                        case Operations.AddStudent:
                            Console.WriteLine("Studenti Elave etmek istediyiniz grupun ID-ni daxil edin ");
                            input = Console.ReadLine();
                            isTrue = int.TryParse(input, out id);
                            if (isTrue)
                            {
                                existedGroup = course.Groups.FirstOrDefault(g => g.Id == id);
                                if (existedGroup is not null)
                                {
                                    if (existedGroup.Students.Count < existedGroup.Limit)
                                    {
                                    StudentName:
                                        Console.WriteLine("Student adini daxil edin");
                                        var studentName = Console.ReadLine();
                                        if (studentName.IsValidStudentName())
                                        {
                                        StudentSurname:
                                            Console.WriteLine("Studentin soyadini daxil edin");
                                            var studentSurname = Console.ReadLine();

                                            if (studentSurname.IsValidStudentSurname())
                                            {
                                            StudentBirthDate:
                                                Console.WriteLine("Studentin tevelludunu daxil edin");
                                                input = Console.ReadLine();
                                                DateTime birthDate;
                                                isTrue = DateTime.TryParseExact(input, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate);
                                                if (isTrue)
                                                {
                                                    var student = new Student(studentName, studentSurname, birthDate);
                                                    existedGroup.Students.Add(student);
                                                    Console.WriteLine("Student added successfully!");
                                                    goto menu;
                                                }
                                                else
                                                {
                                                    Console.WriteLine(ErrorMessages.InvalidFormat.Replace("{Input}", "Tarix"));
                                                    goto StudentBirthDate;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine(ErrorMessages.InvalidFormat.Replace("{Input}", "Soyad"));
                                                goto StudentSurname;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine(ErrorMessages.InvalidFormat.Replace("{Input}", "Ad"));
                                            goto StudentName;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Bu qrupda artiq bes qeder student var");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(ErrorMessages.GroupNotFound);
                                }
                            }
                            else
                            {
                                Console.WriteLine(ErrorMessages.InvalidFormat.Replace("{Input}", "ID"));
                            }
                            break;

                        case Operations.GetStudentsByGroup:
                            Console.WriteLine("Studentlerini gormek istediyiniz grupun Id-si");
                            input = Console.ReadLine();
                            isTrue = int.TryParse(input, out id);

                            if (isTrue)
                            {
                                existedGroup = course.Groups.FirstOrDefault(g => g.Id == id);
                                if (existedGroup is not null)
                                {
                                    foreach(var student in existedGroup.Students)
                                    {
                                        student.GetDetails();
                                        goto menu;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(ErrorMessages.GroupNotFound);

                                    goto menu;
                                }
                            }
                            else
                            {
                                Console.WriteLine(ErrorMessages.InvalidFormat.Replace("{Input}", "ID"));
                                goto menu;
                            }

                                    break;
                        case Operations.GetAllStudents:
                            foreach(var group in course.Groups)
                            {
                                foreach(var student in group.Students)
                                {
                                    student.GetDetails();
                                    
                                }
                            }

                            break;

                        case Operations.SearchForStudent:
                            Console.WriteLine("Axtarmaq istediyiniz studentin adini daxil edin");
                            string searchName = Console.ReadLine();
                            var foundStudents = course.Groups.SelectMany(g => g.Students)
                                                             .Where(s => s.Name.Contains(searchName, StringComparison.OrdinalIgnoreCase))
                                                             .ToList();
                            if (foundStudents.Any())
                            {
                                foreach (var student in foundStudents)
                                {
                                    student.GetDetails();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Student tapilmadi");
                            }
                            goto menu;
                        case Operations.DeleteStudent:
                            Console.WriteLine("Delete etmek istediyiniz studentin Id-si?");
                            input = Console.ReadLine();
                            isTrue = int.TryParse(input, out id);
                            foreach (var group in course.Groups)
                            {
                                var student = group.Students.FirstOrDefault(s => s.Id == id);
                                if (student != null)
                                {
                                    group.Students.Remove(student);
                                    Console.WriteLine("Student ugurla silindi");
                                    goto menu;
                                }
                            }
                            Console.WriteLine("Student tapilmadi");
                            goto menu;
                        case Operations.UpdateStudent:
                            Console.WriteLine("Update etmek istediyiniz studentin Id-si?");
                            input = Console.ReadLine();
                            isTrue = int.TryParse(input, out id);
                            foreach (var group in course.Groups)
                            {
                                var student = group.Students.FirstOrDefault(s => s.Id == id);
                                if (student != null)
                                {
                                    Console.WriteLine("Studentin yeni adini daxil edin");
                                    string newName = Console.ReadLine();
                                    Console.WriteLine("Studentin yeni soyadini daxil edin");
                                    string newSurname = Console.ReadLine();
                                    Console.WriteLine("Studentin yeni tevelludunu daxil edin");
                                    input = Console.ReadLine();
                                    DateTime newBirthDate;
                                    isTrue = DateTime.TryParseExact(input, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out newBirthDate);
                                    if (isTrue)
                                    {
                                        student.Name = newName;
                                        student.Surname = newSurname;
                                        student.BirthDate = newBirthDate;
                                        Console.WriteLine("Student melumati ugurla yenilendi");
                                        goto menu;
                                    }
                                    else
                                    {
                                        Console.WriteLine(ErrorMessages.InvalidFormat.Replace("{Input}", "Tarix"));
                                    }
                                }
                            }
                            Console.WriteLine("Student tapilmadi");
                            goto menu;
                        case Operations.Exit:
                            return;

                    }
                }


                break;
            }
            Console.ReadLine();

        }
    }
}
