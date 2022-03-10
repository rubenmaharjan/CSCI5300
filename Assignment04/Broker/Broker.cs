using System;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using OrchestraLib;

namespace BrokerNS
{
    public class Broker
    {
        private TcpClient _client;
        private string _client_type;

        public Broker()
        {
        }

        public void Request(string request)
        {
            try
            {
                if (request.Contains("<GET_QUOTE>"))
                {
                    _client = new TcpClient("127.0.0.1", 11000);
                    _client_type = "QUOTE";
                    Send(_client, request);
                }
                else if (request.Contains("<GET_ORCHESTRA>"))
                {
                    _client = new TcpClient("127.0.0.1", 11001);
                    _client_type = "ORCHESTRA";
                    Send(_client, request);
                }
            } catch (SocketException se)
            {
                Console.WriteLine("Error connecting to Server");
                throw se;
            }

        }
        public T Recieve<T>()
        {
            byte[] data = new byte[256];
            NetworkStream networkStream = _client.GetStream();
            if (_client_type.Equals("QUOTE"))
            {
                try
                {
                    // Read the first batch of the TcpServer response bytes.
                    Int32 bytes = networkStream.Read(data, 0, data.Length);
                    string responseData = System.Text.Encoding.UTF8.GetString(data, 0, bytes);
                    return (T)Convert.ChangeType(responseData, typeof(T));
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
                    return (T)Convert.ChangeType(orchestra, typeof(T));
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception in recieving: ", e.ToString());
                }
            }
            return (T) Convert.ChangeType(null, typeof(T));
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
