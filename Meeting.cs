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
        LocalChatShare.Sever server;
        Thread thread;
        public Meeting(LocalChatShare.Sever server){
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
            
        }

        private void Meeting_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.server.Stop();
        }
    }
}
