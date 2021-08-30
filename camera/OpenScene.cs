using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

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

            //拡大ボタン機能OFF
            this.MaximizeBox = !this.MaximizeBox;
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

                main.version.Text = version.Text;

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

            main.version.Text = version.Text;

            //メインシーンフォーム位置を画面の真中にする
            main.StartPosition = FormStartPosition.CenterScreen;

            //このフォームの子にする
            main.Owner = this;

            //カメラモード設定
            main.Cmode = MainScene.CamMode.NetCam;

            //ネットワークカメラアドレス設定
            //main.CamTypeName = "http://"+UserID.Text+":"+ PassWord.Text+"@"+IpAdress.Text+ "/axis-cgi/mjpg/video.cgi";
            //ImageViewer?Resolution=640x480&Quality=Standard&Mode=Refresh&Interval=1
            //cgi-bin/camera?resolution=640*360
            main.CamTypeName = "http://" + UserID.Text + ":" + PassWord.Text + "@" + IpAdress.Text + "/" + CGIConment.Text;

            //今回使用したネットワークカメラのステータスを保存
            SaveIPCamStatus();

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

            //前回使ったネットワークカメラのステータスを読み込む
            LoadIpCamStatus();

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

        //ネットワークカメラステータス保存用関数
        private void SaveIPCamStatus()
        {
            string path = "CamStatus.bat";


            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(IpAdress.Text);
                sw.WriteLine(UserID.Text);
                sw.WriteLine(PassWord.Text);
                sw.WriteLine(CGIConment.Text);
            }

        }


        //ネットワークカメラステータス読み込み用関数
        private void LoadIpCamStatus()
        {
            string path = "CamStatus.bat";

            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string[] Getline = new string[4];
                    for (int i = 0; i < 4; i++)
                    {
                        Getline[i] = sr.ReadLine();
                    }

                    IpAdress.Text = Getline[0];
                    UserID.Text = Getline[1];
                    PassWord.Text = Getline[2];
                    CGIConment.Text = Getline[3];

                }
            }
        }

    }
}
