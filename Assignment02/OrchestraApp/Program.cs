using System;
using OrchestraLib;


namespace OrchestraListConsole
{
    class Program
    {
        static void MainMenu()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Main Menu");
            Console.WriteLine("===========");
            Console.WriteLine("1. Show Orchestras");
            Console.WriteLine("2. View Orchestras");
            Console.WriteLine("3. Create Orchestras");
            Console.WriteLine("4. Update Orchestras");
            Console.WriteLine("5. Delete Orchestras");
            Console.WriteLine("E. Exit");
            Console.Write("\nMake a selection : ");
            char mm_selcetion = Console.ReadLine()[0];
            switch (mm_selcetion) 
            {
                case '1':
                    ShowOrchestras();
                    MainMenu();
                    break;
                case '2':
                    Console.Write("\nEnter the id to View : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    ViewOrchestras(id);
                    MainMenu();
                    break;
                case '3':
                    CreateOrchestra();
                    MainMenu();
                    break;
                case '4':
                    Console.Write("\nEnter the id  to Update: ");
                    int update_id = Convert.ToInt32(Console.ReadLine());
                    UpdateOrchestra(update_id);
                    MainMenu();
                    break;
                case '5':
                    Console.Write("\nEnter the id  to Delete: ");
                    int delete_id = Convert.ToInt32(Console.ReadLine());
                    DeleteOrchestra(delete_id);
                    MainMenu();
                    break;
                case 'E':
                case 'e':
                    Console.Write("\nThank You!");
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please reenter");
                    MainMenu();
                    break;

            }
            return;
        }

        static void DeleteOrchestra(int id)
        {
            IOrchestraRepository orchestra_repo = new SqlOrchestraRepository();
            orchestra_repo.Delete(id);
        }

        static string ReadOrNot(Orchestra orchestra, string property)
        {
            string read_line = Console.ReadLine();
            return !string.IsNullOrEmpty(read_line) ? read_line :
                Convert.ToString(orchestra.GetType().GetProperty(property).GetValue(orchestra, null));

        }

        static void UpdateOrchestra(int id)
        {
            IOrchestraRepository orchestra_repo = new SqlOrchestraRepository();
            Orchestra orchestra = orchestra_repo.Read(id);
            if (orchestra == null)
            {
                Console.WriteLine("Id Not Found.");
            }
            else
            {
                Console.WriteLine("\n");
                Console.Write("Enter the Name           : ");
                orchestra.Name = ReadOrNot(orchestra, "Name");
                Console.Write("Enter the Address Line 1 : ");
                orchestra.AddressLine1 = ReadOrNot(orchestra, "AddressLine1");
                Console.Write("Enter the Address Line 2 : ");
                orchestra.AddressLine2 = ReadOrNot(orchestra, "AddressLine2");
                Console.Write("Enter the City           : ");
                orchestra.City = ReadOrNot(orchestra, "City");
                Console.Write("Enter the State          : ");
                orchestra.State = ReadOrNot(orchestra, "State");
                Console.Write("Enter the Zip Code       : ");
                orchestra.ZipCode = ReadOrNot(orchestra, "ZipCode");
                Console.Write("Enter the URL            : ");
                orchestra.WebsiteURL = ReadOrNot(orchestra, "WebsiteURL");
                orchestra_repo.Update(orchestra);
            }
        }

        static void CreateOrchestra()
        {
            Orchestra orchestra = new Orchestra();
            Console.WriteLine("\n");
            Console.Write("Enter the Name           : ");
            orchestra.Name = Console.ReadLine();
            Console.Write("Enter the Address Line 1 : ");
            orchestra.AddressLine1 = Console.ReadLine();
            Console.Write("Enter the Address Line 2 : ");
            orchestra.AddressLine2 = Console.ReadLine();
            Console.Write("Enter the City           : ");
            orchestra.City = Console.ReadLine();
            Console.Write("Enter the State          : ");
            orchestra.State = Console.ReadLine();
            Console.Write("Enter the Zip Code       : ");
            orchestra.ZipCode = Console.ReadLine();
            Console.Write("Enter the URL            : ");
            orchestra.WebsiteURL = Console.ReadLine();

            IOrchestraRepository orchestra_repo = new SqlOrchestraRepository();
            orchestra_repo.Create(orchestra);
        }

        static void ViewOrchestras(int id)
        {
            IOrchestraRepository orchestra_repo = new SqlOrchestraRepository();
            Orchestra orchestra = orchestra_repo.Read(id);
            if (orchestra == null)
            {
                Console.WriteLine("Id Not Found.");
            }
            else
            {
                Console.WriteLine("\n");
                Console.WriteLine("Id            :" + orchestra.Id);
                Console.WriteLine("Name          :" + orchestra.Name);
                Console.WriteLine("Address Line 1:" + orchestra.AddressLine1);
                Console.WriteLine("Address Line 2:" + orchestra.AddressLine2);
                Console.WriteLine("City          :" + orchestra.City);
                Console.WriteLine("State         :" + orchestra.State);
                Console.WriteLine("Zip Code      :" + orchestra.ZipCode);
                Console.WriteLine("URL           :" + orchestra.WebsiteURL);
            }
        }

        static void ShowOrchestras()
        {
            IOrchestraRepository orchestra_repo = new SqlOrchestraRepository();
            var results = orchestra_repo.ReadAll();
            Console.WriteLine("\n");
            Console.WriteLine("\tId  Name");
            Console.WriteLine("----- ---------------------------");
            foreach (Orchestra orchestra in results)
            {
                Console.WriteLine("\t" + orchestra.Id + " " + orchestra.Name);
            };
        }

        static void Main(string[] args)
        {
            MainMenu();
        }
    }
}