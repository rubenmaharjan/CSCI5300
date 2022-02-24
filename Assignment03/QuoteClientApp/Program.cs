using System;
using ServerApp;

namespace ClientApp
{
    class Program
    {
        static void QuoteMenu()
        {
            string[] quote_menu_items = new string[1] { "Get Quote" };
            MenuClass.ShowMenu("Quote Client", quote_menu_items);
            Console.Write("\nEnter your choice : ");
            char quote_mm_selcetion = Console.ReadLine()[0];
            QuoteTCPClient quoteTCPClient = new QuoteTCPClient("127.0.0.1");
            switch (quote_mm_selcetion)
            {
                case '1':
                    quoteTCPClient.Send("GET_QUOTE");
                    quoteTCPClient.Recieve();
                    QuoteMenu();
                    break;
                case 'E':
                case 'e':
                    quoteTCPClient.Send("EXIT");
                    ClientMenu();
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please reenter");
                    QuoteMenu();
                    break;
            }
        }
        static void OrchestraMenu()
        {
            string[] orchestra_menu_items = new string[1] { "Get Orchestra" };
            MenuClass.ShowMenu("Orchestra Client", orchestra_menu_items);
            Console.Write("\nEnter your choice : ");
            char orchestra_mm_selcetion = Console.ReadLine()[0];
            TCPClient orchestraTCPClient = new OrchestraClient("127.0.0.1");
            switch (orchestra_mm_selcetion)
            {
                case '1':
                    Console.Write("\nPlease enter the orchestra id: ");
                    String id = Console.ReadLine();
                    orchestraTCPClient.Send("GET_ORCHESTRA"+ id);
                    orchestraTCPClient.Recieve();
                    OrchestraMenu();
                    break;
                case 'E':
                case 'e':
                    orchestraTCPClient.Send("EXIT");
                    ClientMenu();
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please reenter");
                    OrchestraMenu();
                    break;
            }
        }
        static void ClientMenu()
        {
            string[] menu_items = new string[2] { "Use Quote", "Use Orchestra" };
            MenuClass.ShowMenu("Client", menu_items);
            Console.Write("\nEnter your choice : ");
            char mm_selcetion = Console.ReadLine()[0];
            switch (mm_selcetion)
            {
                case '1':
                    QuoteMenu();
                    break;
                case '2':
                    OrchestraMenu();
                    break;
                case 'E':
                case 'e':
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
