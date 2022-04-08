using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LVC
{
    public class LocalChatShare
    {
        private int _port = 8585;
        public ushort port
        {
            get {
                return ushort.Parse(this._port.ToString());
            }
            set{
                this._port = value; 
            }
        }


        public  void listen()
        {
            // Establish the local endpoin            // for the socket. Dns.GetHostName
            // returns the name of the host
            // running the application.

            IPAddress ipAddr = this.GetLocalIPAddress();
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, this._port);
            

            Socket listener = new Socket(ipAddr.AddressFamily,
                         SocketType.Stream, ProtocolType.Tcp);

            try
            {

                listener.Bind(localEndPoint);

                listener.Listen(90);

                while (true)
                {

                    MessageBox.Show("listen to port " + this._port);

                    // Suspend while waiting for
                    // incoming connection Using
                    // Accept() method the server
                    // will accept connection of client
                    Socket clientSocket = listener.Accept();

                    // Data buffer
                    byte[] bytes = new Byte[1024];
                    string data = null;

                    while (true)
                    {

                        int numByte = clientSocket.Receive(bytes);

                        data += Encoding.ASCII.GetString(bytes,
                                                   0, numByte);

                        if (data.IndexOf("<EOF>") > -1)
                            break;
                    }

                    Console.WriteLine("Text received -> {0} ", data);
                    byte[] message = Encoding.ASCII.GetBytes("Test Server");

                    // Send a message to Client
                    // using Send() method
                    clientSocket.Send(message);

                    // Close client Socket using the
                    // Close() method. After closing,
                    // we can use the closed Socket
                    // for a new Client Connection
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public IPAddress GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip;
                }
            }
            throw new Exception("Can not find any ip address!!!!");
        }



        public Thread serverStart() {

            Thread server = new Thread(() => { listen(); });
            server.Name = "javad thread";
            server.Start();
            return server;
        }
    }
}
