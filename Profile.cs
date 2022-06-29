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
        Call call;
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
            if (this.call != null) {
                this.call.end();
            }
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

        private void btn_call_Click(object sender, EventArgs e)
        {
            if (this.btn_call.Text == "تماس")
            {
                this.client.requestCall(this.id);
                this.btn_call.Text = "قطع تماس";

                this.client.onCallAccept(this.CallAccept);
                this.client.onCallReject(this.CallRejct);
            }
            else {
                if (this.call != null)
                {
                    this.call.end();
                }
                else {
                    this.client.requestCallEnd(this.id);
                }
                this.btn_call.Text = "تماس";

            }

        }


        public string CallAccept(string name, string id) {
            this.showCall();
            return null;
        }

        public void showCall() {
            this.Invoke(new MethodInvoker(delegate {
                this.btn_call.Text = "قطع تماس";
                this.call = new Call(this.name, this.id, this.client, this);
                this.call.Show();
            }));
        }

        public string CallRejct(string name , string id) {
            
            this.Invoke(new MethodInvoker(delegate
            {
                this.btn_call.Text = "تماس";
            }));
            MessageBox.Show("تماس رد شد");
            return null;
        }


        public void callEnded() {
            this.Invoke(new MethodInvoker(delegate
            {
                this.btn_call.Text = "تماس";
            }));
            
            this.client.onCallAccept(null);
            this.client.onCallReject(null);
        }
    }
}
