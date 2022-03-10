using System;

namespace OrchestraServer
{
    class Program
    {
        static void ServerMenu()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Orchestra Server Menu");
            Console.WriteLine("===========");
            Console.WriteLine("1. Start Orchestra Server");
            Console.WriteLine("E. Exit");
            Console.Write("\nEnter your choice : ");
            char mm_selcetion = Console.ReadLine()[0];
            switch (mm_selcetion)
            {
                case '1':
                    OrchestraServer orchestraTCPServer = new OrchestraServer();
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
