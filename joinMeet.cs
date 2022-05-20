using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LVC;
using Newtonsoft.Json;


namespace LocalMiniVideoChat
{
    public partial class joinMeet : Form
    {

        private LocalChatShare.Client client;
        public joinMeet(LocalChatShare.Client clinet)
        {
            this.client = clinet;
            this.init();
        }




        public void init()
        {
            InitializeComponent();
        }

        private void joinMeet_Load(object sender, EventArgs e)
        {
            this.client.Start();

            this.client.onMessageResive(this.messageResive);
            this.client.onEnd(this.end);
        }

        private string end()
        {
            
            this.Invoke(new MethodInvoker(delegate
            {
                this.Close();
                MessageBox.Show("Mett has been end");
            }));
            
            return null;
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
            else
            {
                this.message_list.Items.Add(String.Format("{0} : {1}", name, message));
            }

            return null;
        }

        private void joinMeet_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.client.exit();
        }

        private void send_btn_Click(object sender, EventArgs e)
        {
            if (send_txt.Text != "") {
                this.client.sendMessage(send_txt.Text);
                send_txt.Clear();
            }

        }
    }
}
