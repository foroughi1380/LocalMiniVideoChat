﻿namespace LocalMiniVideoChat
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
            // Meeting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}