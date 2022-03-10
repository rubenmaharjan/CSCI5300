using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BrokerServer
{
    public class BrokerServer
    {
        private readonly int _port;
        private TcpListener _server = null;
        private TcpClient _client;


        public BrokerServer()
            : this(11000)
        {
        }

        public BrokerServer(int port)
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
                try
                {
                    Task.Run(() =>
                        ProcessClient(client)
                    ).ContinueWith((t) =>
                    { if (t.IsFaulted) {
                            Console.WriteLine("Try Again!");
                        }});
                } catch (Exception e)
                {
                    Console.WriteLine("Exception in Broker Processing! ", e.ToString());
                }
            }
        }

        public void StopListening()
        {
            _server.Stop();
        }

        private void ProcessClient(TcpClient client)
        {
            Byte[] bytes = new Byte[256];
            NetworkStream stream = client.GetStream();

            int i;
            while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                string data = System.Text.Encoding.UTF8.GetString(bytes, 0, i);
                Console.WriteLine("Recieved: {0}", data);
                data = data.Replace("<END>", "");
                Console.WriteLine("From Client: {0}", data);
                try
                {
                    if (String.Equals(data, "<GET_QUOTE>"))
                    {
                        _client = new TcpClient("127.0.0.1", 11002);
                        Send(_client, data);
                        NetworkStream networkStream = _client.GetStream();
                        networkStream.CopyToAsync(stream);
                    }
                    else if (data.Contains("<GET_ORCHESTRA>"))
                    {
                        _client = new TcpClient("127.0.0.1", 11001);
                        Send(_client, data);
                        NetworkStream networkStream = _client.GetStream();
                        networkStream.CopyToAsync(stream);
                    }
                    else if (String.Equals(data, "EXIT"))
                    {
                        _client.Close();
                        break;
                    }
                }
                catch (SocketException se)
                {
                    Console.WriteLine("Error connecting to Server! ", se.ToString());
                    throw se;
                }
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
