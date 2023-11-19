using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace currentParserClient
{
    class Client
    {
        public Socket socket = null;

        public Client(String Addresse = "127.0.0.1", int port = 10000) {

            try
            {
                IPHostEntry ipHost = Dns.GetHostByName(Addresse);
                IPAddress ipAdress = ipHost.AddressList[0];
                IPEndPoint endPoint = new IPEndPoint(ipAdress, port);

                socket = new Socket(ipAdress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    socket.Connect(endPoint);
                    Debug.WriteLine("Socket connected to {0}", socket.RemoteEndPoint.ToString());
                }

                catch (ArgumentNullException ane)
                {

                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }

                catch (SocketException se)
                {

                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }
        }

        public void sendMessage(String messageText)
        {
            byte[] messageSent = Encoding.ASCII.GetBytes(messageText);
            int byteSent = socket.Send(messageSent);
        }

        public String receiveMessage()
        {
            byte[] messageReceived = new byte[1024];
            int byteRecv = socket.Receive(messageReceived);

            return Encoding.ASCII.GetString(messageReceived, 0, byteRecv);
        }

    }
}
