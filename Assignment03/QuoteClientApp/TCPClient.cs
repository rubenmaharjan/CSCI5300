using System;
using System.Net.Sockets;

namespace ClientApp
{
    public abstract class TCPClient
    {
        protected TcpClient _client;

        public TCPClient()
        {
        }

        public TCPClient(string hostName, int port=11000)
        {
            _client = new TcpClient(hostName, port);
        }

        public void Close()
        {
            try {
                _client.Close();
            } catch (SocketException e)
            {
                Console.WriteLine("Socket Error : ", e.ToString());
            }
        }

        public void Send(string request)
        {
            request += "<END>";
            try {
                Byte[] data = System.Text.Encoding.UTF8.GetBytes(request);
                NetworkStream networkStream = _client.GetStream();
                networkStream.Write(data, 0, data.Length);
                networkStream.Flush();
            } catch (Exception e) {
                Console.WriteLine("Exception in send: ", e.ToString());
            }
        }

        public abstract void Recieve();
    }
}
