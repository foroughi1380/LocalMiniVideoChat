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
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;

namespace LocalMiniVideoChat
{
    public partial class Call : Form
    {
        bool isShareCamera = true;
        Boolean callend = false;
        LocalChatShare.Client client;
        string name, id;
        Profile profile;

        VideoCaptureDevice captureDevice;
        

        public Call(string name, string id, LocalChatShare.Client client, Profile profile)
        {
            this.name = name;
            this.id = id;
            this.client = client;
            this.profile = profile;
            InitializeComponent();
        }

        private void Call_Load(object sender, EventArgs e)
        {
            this.Text = String.Format("{0} تماس با", this.name);
            this.client.onCallEnded(this.CallEnded);
            this.client.onCameraImage(this.cirevice);
            this.client.onCameraEnd(this.endresive);
            this.StartShareCamera();
        }

        public string cirevice(string id , Image img) {
            pictureBox1.Invoke(new MethodInvoker(delegate
            {
                pictureBox1.Image = img;
                lbl_camera.Visible = false;
            }));
            return null;
        }
        public string endresive(string id)
        {
            pictureBox1.Invoke(new MethodInvoker(delegate
            {
                lbl_camera.Visible = true;
                pictureBox1.Image = null;
            }));
            return null;
        }

        private string CallEnded(string name, string id) {
            this.Invoke(new MethodInvoker(delegate {
                profile.btn_call.Text = "تماس";
                this.Close();
                MessageBox.Show("تماس پایان یافت");
            }));
            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.end();
        }

        private void Call_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(!this.callend)
                this.end();
        }

        public void end() {
            this.callend = true;
            this.client.callEnd(this.id);
            this.profile.callEnded();
            this.Close();
        }

        public void StartShareCamera() {
            try
            {
                var f = FilterCategory.VideoInputDevice;
                this.captureDevice = new VideoCaptureDevice(new FilterInfoCollection(FilterCategory.VideoInputDevice)[0].MonikerString);
                this.captureDevice.NewFrame += new NewFrameEventHandler(fraimRevied);
                this.captureDevice.Start();
                button2.Text = "قطع دوربین";
                this.isShareCamera = true;
            }
            catch (Exception e) {
                button2.Text = "اشتراک دوربین";
                button2.Enabled = false;
                MessageBox.Show("خطا در استفاده از دوربین");

            }
        }

        public void StopeSharingCamera() {
            this.isShareCamera = false;
            button2.Text = "اشتراک دوربین";
            this.client.stopCameraImage(this.id);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text.Equals("قطع دوربین")) {
                this.StopeSharingCamera();
            }
            else {
                this.StartShareCamera();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text.Equals("قطع صدا"))
            {
                button3.Text = "وصل صدا";
            }
            else {
                button3.Text = "قطع صدا";
            }
        }

        void fraimRevied(object sender, NewFrameEventArgs eventArgs)
        {
           
                this.Invoke(new MethodInvoker(delegate
                {
                    if (this.isShareCamera)
                    {
                        lbl_my_camera_off.Visible = false;
                        var bit = (Bitmap)eventArgs.Frame.Clone();
                        myCamera.Image = bit;
                        this.client.sendCameraImage(this.id, bit);
                    }
                    else {
                        lbl_my_camera_off.Visible = true;
                        myCamera.Image = null;
                    }
                       
                }));


        }

    }
}
