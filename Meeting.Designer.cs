namespace LocalMiniVideoChat
{
    partial class Meeting
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
            this.ip_lbl = new System.Windows.Forms.Label();
            this.users_lb = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.send_txt = new System.Windows.Forms.TextBox();
            this.send_btn = new System.Windows.Forms.Button();
            this.message_list = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ip : ";
            // 
            // ip_lbl
            // 
            this.ip_lbl.AutoSize = true;
            this.ip_lbl.Location = new System.Drawing.Point(42, 9);
            this.ip_lbl.Name = "ip_lbl";
            this.ip_lbl.Size = new System.Drawing.Size(27, 13);
            this.ip_lbl.TabIndex = 1;
            this.ip_lbl.Text = "N/A";
            // 
            // users_lb
            // 
            this.users_lb.FormattingEnabled = true;
            this.users_lb.Location = new System.Drawing.Point(15, 69);
            this.users_lb.Name = "users_lb";
            this.users_lb.Size = new System.Drawing.Size(120, 368);
            this.users_lb.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Users";
            // 
            // send_txt
            // 
            this.send_txt.Location = new System.Drawing.Point(141, 417);
            this.send_txt.Name = "send_txt";
            this.send_txt.Size = new System.Drawing.Size(565, 20);
            this.send_txt.TabIndex = 4;
            // 
            // send_btn
            // 
            this.send_btn.Location = new System.Drawing.Point(713, 415);
            this.send_btn.Name = "send_btn";
            this.send_btn.Size = new System.Drawing.Size(75, 23);
            this.send_btn.TabIndex = 5;
            this.send_btn.Text = "send";
            this.send_btn.UseVisualStyleBackColor = true;
            this.send_btn.Click += new System.EventHandler(this.send_btn_Click);
            // 
            // message_list
            // 
            this.message_list.FormattingEnabled = true;
            this.message_list.Location = new System.Drawing.Point(141, 316);
            this.message_list.Name = "message_list";
            this.message_list.Size = new System.Drawing.Size(647, 95);
            this.message_list.TabIndex = 6;
            // 
            // Meeting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.message_list);
            this.Controls.Add(this.send_btn);
            this.Controls.Add(this.send_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.users_lb);
            this.Controls.Add(this.ip_lbl);
            this.Controls.Add(this.label1);
            this.Name = "Meeting";
            this.Text = "Meeting";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Meeting_FormClosed);
            this.Load += new System.EventHandler(this.Meeting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ip_lbl;
        private System.Windows.Forms.ListBox users_lb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox send_txt;
        private System.Windows.Forms.Button send_btn;
        private System.Windows.Forms.ListBox message_list;
    }
}