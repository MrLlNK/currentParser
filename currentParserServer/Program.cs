using static currentParserServer.Server;

namespace currentParserServer
{
    internal static class Program
    {
        static void Main()
        {
            Server server = new Server();
            server.startServer();
        }

    }
}