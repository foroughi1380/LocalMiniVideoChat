namespace LocalMiniVideoChat
{
    partial class joinMeet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.message_list = new System.Windows.Forms.ListBox();
            this.send_btn = new System.Windows.Forms.Button();
            this.send_txt = new System.Windows.Forms.TextBox();
            this.show_pic = new System.Windows.Forms.PictureBox();
            this.share_lbl = new System.Windows.Forms.Label();
            this.users_lbx = new System.Windows.Forms.ListBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lbx_contacts = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.show_pic)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // message_list
            // 
            this.message_list.FormattingEnabled = true;
            this.message_list.Location = new System.Drawing.Point(6, 240);
            this.message_list.Name = "message_list";
            this.message_list.Size = new System.Drawing.Size(272, 186);
            this.message_list.TabIndex = 9;
            // 
            // send_btn
            // 
            this.send_btn.Location = new System.Drawing.Point(207, 432);
            this.send_btn.Name = "send_btn";
            this.send_btn.Size = new System.Drawing.Size(71, 23);
            this.send_btn.TabIndex = 8;
            this.send_btn.Text = "send";
            this.send_btn.UseVisualStyleBackColor = true;
            this.send_btn.Click += new System.EventHandler(this.send_btn_Click);
            // 
            // send_txt
            // 
            this.send_txt.Location = new System.Drawing.Point(6, 432);
            this.send_txt.Name = "send_txt";
            this.send_txt.Size = new System.Drawing.Size(195, 20);
            this.send_txt.TabIndex = 7;
            this.send_txt.TextChanged += new System.EventHandler(this.send_txt_TextChanged);
            // 
            // show_pic
            // 
            this.show_pic.Location = new System.Drawing.Point(6, 6);
            this.show_pic.Name = "show_pic";
            this.show_pic.Size = new System.Drawing.Size(272, 228);
            this.show_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.show_pic.TabIndex = 10;
            this.show_pic.TabStop = false;
            // 
            // share_lbl
            // 
            this.share_lbl.AutoSize = true;
            this.share_lbl.Location = new System.Drawing.Point(109, 121);
            this.share_lbl.Name = "share_lbl";
            this.share_lbl.Size = new System.Drawing.Size(60, 13);
            this.share_lbl.TabIndex = 11;
            this.share_lbl.Text = "No Sharing";
            // 
            // users_lbx
            // 
            this.users_lbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.users_lbx.FormattingEnabled = true;
            this.users_lbx.Location = new System.Drawing.Point(3, 3);
            this.users_lbx.Name = "users_lbx";
            this.users_lbx.Size = new System.Drawing.Size(278, 466);
            this.users_lbx.TabIndex = 12;
            this.users_lbx.SelectedIndexChanged += new System.EventHandler(this.users_lbx_SelectedIndexChanged);
            this.users_lbx.DoubleClick += new System.EventHandler(this.users_lbx_DoubleClick);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Location = new System.Drawing.Point(12, 12);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(292, 498);
            this.tabControl2.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl2.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.share_lbl);
            this.tabPage1.Controls.Add(this.show_pic);
            this.tabPage1.Controls.Add(this.send_btn);
            this.tabPage1.Controls.Add(this.message_list);
            this.tabPage1.Controls.Add(this.send_txt);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(284, 472);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "همگانی";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.users_lbx);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(284, 472);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "افراد انلاین";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lbx_contacts);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(284, 472);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "مخاطبین";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lbx_contacts
            // 
            this.lbx_contacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbx_contacts.FormattingEnabled = true;
            this.lbx_contacts.Location = new System.Drawing.Point(3, 3);
            this.lbx_contacts.Name = "lbx_contacts";
            this.lbx_contacts.Size = new System.Drawing.Size(278, 466);
            this.lbx_contacts.TabIndex = 0;
            this.lbx_contacts.DoubleClick += new System.EventHandler(this.lbx_contacts_DoubleClick);
            // 
            // joinMeet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 522);
            this.Controls.Add(this.tabControl2);
            this.Name = "joinMeet";
            this.Text = "joinMeet";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.joinMeet_FormClosed);
            this.Load += new System.EventHandler(this.joinMeet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.show_pic)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox message_list;
        private System.Windows.Forms.Button send_btn;
        private System.Windows.Forms.TextBox send_txt;
        private System.Windows.Forms.PictureBox show_pic;
        private System.Windows.Forms.Label share_lbl;
        private System.Windows.Forms.ListBox users_lbx;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox lbx_contacts;
    }
}