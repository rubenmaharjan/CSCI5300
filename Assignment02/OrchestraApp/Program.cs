using System;
using OrchestraLib;


namespace OrchestraListConsole
{
    class Program
    {
        static void MainMenu()
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("===========");
            Console.WriteLine("1. Show Orchestras");
            Console.WriteLine("2. View Orchestras");
            Console.WriteLine("E. Exit");
            Console.Write("Make a selection : ");
            char mm_selcetion = Console.ReadLine()[0];
            switch (mm_selcetion) 
            {
                case '1':
                    ShowOrchestras();
                    MainMenu();
                    break;
                case '2':
                    Console.Write("Enter the id : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    ViewOrchestras(id);
                    MainMenu();
                    break;
                case 'E':
                case 'e':
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please reenter");
                    MainMenu();
                    break;

            }
            return;
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