using System;

namespace BrokerServer
{
    class Program
    {
        static void ServerMenu()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Quote Server Menu");
            Console.WriteLine("===========");
            Console.WriteLine("1. Start Broker Server");
            Console.WriteLine("E. Exit");
            Console.Write("\nEnter your choice : ");
            char mm_selcetion = Console.ReadLine()[0];
            switch (mm_selcetion)
            {
                case '1':
                    BrokerServer brokerServer = new BrokerServer();
                    brokerServer.StartListening();
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
