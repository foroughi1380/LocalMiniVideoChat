namespace LocalMiniVideoChat
{
    partial class ConnectDialog
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
            this.host_txb = new System.Windows.Forms.TextBox();
            this.port_txb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.name_txb = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // host_txb
            // 
            this.host_txb.Location = new System.Drawing.Point(61, 12);
            this.host_txb.Name = "host_txb";
            this.host_txb.Size = new System.Drawing.Size(100, 20);
            this.host_txb.TabIndex = 0;
            this.host_txb.Text = "127.0.0.1";
            // 
            // port_txb
            // 
            this.port_txb.Location = new System.Drawing.Point(179, 12);
            this.port_txb.Name = "port_txb";
            this.port_txb.Size = new System.Drawing.Size(100, 20);
            this.port_txb.TabIndex = 1;
            this.port_txb.Text = "8585";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = ":";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "name";
            // 
            // name_txb
            // 
            this.name_txb.Location = new System.Drawing.Point(51, 74);
            this.name_txb.Name = "name_txb";
            this.name_txb.Size = new System.Drawing.Size(100, 20);
            this.name_txb.TabIndex = 0;
            this.name_txb.Text = "User ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(179, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ConnectDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 121);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.port_txb);
            this.Controls.Add(this.name_txb);
            this.Controls.Add(this.host_txb);
            this.Name = "ConnectDialog";
            this.Text = "ConnectDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox host_txb;
        private System.Windows.Forms.TextBox port_txb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox name_txb;
        private System.Windows.Forms.Button button1;
    }
}