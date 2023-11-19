using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace currentParser.Server
{

    public class Server
    {
        public const int port = 10000;
        public IPAddress ipAddress = IPAddress.Any;
        public const int sleepTimer = 200;

        public Server() { 
        
            TcpListener tcpListener = new TcpListener(ipAddress, port);
            Debug.WriteLine("Listen on port: " + port.ToString());
            try
            {
                tcpListener.Start();
                while (!tcpListener.Pending())
                {
                    Thread.Sleep(sleepTimer);
                }

                Socket socket = tcpListener.AcceptSocket();

            }
            catch (Exception err)
            {
                throw new Exception("Fehler beim Verbindungserkennung", err);
            }      
        }



    }

}