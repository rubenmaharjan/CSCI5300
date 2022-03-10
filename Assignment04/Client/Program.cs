using System;
using BrokerNS;
using OrchestraLib;

namespace Client
{
    class Program
    {
        static void ClientMenu_Old()
        {
            string[] menu_items = new string[2] { "Get Quote", "Get Orchestra" };
            Console.WriteLine("\n");
            Console.WriteLine("Client Menu");
            Console.WriteLine("===========");
            for (int i = 0; i < menu_items.Length; i++)
            {
                Console.WriteLine(@"{0}. {1}", i + 1, menu_items[i]);
            }
            Console.WriteLine("E. Exit");
            Console.Write("\nEnter your choice : ");
            char mm_selcetion = Console.ReadLine()[0];
            Broker broker = new Broker();
            switch (mm_selcetion)
            {
                case '1':
                    try
                    {
                        broker.Request("<GET_QUOTE>");
                        string response = broker.Recieve<string>();
                        Console.WriteLine("Received: {0}", response);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error!  ", e.ToString());
                    }
                    ClientMenu();
                    break;
                case '2':
                    Console.Write("\nEnter ID : ");
                    string id = Console.ReadLine();
                    try
                    {
                        broker.Request("<GET_ORCHESTRA>" + id);
                        Orchestra orchestra = broker.Recieve<Orchestra>();
                        if (orchestra.Id == 0)
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
                    catch (Exception e)
                    {
                        Console.WriteLine("Error!  ", e.ToString());
                    }
                    ClientMenu();
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
        static void ClientMenu()
        {
            string[] menu_items = new string[2] { "Get Quote", "Get Orchestra" };
            Console.WriteLine("\n");
            Console.WriteLine("Client Menu");
            Console.WriteLine("===========");
            for (int i = 0; i < menu_items.Length; i++)
            {
                Console.WriteLine(@"{0}. {1}", i + 1, menu_items[i]);
            }
            Console.WriteLine("E. Exit");
            Console.Write("\nEnter your choice : ");
            char mm_selcetion = Console.ReadLine()[0];
            switch (mm_selcetion)
            {
                case '1':
                    Client quote_client = new Client("QUOTE");
                    try
                    {
                        quote_client.Request("<GET_QUOTE>");
                        quote_client.Recieve();
                        quote_client.Close();
                    } catch (Exception e)
                    {
                        Console.Write("Error!");
                    }
                    ClientMenu();
                    break;
                case '2':
                    Client orchestra_client = new Client("ORCHESTRA");
                    Console.Write("\nEnter ID : ");
                    string id = Console.ReadLine();
                    try
                    {
                        orchestra_client.Request("<GET_ORCHESTRA>" + id);
                        orchestra_client.Recieve();
                        orchestra_client.Close();
                    } catch (Exception e)
                    {
                        Console.Write("Error!");
                    }
                    ClientMenu();
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
