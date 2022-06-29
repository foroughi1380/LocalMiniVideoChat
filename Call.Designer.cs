namespace LocalMiniVideoChat
{
    partial class Call
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
            this.button1 = new System.Windows.Forms.Button();
            this.myCamera = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.lbl_my_camera_off = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_camera = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.myCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(222, 191);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "قطع تماس";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // myCamera
            // 
            this.myCamera.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.myCamera.Location = new System.Drawing.Point(203, 47);
            this.myCamera.Name = "myCamera";
            this.myCamera.Size = new System.Drawing.Size(94, 72);
            this.myCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.myCamera.TabIndex = 1;
            this.myCamera.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(222, 163);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "دوربین";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbl_my_camera_off
            // 
            this.lbl_my_camera_off.AutoSize = true;
            this.lbl_my_camera_off.Location = new System.Drawing.Point(208, 76);
            this.lbl_my_camera_off.Name = "lbl_my_camera_off";
            this.lbl_my_camera_off.Size = new System.Drawing.Size(84, 13);
            this.lbl_my_camera_off.TabIndex = 3;
            this.lbl_my_camera_off.Text = "اشتراک قطع است";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(238, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "دوربین خود";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(12, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(185, 187);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_camera
            // 
            this.lbl_camera.AutoSize = true;
            this.lbl_camera.Location = new System.Drawing.Point(63, 111);
            this.lbl_camera.Name = "lbl_camera";
            this.lbl_camera.Size = new System.Drawing.Size(84, 13);
            this.lbl_camera.TabIndex = 6;
            this.lbl_camera.Text = "اشتراک قطع است";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(138, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "دوربین مخاطب";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(222, 134);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "قطع صدا";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Call
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 226);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_camera);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_my_camera_off);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.myCamera);
            this.Controls.Add(this.button1);
            this.Name = "Call";
            this.Text = "Call";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Call_FormClosed);
            this.Load += new System.EventHandler(this.Call_Load);
            ((System.ComponentModel.ISupportInitialize)(this.myCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox myCamera;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbl_my_camera_off;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_camera;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
    }
}