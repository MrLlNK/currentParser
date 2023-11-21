using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using static currentParserServer.CurrentParser;

namespace currentParserServer
{
    public class Server
    {
        public const int port = 10000;
        public const int sleepTimer = 200;

        public void startServer()
        {
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHost.AddressList[0];
            IPEndPoint endPoint = new IPEndPoint(ipAddress, port);

            Socket socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try
            {

                socket.Bind(endPoint);
                socket.Listen(10);
                while (true)
                {
                    Console.WriteLine("Waiting connection ...");
                    Socket clientSocket = socket.Accept();

                    byte[] buffer = new byte[1024];
                    string data = null;

                    while (true)
                    {

                        int numByte = clientSocket.Receive(buffer);

                        data += Encoding.ASCII.GetString(buffer, 0, numByte);
                        
                        Thread.Sleep(sleepTimer);
                        int posOfIndex = data.IndexOf("<CURRENT>");
                        if (posOfIndex >= 0)
                        {
                            data = data.Remove(posOfIndex);
                            Console.WriteLine("Text received -> {0} ", data);
                            CurrentParser currentParser = new CurrentParser();

                            string currentInText = currentParser.calcStringValueFromValue(data);
                            Console.WriteLine("Write --> " + currentInText);
                            byte[] message = Encoding.ASCII.GetBytes(currentInText);

                            clientSocket.Send(message);

                            break;
                        }
                    }

                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();

                }
            }
            catch (Exception err)
            {
                throw new Exception(err.ToString());
            }

        }

    }
}
