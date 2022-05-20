﻿using System;
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


namespace LocalMiniVideoChat
{
    public partial class joinMeet : Form
    {

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
            this.client.Start();

        }

        private void joinMeet_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.client.exit();
        }
    }
}