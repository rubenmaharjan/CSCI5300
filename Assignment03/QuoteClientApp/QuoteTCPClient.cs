using System;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using OrchestraLib;

namespace ClientApp
{
    public class QuoteTCPClient: TCPClient
    {

        public QuoteTCPClient()
        {
        }

        public QuoteTCPClient(string hostName, int port=11000)
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
                Int32 bytes = networkStream.Read(data, 0, data.Length);
                string responseData = System.Text.Encoding.UTF8.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);
            } catch (Exception e)
            {
                Console.WriteLine("Exception in recieving: ", e.ToString());
            }

        }
    }
}
