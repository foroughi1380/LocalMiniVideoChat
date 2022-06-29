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
        private string[] names = new string[0];

        public ArrayList contacts = new ArrayList();
        public Dictionary<string, Profile> Profiles = new Dictionary<string, Profile>();

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
            mc.tp = null;
            this.messages.Add("public", mc);



            this.client.Start();

            this.client.onMessageResive(this.messageResive);
            this.client.onEnd(this.end);
            this.client.onImageResive(this.showImage);
            this.client.onEndShow(this.endShow);
            this.client.onUsersUpdated(this.usersUpdated);
            this.client.onPvMessageResive(this.pvMessageRecive);
            this.client.onRequestCall(this.requestCall);
            this.Text = this.client.name;


            this.client.requestUsrsList();
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
                this.message_list.Items.AddRange(this.messages["public"].message.ToArray());
            }

        }

        private void joinMeet_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.client.exit();
        }

        private void send_btn_Click(object sender, EventArgs e)
        {
            if (send_txt.Text.Trim() != "") {
                this.client.sendMessage(send_txt.Text.Trim());

                //if (tabControl1.SelectedTab.Tag.ToString() == "public")
                //{
                //    this.client.sendMessage(send_txt.Text.Trim());
                //}
                //else {
                //    this.client.sendPvMessage(tabControl1.SelectedTab.Tag.ToString(), send_txt.Text.Trim());
                //}

                send_txt.Clear();
            }

        }

        private string usersUpdated(string[] ids, string[] names) {
            this.ides = ids;
            this.names = names;
            if (users_lbx.InvokeRequired)
            {

                users_lbx.Invoke(new MethodInvoker(delegate
                {
                    //users_lbx.Items.Clear();
                    //users_lbx.Items.AddRange(names);
                    usersUpdated(ids, names);
                }));
            }
            else {
                users_lbx.Items.Clear();
                for (int i = 0; i < ides.Length; i++) {
                    users_lbx.Items.Add(names[i] + (this.client.id == ids[i] ? " (شما) " : ""));
                }
                
            }
            
            return null;
        }

        private void users_lbx_DoubleClick(object sender, EventArgs e)
        {
            if (users_lbx.SelectedIndex > -1) {
                var id = this.ides[users_lbx.SelectedIndex];
                if (id == this.client.id) return;

                

                if (this.Profiles.ContainsKey(id))
                {
                    this.Profiles[id].Focus();
                    //tabControl1.SelectedTab = this.addTab(users_lbx.SelectedItem.ToString(), id);
                }
                else {
                    //tabControl1.SelectedTab =  this.messages[id].tp;
                    var profile = new Profile(this, this.client, id , this.names[users_lbx.SelectedIndex]);
                    this.Profiles.Add(id, profile);
                    profile.Show();

                    if (this.messages.ContainsKey(id)) {
                        foreach (string message in this.messages[id].message) {
                            profile.addMessage(message);
                        }
                    }

                }
                
            }
        }

        public void closeProfile(string id) {
            this.Profiles.Remove(id);
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
                //TabPage tp = new TabPage();
                //tp.Text = name;
                //tp.Tag = tag;
                
                lbx_contacts.Items.Add(name);
                contacts.Add(tag);

                //tabControl1.TabPages.Add(tp);
                var mc = new messageContain();
                //mc.tp = tp;
                mc.message = new ArrayList();

                this.messages.Add(tag, mc);

                return null;
            }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.fillMessages();
        }

        public string pvMessageRecive(string pv_id , string pv_name , string message, string sender_id, string sender_name) {
            if (! this.messages.ContainsKey(pv_id))
            {
                addTab(pv_name, pv_id);
            }

            while (!this.messages.ContainsKey(pv_id)) { Thread.Sleep(100); }
            var m = String.Format("{0} : {1}", (sender_id == this.client.id) ? "شما" : sender_name, message);
            this.messages[pv_id].message.Add(m);

            if (this.Profiles.ContainsKey(pv_id)) {
                this.Profiles[pv_id].addMessage(m);
            }

            //this.fillMessages();

            return null;
        }

        private void send_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void users_lbx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbx_contacts_DoubleClick(object sender, EventArgs e)
        {
            if (lbx_contacts.SelectedIndex > -1)
            {
                string id = (string) this.contacts[lbx_contacts.SelectedIndex];



                if (this.Profiles.ContainsKey(id))
                {
                    this.Profiles[id].Focus();
                    //tabControl1.SelectedTab = this.addTab(users_lbx.SelectedItem.ToString(), id);
                }
                else
                {
                    //tabControl1.SelectedTab =  this.messages[id].tp;
                    int index = this.arrayIndexOf(this.ides, id);
                    var profile = new Profile(this, this.client, id, this.names[index]);
                    this.Profiles.Add(id, profile);
                    profile.Show();

                    if (this.messages.ContainsKey(id))
                    {
                        foreach (string message in this.messages[id].message)
                        {
                            profile.addMessage(message);
                        }
                    }

                }

            }
        }

        public int arrayIndexOf(string[] array, string value) {
           
            for (int i = 0; i < array.Length; i++) {
                if (array[i] == value) {
                    return i;
                }
            }
            return -1;
        }

        public string requestCall(string name , string id) {
            this.Invoke(new MethodInvoker(delegate
            {
                Ringing ringing = new Ringing(name, id, this.client, this);
                ringing.Show();
            }));
            return null;
        }
    }
}
