using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.Echo();

        }
        public class Server
        {
            public const int PORT = 5555;
            TcpListener listener = null;
            public void Echo()
            {                
                TcpClient client = null;
                try
                {
                    //IPAddress address = Dns.GetHostEntry("").AddressList[0];
                    //listener = new TcpListener(address, PORT);
                    listener = new TcpListener(IPAddress.Any, PORT);
                    listener.Start();
                    Console.WriteLine("server 1~~ready");
                    while (true)
                    {
                        Console.WriteLine("server 2~~ready");
                        client = listener.AcceptTcpClient();
                        Console.WriteLine("server 3~~Accept");
                        Thread t = new Thread(new ParameterizedThreadStart(ProcessClient));
                        t.Start(client);
                    }
                }
                catch (Exception ee) { System.Console.WriteLine(ee.Message); }
            }
            public void ProcessClient(object o)
            {
                TcpClient client = o as TcpClient;
                NetworkStream ns = null;
                StreamReader sr = null;
                StreamWriter sw = null;
                string clientName = "";
                try
                {
                    ns = client.GetStream();
                    Socket socket = client.Client;
                    clientName = socket.RemoteEndPoint.ToString();
                    Console.WriteLine(clientName + "접속");
                    sr = new StreamReader(ns, Encoding.Default);
                    sw = new StreamWriter(ns, Encoding.Default);
                    while (true)
                    {
                        string message = sr.ReadLine();
                        sw.WriteLine("[server: {0}]", message);
                        sw.Flush();
                        string dstes = DateTime.Now.ToString()+": ";
                        Console.Write(dstes);
                        Console.WriteLine(message);
                    }
                }
                catch (Exception) { Console.WriteLine(clientName + "접속해제"); }
                finally
                {
                    sw.Close();
                    sr.Close();
                    client.Close();
                }
            }
        }
    }
}