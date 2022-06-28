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

namespace LocalMiniVideoChat
{
    public partial class Profile : Form
    {

        joinMeet meet;
        LocalChatShare.Client client;
        string id;
        string name;
        public Profile(joinMeet meet , LocalChatShare.Client client, string id, string name)
        {
            this.meet = meet;
            this.client = client;
            this.id = id;
            this.name = name;
            InitializeComponent();
        }

        private void Profile_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.meet.closeProfile(this.id);
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            this.Text = this.name;
            this.lbl_name.Text = this.name;
            this.lbl_id.Text = this.id;
        }


        public void addMessage(string message) {
            if (lbx_chat.InvokeRequired)
            {
                lbx_chat.Invoke(new MethodInvoker(delegate { addMessage(message); }));
            }
            else {
                lbx_chat.Items.Add(message);
            }
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            if (txb_send.Text.Trim() != "")
            {
                this.client.sendPvMessage(this.id, txb_send.Text.Trim());
                txb_send.Clear();
            }
        }

        private void lbx_chat_DoubleClick(object sender, EventArgs e)
        {
            
        }
    }
}
