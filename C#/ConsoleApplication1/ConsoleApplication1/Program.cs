using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace ConsoleApplication1
{
    public class Program
    {
        public static void Main(String[] args)
        {
            Client client = new Client();
            client.Echo();
        }
        public class Client
        {
            public const int PORT = 5555;
            public const string IP = "localhost";
            public void Echo()
            {
                NetworkStream ns = null;
                StreamReader sr = null;
                StreamWriter sw = null;
                TcpClient client = null;
                try
                {
                    client = new TcpClient(IP, PORT);
                    ns = client.GetStream();
                    sr = new StreamReader(ns, Encoding.Default);
                    sw = new StreamWriter(ns, Encoding.Default);
                    string s = string.Empty;
                    Console.WriteLine("입력하세요");
                    while ((s = Console.ReadLine()) != null)
                    {
                        sw.WriteLine(s);
                        sw.Flush();
                        string message = sr.ReadLine();
                        Console.WriteLine(message);
                    }
                }
                catch (Exception ee) { System.Console.WriteLine(ee.Message); }
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