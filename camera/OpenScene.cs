using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using SharpDX.MediaFoundation;


namespace camera
{
    /// <summary>
    /// 開始シーン
    /// </summary>
    public partial class OpenScene : Form
    {
        //カメラ名リスト
        List<string> CameraNames = new List<string>();

        public OpenScene()
        {
            InitializeComponent();
            ListOfAttachedCameras();
        }

        //Webカメラを起動
        private void StartWebCamera_Click(object sender, EventArgs e)
        {
            //if (CameraNames.Count > 0)
            //{
                MainScene main = new MainScene();
                main.Owner = this;
                main.Cmode = MainScene.CamMode.WebCam;
                main.WebCamNum = WebCamSelect.SelectedIndex;
                main.Show();
                       
                //this.Close();
                this.Visible = false;
            //}
            //else
            //{
            //    MessageBox.Show("使用できるカメラは0です");
            //}
        }

        //ネットワークカメラを起動
        private void StartnetCamera_Click(object sender, EventArgs e)
        {
            MainScene main = new MainScene();
            main.Owner = this;
            main.Cmode = MainScene.CamMode.NetCam;
            //main.CamTypeName = "http://"+UserID.Text+":"+ PassWord.Text+"@"+IpAdress.Text+ "/axis-cgi/mjpg/video.cgi";
            main.CamTypeName = "http://" + UserID.Text + ":" + PassWord.Text + "@" + IpAdress.Text + "/cgi-bin/camera?resolution=640";
            main.Show();
            this.Visible = false;
        }

        //Load
        private void OpenScene_Load(object sender, EventArgs e)
        {
            //使用できるWEBカメラ表示
            for(int i = 0; i < CameraNames.Count; i++)
            {
                WebCamSelect.Items.Add(CameraNames[i]);
            }

            if (CameraNames.Count > 0) 
            {
                WebCamSelect.SelectedIndex = 0;
                //WebCamSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            else
            {

                WebCamSelect.Items.Add("利用できるカメラは0");
                WebCamSelect.SelectedIndex = 0;
                WebCamSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            }

        }
    
        //使用できるWEBカメラリストを取得
        public void ListOfAttachedCameras()
        {
            var cameras = new List<string>();
            var attributes = new MediaAttributes(1);
            attributes.Set(CaptureDeviceAttributeKeys.SourceType.Guid, CaptureDeviceAttributeKeys.SourceTypeVideoCapture.Guid);
            var devices = MediaFactory.EnumDeviceSources(attributes);
            for (var i = 0; i < devices.Count(); i++)
            {
                var friendlyName = devices[i].Get(CaptureDeviceAttributeKeys.FriendlyName);
                CameraNames.Add(friendlyName);
            }
            //return cameras.ToArray();
        }   
    }
}
