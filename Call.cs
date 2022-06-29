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
    public partial class Call : Form
    {
        Boolean callend = false;
        LocalChatShare.Client client;
        string name, id;
        Profile profile;
        public Call(string name, string id, LocalChatShare.Client client, Profile profile)
        {
            this.name = name;
            this.id = id;
            this.client = client;
            this.profile = profile;
            InitializeComponent();
        }

        private void Call_Load(object sender, EventArgs e)
        {
            this.Text = String.Format("{0} تماس با", this.name);
            this.client.onCallEnded(this.CallEnded);
        }


        private string CallEnded(string name, string id) {
            this.Invoke(new MethodInvoker(delegate {
                profile.btn_call.Text = "تماس";
                this.Close();
                MessageBox.Show("تماس پایان یافت");
            }));
            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.end();
        }

        private void Call_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(!this.callend)
                this.end();
        }

        public void end() {
            this.callend = true;
            this.client.callEnd(this.id);
            this.profile.callEnded();
            this.Close();
        }
    }
}
