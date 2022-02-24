using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using OrchestraLib;
using System.Runtime.Serialization.Formatters.Binary;

namespace ServerApp
{
    public class OrchestraServer: TCPServer
    {
        public OrchestraServer()
            :this(11001)
        {
        }

        public OrchestraServer(int port)
            :base(port)
        {
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
                if (data.Contains("GET_ORCHESTRA"))
                {
                    int id = (int)Convert.ToInt64(data.Replace("GET_ORCHESTRA", ""));
                    IOrchestraRepository orchestra_repo = new SqlOrchestraRepository();
                    Orchestra orchestra = orchestra_repo.Read(id);
                    BinaryFormatter bf = new BinaryFormatter();
                    if (orchestra != null)
                    {
                        bf.Serialize(stream, orchestra);
                    }
                    else {
                        bf.Serialize(stream, new Orchestra());
                    }
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
