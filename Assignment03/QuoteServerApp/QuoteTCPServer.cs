using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace ServerApp
{
    public class QuoteTCPServer: TCPServer
    {
        private readonly List<String> quotes;

        public QuoteTCPServer()
            : this(11000) 
        {
        }

        public QuoteTCPServer(int port)
            :base(port)
        {
            quotes = new List<string> {
                "Strive not to be a success, but rather to be of value. -Albert Einstein",
                "Life is what happens to you while you’re busy making other plans. -John Lennon",
                "The mind is everything. What you think, you become. -Buddha",
                "Your time is limited, so don’t waste it living someone else’s life. -Steve Jobs",
                "The most difficult thing is the decision to act, the rest is merely tenacity. -Amelia Earhart",
                "The best and most beautiful things in the world cannot be seen or even touched - they must be felt with the heart. -Helen Keller",
                "Try to be a rainbow in someone's cloud. -Maya Angelou"
            };
        }

        protected override void ProcessClient(TcpClient client)
        {
            Byte[] bytes = new Byte[256];
            NetworkStream stream = client.GetStream();

            int i;
            while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                string data = System.Text.Encoding.UTF8.GetString(bytes, 0, i);
                Console.WriteLine("Recieved: {0}", data);
                data =  data.Replace("<END>", "");
                Console.WriteLine("From Client: {0}", data);
                if (String.Equals(data, "GET_QUOTE"))
                {
                    Random random = new Random();
                    int index = random.Next(0, this.quotes.Count - 1);
                    Byte[] response = System.Text.Encoding.UTF8.GetBytes(this.quotes[index]);
                    stream.Write(response, 0, response.Length);
                    stream.Flush();
                }
                else if (String.Equals(data, "EXIT"))
                {
                    break;
                }
            }
            Console.WriteLine("A Client Disconnected!");
        }

    }
}
