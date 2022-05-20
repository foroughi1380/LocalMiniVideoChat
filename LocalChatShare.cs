using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using Newtonsoft.Json;


namespace LVC
{
    public class LocalChatShare
    {
        public class Command
        {
            public string type { get; set; }
            public string[] data { get; set; }
        }

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

            public Command convertJsonToCommand(string json) {
                var ret = new Command();


                return ret;
            }
        }

        public class Server : Connectionable {
            private ArrayList users = new ArrayList();

            private TcpListener listener;


            #region listener
            private Func<int , string, string> connectedListener;
            private Func<int , string> disconnectedListener;
            #endregion

            public override void listen()
            {

                this.listener = new TcpListener(this._port);

                this.listener.Start();

                
                while (true) {
                    try
                    {
                        TcpClient clinet = this.listener.AcceptTcpClient();
                        StreamReader reader = new StreamReader(clinet.GetStream());
                        // TODO : fix hacker not send data
                        string login = reader.ReadLine();
                        Command rcm = JsonConvert.DeserializeObject<Command>(login);

                        this.Login(rcm, clinet);
                    }
                    catch (Exception e) { MessageBox.Show(e.Message); continue;  }
                    
                }

            }

            public override void notListen()
            {
                if (this.listener != null) {
                    try {
                        this.listener.Stop();
                    } catch (Exception e) { }

                }
            }



            private void Login(Command rcm , TcpClient client) {
                switch (rcm.type) {
                    case "guest":
                        string name = rcm.data[0];


                        User user = new User(client, name);
                        user.onMessage(this.messageResive);
                        user.onExit((id) =>
                        {

                            foreach (User u in this.users) {
                                if (u.id == id) {
                                    this.users.Remove(u);
                                    break;
                                }
                            }
                            this.disconnectedListener(id);
                            return null;
                        });

                        this.users.Add(user);
                        user.id = user.GetHashCode();

                        if(this.connectedListener != null)
                            this.connectedListener(user.id, user.name);

                        break;
                }
            }


            private string messageResive(string name, string message) {
                
                return null;
            }

            public void onConnected(Func<int, string, string> listener) {
                this.connectedListener = listener;
            }

            public void onDisconnected(Func<int, string> listener) {
                this.disconnectedListener = listener;
            }
        }


        public class Client : Connectionable
        {
            private TcpClient client;
            public override void listen()
            {
                this.client = new TcpClient("127.0.0.1" , this._port);

                try
                {
                    Command cmd = new Command();
                    cmd.type = "guest";
                    cmd.data = new string[] { "javad mavad" };

                    var output = new StreamWriter(client.GetStream());
                    output.WriteLine(JsonConvert.SerializeObject(cmd));
                    output.Flush();
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            public override void notListen()
            {
                //throw new NotImplementedException();
            }

            public void exit() {
                Command cmd = new Command();
                cmd.type = "exit";

                var output = new StreamWriter(this.client.GetStream());
                output.WriteLine(JsonConvert.SerializeObject(cmd));
                output.Flush();

                this.client.Close();
                this.Stop();
            }
        }


        public class User {
            #region connection variables 
            private TcpClient client;
            private StreamReader input;
            private StreamWriter output;
            #endregion


            #region personal variable
            public string name;
            public int id;
            #endregion

            #region listeners
            private Func<string, string, string> messageListener;
            private Func<int,string> exitListener;
            #endregion


            #region threads variable
            Thread listenThread;
            #endregion

            public User(TcpClient client, string name) {
                this.client = client;
                this.name = name;
                this.input = new StreamReader(client.GetStream());
                this.output = new StreamWriter(client.GetStream());

                this.listenThread = new Thread(this.listen);
                this.listenThread.Start();
                
            }

            private void listen() {
                while (true) {
                    string requestjson = this.input.ReadLine();


                    try
                    {
                        Command cmd = JsonConvert.DeserializeObject<Command>(requestjson);
                        switch (cmd.type) {
                            case "msg":
                                this.messageListener(this.name , cmd.data[0]);
                                break;
                            case "exit":
                                this.exitListener(this.id);
                                this.listenThread.Abort();
                                break;
                        }
                    }
                    catch (Exception e) { continue; }
                }
            }


            public void onMessage(Func<string, string, string> listen){
                this.messageListener = listen;
            }
            
            public void onExit(Func<int,string> listen){
                this.exitListener = listen;
            }

            
        }

    }
}
