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
using System.Threading;
namespace LocalMiniVideoChat
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        private void metting_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Meeting(new LocalChatShare.Sever()).Show();
            //new Meeting(new LocalChatShare.Sever()).ShowDialog();
            this.Show();
        }
    }
}
