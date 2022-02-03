using System;
using System.Net;
using QuoteServerApp;

namespace QuoteClientApp
{
    class Program
    {
        static void ClientMenu()
        {
            string[] menu_items = new string[1] { "Get Quote" };
            MenuClass.ShowMenu("Client", menu_items);
            QuoteTCPClient quoteTCPClient = new QuoteTCPClient("127.0.0.1");
            char mm_selcetion = Console.ReadLine()[0];
            switch (mm_selcetion)
            {
                case '1':
                    ClientMenu();
                    break;
                case 'E':
                case 'e':
                    quoteTCPClient.Close();
                    Console.Write("\nPress any key to continue...");
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please reenter");
                    ClientMenu();
                    break;
            }
        }

        static void Main(string[] args)
        {
            ClientMenu();
        }
    }
}
