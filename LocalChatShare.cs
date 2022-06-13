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
using System.Drawing.Imaging;
using System.Drawing;


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
            private bool disconnected = false;

            private TcpListener listener;
            public string name = "host";

            #region listener
            private Func<int , string, string> connectedListener;
            private Func<string , string, string> messageListener;
            private Func<int , string> disconnectedListener;
            private Func<string , bool> userAcceptListener;
            private Func<Image , bool> imageListener;
            #endregion

            private Thread schreenShareThread;
            public override void listen()
            {

                this.listener = new TcpListener(this._port);

                this.listener.Start();

                
                while (! this.disconnected) {
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

                        if (this.userAcceptListener != null && this.userAcceptListener(name))
                        {

                            user.onMessage((n, m) => {
                                if (this.messageListener != null) {
                                    Command cmd = new Command();
                                    cmd.type = "msg";
                                    cmd.data = new string[] { n , m };
                                    this.broadCast(cmd);

                                    this.messageListener(n, m);
                                }
                                return null;
                            });
                            user.onExit((id) =>
                            {

                                foreach (User u in this.users)
                                {
                                    if (u.id == id)
                                    {
                                        try
                                        {
                                            u.Disconnect();
                                        }
                                        catch (Exception e) { }
                                        
                                        this.users.Remove(u);
                                        break;
                                    }
                                }
                                this.disconnectedListener(id);

                                this.broadCastUsers();

                                return null;
                            });



                            this.users.Add(user);
                            user.id = user.GetHashCode();

                            Command acccept = new Command();
                            acccept.type = "accept";
                            user.sendCommand(acccept);

                            if (this.connectedListener != null) {
                                this.connectedListener(user.id, user.name);
                            }
                            this.broadCastUsers();
                        }
                        else {
                            Command reject = new Command();
                            reject.type = "reject";
                            user.sendCommand(reject);
                            user.Disconnect();
                        }

                        break;
                }
            }


            public void onMessageResive(Func<string, string, string> listener) {
                this.messageListener = listener;
            }

            public void onConnected(Func<int, string, string> listener) {
                this.connectedListener = listener;
            }

            public void onDisconnected(Func<int, string> listener) {
                this.disconnectedListener = listener;
            }
            public void onRequestLogin(Func<string, bool> listener) {
                this.userAcceptListener = listener;
            }
            
            public void onImageRevive(Func<Image, bool> listener) {
                this.imageListener = listener;
            }

            public void broadCast(Command cmd) {
                foreach (User u in this.users) {
                    u.sendCommand(cmd);
                }
            }

            public void sendMessage(string message)
            {
                Command cmd = new Command();
                cmd.type = "msg";
                cmd.data = new string[] { this.name , message };
                this.broadCast(cmd);
            }

            public void end() {
                Command cmd = new Command();
                cmd.type = "end";
                this.broadCast(cmd);
                this.disconnected = true;
                //this.Stop();
            }


            public void startShareScreen() {
                this.schreenShareThread = new Thread(() => {
                    while (true) {
                        Thread.Sleep(50);
                        byte[] arr = this.CaptureMyScreen();
                        if (arr != null)
                        {
                            if (this.imageListener != null)
                            {
                                Image img = Image.FromStream(new MemoryStream(arr));
                                this.imageListener(img);
                            }
                        }
                        Command cmd = new Command();
                        cmd.type = "img";
                        cmd.data = new string[] { Convert.ToBase64String(arr) };
                        this.broadCast(cmd);
                    }
                });


                this.schreenShareThread.Start();
            }
            public void stopShareScreen() {
                if (this.schreenShareThread != null) {
                    this.schreenShareThread.Abort();
                    this.schreenShareThread = null;

                    Command cmd = new Command();
                    cmd.type = "noshare";
                    this.broadCast(cmd);
                }
            }


            private byte[] CaptureMyScreen()
            {
                try
                {
                    Bitmap captureBitmap = new Bitmap(1024, 768, PixelFormat.Format32bppArgb);
                    Rectangle captureRectangle = Screen.AllScreens[0].Bounds;
                    Graphics captureGraphics = Graphics.FromImage(captureBitmap);
                    captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);
                    ImageConverter converter = new ImageConverter();
                    return (byte[])converter.ConvertTo(captureBitmap, typeof(byte[]));

                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            public void broadCastUsers()
            {
                Command users = new Command();
                users.type = "userUpdatedddd";
                ArrayList ids = new ArrayList();
                ArrayList names = new ArrayList();


                foreach(User user in this.users){
                    ids.Add(user.id);
                    names.Add(user.name);
                }

                users.data = new string[]
                {
                    JsonConvert.SerializeObject(ids.ToArray()),
                    JsonConvert.SerializeObject(names.ToArray()),
                };

                this.broadCast(users);
            }
        }


        public class Client : Connectionable
        {
            private string name;
            private bool disconnected = false;

            private Queue<Command> commands = new Queue<Command>();
            private Thread writeThread;

            private StreamWriter output;
            private StreamReader input;

            private TcpClient client;

            private Func<string, string, string> messageListener;
            private Func<string> endListener;
            private Func<Image, bool> imageListener;
            private Func<string> noshareListener;

            private Func<string[], string[], string> userUpdated;

            public override void listen()
            {
                while (! this.disconnected)
                {
                    
                    try
                    {
                        string requestjson = this.input.ReadLine();

                        Command cmd = JsonConvert.DeserializeObject<Command>(requestjson);
                        switch (cmd.type)
                        {
                            case "msg":
                                if(this.messageListener != null)
                                    this.messageListener(cmd.data[0], cmd.data[1]);
                                break;
                            case "end":       
                                if (this.endListener != null) {
                                    this.endListener();
                                }
                                this.writeThread.Abort();
                                this.Stop();
                                break;
                            case "img":
                                
                                if (this.imageListener != null) {
                                    Image img = Image.FromStream(new MemoryStream(Convert.FromBase64String(cmd.data[0])));
                                    this.imageListener(img);
                                }
                                break;
                            case "noshare":
                                if (this.noshareListener != null) {
                                    this.noshareListener();
                                }
                                break;

                            case "userUpdatedddd":
                                if (this.userUpdated != null)
                                {
                                    string[] id = JsonConvert.DeserializeObject<string[]>(cmd.data[0]);
                                    string[] name = JsonConvert.DeserializeObject<string[]>(cmd.data[1]);

                                    this.userUpdated(id , name);
                                }
                                break;
                        }
                    }
                    catch (Exception e) { continue; }
                }
            }


            public void connect(string host , int port , string name) {
                this.client = new TcpClient(host, port);
                this._port = port;

                this.input = new StreamReader(this.client.GetStream());
                this.output = new StreamWriter(this.client.GetStream());

                Command cmd = new Command();
                cmd.type = "guest";
                cmd.data = new string[] { name };

                this.output.WriteLine(JsonConvert.SerializeObject(cmd));
                this.output.Flush();


                string responsejson = this.input.ReadLine();
                cmd = JsonConvert.DeserializeObject<Command>(responsejson);

                if (cmd.type == "accept")
                {
                    this.name = name;
                    this.writeThread = new Thread(this.writeToStream);
                    this.writeThread.Start();
                    this.Start();
                }
                else {
                    throw new Exception("rejected");
                }
            }

            public override void notListen()
            {
                //throw new NotImplementedException();
            }

            private void writeToStream() {
                while (! this.disconnected)
                {
                    if (this.commands.Count != 0)
                    {
                        this.output.WriteLine(JsonConvert.SerializeObject(this.commands.Dequeue()));
                        this.output.Flush();
                    }
                }
            }

            public void sendCommand(Command command)
            {
                this.commands.Enqueue(command);
            }

            public void sendMessage(string message) {
                Command cmd = new Command();
                cmd.type = "msg";
                cmd.data = new string[] { message };
                this.sendCommand(cmd);
            }

            public void exit() {
                Command cmd = new Command();
                cmd.type = "exit";

                var output = new StreamWriter(this.client.GetStream());
                output.WriteLine(JsonConvert.SerializeObject(cmd));
                output.Flush();

                this.client.Close();
                this.disconnected = true;
                //this.Stop();
            }

            public void onMessageResive(Func<string, string, string> listen)
            {
                this.messageListener = listen;
            }

            public void onImageResive(Func<Image, bool> listen)
            {
                this.imageListener = listen;
            }
            public void onEnd(Func<string> listen)
            {
                this.endListener = listen;
            }            
            public void onEndShow(Func<string> listen)
            {
                this.noshareListener = listen;
            }
            
            public void onUsersUpdated(Func<string[], string[], string> listen)
            {
                this.userUpdated = listen;
            }            
        }


        public class User {
            #region connection variables 
            private TcpClient client;
            private StreamReader input;
            private StreamWriter output;
            private Queue<Command> commands;
            #endregion


            #region personal variable
            public string name;
            public int id;
            private bool disconnected = false;
            #endregion

            #region listeners
            private Func<string, string, string> messageListener;
            private Func<int,string> exitListener;
            #endregion


            #region threads variable
            Thread listenThread;
            Thread writeThread;
            #endregion

            public User(TcpClient client, string name) {
                this.client = client;
                this.name = name;
                this.input = new StreamReader(client.GetStream());
                this.output = new StreamWriter(client.GetStream());

                this.commands = new Queue<Command>();

                this.listenThread = new Thread(this.listen);
                this.writeThread = new Thread(this.writeToStream);

                this.listenThread.Start();
                this.writeThread.Start();
            }

            private void listen() {
                while (! this.disconnected) {
                    try
                    {
                        string requestjson = this.input.ReadLine();

                        Command cmd = JsonConvert.DeserializeObject<Command>(requestjson);
                        switch (cmd.type) {
                            case "msg":
                                this.messageListener(this.name , cmd.data[0]);
                                break;
                            case "exit":
                                this.exitListener(this.id);
                                break;
                        }
                    }
                    catch (Exception e) {continue; }
                }
            }

            private void writeToStream() {
                while (! this.disconnected) {
                    try
                    {
                        if (this.commands.Count != 0)
                        {
                            this.output.WriteLine(JsonConvert.SerializeObject(this.commands.Dequeue()));
                            this.output.Flush();
                        }
                    }
                    catch (Exception e) { continue;  }
                    
                }
            }

            public void sendCommand(Command command) {
                this.commands.Enqueue(command);
            }

            public void onMessage(Func<string, string, string> listen){
                this.messageListener = listen;
            }
            
            public void onExit(Func<int,string> listen){
                this.exitListener = listen;
            }

            public void Disconnect() {
                this.disconnected = true;
            }
        }

    }
}
