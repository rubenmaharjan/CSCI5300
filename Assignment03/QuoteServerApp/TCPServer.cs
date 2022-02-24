using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ServerApp
{
    public abstract class TCPServer
    {
        protected readonly int _port;
        protected TcpListener _server = null;

        protected TCPServer()
            : this(11000)
        {
        }

        protected TCPServer(int port)
        {
            _port = port;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            _server = new TcpListener(localAddr, _port);
        }

        public void StartListening()
        {
            _server.Start();
            while (true)
            {
                Console.WriteLine("Waiting for a connection... ");
                TcpClient client = _server.AcceptTcpClient();
                Console.WriteLine("Connected!");
                Task.Run(() => ProcessClient(client));
            }
        }
        protected abstract void ProcessClient(TcpClient client);

        public void StopListening()
        {
            _server.Stop();
        }
    }
}
