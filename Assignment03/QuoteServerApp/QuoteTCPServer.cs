using System;
using System.Net;
using System.Net.Sockets;

namespace QuoteServerApp
{
    public class QuoteTCPServer
    {
        private readonly int _port;
        private TcpListener _server = null;

        public QuoteTCPServer()
            : this(11000)
        {
        }

        public QuoteTCPServer(int port)
        {
            _port = port;
        }

        public void StartListening()
        {
            IPAddress localAddr = Dns.GetHostAddresses(Dns.GetHostName())[0];
            _server = new TcpListener(localAddr, _port);

            _server.Start();

            while (true)
            {
                Console.WriteLine("Waiting for a connection... ");
                TcpClient client = _server.AcceptTcpClient();
                Console.WriteLine("Connected!");
            }
        }
        public void StopListening()
        {
            _server.Stop();
        }
    }
}
