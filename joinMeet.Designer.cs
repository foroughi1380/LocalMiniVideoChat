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
            this.label1 = new System.Windows.Forms.Label();
            this.message_list = new System.Windows.Forms.ListBox();
            this.send_btn = new System.Windows.Forms.Button();
            this.send_txt = new System.Windows.Forms.TextBox();
            this.show_pic = new System.Windows.Forms.PictureBox();
            this.share_lbl = new System.Windows.Forms.Label();
            this.users_lbx = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.publictab = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.show_pic)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "users";
            // 
            // message_list
            // 
            this.message_list.FormattingEnabled = true;
            this.message_list.Location = new System.Drawing.Point(155, 339);
            this.message_list.Name = "message_list";
            this.message_list.Size = new System.Drawing.Size(504, 95);
            this.message_list.TabIndex = 9;
            // 
            // send_btn
            // 
            this.send_btn.Location = new System.Drawing.Point(584, 436);
            this.send_btn.Name = "send_btn";
            this.send_btn.Size = new System.Drawing.Size(75, 23);
            this.send_btn.TabIndex = 8;
            this.send_btn.Text = "send";
            this.send_btn.UseVisualStyleBackColor = true;
            this.send_btn.Click += new System.EventHandler(this.send_btn_Click);
            // 
            // send_txt
            // 
            this.send_txt.Location = new System.Drawing.Point(155, 438);
            this.send_txt.Name = "send_txt";
            this.send_txt.Size = new System.Drawing.Size(422, 20);
            this.send_txt.TabIndex = 7;
            this.send_txt.TextChanged += new System.EventHandler(this.send_txt_TextChanged);
            // 
            // show_pic
            // 
            this.show_pic.Location = new System.Drawing.Point(155, 9);
            this.show_pic.Name = "show_pic";
            this.show_pic.Size = new System.Drawing.Size(507, 307);
            this.show_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.show_pic.TabIndex = 10;
            this.show_pic.TabStop = false;
            // 
            // share_lbl
            // 
            this.share_lbl.AutoSize = true;
            this.share_lbl.Location = new System.Drawing.Point(382, 165);
            this.share_lbl.Name = "share_lbl";
            this.share_lbl.Size = new System.Drawing.Size(60, 13);
            this.share_lbl.TabIndex = 11;
            this.share_lbl.Text = "No Sharing";
            // 
            // users_lbx
            // 
            this.users_lbx.FormattingEnabled = true;
            this.users_lbx.Location = new System.Drawing.Point(12, 25);
            this.users_lbx.Name = "users_lbx";
            this.users_lbx.Size = new System.Drawing.Size(137, 433);
            this.users_lbx.TabIndex = 12;
            this.users_lbx.DoubleClick += new System.EventHandler(this.users_lbx_DoubleClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.publictab);
            this.tabControl1.Location = new System.Drawing.Point(164, 317);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(495, 22);
            this.tabControl1.TabIndex = 13;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // publictab
            // 
            this.publictab.Location = new System.Drawing.Point(4, 22);
            this.publictab.Name = "publictab";
            this.publictab.Padding = new System.Windows.Forms.Padding(3);
            this.publictab.Size = new System.Drawing.Size(487, 0);
            this.publictab.TabIndex = 0;
            this.publictab.Tag = "public";
            this.publictab.Text = "Public";
            this.publictab.UseVisualStyleBackColor = true;
            // 
            // joinMeet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 468);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.users_lbx);
            this.Controls.Add(this.share_lbl);
            this.Controls.Add(this.show_pic);
            this.Controls.Add(this.message_list);
            this.Controls.Add(this.send_btn);
            this.Controls.Add(this.send_txt);
            this.Controls.Add(this.label1);
            this.Name = "joinMeet";
            this.Text = "joinMeet";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.joinMeet_FormClosed);
            this.Load += new System.EventHandler(this.joinMeet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.show_pic)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox message_list;
        private System.Windows.Forms.Button send_btn;
        private System.Windows.Forms.TextBox send_txt;
        private System.Windows.Forms.PictureBox show_pic;
        private System.Windows.Forms.Label share_lbl;
        private System.Windows.Forms.ListBox users_lbx;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage publictab;
    }
}