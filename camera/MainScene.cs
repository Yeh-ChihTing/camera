using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;


namespace camera
{
    /// <summary>
    /// Mainシーン
    /// </summary>
    public partial class MainScene : Form
    {
        //public変数

        /// <summary>
        /// カメラ横幅 
        /// </summary>
        public static readonly int Cam_Width = 640;
        /// <summary>
        /// カメラ縦幅
        /// </summary>
        public static readonly int Cam_Height = 360;
        /// <summary>
        /// 今のIMAGEを取る
        /// </summary>
        public Image GetCutPicNow = null;
        /// <summary>
        /// カメラサイズモード
        /// </summary>
        public enum CutSize             
        {
            OnehundredPer,//100%
            TwohundredPer,//200%
            FourhundredPer,//400%
            EighthundredPer//800%

        };
        
        /// <summary>
        /// カメラモード
        /// </summary>
        public enum CamMode　
        {
            WebCam,//WEBカメラ
            NetCam//ネットワークカメラ

        };
        /// <summary>
        /// カカメラモード宣言
        /// </summary>
        public CamMode Cmode;
        //public int bx, by, bw, bh;
        /// <summary>
        /// 今の倍率
        /// </summary>
        public int BMul = 1;
        /// <summary>
        /// Webカメラの番号
        /// </summary>
        public int WebCamNum = 0;
        /// <summary>
        /// カメラの名前
        /// </summary>
        public string CamTypeName;
        /// <summary>
        /// percent値計算用
        /// </summary>
        public double percentOfSusses = 0;
        /// <summary>
        /// 粋名リスト
        /// </summary>
        public List<string> BoxNameList = new List<string>();

        //private変数

        /// <summary>
        /// カメラ画面処理用
        /// </summary>
        private Mat img = new Mat();
        /// <summary>
        /// カメラ画面取得
        /// </summary>
        private VideoCapture vc;
        /// <summary>
        /// 検査用写真用空間
        /// </summary>
        private Image MasterImage=null;
        /// <summary>
        /// 一つ目の粋の宣言
        /// </summary>
        private MyBox box1;
        /// <summary>
        ///粋数
        /// </summary>
        private int BoxNum = 1;
        /// <summary>
        ///粋リスト
        /// </summary>
        private List<MyBox> MyBoxList = new List<MyBox>();

        /// <summary>
        ///ループボタン状態フラグ
        /// </summary>
        private bool LoopBtnFlag = true;

        /// <summary>
        ///ループフレーム
        /// </summary>
        private int LoopFrame = 100;

        /// <summary>
        ///音声プレイヤー
        /// </summary>
        private System.Media.SoundPlayer Player = null;
        /// <summary>
        ///合格音
        /// </summary>
        private string SussesSound = @"Sound\Answer.wav";
        /// <summary>
        ///不合格音
        /// </summary>
        private string FailSound = @"Sound\Wrong.wav";
        /// <summary>
        ///現在使用しているマスタ画像名
        /// </summary>
        private string SaveDataname;

        private bool StarChooseCol = false;
        private Color CheckCol;

        //List<Rectangle> BoxList = new List<Rectangle>();
        //int CamWidth;
        //int CamHeight;
        //private int RC;
        //private int GC;
        //private int BC;  
        public MainScene()
        {
            InitializeComponent();
            //this.Owner = null;
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            /// <summary>
            /// 初期化
            /// </summary>
            CSComboBox.SelectedIndex = (int)CutSize.OnehundredPer;
            box1 = new MyBox();
            CutPic.Controls.Add(box1);
            panel1.Controls.Add(CutPic);
            this.Controls.Add(panel1);
            MyBoxList.Add(box1);
            BoxNameCombo.SelectedIndex = 0;
            MyBoxList[0]._borderColor = Color.LightSeaGreen;
            MyBoxList[0].Invalidate();
            RedTrack.Value = MyBoxList[0].Red;
            GreenTrack.Value = MyBoxList[0].Green;
            BlueTrack.Value = MyBoxList[0].Blue;
            RSetText.Text = RedTrack.Value.ToString();
            GSetText.Text = GreenTrack.Value.ToString();
            BSetText.Text = BlueTrack.Value.ToString();
            int BoxPercent = MyBoxList[BoxNameCombo.SelectedIndex].MySPercent;
            SetSusscePercent.Text = BoxPercent.ToString();
            CheckMode.SelectedIndex = 0;
            
            /// <summary>
            /// 初期化END
            /// </summary>


            /// <summary>
            /// SaveDataフォルタ存在検査
            /// </summary>
            if (!Directory.Exists("SaveData"))
            {
                Directory.CreateDirectory("SaveData");
            }
            /// <summary>
            /// Pic
            /// </summary>
            if (!Directory.Exists("Pic"))
            {
                Directory.CreateDirectory("Pic");
            }

            /// <summary>
            /// カメラの稼働処理
            /// </summary>
            try
            {
                Task.Run(() =>
                {

                    //int X = CameraPic.Width;
                    //int Y = CameraPic.Height;
                    //CamWidth = CameraPic.Width;
                    //CamHeight = CameraPic.Height;
                    //byte[,] data = new byte[CamWidth, CamHeight];


                    if (Cmode == CamMode.WebCam)
                    {

                        vc = new VideoCapture(WebCamNum);
                        vc.Open(WebCamNum);
                        if (!vc.ConvertRgb)
                        {
                            MessageBox.Show("このカメラは使用できない");
                        }

                    }
                    else if (Cmode == CamMode.NetCam)
                    {
                        //using (vc = new VideoCapture("http://root:root@169.254.154.96/axis-cgi/mjpg/video.cgi")) ;
                        vc = new VideoCapture(CamTypeName);
                        vc.Open(CamTypeName);
                        if (!vc.ConvertRgb)
                        {
                            MessageBox.Show("このカメラは使用できない");
                        }
                    }

                    while (true)
                    {

                        //if (StartCam)
                        //{

                        //vc.Read(img);
                        img = vc.RetrieveMat();
                        CameraPic.Image = img.ToBitmap();
                        // }
                    }

                });

            }
            catch
            {

            }


        }


        /// <summary>
        ///数値変化チェックタイマー
        /// </summary>
        private void _数値変化チェック_Tick(object sender, EventArgs e)
        {
            /// <summary>
            /// 色合い値の表示
            /// </summary>
            Rtracktext.Text = RedTrack.Value.ToString();
            RSetText.Text = RedTrack.Value.ToString();
            //RC = RedTrack.Value;
            Gtracktext.Text = GreenTrack.Value.ToString();
            GSetText.Text = GreenTrack.Value.ToString();
            //GC = GreenTrack.Value;
            Btracktext.Text = BlueTrack.Value.ToString();
            BSetText.Text = BlueTrack.Value.ToString();
            //BC = BlueTrack.Value;

        }

        /// <summary>
        ///一回検査ボタン
        /// </summary>
        private void Check_Click(object sender, EventArgs e)
        {
            Check();
        }

        /// <summary>
        ///マスター画像選択ボタン
        /// </summary>
        private void GetPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fileStream = File.OpenRead(ofd.FileName))
                {
                    
                    // 画像データの検証なしで読み込む
                    Image image = Image.FromStream(fileStream, true, true);
 
                    MasterImage = image;

                    //
                    CutPic.Image = MasterImage;

                    SaveDataname = ofd.FileName;

                    //対象情報データある時の処理
                    string[] name = SaveDataname.Split('.');
                    string dataSpace= name[0] + ".bat";
                    if (File.Exists(dataSpace))
                    {
                        MyBoxList.Clear();
                        BoxNameCombo.Items.Clear();
                        CutPic.Controls.Clear();
                        BoxNameList.Clear();
                        int line_cnt = 0;
                        string line;
                        List<string> DataList = new List<string>();
                        using(StreamReader sr=new StreamReader(dataSpace))
                        {
                            // ファイルの内容を1行ずつ読み込み
                            while ((line = sr.ReadLine()) != null)
                            {
                                line_cnt++;
                                //Console.WriteLine("{0}行目:{1}", line_cnt, line);
                                // Listに追加
                                DataList.Add(line);
                            }
                        }

                        int nums = Convert.ToInt32(DataList[0]);

                        for(int i = 0; i < nums; i++)
                        {
                            MyBox box = new MyBox();
                            CutPic.Controls.Add(box);
                            //name
                            string[] names = DataList[(i * 8) + 1].Split(':');
                            box.MyNumber.Text = names[1];
                            BoxNameList.Add(names[1]);
                            MyBoxList.Add(box);                           
                            BoxNameCombo.Items.Add(names[1]);
                            //pos
                            string[] Posstr = DataList[(i * 8) + 2].Split(':',',');
                            int PosX = Convert.ToInt32(Posstr[1]);
                            int PosY = Convert.ToInt32(Posstr[2]);
                            box.Location = new System.Drawing.Point(PosX, PosY);
                            //size
                            string[] Size = DataList[(i * 8) + 3].Split(':', ',');
                            int w = Convert.ToInt32(Size[1]);
                            int h = Convert.ToInt32(Size[2]);
                            box.Size = new System.Drawing.Size(w, h);
                            //BoxCheck
                            string Checked = DataList[(i * 8) + 4];
                            if (Checked == "BoxCheckedFalse")
                            {
                                box.BoxChecked = false;
                            }
                            else if(Checked == "BoxCheckedTrue")
                            {
                                box.BoxChecked = true;
                            }
                            //RGB
                            string[] col = DataList[(i * 8) + 5].Split(':', ',');
                            int SR = Convert.ToInt32(col[1]);
                            int SG = Convert.ToInt32(col[2]);
                            int SB = Convert.ToInt32(col[3]);
                            box.Red = SR;
                            box.Green = SG;
                            box.Blue = SB;
                            //%
                            string[] SPercent = DataList[(i * 8) + 6].Split(':', ',');
                            box.MySPercent = Convert.ToInt32(SPercent[1]);
                            //Mode
                            string[] Smode = DataList[(i * 8) + 7].Split(':', ',');
                            box.MyBoxMode = (MyBox.BoxMode)Convert.ToInt32(Smode[1]);
                            //checkBox
                            string[] SCheckBoxCol = DataList[(i * 8) + 8].Split(':', ',');
                            box.UsedCol = Color.FromArgb(Convert.ToInt32(SCheckBoxCol[1]), Convert.ToInt32(SCheckBoxCol[2])
                                , Convert.ToInt32(SCheckBoxCol[3]));
                        }

                        BoxNameCombo.SelectedIndex = 0;
                    }
                 
                    //ChangePic.Image = MasterImage;
                }
              
            }

            GetCutPicNow = CutPic.Image; 
            
        }

        /// <summary>
        ///カメラ画像を保存
        /// </summary>
        private void SavePicBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "newMaster";
            sfd.Filter = "JPEG形式|*.jpg";

            string dc = Directory.GetCurrentDirectory()+@"\Pic";
            sfd.InitialDirectory = dc;
            


            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    //img.SaveImage(sfd.FileName);
                    Bitmap bmp = new Bitmap(img.ToBitmap());
                    bmp.Save(sfd.FileName, ImageFormat.Jpeg);

                    if (CutPic.Image == null)
                    {
                        CutPic.Image = bmp;
                        MasterImage = CutPic.Image;

                        GetCutPicNow = CutPic.Image;
                    }

                    SaveDataname = sfd.FileName;
                }
                catch (NullReferenceException a)
                {
                    MessageBox.Show(a.ToString());
                }
            }
        }

        /// <summary>
        ///マスター画像サイズ変更処理
        /// </summary>
        private void CSComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.Control;
            for (int i = 0; i < MyBoxList.Count; i++)
            {
                MyBoxList[i].Drawbox.Visible = false;
                //MyBoxList[i].Drawbox.BackColor = Color.Transparent;
            }

            try
            {
                //100%
                if (CSComboBox.SelectedIndex == (int)CutSize.OnehundredPer)
                {
                    CutPic.Width = Cam_Width;
                    CutPic.Height = Cam_Height;

                    if (MasterImage != null)
                    {
                        double[] bx = new double[MyBoxList.Count];
                        double[] by = new double[MyBoxList.Count];
                        double[] bw = new double[MyBoxList.Count];
                        double[] bh = new double[MyBoxList.Count];

                        GetNowBoxStatus(bx, by, bw, bh);
                        // Image GetCutPic = CutPic.Image;
                        CutPic.Image = new Bitmap(CutPic.Width, CutPic.Height);

                        using (var bmp = new Bitmap(GetCutPicNow))
                        using (var g = Graphics.FromImage(CutPic.Image))
                        {
                            // 補間モードの設定（各画素が見えるように） 
                            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                            // 描画  
                            g.DrawImage(bmp, 0, 0, Cam_Width, Cam_Height);
                        }

                        for (int i = 0; i < MyBoxList.Count; i++)
                        {
                            double x, y;
                            x =Math.Round(bx[i] / BMul);
                            y= Math.Round(by[i] / BMul);
                            MyBoxList[i].Location = new System.Drawing.Point((int)x,(int)y);
                            MyBoxList[i].Width = (int)Math.Round(bw[i] / BMul);
                            MyBoxList[i].Height = (int)Math.Round(bh[i] / BMul);
                           
                        }
                        //box1.Location = new System.Drawing.Point(bx / 2, by / 2);
                        //box1.Width = bw / 2;
                        //box1.Height = bh / 2;
                      
                    }

                    BMul = 1;
                    //for (int i = 0; i < MyBoxList.Count; i++)
                    //{
                    //    MyBoxList[i].setBottonRight(BMul);
                    //}

                }

                //200%
                if (CSComboBox.SelectedIndex == (int)CutSize.TwohundredPer)
                {
                    double[] bx = new double[MyBoxList.Count];
                    double[] by = new double[MyBoxList.Count];
                    double[] bw = new double[MyBoxList.Count];
                    double[] bh = new double[MyBoxList.Count];

                    GetNowBoxStatus(bx, by, bw, bh);


                    CutPic.Width = Cam_Width * 2;
                    CutPic.Height = Cam_Height * 2;

                    CutPic.Image = new Bitmap(CutPic.Width, CutPic.Height);

                    using (var bmp = new Bitmap(GetCutPicNow))
                    using (var g = Graphics.FromImage(CutPic.Image))
                    {
                        // 補間モードの設定（各画素が見えるように） 
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                        // 描画  
                        g.DrawImage(
                              bmp,
                              new RectangleF(0f, 0f, bmp.Width * 2, bmp.Height * 2),
                              new RectangleF(0, 0, bmp.Width, bmp.Height),
                              GraphicsUnit.Pixel);
                    }

                    for (int i = 0; i < MyBoxList.Count; i++)
                    {
                        if (BMul == 1)
                        {
                           
                            MyBoxList[i].Location = new System.Drawing.Point((int)bx[i] * 2, (int)by[i] * 2);
                            MyBoxList[i].Width = (int)bw[i] * 2;
                            MyBoxList[i].Height = (int)bh[i] * 2;
                        }

                        if (BMul == 4)
                        {
                            double x, y;
                            x = Math.Round(bx[i] /2);
                            y = Math.Round(by[i] / 2);
                            MyBoxList[i].Location = new System.Drawing.Point((int)x, (int)y);
                            MyBoxList[i].Width =(int)Math.Round(bw[i] / 2);
                            MyBoxList[i].Height = (int)Math.Round(bh[i] / 2);
                        }

                        if (BMul == 8)
                        {
                            double x, y;
                            x = Math.Round(bx[i] / 4);
                            y = Math.Round(by[i] / 4);
                            MyBoxList[i].Location = new System.Drawing.Point((int)x, (int)y);
                            MyBoxList[i].Width = (int)Math.Round(bw[i] / 4);
                            MyBoxList[i].Height = (int)Math.Round(bh[i] / 4);
                        }

                    }
                    BMul = 2;
                    //for (int i = 0; i < MyBoxList.Count; i++)
                    //{
                    //    MyBoxList[i].setBottonRight(BMul);
                    //}
                }

                //400%
                if (CSComboBox.SelectedIndex == (int)CutSize.FourhundredPer)
                {
                    double[] bx = new double[MyBoxList.Count];
                    double[] by = new double[MyBoxList.Count];
                    double[] bw = new double[MyBoxList.Count];
                    double[] bh = new double[MyBoxList.Count];

                    GetNowBoxStatus(bx, by, bw, bh);

                    //Image GetCutPic = CutPic.Image;
                    CutPic.Width = Cam_Width * 4;
                    CutPic.Height = Cam_Height * 4;

                    CutPic.Image = new Bitmap(CutPic.Width, CutPic.Height);

                    using (var bmp = new Bitmap(GetCutPicNow))
                    using (var g = Graphics.FromImage(CutPic.Image))
                    {
                        // 補間モードの設定（各画素が見えるように） 
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                        // 描画  
                        g.DrawImage(
                              bmp,
                              new RectangleF(0f, 0f, bmp.Width * 4, bmp.Height * 4),
                              new RectangleF(0, 0, bmp.Width, bmp.Height),
                              GraphicsUnit.Pixel);
                    }

                    for (int i = 0; i < MyBoxList.Count; i++)
                    {
                        if (BMul == 1)
                        {
                            MyBoxList[i].Location = new System.Drawing.Point((int)bx[i] * 4, (int)by[i] * 4);
                            MyBoxList[i].Width = (int)bw[i] * 4;
                            MyBoxList[i].Height = (int)bh[i] * 4;
                        }

                        if (BMul == 2)
                        {
                            MyBoxList[i].Location = new System.Drawing.Point((int)bx[i] * 2, (int)by[i] * 2);
                            MyBoxList[i].Width = (int)bw[i] * 2;
                            MyBoxList[i].Height = (int)bh[i] * 2;
                        }

                        if (BMul == 8)
                        {
                            double x, y;
                            x = Math.Round(bx[i] / 2);
                            y = Math.Round(by[i] / 2);
                            MyBoxList[i].Location = new System.Drawing.Point((int)x, (int)y);
                            MyBoxList[i].Width = (int)Math.Round(bw[i] / 2);
                            MyBoxList[i].Height = (int)Math.Round(bh[i] / 2);
                        }

                    }

                    BMul = 4;
                    //for (int i = 0; i < MyBoxList.Count; i++)
                    //{
                    //    MyBoxList[i].setBottonRight(BMul);
                    //}
                }

                //800%
                if (CSComboBox.SelectedIndex == (int)CutSize.EighthundredPer)
                {
                    double[] bx = new double[MyBoxList.Count];
                    double[] by = new double[MyBoxList.Count];
                    double[] bw = new double[MyBoxList.Count];
                    double[] bh = new double[MyBoxList.Count];


                    GetNowBoxStatus(bx, by, bw, bh);

                    //Image GetCutPic = CutPic.Image;
                    CutPic.Width = Cam_Width * 8;
                    CutPic.Height = Cam_Height * 8;

                    CutPic.Image = new Bitmap(CutPic.Width, CutPic.Height);

                    using (var bmp = new Bitmap(GetCutPicNow))
                    using (var g = Graphics.FromImage(CutPic.Image))
                    {
                        // 補間モードの設定（各画素が見えるように） 
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                        //描画  
                        g.DrawImage(
                              bmp,
                              new RectangleF(0f, 0f, bmp.Width * 8, bmp.Height * 8),
                              new RectangleF(0, 0, bmp.Width, bmp.Height),
                              GraphicsUnit.Pixel);
                    }

                    for (int i = 0; i < MyBoxList.Count; i++)
                    {
                        if (BMul == 1)
                        {
                            MyBoxList[i].Location = new System.Drawing.Point((int)bx[i] * 8, (int)by[i] * 8);
                            MyBoxList[i].Width = (int)bw[i] * 8;
                            MyBoxList[i].Height = (int)bh[i] * 8;
                        }

                        if (BMul == 2)
                        {
                            MyBoxList[i].Location = new System.Drawing.Point((int)bx[i] * 4, (int)by[i] * 4);
                            MyBoxList[i].Width = (int)bw[i] * 4;
                            MyBoxList[i].Height = (int)bh[i] * 4;
                        }

                        if (BMul == 4)
                        {
                            MyBoxList[i].Location = new System.Drawing.Point((int)bx[i] * 2, (int)by[i] * 2);
                            MyBoxList[i].Width = (int)bw[i] * 2;
                            MyBoxList[i].Height = (int)bh[i] * 2;
                        }

                    }

                    BMul = 8;
                    //for (int i = 0; i < MyBoxList.Count; i++)
                    //{
                    //    MyBoxList[i].setBottonRight(BMul);
                    //}
                }
            }
            catch
            {
                MessageBox.Show("お先に画像を選択してください");
            }
        }

        /// <summary>
        ///粋の位置とサイズを取得
        /// </summary>
        public void GetNowBoxStatus(double[] x, double[] y, double[] w, double[] h)
        {
            for (int i = 0; i < MyBoxList.Count; i++)
            {
                x[i] = MyBoxList[i].Location.X;
                y[i] = MyBoxList[i].Location.Y;
                w[i] = MyBoxList[i].Width;
                h[i] = MyBoxList[i].Height;
            }
        }

        /// <summary>
        ///粋の増加ボタン
        /// </summary>
        private void AddBox_Click(object sender, EventArgs e)
        {
            BoxNum++;
            MyBox box = new MyBox();
            CutPic.Controls.Add(box);
            box.MyNumber.Text = BoxNum.ToString(); ;
            MyBoxList.Add(box);
            BoxNameCombo.Items.Add(BoxNum.ToString());
        }

        /// <summary>
        ///粋の消すボタン
        /// </summary>
        private void DelectBox_Click(object sender, EventArgs e)
        {
            //GetCutPic();
            //Graphics g = Graphics.FromImage(BoxList[0]);
            if (MyBoxList.Count > 1)
            {            
                MyBoxList.RemoveAt(BoxNameCombo.SelectedIndex);
                CutPic.Controls.RemoveAt(BoxNameCombo.SelectedIndex);
                BoxNum--;
                
                if (BoxNameList.Count == 0)
                {
                    BoxNameCombo.Items.Clear();
                    for (int i = 0; i < BoxNum; i++)
                    {
                        MyBoxList[i].MyNumber.Text = (i + 1).ToString();
                        BoxNameCombo.Items.Add((i + 1).ToString());
                    }
                }
                else
                {
                    if (BoxNameCombo.SelectedIndex < BoxNameList.Count)
                    {
                        BoxNameList.RemoveAt(BoxNameCombo.SelectedIndex);
                    }
                    BoxNameCombo.Items.Clear();
                   
                    for (int i = 0; i < BoxNum; i++)
                    {
                        
                        if (i < BoxNameList.Count - 1 && BoxNameList[i] != "")
                        {
                           
                            if (i < BoxNameList.Count-1)
                            {
                                MyBoxList[i].MyNumber.Text = BoxNameList[i];
                                BoxNameCombo.Items.Add(BoxNameList[i]);
                            }
                            else
                            {
                                MyBoxList[i].MyNumber.Text = (i + 1).ToString();
                                BoxNameCombo.Items.Add((i + 1).ToString());
                            }
                        }
                        else
                        {
                            MyBoxList[i].MyNumber.Text = (i + 1).ToString();
                            BoxNameCombo.Items.Add((i + 1).ToString());                           
                        }
                    }

                    
                }
                BoxNameCombo.SelectedIndex = 0;
                //for (int i = 0; i < MyBoxList.Count; i++)
                //{

                //    Bitmap bmpC = new Bitmap(CutPic.Width, CutPic.Height);
                //    Graphics gc = Graphics.FromImage(bmpC);

                //    Rectangle CutRect = new Rectangle(0, 0, CutPic.Width, CutPic.Height);
                //    gc.DrawImage(CutPic.Image, CutRect, CutRect, GraphicsUnit.Pixel);
                //    gc.DrawRectangle(Pens.Blue, MyBoxList[i]);
                //    CutPic.Image = bmpC;
                //}


            }
            //BoxList.Clear();
        }

        /// <summary>
        ///CSVデータ保存
        /// </summary>
        private void SaveDataOnCsv(bool[] ok)
        {
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            string Path = "SaveData/" + dt.Year + "." + dt.Month + "." + dt.Day + "監視データ.csv";
            //DataTable dt;
            StreamWriter sw;
            if (!File.Exists(Path))
            {
                sw = new StreamWriter(Path, false, Encoding.GetEncoding("utf-8"));
                sw.WriteLine(DateTime.Now);
                for (int i = 0; i < ok.Length; i++)
                {
                    if (BoxNameList.Count == 0)
                    {
                        if (ok[i])
                        {
                            if (MyBoxList[i].MyBoxMode ==MyBox.BoxMode.Samontape)
                            {
                                sw.WriteLine((i + 1).ToString() + "," + "温度正常");
                            }
                            else if (MyBoxList[i].MyBoxMode == MyBox.BoxMode.LampOn)
                            {
                                sw.WriteLine((i + 1).ToString() + "," + "点灯");
                            }
                            else if (MyBoxList[i].MyBoxMode == MyBox.BoxMode.LampOff)
                            {
                                sw.WriteLine((i + 1).ToString() + "," + "消灯");
                            }
                        }
                        else
                        {
                            if (MyBoxList[i].MyBoxMode == 0)
                            {
                                sw.WriteLine((i + 1).ToString() + "," + "温度高");
                            }
                            else if (MyBoxList[i].MyBoxMode == MyBox.BoxMode.LampOn)
                            {
                                sw.WriteLine((i + 1).ToString() + "," + "消灯");
                            }
                            else if (MyBoxList[i].MyBoxMode == MyBox.BoxMode.LampOff)
                            {
                                sw.WriteLine((i + 1).ToString() + "," + "点灯");
                            }
                        }
                    }
                    else
                    {
                        if (ok[i])
                        {
                            if (MyBoxList[i].MyBoxMode == 0)
                            {
                                sw.WriteLine(BoxNameList[i] + "," + "温度正常");
                            }
                            else if (MyBoxList[i].MyBoxMode == MyBox.BoxMode.LampOn)
                            {
                                sw.WriteLine(BoxNameList[i] + ","  + "点灯");
                            }
                            else if (MyBoxList[i].MyBoxMode == MyBox.BoxMode.LampOff)
                            {
                                sw.WriteLine(BoxNameList[i] + ","  + "," + "消灯");
                            }

                        }
                        else
                        {
                            if (MyBoxList[i].MyBoxMode == 0)
                            {
                                sw.WriteLine(BoxNameList[i] + "," + "温度高");
                            }
                            else if (MyBoxList[i].MyBoxMode == MyBox.BoxMode.LampOn)
                            {
                                sw.WriteLine(BoxNameList[i] + "," + "," + "消灯");
                            }
                            else if (MyBoxList[i].MyBoxMode == MyBox.BoxMode.LampOff)
                            {
                                sw.WriteLine(BoxNameList[i] + "," + "," + "点灯");
                            }
                        }
                    }
                }               
            }
            else
            {
               // Excel.Application excelApp;

                
                sw = File.AppendText(Path);

                //excelApp =new Excel.Application();

             
                ////Excel 起動しているなら終了したいです
                //if (!excelApp.Visible)
                //{
                //    excelApp.Quit();
                //}
               

                sw.WriteLine(DateTime.Now);
                for (int i = 0; i < ok.Length; i++)
                {
                    if (BoxNameList.Count == 0)
                    {
                        if (ok[i])
                        {
                            if (MyBoxList[i].MyBoxMode == MyBox.BoxMode.Samontape)
                            {
                                sw.WriteLine((i + 1).ToString() + "," + "温度正常");
                            }
                            else if (MyBoxList[i].MyBoxMode == MyBox.BoxMode.LampOn)
                            {
                                sw.WriteLine((i + 1).ToString() + "," + "点灯");
                            }
                            else if (MyBoxList[i].MyBoxMode == MyBox.BoxMode.LampOff)
                            {
                                sw.WriteLine((i + 1).ToString() + "," + "消灯");
                            }
                        }
                        else
                        {
                            if (MyBoxList[i].MyBoxMode == 0)
                            {
                                sw.WriteLine((i + 1).ToString() + "," + "温度高");
                            }
                            else if (MyBoxList[i].MyBoxMode == MyBox.BoxMode.LampOn)
                            {
                                sw.WriteLine((i + 1).ToString() + "," + "消灯");
                            }
                            else if (MyBoxList[i].MyBoxMode == MyBox.BoxMode.LampOff)
                            {
                                sw.WriteLine((i + 1).ToString() + "," + "点灯");
                            }
                        }
                    }
                    else
                    {
                        if (ok[i])
                        {
                            if (MyBoxList[i].MyBoxMode == 0)
                            {
                                sw.WriteLine(BoxNameList[i] + "," + "温度正常");
                            }
                            else if (MyBoxList[i].MyBoxMode == MyBox.BoxMode.LampOn)
                            {
                                sw.WriteLine(BoxNameList[i] + "," + "点灯");
                            }
                            else if (MyBoxList[i].MyBoxMode == MyBox.BoxMode.LampOff)
                            {
                                sw.WriteLine(BoxNameList[i] + "," + "," + "消灯");
                            }

                        }
                        else
                        {
                            if (MyBoxList[i].MyBoxMode == 0)
                            {
                                sw.WriteLine(BoxNameList[i] + "," + "温度高");
                            }
                            else if (MyBoxList[i].MyBoxMode == MyBox.BoxMode.LampOn)
                            {
                                sw.WriteLine(BoxNameList[i] + "," + "," + "消灯");
                            }
                            else if (MyBoxList[i].MyBoxMode == MyBox.BoxMode.LampOff)
                            {
                                sw.WriteLine(BoxNameList[i] + "," + "," + "点灯");
                            }
                        }
                    }
                }
            }

            sw.Close();
        }

        /// <summary>
        ///粋名設定ボタン
        /// </summary>
        private void SettingName_Click(object sender, EventArgs e)
        {
            SettingBoxName SBN = new SettingBoxName();
            SBN.Owner = this;
            SBN.Boxnum = MyBoxList.Count;

            //if (Boxname.Count != 0)
            //{
            //    for (int i = 0; i < Boxname.Count; i++)
            //    {
            //        SBN.TextBox[i].Text = Boxname[i];
            //    }
            //}
            SBN.ShowDialog();


            BoxNameList.Clear();
            BoxNameCombo.Items.Clear();
            for (int i = 0; i < SBN.TextBox.Count; i++)
            {
                BoxNameList.Add(SBN.TextBox[i].Text);
                if (SBN.TextBox[i].Text !="")
                {
                    BoxNameCombo.Items.Add(SBN.TextBox[i].Text);
                    MyBoxList[i].MyNumber.Text = SBN.TextBox[i].Text;

                }
                else
                {
                    BoxNameCombo.Items.Add((i+1).ToString());
                    MyBoxList[i].MyNumber.Text = (i + 1).ToString();
                }
            }

            BoxNameCombo.SelectedIndex = 0;

        }

        /// <summary>
        ///粋選択したイベント
        /// </summary>
        private void BoxNameCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            for(int i = 0; i < MyBoxList.Count; i++)
            {
                MyBoxList[i]._borderColor = Color.Blue;
                MyBoxList[i].Invalidate();
            }
            MyBoxList[BoxNameCombo.SelectedIndex]._borderColor = Color.LightSeaGreen;

            MyBoxList[BoxNameCombo.SelectedIndex].Invalidate();
            RedTrack.Value = MyBoxList[BoxNameCombo.SelectedIndex].Red;
            GreenTrack.Value = MyBoxList[BoxNameCombo.SelectedIndex].Green;
            BlueTrack.Value = MyBoxList[BoxNameCombo.SelectedIndex].Blue;

            RSetText.Text = RedTrack.Value.ToString();
            GSetText.Text = GreenTrack.Value.ToString();
            BSetText.Text = BlueTrack.Value.ToString();

            int BoxPercent = MyBoxList[BoxNameCombo.SelectedIndex].MySPercent;
            SetSusscePercent.Text = BoxPercent.ToString();
            CheckMode.SelectedIndex = (int)MyBoxList[BoxNameCombo.SelectedIndex].MyBoxMode;

            UseThisCol.Checked = MyBoxList[BoxNameCombo.SelectedIndex].BoxChecked;

            BoxSetting.Text = BoxNameCombo.SelectedItem.ToString() + "の設定";

            UseCol.BackColor = MyBoxList[BoxNameCombo.SelectedIndex].UsedCol;
        }

        /// <summary>
        ///RGB値の変更
        /// </summary>

        /// <summary>
        ///R値変更
        /// </summary>
        private void RedTrack_ValueChanged(object sender, EventArgs e)
        {

            MyBoxList[BoxNameCombo.SelectedIndex].Red = RedTrack.Value;

        }

        /// <summary>
        ///G値変更
        /// </summary>
        private void GreenTrack_ValueChanged(object sender, EventArgs e)
        {

            MyBoxList[BoxNameCombo.SelectedIndex].Green = GreenTrack.Value;

        }

        /// <summary>
        ///B値変更
        /// </summary>
        private void BlueTrack_ValueChanged(object sender, EventArgs e)
        {

            MyBoxList[BoxNameCombo.SelectedIndex].Blue = BlueTrack.Value;

        }

        /// <summary>
        ///RGB値の変更END
        /// </summary>

        /// <summary>
        ///formにマウスクリック
        /// </summary>
        private void MainScene_MouseClick(object sender, MouseEventArgs e)
        {

        }

        /// <summary>
        ///連続チェックボタン
        /// </summary>
        private void CheckLoopBtn_Click(object sender, EventArgs e)
        {

            if (LoopBtnFlag)
            {
                
                CheckLoopBtn.Text = "停止";
                CheckLoopBtn.BackColor = Color.Pink;
                //Cheack();
                LoopFrame = (Convert.ToInt32(HourText.Text)*36000) + (Convert.ToInt32(MinText.Text)*6000) 
                    + (Convert.ToInt32(SecText.Text)*1000);
                if (LoopFrame != 0)
                {
                    LoopTimer.Enabled = true;
                    LoopTimer.Interval = LoopFrame;
                    Check();
                }
                else
                {
                    MessageBox.Show("0間隔連続チェックはできないです、時間を入力してください");
                    LoopTimer.Enabled = false;
                    CheckLoopBtn.Text = "連続チェック";
                    CheckLoopBtn.BackColor = SystemColors.Control;
                }

               
            }

            else
            {
                LoopTimer.Enabled = false;
                CheckLoopBtn.Text = "連続チェック";
                CheckLoopBtn.BackColor = SystemColors.Control;
                this.BackColor = SystemColors.Control;
                for(int i = 0; i < MyBoxList.Count; i++)
                {
                    MyBoxList[i].Drawbox.Visible = false;
                    //MyBoxList[i].Drawbox.BackColor = Color.Transparent;
                }
            }


            LoopBtnFlag = !LoopBtnFlag;
        }

        /// <summary>
        ///チェック用関数
        /// </summary>
        private void Check()
        {
            try
            {
                CSComboBox.SelectedIndex = (int)CutSize.OnehundredPer;

                Bitmap Origin = (Bitmap)CameraPic.Image.Clone();
                Bitmap CheackBT = (Bitmap)MasterImage.Clone();
                int OR=0, OG=0, OB=0, CR, CG, CB;
                bool[] OkOrFail = new bool[MyBoxList.Count];
                for (int i = 0; i < OkOrFail.Length; i++)
                {
                    OkOrFail[i] = true;

                }

                bool haveFail = false;

                CheckPerList.Items.Clear();

                for (int k = 0; k < MyBoxList.Count; k++)
                {

                    int X = MyBoxList[k].Location.X;
                    int SizeX = X + (MyBoxList[k].Width);
                    int Y = MyBoxList[k].Location.Y;
                    int SizeY = Y + (MyBoxList[k].Height);

                    int RightNum = 0;

                    

                    Bitmap bmp = new Bitmap(MyBoxList[k].Width, MyBoxList[k].Height);

                    Graphics g = Graphics.FromImage(bmp);

                    Rectangle srcRect = new Rectangle(X, Y, MyBoxList[k].Width, MyBoxList[k].Height);
                    //描画する部分の範囲を決定する
                    Rectangle desRect = new Rectangle(0, 0, MyBoxList[k].Width, MyBoxList[k].Width);
                    //画像の一部を描画する
                    g.DrawImage(MasterImage, desRect, srcRect, GraphicsUnit.Pixel);

                    //Graphicsオブジェクトのリソースを解放する
                    g.Dispose();

                    MyBoxList[k].Drawbox.Visible = true;
                    //PictureBox1に表示する
                    MyBoxList[k].Drawbox.Image = bmp;
                    MyBoxList[k].Drawbox.Location = new System.Drawing.Point(3,3);
                    MyBoxList[k].Drawbox.Width = MyBoxList[k].Width-6;
                    MyBoxList[k].Drawbox.Height = MyBoxList[k].Height - 6;

                    for (int i = X; i < SizeX; i++)
                    {
                        for (int j = Y; j < SizeY; j++)
                        {

                            if (!MyBoxList[k].BoxChecked)
                            {
                                OR = Origin.GetPixel(i, j).R;
                                OG = Origin.GetPixel(i, j).G;
                                OB = Origin.GetPixel(i, j).B;
                            }
                            else
                            {
                                OR = CheckCol.R;
                                OG = CheckCol.G;
                                OB = CheckCol.B;
                            }
                            CR = CheackBT.GetPixel(i, j).R;
                            CG = CheackBT.GetPixel(i, j).G;
                            CB = CheackBT.GetPixel(i, j).B;
                            if ((CR <= OR + MyBoxList[k].Red && CR >= OR - MyBoxList[k].Red) &&
                                (CG <= OG + MyBoxList[k].Green && CG >= OG - MyBoxList[k].Green) &&
                                (CB <= OB + MyBoxList[k].Blue && CB >= OB - MyBoxList[k].Blue))
                            {

                                OkOrFail[k] = true;
                                bmp.SetPixel(i - X, j - Y, Color.Green);
                                MyBoxList[k].ChangeColor(Color.Blue);
                                RightNum++;
                            }
                            else
                            {
                                //haveFail = true;
                                //OkOrFail[k] = false;
                                //MyBoxList[k].ChangeColor(Color.Red);
                                break;
                            }
                        }

                    }

                    MyBoxList[k].Drawbox.Image = bmp;
                    percentOfSusses = ((double)RightNum / ((double)MyBoxList[k].Width * (double)MyBoxList[k].Height)) * 100.0;
                    int Getpercent = (int)percentOfSusses;
                    int BoxPercent = MyBoxList[k].MySPercent;

                    if (BoxNameList.Count > 0)
                    {
                        if (BoxNameList[k] != "")
                        {
                            CheckPerList.Items.Add(BoxNameList[k] + " : " + Getpercent.ToString() + "%"
                                +"/ "+ BoxPercent.ToString()+"%" + " 一致");
                        }
                        else
                        {
                            CheckPerList.Items.Add((k+1).ToString() + " : " + Getpercent.ToString() + "%"
                                + "/" + BoxPercent.ToString() + "%" + " 一致");
                        }
                    }
                    else
                    {
                        CheckPerList.Items.Add((k + 1).ToString() + " : " + Getpercent.ToString() + "%"
                                +"/"+ BoxPercent.ToString()+ "%" + " 一致");
                    }
                    // GetPercent.Text = Getpercent.ToString();
                    if (percentOfSusses < BoxPercent)
                    {
                        MyBoxList[k].ChangeColor(Color.Red);
                        haveFail = true;
                        OkOrFail[k] = false;
                    }

                    
                }

            if (!haveFail)
            {
                if (LoopBtnFlag)
                {
                    Player = new System.Media.SoundPlayer(SussesSound);
                    Player.Play();
                }
                this.BackColor = Color.Green;
                //DrawCheak();
                //Ans.Text = "OK";
            }
            else
            {
                Player = new System.Media.SoundPlayer(FailSound);
                Player.Play();
                this.BackColor = Color.Red;
                //Ans.Text = "FAIL";
            }

                SaveDataOnCsv(OkOrFail);
            }
            catch
            {
                MessageBox.Show("画像データを選択してください");
            }
        }

        /// <summary>
        ///入力を数字に限定用関数
        /// </summary>
        private void OnlyInputNum(object sender,KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        ///ループ
        /// </summary>
        private void LoopTimer_Tick(object sender, EventArgs e)
        {
            Check();
        }

        /// <summary>
        ///RsetText入力したイベント
        /// </summary>
        private void RSetText_TextChanged(object sender, EventArgs e)
        {
            TextBox text = (TextBox)sender;
            if (text.Text != "")
            {
                if (Convert.ToInt32(text.Text) < 0 || Convert.ToInt32(text.Text) > 255)
                {
                    MessageBox.Show("0~255にしてください");
                    if (Convert.ToInt32(text.Text) > 255)
                    {
                        text.Text = "255";
                    }
                    else if (Convert.ToInt32(text.Text) < 0)
                    {
                        text.Text = "0";
                    }
                }
                else
                {
                    RedTrack.Value = Convert.ToInt32(text.Text);

                }
            }
        }

        /// <summary>
        ///GsetText入力したイベント
        /// </summary>
        private void GSetText_TextChanged(object sender, EventArgs e)
        {
            TextBox text = (TextBox)sender;
            if (text.Text != "")
            {
                if (Convert.ToInt32(text.Text) < 0 || Convert.ToInt32(text.Text) > 255)
                {
                    MessageBox.Show("0~255にしてください");
                    if (Convert.ToInt32(text.Text) > 255)
                    {
                        text.Text = "255";
                    }
                    else if (Convert.ToInt32(text.Text) < 0)
                    {
                        text.Text = "0";
                    }
                }
                else
                {
                    GreenTrack.Value = Convert.ToInt32(text.Text);

                }
            }
        }

        /// <summary>
        ///BsetText入力したイベント
        /// </summary>
        private void BSetText_TextChanged(object sender, EventArgs e)
        {
            TextBox text = (TextBox)sender;
            if (text.Text != "")
            {
                if (Convert.ToInt32(text.Text) < 0 || Convert.ToInt32(text.Text) > 255)
                {
                    MessageBox.Show("0~255にしてください");
                    if (Convert.ToInt32(text.Text) > 255)
                    {
                        text.Text = "255";
                    }
                    else if (Convert.ToInt32(text.Text) < 0)
                    {
                        text.Text = "0";
                    }
                }
                else
                {
                    BlueTrack.Value = Convert.ToInt32(text.Text);

                }
            }
        }

        /// <summary>
        ///SetSusscePercent入力したイベント
        /// </summary>
        private void SetSusscePercent_TextChanged(object sender, EventArgs e)
        {
            TextBox text = (TextBox)sender;
            if (text.Text != "")
            {
                if (Convert.ToInt32(text.Text) < 0 || Convert.ToInt32(text.Text) > 100)
                {
                    MessageBox.Show("0~100にしてください");
                    if (Convert.ToInt32(text.Text) > 100)
                    {
                        text.Text = "100";
                    }
                    else if (Convert.ToInt32(text.Text) < 0)
                    {
                        text.Text = "0";
                    }
                }
                else
                {
                    MyBoxList[BoxNameCombo.SelectedIndex].MySPercent = Convert.ToInt32(text.Text);
                }
            }
        }

        /// <summary>
        ///検査結果画面クリアボタン
        /// </summary>
        private void ClearCheckScene_Click(object sender, EventArgs e)
        {
           
            this.BackColor = SystemColors.Control;
            for (int i = 0; i < MyBoxList.Count; i++)
            {
                MyBoxList[i].Drawbox.Visible = false;
                //MyBoxList[i].Drawbox.BackColor = Color.Transparent;
            }
        }

        private void CheckMode_SelectedValueChanged(object sender, EventArgs e)
        {
            MyBoxList[BoxNameCombo.SelectedIndex].MyBoxMode = (MyBox.BoxMode)CheckMode.SelectedIndex;
        }

        /// <summary>
        /// フォーム閉める時
        /// </summary>
        private void MainScene_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("対象情報を保存しますか？ ", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SaveBoxSetting();
            }

            this.Owner.Visible = true;
            
        }

        /// <summary>
        /// ボックス情報保存関数
        /// </summary>
        private void SaveBoxSetting()
        {
            if (CutPic.Image != null)
            {
                string[] name = SaveDataname.Split('.');
                string Path = name[0] + ".bat";
                if (SaveDataname != "")
                {
                    using (StreamWriter sw = new StreamWriter(Path, false, Encoding.GetEncoding("utf-8")))
                    {
                        sw.WriteLine(BoxNum.ToString());
                        for (int i = 0; i < BoxNum; i++)
                        {
                            sw.WriteLine("name:" + BoxNameCombo.Items[i].ToString());
                            sw.WriteLine("pos:" + MyBoxList[i].Location.X + "," + MyBoxList[i].Location.Y);
                            sw.WriteLine("size:" + MyBoxList[i].Width + "," + MyBoxList[i].Height);
                            sw.WriteLine("BoxChecked" + MyBoxList[i].BoxChecked);

                            int _赤 = MyBoxList[i].Red;
                            int _緑 = MyBoxList[i].Green;
                            int _青 = MyBoxList[i].Blue;
                            sw.WriteLine("RGB:" + _赤.ToString() + "," + _緑.ToString() + "," + _青.ToString());

                            int _パーセント = MyBoxList[i].MySPercent;
                            sw.WriteLine("%:" + _パーセント.ToString());
                            sw.WriteLine("Mode:" + ((int)MyBoxList[i].MyBoxMode).ToString());

                            Color Col = MyBoxList[i].UsedCol;
                            sw.WriteLine("CheckCol:" + Col.R + "," + Col.G + "," + Col.B);

                        }
                    }
                }
                else
                {

                }
            }
            else
            {
                MessageBox.Show("画像選択してください");
            }
        }

        /// <summary>
        /// ボックス情報保存ボタン
        /// </summary>
        private void SaveBoxData_Click(object sender, EventArgs e)
        {
            DialogResult result=MessageBox.Show("対象情報を保存しますか？ ", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SaveBoxSetting();
            }
        }

        private void ChooseCol_Click(object sender, EventArgs e)
        {
            StarChooseCol = true;
        }

        private void CutPic_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (StarChooseCol)
                {
                    Bitmap bmp = new Bitmap(CutPic.Image);
                    Color color = bmp.GetPixel(e.X, e.Y);
                    //RNums.Text = color.R.ToString();
                    //GNums.Text = color.G.ToString();
                    //BNums.Text = color.B.ToString();

                    UseCol.BackColor = Color.FromArgb(color.R, color.G, color.B);

                    MyBoxList[BoxNameCombo.SelectedIndex].UsedCol=CheckCol = color;
                    
                    //Mdown.X = e.X;
                    //Mdown.Y = e.Y;
                    StarChooseCol = false;
                }
            }
            catch
            {

            }
        }

        private void CutPic_MouseMove(object sender, MouseEventArgs e)
        {
            if (StarChooseCol)
            {
                Bitmap bmp = new Bitmap(CutPic.Image);
                Color color = bmp.GetPixel(e.X, e.Y);
                //RNums.Text = color.R.ToString();
                //GNums.Text = color.G.ToString();
                //BNums.Text = color.B.ToString();

                UseCol.BackColor = Color.FromArgb(color.R, color.G, color.B);

                //Mdown.X = e.X;
                //Mdown.Y = e.Y;
                //StarChooseCol = false;
            }
        }


        private void UseThisCol_CheckedChanged(object sender, EventArgs e)
        {
            if (UseThisCol.Checked)
            {
                MyBoxList[BoxNameCombo.SelectedIndex].BoxChecked = true;
            }
            else
            {
                MyBoxList[BoxNameCombo.SelectedIndex].BoxChecked = false;
            }
        }

        ///廃棄コード
        //private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        //{
        //    //try
        //    //{
        //    //    Color color = BitmapConverter.ToBitmap(img).GetPixel(e.X, e.Y);
        //    //    RNums.Text = color.R.ToString();
        //    //    GNums.Text = color.G.ToString();
        //    //    BNums.Text = color.B.ToString();

        //    //    PColor.BackColor = Color.FromArgb(color.R, color.G, color.B);

        //    //    //Mdown.X = e.X;
        //    //    //Mdown.Y = e.Y;
        //    //}
        //    //catch
        //    //{

        //    //}
        //}

        //private void CameraPic_MouseUp(object sender, MouseEventArgs e)
        //{
        //    //Mup.X = e.X;
        //    //Mup.Y = e.Y;

        //    //int sizeX = Mup.X - Mdown.X;
        //    //int sizeY = Mup.Y - Mdown.Y;

        //    //Bitmap bmp = new Bitmap(ChangePic.Width, ChangePic.Height);
        //    //Graphics g = Graphics.FromImage(bmp);

        //    //Rectangle srcRect = new Rectangle(Mdown.X, Mdown.Y, sizeX, sizeY);
        //    ////描画する部分の範囲を決定する。ここでは、位置(0,0)、大きさ100x100で描画する
        //    //Rectangle desRect = new Rectangle(0, 0, ChangePic.Width, ChangePic.Height);
        //    ////画像の一部を描画する
        //    //g.DrawImage(img.ToBitmap(), desRect, srcRect, GraphicsUnit.Pixel);


        //    ////Graphicsオブジェクトのリソースを解放する
        //    //g.Dispose();

        //    ////PictureBox1に表示する
        //    //ChangePic.Image = bmp;
        //}

        //private void ChangePic_MouseDown(object sender, MouseEventArgs e)
        //{
        //    //try
        //    //{
        //    //    Color color = BitmapConverter.ToBitmap(img).GetPixel(e.X, e.Y);
        //    //    RNums.Text = color.R.ToString();
        //    //    GNums.Text = color.G.ToString();
        //    //    BNums.Text = color.B.ToString();

        //    //    PColor.BackColor = Color.FromArgb(color.R, color.G, color.B);
        //    //}
        //    //catch
        //    //{

        //    //}
        //}

        //private void CutPic_MouseDown(object sender, MouseEventArgs e)
        //{
        //    //try
        //    //{
        //    //    Bitmap bmp = new Bitmap(CutPic.Image);
        //    //    Color color = bmp.GetPixel(e.X, e.Y);
        //    //    RNums.Text = color.R.ToString();
        //    //    GNums.Text = color.G.ToString();
        //    //    BNums.Text = color.B.ToString();

        //    //    PColor.BackColor = Color.FromArgb(color.R, color.G, color.B);

        //    //    Mdown.X = e.X;
        //    //    Mdown.Y = e.Y;
        //    //}
        //    //catch
        //    //{

        //    //}
        //}

        //private void CutPic_MouseUp(object sender, MouseEventArgs e)
        //{
        //    //Mup.X = e.X;
        //    //Mup.Y = e.Y;

        //    //int GetSizeX = Mup.X - Mdown.X;
        //    //int GetSizeY = Mup.Y - Mdown.Y;

        //    //Bitmap bmp = new Bitmap(ChangePic.Width, ChangePic.Height);
        //    //Graphics g = Graphics.FromImage(bmp);

        //    //Rectangle srcRect = new Rectangle(Mdown.X, Mdown.Y, GetSizeX, GetSizeY);
        //    ////描画する部分の範囲を決定する。ここでは、位置(0,0)、大きさ100x100で描画する
        //    //Rectangle desRect = new Rectangle(0, 0, ChangePic.Width, ChangePic.Height);
        //    ////画像の一部を描画する
        //    //g.DrawImage(CutPic.Image, desRect, srcRect, GraphicsUnit.Pixel);


        //    ////Graphicsオブジェクトのリソースを解放する
        //    //g.Dispose();


        //    ////PictureBox1に表示する
        //    //ChangePic.Image = bmp;

        //    ////PaintBox(PE, Mup.X, Mup.Y, GetSizeX, GetSizeY);
        //    ////GetCutPic();

        //    //Bitmap bmpC = new Bitmap(CutPic.Width, CutPic.Height);
        //    //Graphics gc = Graphics.FromImage(bmpC);

        //    //Rectangle CutRect = new Rectangle(0, 0, CutPic.Width, CutPic.Height);
        //    //gc.DrawImage(CutPic.Image, CutRect, CutRect, GraphicsUnit.Pixel);
        //    //gc.DrawRectangle(Pens.Blue, Mdown.X - 1, Mdown.Y - 1, GetSizeX + 1, GetSizeY + 1);
        //    //CutPic.Image = bmpC;

        //    //Rectangle boxRect = new Rectangle(Mdown.X, Mdown.Y, GetSizeX, GetSizeY);
        //    //BoxList.Add(boxRect);



        //    //gc.Dispose();
        //}
        //private void GetCutPic()
        //{
        //    //Bitmap bmp = new Bitmap(CutPic.Width, CutPic.Height);

        //    //Graphics g = Graphics.FromImage(bmp);

        //    //Rectangle srcRect = new Rectangle(0, 0, img.Width, img.Width);
        //    ////描画する部分の範囲を決定する。ここでは、位置(0,0)、大きさ100x100で描画する
        //    //Rectangle desRect = new Rectangle(0, 0, img.Width, img.Width);
        //    ////画像の一部を描画する
        //    //g.DrawImage(img.ToBitmap(), desRect, srcRect, GraphicsUnit.Pixel);

        //    ////Graphicsオブジェクトのリソースを解放する
        //    //g.Dispose();

        //    ////PictureBox1に表示する
        //    //CutPic.Image = bmp;


        //}
    }
}