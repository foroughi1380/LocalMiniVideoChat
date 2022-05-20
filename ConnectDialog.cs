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

namespace LocalMiniVideoChat
{
    public partial class ConnectDialog : Form
    {
        public ConnectDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var name = name_txb.Text;
            var host = host_txb.Text;
            int port = 0;
            try
            {
                port = int.Parse(port_txb.Text);
            }
            catch (Exception ex) {
                MessageBox.Show("invalid port");
                return;
            }

            if (name == "") {
                MessageBox.Show("invalid name");
            }

            if (host == "") {
                MessageBox.Show("invalid host");
            }

            LVC.LocalChatShare.Client client = new LVC.LocalChatShare.Client();



            var t = new Thread(() =>
            {
                try
                {
                    button1.Invoke(new MethodInvoker(delegate
                    {
                        button1.Text = "wait ...";
                        button1.Enabled = false;
                    }));

                    client.connect(host, port, name);

                    button1.Invoke(new MethodInvoker(delegate
                    {
                        this.Hide();
                        new joinMeet(client).Show();
                        this.Close();
                    }));
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error to Join (host not found or host rejected)");
                    try
                    {
                        button1.Invoke(new MethodInvoker(delegate
                        {
                            try
                            {

                                button1.Text = "conncet";
                                button1.Enabled = true;
                            }
                            catch (Exception ee) { }
                        }));
                    }
                    catch (Exception ee) { }
                }
            });

            t.IsBackground = true;
            t.Start();
            

        }
    }
}
