using System;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using OrchestraLib;

namespace ClientApp
{
    public class OrchestraClient: TCPClient
    {
        public OrchestraClient()
        {
        }

        public OrchestraClient(string hostName, int port=11001)
            :base(hostName, port)
        {
        }

        public override void Recieve()
        {
            try
            {
                byte[] data = new byte[256];
                NetworkStream networkStream = _client.GetStream();

                // Read the first batch of the TcpServer response bytes.

                BinaryFormatter bf = new BinaryFormatter();
                Orchestra orchestra =  (Orchestra)bf.Deserialize(networkStream);
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
            } catch (Exception e)
            {
                Console.WriteLine("Exception in recieving: ", e.ToString());
            }
        }
    }
}
