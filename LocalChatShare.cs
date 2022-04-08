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
        public abstract class Connectionable {
            private Thread thread;
            public IPAddress ip;
            protected int _port = 8585;

            public ushort port
            {
                get
                {
                    return ushort.Parse(this._port.ToString());
                }
                set
                {
                    this._port = value;
                }
            }

            public abstract void listen();
            public abstract void notListen();

            public Thread Start()
            {
                if (this.thread == null)
                {
                    this.ip = GetLocalIPAddress();
                    this.thread = new Thread(() => { listen(); });
                    this.thread.Start();
                    return this.thread;
                }
                return null;
            }

            public void Stop()
            {
                this.notListen();
                this.thread.Abort();
                this.thread = null;
            }


            public static IPAddress GetLocalIPAddress()
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
        }

        public class Sever : Connectionable {
            private Socket listener;
            public override void listen()
            {
                
                IPEndPoint localEndPoint = new IPEndPoint(this.ip, this._port);


                listener = new Socket(this.ip.AddressFamily,
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

            public override void notListen()
            {
                if (this.listener!=null) {
                    try {
                        this.listener.Close();
                    }catch(Exception e) { }
                    
                }
            }
        }
        public class Client : Connectionable
        {
            public override void listen()
            {

                IPEndPoint localEndPoint = new IPEndPoint(this.ip, this._port);


                Socket listener = new Socket(this.ip.AddressFamily,
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

            public override void notListen()
            {
                throw new NotImplementedException();
            }
        }

    }
}
