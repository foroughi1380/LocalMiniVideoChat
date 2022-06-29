namespace LocalMiniVideoChat
{
    partial class Profile
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
            this.btn_send = new System.Windows.Forms.Button();
            this.txb_send = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_id = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.btn_call = new System.Windows.Forms.Button();
            this.lbx_chat = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(260, 416);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(75, 23);
            this.btn_send.TabIndex = 0;
            this.btn_send.Text = "ارسال";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // txb_send
            // 
            this.txb_send.Location = new System.Drawing.Point(12, 418);
            this.txb_send.Name = "txb_send";
            this.txb_send.Size = new System.Drawing.Size(242, 20);
            this.txb_send.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel1.Controls.Add(this.lbl_id);
            this.panel1.Controls.Add(this.lbl_name);
            this.panel1.Controls.Add(this.btn_call);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(347, 43);
            this.panel1.TabIndex = 2;
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.Location = new System.Drawing.Point(13, 26);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(35, 13);
            this.lbl_id.TabIndex = 3;
            this.lbl_id.Text = "label2";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(13, 9);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(35, 13);
            this.lbl_name.TabIndex = 3;
            this.lbl_name.Text = "label1";
            // 
            // btn_call
            // 
            this.btn_call.Location = new System.Drawing.Point(285, 12);
            this.btn_call.Name = "btn_call";
            this.btn_call.Size = new System.Drawing.Size(51, 23);
            this.btn_call.TabIndex = 0;
            this.btn_call.Text = "تماس";
            this.btn_call.UseVisualStyleBackColor = true;
            this.btn_call.Click += new System.EventHandler(this.btn_call_Click);
            // 
            // lbx_chat
            // 
            this.lbx_chat.FormattingEnabled = true;
            this.lbx_chat.Location = new System.Drawing.Point(12, 198);
            this.lbx_chat.Name = "lbx_chat";
            this.lbx_chat.Size = new System.Drawing.Size(320, 212);
            this.lbx_chat.TabIndex = 3;
            this.lbx_chat.DoubleClick += new System.EventHandler(this.lbx_chat_DoubleClick);
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 450);
            this.Controls.Add(this.lbx_chat);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txb_send);
            this.Controls.Add(this.btn_send);
            this.Name = "Profile";
            this.Text = "Profile";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Profile_FormClosed);
            this.Load += new System.EventHandler(this.Profile_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.TextBox txb_send;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_id;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.ListBox lbx_chat;
        public System.Windows.Forms.Button btn_call;
    }
}