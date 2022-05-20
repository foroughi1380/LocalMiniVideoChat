using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LVC;
namespace LocalMiniVideoChat
{
    public partial class Meeting : Form
    {
        Dictionary<int, string> connectedUsers = new Dictionary<int, string>();

        LocalChatShare.Server server;
        Thread thread;
        public Meeting(LocalChatShare.Server server){
            this.server = server;
            init();
        }

        private void init()
        {
            this.thread = this.server.Start();
            InitializeComponent();
        }

        private void Meeting_Load(object sender, EventArgs e)
        {
            if (this.thread.IsAlive != null)
            {
                this.ip_lbl.Text = this.server.ip.ToString();
            }
            else {
                MessageBox.Show("server not connected");
                this.Close();
            }

            this.server.onMessageResive(this.messageResive);
            this.server.onConnected(this.userConnected);
            this.server.onDisconnected(this.userDisconnected);
            this.server.onRequestLogin(this.requestLogin);
            
        }

        private string messageResive(string name, string message)
        {
            if (this.message_list.InvokeRequired)
            {
                this.message_list.Invoke(new MethodInvoker(delegate
                {
                    this.message_list.Items.Add(String.Format("{0} : {1}", name, message));
                }));
            }
            else {
                this.message_list.Items.Add(String.Format("{0} : {1}", name, message));
            }

            return null;
        }

        private bool requestLogin(string name)
        {
            return MessageBox.Show("do you accept `" + name + "`", "Login request", MessageBoxButtons.YesNo) == DialogResult.Yes;
        }

        private string userDisconnected(int id)
        {
            this.connectedUsers.Remove(id);
            this.fillConnectedUser();
            return null;
        }

        


        private string userConnected(int id , string name) {
            this.connectedUsers.Add(id, name);
            this.fillConnectedUser();

            return null;
        }

        private void fillConnectedUser() {
            if (users_lb.InvokeRequired)
            {
                users_lb.Invoke(new MethodInvoker(delegate {
                    users_lb.Items.Clear();
                }));
            }
            else
            {
                users_lb.Items.Clear();
            }


            foreach (string name in this.connectedUsers.Values) {
                if (users_lb.InvokeRequired)
                {
                    users_lb.Invoke(new MethodInvoker(delegate {
                        users_lb.Items.Add(name);
                    }));
                }
                else
                {
                    users_lb.Items.Add(name);
                }
            }
        }

        private void Meeting_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.server.end();
        }

        private void send_btn_Click(object sender, EventArgs e)
        {
            if (send_txt.Text != "")
            {
                this.server.sendMessage(send_txt.Text);
                this.message_list.Items.Add(String.Format("{0} : {1}", this.server.name, send_txt.Text));
                send_txt.Clear();
            }
        }


    }
}
