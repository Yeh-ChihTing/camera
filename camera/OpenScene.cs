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

            //フォーム位置を画面の真中にする
            this.StartPosition = FormStartPosition.CenterScreen;

            //使用できるカメラデバイス検索関数
            ListOfAttachedCameras();

        }

        //Webカメラを起動
        private void StartWebCamera_Click(object sender, EventArgs e)
        {
            if (CameraNames.Count > 0)
            {
                //新しいメインシーン宣言
                MainScene main = new MainScene();

                //メインシーンフォーム位置を画面の真中にする
                main.StartPosition = FormStartPosition.CenterScreen;

                //このフォームの子にする
                main.Owner = this;

                //カメラモード設定
                main.Cmode = MainScene.CamMode.WebCam;

                //使用するカメラ番号
                main.WebCamNum = WebCamSelect.SelectedIndex;

                //メインシーン表示
                main.Show();

                //this.Close();
                //このフォームを隠し
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("使用できるカメラは0です");
            }
        }

        //ネットワークカメラを起動
        private void StartnetCamera_Click(object sender, EventArgs e)
        {
            //新しいメインシーン宣言
            MainScene main = new MainScene();

            //メインシーンフォーム位置を画面の真中にする
            main.StartPosition = FormStartPosition.CenterScreen;

            //このフォームの子にする
            main.Owner = this;

            //カメラモード設定
            main.Cmode = MainScene.CamMode.NetCam;

            //ネットワークカメラアドレス設定
            //main.CamTypeName = "http://"+UserID.Text+":"+ PassWord.Text+"@"+IpAdress.Text+ "/axis-cgi/mjpg/video.cgi";
            main.CamTypeName = "http://" + UserID.Text + ":" + PassWord.Text + "@" + IpAdress.Text + "/" + CGIConment.Text;

            //メインシーン表示
            main.Show();

            //このフォームを隠し
            this.Visible = false;
        }

        //Load
        private void OpenScene_Load(object sender, EventArgs e)
        {
            //使用できるWEBカメラ表示
            for (int i = 0; i < CameraNames.Count; i++)
            {
                WebCamSelect.Items.Add(CameraNames[i]);
            }

            //使用できるWEBカメラ0ではない
            if (CameraNames.Count > 0)
            {
                WebCamSelect.SelectedIndex = 0;
                //WebCamSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            //使用できるWEBカメラ0です
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
