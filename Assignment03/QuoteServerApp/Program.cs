using System;

namespace QuoteServerApp
{
    class Program
    {
        static void ServerMenu()
        {
            string[] menu_items = new string[1] { "Start" };
            MenuClass.ShowMenu("Server", menu_items);
            char mm_selcetion = Console.ReadLine()[0];
            QuoteTCPServer quoteTCPServer = new QuoteTCPServer();
            switch (mm_selcetion)
            {
                case '1':
                    quoteTCPServer.StartListening();
                    break;
                case 'E':
                case 'e':
                    quoteTCPServer.StartListening();
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
