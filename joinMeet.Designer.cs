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
            ((System.ComponentModel.ISupportInitialize)(this.show_pic)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // message_list
            // 
            this.message_list.FormattingEnabled = true;
            this.message_list.Location = new System.Drawing.Point(15, 322);
            this.message_list.Name = "message_list";
            this.message_list.Size = new System.Drawing.Size(647, 95);
            this.message_list.TabIndex = 9;
            // 
            // send_btn
            // 
            this.send_btn.Location = new System.Drawing.Point(587, 421);
            this.send_btn.Name = "send_btn";
            this.send_btn.Size = new System.Drawing.Size(75, 23);
            this.send_btn.TabIndex = 8;
            this.send_btn.Text = "send";
            this.send_btn.UseVisualStyleBackColor = true;
            this.send_btn.Click += new System.EventHandler(this.send_btn_Click);
            // 
            // send_txt
            // 
            this.send_txt.Location = new System.Drawing.Point(15, 423);
            this.send_txt.Name = "send_txt";
            this.send_txt.Size = new System.Drawing.Size(565, 20);
            this.send_txt.TabIndex = 7;
            // 
            // show_pic
            // 
            this.show_pic.Location = new System.Drawing.Point(12, 9);
            this.show_pic.Name = "show_pic";
            this.show_pic.Size = new System.Drawing.Size(650, 307);
            this.show_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.show_pic.TabIndex = 10;
            this.show_pic.TabStop = false;
            // 
            // share_lbl
            // 
            this.share_lbl.AutoSize = true;
            this.share_lbl.Location = new System.Drawing.Point(303, 156);
            this.share_lbl.Name = "share_lbl";
            this.share_lbl.Size = new System.Drawing.Size(60, 13);
            this.share_lbl.TabIndex = 11;
            this.share_lbl.Text = "No Sharing";
            // 
            // joinMeet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 450);
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
    }
}