
using System.Diagnostics;
namespace MyTASK3
{
    public static class Program
    {

        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            showMenu();

        }

        public static void showMenu()
        {
            Hospital NergizKlinika = new Hospital();
            while (true) {
                Console.WriteLine("--Hospitala xoş gəlmisiniz--");
                Console.WriteLine("1.Həkim əlavə edin ");
                Console.WriteLine("2.Həkimlərin siyasını görün ");
                Console.WriteLine("3.Görüş təyin edin ");
                Console.WriteLine("4.Həkimlərin görüş siyahısına baxın ");
                Console.WriteLine("0.Çıxış edin ");

                Console.WriteLine("Zəhmət olmasa etmək istədiyiniz əməliyyatı menyudan seçin");
                string choice = Console.ReadLine();
                int answer;
                bool isSuceeded = int.TryParse(choice, out answer);
                if (isSuceeded)
                {

                    switch (answer)
                    {
                        case 0:
                            Console.WriteLine("Çıxış edildi");
                            return;
                        case 1:
                            Console.WriteLine("Hekimin adini qeyd edin");
                            string DoctorName = Console.ReadLine();
                            Console.WriteLine("Hekimin soyadini qeyd edin");
                            string DoctorSurname = Console.ReadLine();
                            Console.WriteLine("Hekimin yaşını qeyd edin");
                            int DoctorAge = Convert.ToInt32(Console.ReadLine());
                            Doctor newDoctor = new Doctor(DoctorName, DoctorSurname, DoctorAge);
                            NergizKlinika.AddDoctor(newDoctor);
                            break;
                        case 2:
                            NergizKlinika.ViewAllDoctors();
                            break;
                        case 3:
                         
                            NergizKlinika.ScheduleAppointment();
                                break;
                            case 4:
                            NergizKlinika.SeeAllAppointmentsOfDoctor();
                            break;
                            default:
                            return;
                      


                    }

                }

            }
        }
    }
}