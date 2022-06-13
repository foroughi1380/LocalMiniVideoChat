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
using System.Collections;
using System.Threading;

namespace LocalMiniVideoChat
{
    public partial class joinMeet : Form
    {
        public struct messageContain {
            public ArrayList message;
            public TabPage tp;
        }

        private Dictionary<string, messageContain> messages;

        private string[] ides = new string[0];

        private Dictionary<int, string> users = new Dictionary<int, string>();

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
            this.messages = new Dictionary<string, messageContain>();
            var mc = new messageContain();
            mc.message = new ArrayList();
            mc.tp = publictab;
            this.messages.Add("public", mc);



            this.client.Start();

            this.client.onMessageResive(this.messageResive);
            this.client.onEnd(this.end);
            this.client.onImageResive(this.showImage);
            this.client.onEndShow(this.endShow);
            this.client.onUsersUpdated(this.usersUpdated);
            this.client.onPvMessageResive(this.pvMessageRecive);
            this.Text = this.client.name;
        }

        private string endShow()
        {
            share_lbl.Invoke(new MethodInvoker(delegate
            {
                share_lbl.Visible = true;
                show_pic.Image = null;

            }));
            return null;
        }

        private bool showImage(Image image)
        {
            share_lbl.Invoke(new MethodInvoker(delegate
            {
                share_lbl.Visible = false;
            }));

            show_pic.Image = image;
            return false;
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
            this.messages["public"].message.Add(String.Format("{0} : {1}", name, message));
            this.fillMessages();
            return null;
        }


        public void fillMessages() {
            if (this.message_list.InvokeRequired)
            {
                this.message_list.Invoke(new MethodInvoker(delegate
                {
                    this.fillMessages();
                }));
            }
            else
            {
                this.message_list.Items.Clear();
                this.message_list.Items.AddRange(this.messages[tabControl1.SelectedTab.Tag.ToString()].message.ToArray());
            }

        }

        private void joinMeet_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.client.exit();
        }

        private void send_btn_Click(object sender, EventArgs e)
        {
            if (send_txt.Text.Trim() != "") {
                if (tabControl1.SelectedTab.Tag.ToString() == "public")
                {
                    this.client.sendMessage(send_txt.Text.Trim());
                }
                else {
                    this.client.sendPvMessage(tabControl1.SelectedTab.Tag.ToString(), send_txt.Text.Trim());
                }

                send_txt.Clear();
            }

        }

        private string usersUpdated(string[] ids, string[] names) {
            this.ides = ids;
            if (users_lbx.InvokeRequired)
            {
                users_lbx.Invoke(new MethodInvoker(delegate {
                    users_lbx.Items.Clear();
                    users_lbx.Items.AddRange(names);
                }));
            }
            else {
                users_lbx.Items.Clear();
                users_lbx.Items.AddRange(names);
            }
            
            return null;
        }

        private void users_lbx_DoubleClick(object sender, EventArgs e)
        {
            if (users_lbx.SelectedIndex > -1) {
                var id = this.ides[users_lbx.SelectedIndex];

                if (!this.messages.ContainsKey(id))
                {
                    tabControl1.SelectedTab = this.addTab(users_lbx.SelectedItem.ToString(), id);
                }
                else {
                    tabControl1.SelectedTab =  this.messages[id].tp;
                }
                
            }
        }

        public TabPage addTab(string name, string tag) {
            if (this.message_list.InvokeRequired)
            {
                this.message_list.Invoke(new MethodInvoker(delegate
                {
                    this.addTab(name, tag);
                }));

                return null;
            }
            else {
                TabPage tp = new TabPage();
                tp.Text = name;
                tp.Tag = tag;

                tabControl1.TabPages.Add(tp);
                var mc = new messageContain();
                mc.tp = tp;
                mc.message = new ArrayList();

                this.messages.Add(tag, mc);

                return tp;
            }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.fillMessages();
        }

        public string pvMessageRecive(string id , string name , string message) {
            if (! this.messages.ContainsKey(id))
            {
                addTab(name, id);
            }

            while (!this.messages.ContainsKey(id)) { Thread.Sleep(100); }
            this.messages[id].message.Add(String.Format("{0} : {1}", name, message));
            this.fillMessages();

            return null;
        }

        private void send_txt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
