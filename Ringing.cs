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
    public partial class Ringing : Form
    {
        string name, id;
        LocalChatShare.Client client;
        joinMeet meet;
        public Ringing(string name , string id, LocalChatShare.Client client, joinMeet meet)
        {
            this.name = name;
            this.id = id;
            this.client = client;
            this.meet = meet;
            InitializeComponent();
        }

        private void btn_accept_Click(object sender, EventArgs e)
        {
            this.client.callAccept(this.id);
            if (this.meet.Profiles.ContainsKey(this.id))
            {
                Profile p = this.meet.Profiles[this.id];
                p.Focus();
                p.showCall();
            }
            else {
                Profile p = new Profile(meet , this.client, id, name);
                this.meet.Profiles.Add(id , p);
                p.Show();
                p.showCall();
            }
            this.Close();
        }

        private void btn_reject_Click(object sender, EventArgs e)
        {
            this.client.callReject(this.id);
            this.Close();
        }

        private void Ringing_Load(object sender, EventArgs e)
        {
            lbl_name.Text = this.name;
            this.client.onRequestCallEnded(this.requestEnded);
        }


        public string requestEnded(string name , string id) {
            this.Invoke(new MethodInvoker(delegate
            {
                this.Close();
            }));
            
            return null;
        }
    }
}
