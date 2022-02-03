using System;
using System.Net.Sockets;

namespace QuoteClientApp
{
    public class QuoteTCPClient
    {
        private TcpClient _client;

        public QuoteTCPClient()
        {
        }

        public QuoteTCPClient(string hostName, int port=11000)
        {
            _client = new TcpClient(hostName, port);
        }

        public void Close()
        {
            try {
                _client.Close();
            } catch (SocketException e)
            {
                Console.WriteLine("Socket Erro : ", e.ToString());
            }
        }

        public void Send(string request)
        {
            request += "<END>";
            Byte[] data = System.Text.Encoding.UTF8.GetBytes(request);
            NetworkStream networkStream = _client.GetStream();
            networkStream.Write(data, 0, data.Length);
        }
    }
}
