using System;

namespace ServerApp
{
    class Program
    {
        static void ServerMenu()
        {
            string[] menu_items = new string[2] { "Start Quote Server", "Start Orchestra Server" };
            MenuClass.ShowMenu("Server", menu_items);
            Console.Write("\nEnter your choice : ");
            char mm_selcetion = Console.ReadLine()[0];
            switch (mm_selcetion)
            {
                case '1':
                    TCPServer quoteTCPServer = new QuoteTCPServer();
                    quoteTCPServer.StartListening();
                    break;
                case '2':
                    TCPServer orchestraTCPServer = new OrchestraServer();
                    orchestraTCPServer.StartListening();
                    break;
                case 'E':
                case 'e':
                    Console.Write("\nPress any key to continue...");
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please reenter");
                    ServerMenu();
                    break;
            }

        }

        static void Main(string[] args)
        {
            ServerMenu();
        }
    }
}
