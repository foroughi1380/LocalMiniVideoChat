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

            this.server.onConnected(this.userConnected);
            this.server.onDisconnected(this.userDisconnected);
            
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
            this.server.Stop();
        }
    }
}
