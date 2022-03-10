using System;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using OrchestraLib;

namespace Client
{
    public class Client
    {
        private TcpClient _client;
        private string _client_type;

        public Client(string client_type)
        {
            _client_type = client_type;
        }

        public void Close()
        {
            _client.Close();
        }
        public void Request(string request)
        {
            try
            {
                _client = new TcpClient("127.0.0.1", 11000);
                Send(_client, request);
            } catch (SocketException se)
            {
                Console.WriteLine("Error connecting to Server");
                throw se;
            }

        }
        public void Recieve()
        {
            byte[] data = new byte[256];
            NetworkStream networkStream = _client.GetStream();
            networkStream.ReadTimeout = 1000;
            if (_client_type.Equals("QUOTE"))
            {
                try
                {
                    // Read the first batch of the TcpServer response bytes.
                    Int32 bytes = networkStream.Read(data, 0, data.Length);
                    string responseData = System.Text.Encoding.UTF8.GetString(data, 0, bytes);
                    Console.WriteLine("Received: {0}", responseData);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception in recieving: ", e.ToString());
                }
            }
            else if(_client_type.Equals("ORCHESTRA"))
            {
                try
                {
                    // Read the first batch of the TcpServer response bytes.
                    BinaryFormatter bf = new BinaryFormatter();
                    Orchestra orchestra = (Orchestra)bf.Deserialize(networkStream);
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
                    Console.WriteLine("Exception in recieving: ", e.ToString());
                }
            } else {
                    Console.WriteLine("Exception in recieving");
            }
        }

        public void Send(TcpClient _client, string request)
        {
            request += "<END>";
            try
            {
                Byte[] data = System.Text.Encoding.UTF8.GetBytes(request);
                NetworkStream networkStream = _client.GetStream();
                networkStream.Write(data, 0, data.Length);
                networkStream.Flush();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in send: ", e.ToString());
            }
        }

    }
}
