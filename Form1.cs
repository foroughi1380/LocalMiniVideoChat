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
    public partial class Form1 : Form
    {
        LocalChatShare lcv;
        public Form1()
        {
            InitializeComponent();
            lcv = new LocalChatShare();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ip_lbl.Text = this.lcv.GetLocalIPAddress();
        }
    }
}
