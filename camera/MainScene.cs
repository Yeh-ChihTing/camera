using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Diagnostics;

namespace camera
{
    /// <summary>
    /// Mainシーン
    /// </summary>
    public partial class MainScene : Form
    {
        ///変数宣言


        //public変数

        /// <summary>
        /// カメラ横幅640 
        /// </summary>
        public static readonly int Cam_Width = 640;

        /// <summary>
        /// カメラ縦幅360
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
        public CamMode Cmode { get; set; }

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

        /// <summary>
        ///今クリックした対象番号
        /// </summary>
        public int NowBox { get; set; }

        /// <summary>
        ///連続チェックLCOK用FLAG
        /// </summary>
        public bool LoopCheckLock = false;
        
        
        //private変数


        /// <summary>
        /// カメラ画面処理用
        /// </summary>
        private Mat img = new Mat();

        /// <summary>
        /// 検査用写真用空間
        /// </summary>
        private Image MasterImage = null;

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
        private SoundPlayer Player = null;

        /// <summary>
        ///正常音
        /// </summary>
        private string SussesSound = @"Sound\Answer.wav";

        /// <summary>
        ///異常音
        /// </summary>
        private string FailSound = @"Sound\Wrong.wav";

        /// <summary>
        ///現在使用しているマスタ画像名
        /// </summary>
        private string SaveDataname;

        /// <summary>
        ///指定色検査用色選択ＦＬＡＧ
        /// </summary>
        private bool StarChooseCol = false;

        /// <summary>
        ///自動対象用色選択ＦＬＡＧ
        /// </summary>
        private bool StarChooseAutoCol = false;

        /// <summary>
        ///検査用色
        /// </summary>
        private Color CheckCol { get; set; }

        /// <summary>
        ///マスタ画像名を記録用
        /// </summary>
        private string NowName { get; set; }

        /// <summary>
        ///起動経過時間
        /// </summary>
        private int CrossTime = 0;

        /// <summary>
        ///チェック実行中FLAG
        /// </summary>
        private bool OneTimeCheck = true;

        /// <summary>
        ///自動対象検索実行中FLAG
        /// </summary>
        private bool OneTimeAuto = true;

        /// <summary>
        ///結果取得リスト
        /// </summary>
        private List<bool> GetAnser = new List<bool>();

        /// <summary>
        ///現在時間取得用
        /// </summary>
        private DateTime nowTime = DateTime.Now;

        /// <summary>
        ///ガンマ設定値を取得
        /// </summary>
        private double GetGamma = 1.0;

        /// <summary>
        ///マウス指したところ色取得用
        /// </summary>
        private Bitmap GetColor;

        /// <summary>
        ///現在ライブ画像の全RGB値を取得用リスト
        /// </summary>
        private List<int> NowR = new List<int>();
        private List<int> NowG = new List<int>();
        private List<int> NowB = new List<int>();

        /// <summary>
        ///自動ガンマ調整起動FLAG
        /// </summary>
        private bool StarGamamCheck = false;

        //変数宣言END

        /// <summary>
        ///初期化
        /// </summary>
        public MainScene()
        {
            InitializeComponent();

            //拡大ボタン機能OFF
            this.MaximizeBox = !this.MaximizeBox;

        }

        /// <summary>
        ///ロード
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            /// <summary>
            /// 初期化
            /// </summary>

            //画像サイズ100%に設定
            CSComboBox.SelectedIndex = (int)CutSize.OnehundredPer;

            //最初の対象ボックス生成
            MyBox box1 = new MyBox();

            //対象ボックス番号設定
            box1.MyNum = 1;

            //対象ボックスをCutPicの子にする
            CutPic.Controls.Add(box1);

            //CutPicをpanel1の子にする
            panel1.Controls.Add(CutPic);

            //panel1をこのフォームの子にする
            this.Controls.Add(panel1);

            //対象ボックスをボックスリストに加入
            MyBoxList.Add(box1);

            //コンボボックスの選択したインデックスを0にする
            BoxNameCombo.SelectedIndex = 0;

            //対象ボックスの色をLightSeaGreenにする
            MyBoxList[0]._borderColor = Color.LightSeaGreen;
            MyBoxList[0].Invalidate();

            //色合いの数値を初期化
            RedTrack.Value = MyBoxList[0].Red;
            GreenTrack.Value = MyBoxList[0].Green;
            BlueTrack.Value = MyBoxList[0].Blue;
            RSetText.Text = RedTrack.Value.ToString();
            GSetText.Text = GreenTrack.Value.ToString();
            BSetText.Text = BlueTrack.Value.ToString();

            //正常パーセントの数値を初期化
            int BoxPercent = MyBoxList[BoxNameCombo.SelectedIndex].MySPercent;
            SetSusscePercent.Text = BoxPercent.ToString();

            //モードを初期化
            CheckMode.SelectedIndex = 0;

            /// <summary>
            /// 初期化END
            /// </summary>


            /// <summary>
            /// SaveDataフォルタ存在検査　存在しないなら作る
            /// </summary>
            if (!Directory.Exists("SaveData"))
            {
                Directory.CreateDirectory("SaveData");
            }
            /// <summary>
            /// Picフォルタ存在検査　存在しないなら作る
            /// </summary>
            if (!Directory.Exists("Pic"))
            {
                Directory.CreateDirectory("Pic");
            }

            /// <summary>
            /// カメラ画面取得
            /// </summary>
            VideoCapture vc = new VideoCapture();

           

            /// <summary>
            /// カメラの稼働処理
            /// </summary>
            try
            {

                Task.Run(() =>
                {

                    //WEBカメラモード
                    if (Cmode == CamMode.WebCam)
                    {
                        //使用するカメラを取得
                        vc = new VideoCapture(WebCamNum);

                        //取得カメラをオープン
                        vc.Open(WebCamNum);

                        //表示できないなら
                        if (!vc.ConvertRgb)
                        {
                            MessageBox.Show("このカメラは使用できない");
                        }
                    }
                    //ネットワークカメラモード
                    else if (Cmode == CamMode.NetCam)
                    {
                        //使用するカメラを取得
                        //using (vc = new VideoCapture("http://root:root@169.254.154.96/axis-cgi/mjpg/video.cgi")) ;
                        vc = new VideoCapture(CamTypeName);

                        //取得カメラをオープン
                        vc.Open(CamTypeName);

                        //表示できないなら
                        if (!vc.ConvertRgb)
                        {
                            MessageBox.Show("このカメラは使用できない");
                        }
                    }

                   

                    if (vc.ConvertRgb)
                    {
                        //カメラ画像表示ループ
                        while (true)
                        {
                            //取得した画像をMATに変換
                            img = vc.RetrieveMat();
                  

                            //ガンマ補正計算
                            try
                            {
                                if (GammaPanel.Visible)
                                {
                                    //ガンマ補正
                                    if (GammaPanel.Visible)
                                    {
                                        byte[] lut = new byte[256];
                                        for (int i = 0; i < lut.Length; i++)
                                        {
                                            lut[i] = (byte)(Math.Pow(i / 255.0, 1.0 / GetGamma) * 255.0);
                                        }
                                        Cv2.LUT(img, lut, img);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }

                            //変換したMatをbitmapに変換そしてカメライメージとして表示
                            CameraPic.Image = img.ToBitmap();

                            //ガンマ補正開始フラグ
                            if (GammaPanel.Visible)
                            {
                                if (!StarGamamCheck)
                                {
                                    StarGamamCheck = true;
                                }
                            }
                        }
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
            //赤
            Rtracktext.Text = RedTrack.Value.ToString();
            RSetText.Text = RedTrack.Value.ToString();

            //緑
            Gtracktext.Text = GreenTrack.Value.ToString();
            GSetText.Text = GreenTrack.Value.ToString();

            //青
            Btracktext.Text = BlueTrack.Value.ToString();
            BSetText.Text = BlueTrack.Value.ToString();

            //連続チェック起動中に経過時間計算
            if (LoopCheckLock)
            {
                //経過時間秒数++
                CrossTime++;

                //経過時間の表示と計算
                //一分以下
                if (CrossTime < 60)
                {
                    CrossTimeLabel.Text = "経過時間：" +
                        CrossTime.ToString() + "　秒";
                }
                //一時間以下
                else if (CrossTime >= 60 && CrossTime < 3600)
                {
                    int Min = CrossTime / 60;
                    int Sec = CrossTime % 60;
                    CrossTimeLabel.Text = "経過時間：" +
                        Min.ToString() + "　分　" +
                        Sec.ToString() + "　秒";
                }
                //一時間以上
                else if (CrossTime >= 3600)
                {
                    int Hour = CrossTime / 3600;
                    int Min = (CrossTime % 3600) / 60;
                    int Sec = (CrossTime % 3600) % 60;
                    CrossTimeLabel.Text = "経過時間：" +
                        Hour.ToString() + "　時　" +
                        Min.ToString() + "　分　" +
                        Sec.ToString() + "　秒";
                }
            }

            //現在時間の表示
            nowTime = DateTime.Now;
            this.Text = "画像検査  " + "現在時間: " +
                nowTime.Year + " 年 " +
                nowTime.Month + " 月 " +
                nowTime.Hour + " 時 " +
                nowTime.Minute + " 分 " +
                nowTime.Second + " 秒";

       

        }

        /// <summary>
        ///一回検査ボタン
        /// </summary>
        private void Check_Click(object sender, EventArgs e)
        {
            if (OneTimeCheck)
            {
                //CutPicイメージ存在確認
                if (CutPic.Image != null)
                {
                    OneTimeCheck = false;

                    //ボタンLOCKしてない判定
                    if (!LoopCheckLock)
                    {
                        //チェック用関数
                        Check();
                    }

                    OneTimeCheck = true;
                }
                else
                {
                    MessageBox.Show("まずは画像選択とか画像保存してください。");
                }
            }

        }

        /// <summary>
        ///連続チェックボタン
        /// </summary>
        private void CheckLoopBtn_Click(object sender, EventArgs e)
        {
            //起動可能の時
            if (LoopBtnFlag)
            {
                //CutPicイメージ存在確認
                if (CutPic.Image != null)
                {
                    //ボタンの文字の変更
                    CheckLoopBtn.Text = "停止";

                    //ボタンの色の変更
                    CheckLoopBtn.BackColor = Color.Pink;

                    //指定したループタイムの計算
                    LoopFrame = (Convert.ToInt32(HourText.Text) * 3600000) + (Convert.ToInt32(MinText.Text) * 60000)
                        + (Convert.ToInt32(SecText.Text) * 1000);

                    //指定時間が0ではないの時
                    if (LoopFrame != 0)
                    {
                        //起動経過時間初期化
                        CrossTime = 0;

                        //各ボタングループ操作LOCK
                        BoxSetting.Enabled = false;
                        CheckSetting.Enabled = false;
                        AutoGroup.Enabled = false;

                        //ループ時間設定
                        LoopTimer.Interval = LoopFrame;

                        //ループタイマー起動
                        LoopTimer.Enabled = true;

                        //他のボタンLCOK
                        LoopCheckLock = true;

                        //一回目のチェック
                        Check();

                        //時間の入力を変更不可能
                        HourText.ReadOnly = true;
                        MinText.ReadOnly = true;
                        SecText.ReadOnly = true;


                    }
                    //指定時間が0の時
                    else
                    {
                        MessageBox.Show("0間隔連続チェックはできないです、時間を入力してください");

                        //ループタイマー閉じる
                        LoopTimer.Enabled = false;

                        //他のボタンLOCK解除
                        LoopCheckLock = false;

                        //各ボタングループ操作LOCK解除
                        BoxSetting.Enabled = true;
                        CheckSetting.Enabled = true;
                        AutoGroup.Enabled = true;

                        //ボタン文字の変更
                        CheckLoopBtn.Text = "連続チェック";

                        //ボタン背景色切の変更
                        CheckLoopBtn.BackColor = SystemColors.Control;
                    }
                }
                else
                {
                    MessageBox.Show("まずは画像選択とか画像保存してください。");
                }
            }

            //起動中の時
            else
            {
                //ループタイマーを閉じる
                LoopTimer.Enabled = false;

                //他のボタンLOCK解除
                LoopCheckLock = false;

                //各ボタングループ操作LOCK解除
                BoxSetting.Enabled = true;
                CheckSetting.Enabled = true;
                AutoGroup.Enabled = true;

                //ボタンの文字の変更
                CheckLoopBtn.Text = "連続チェック";

                //ボタンの色の変更
                CheckLoopBtn.BackColor = Color.FromArgb(128, 255, 128);

                //ボタン背景色の変更
                this.BackColor = SystemColors.Control;

                //DRAWBOXを非表示
                for (int i = 0; i < MyBoxList.Count; i++)
                {
                    MyBoxList[i].Drawbox.Visible = false;
                    //MyBoxList[i].Drawbox.BackColor = Color.Transparent;
                }

                //時間の入力を変更可能
                HourText.ReadOnly = false;
                MinText.ReadOnly = false;
                SecText.ReadOnly = false;
            }

            //CutPicイメージ存在確認
            if (CutPic.Image != null)
            {
                //ループFLAGの切り替え
                LoopBtnFlag = !LoopBtnFlag;
            }
        }

        /// <summary>
        ///チェックループ
        /// </summary>
        private void LoopTimer_Tick(object sender, EventArgs e)
        {
            //検査関数
            Check();
        }

        /// <summary>
        ///チェック用関数
        /// </summary>
        private void Check()
        {
            try
            {
                //サイズを100%に戻す
                CSComboBox.SelectedIndex = (int)CutSize.OnehundredPer;

                //カメラ画像のbitmap取得
                Bitmap Origin = (Bitmap)CameraPic.Image.Clone();
                //マスター画像のbitmap取得
                Bitmap CheackBT = (Bitmap)MasterImage.Clone();

                //各ピクセルRGB値取得用int
                int OR = 0, OG = 0, OB = 0, CR = 0, CG = 0, CB = 0;

                //検査結果保存用FLAG数列
                bool[] OkOrFail = new bool[MyBoxList.Count];

                //検査結果保存用FLAG数列初期化(True)
                for (int i = 0; i < OkOrFail.Length; i++)
                {
                    OkOrFail[i] = true;
                }

                //異常あるFALG
                bool haveFail = false;

                //結果結果表示をクリア
                CheckPerList.Items.Clear();

                //対象数ループ
                for (int k = 0; k < MyBoxList.Count; k++)
                {

                    //対象位置とサイズ取得
                    int X = MyBoxList[k].Location.X;
                    int SizeX = X + (MyBoxList[k].Width);
                    int Y = MyBoxList[k].Location.Y;
                    int SizeY = Y + (MyBoxList[k].Height);

                    //正しい数計算用int
                    int RightNum = 0;

                    //対象範囲のbitmap生成
                    Bitmap bmp = new Bitmap(MyBoxList[k].Width, MyBoxList[k].Height);

                    //グラフィック処理用
                    Graphics g = Graphics.FromImage(bmp);

                    //描画する部分の位置を決定する
                    Rectangle srcRect = new Rectangle(X, Y, MyBoxList[k].Width, MyBoxList[k].Height);

                    //描画する部分の範囲を決定する
                    Rectangle desRect = new Rectangle(0, 0, MyBoxList[k].Width, MyBoxList[k].Width);

                    //画像の一部を描画する
                    g.DrawImage(MasterImage, desRect, srcRect, GraphicsUnit.Pixel);

                    //Graphicsオブジェクトのリソースを解放する
                    g.Dispose();

                    //対象ボックスの塗る用DRAWBOXを表示
                    MyBoxList[k].Drawbox.Visible = true;

                    //DRAWBOX塗った以外部分を背景画像にする
                    MyBoxList[k].Drawbox.Image = bmp;

                    //DRAWBOXの位置とサイズ初期化
                    MyBoxList[k].Drawbox.Location = new System.Drawing.Point(3, 3);
                    MyBoxList[k].Drawbox.Width = MyBoxList[k].Width - 6;
                    MyBoxList[k].Drawbox.Height = MyBoxList[k].Height - 6;

                    //対象内内部検査ループXからY
                    for (int i = X; i < SizeX; i++)
                    {
                        for (int j = Y; j < SizeY; j++)
                        {
                            //カメラ画像のピクセル色を取得
                            OR = Origin.GetPixel(i, j).R;
                            OG = Origin.GetPixel(i, j).G;
                            OB = Origin.GetPixel(i, j).B;

                            //指定色使用しないならマスタ画像からピクセル色を取得
                            if (!MyBoxList[k].BoxChecked)
                            {
                                CR = CheackBT.GetPixel(i, j).R;
                                CG = CheackBT.GetPixel(i, j).G;
                                CB = CheackBT.GetPixel(i, j).B;
                            }
                            //指定色を取得
                            else
                            {
                                CR = CheckCol.R;
                                CG = CheckCol.G;
                                CB = CheckCol.B;
                            }

                            //カメラ画像のピクセル色はマスタ画像のピクセル色が指定色と範囲内ならば正常
                            if ((CR <= OR + MyBoxList[k].Red && CR >= OR - MyBoxList[k].Red) &&
                                (CG <= OG + MyBoxList[k].Green && CG >= OG - MyBoxList[k].Green) &&
                                (CB <= OB + MyBoxList[k].Blue && CB >= OB - MyBoxList[k].Blue))
                            {

                                //OkOrFail[k] = true;
                                //正常部分のピクセルを緑にする
                                bmp.SetPixel(i - X, j - Y, Color.Blue);
                                //正常に青に変更
                                MyBoxList[k].ChangeColor(Color.Blue);
                                //正しい数++
                                RightNum++;
                            }
                            //異常
                            else
                            {
                                //haveFail = true;
                                //OkOrFail[k] = false;
                                //MyBoxList[k].ChangeColor(Color.Red);
                                //break;
                            }
                        }

                    }

                    //drawboxに緑ではない部分背景画像にする
                    MyBoxList[k].Drawbox.Image = bmp;

                    //正常した部分のパーセント計算
                    percentOfSusses = ((double)RightNum / ((double)MyBoxList[k].Width * (double)MyBoxList[k].Height)) * 100.0;

                    //計算した結果をINTに転換
                    int Getpercent = (int)percentOfSusses;

                    //対象ボックスの正常基準を取得
                    int BoxPercent = MyBoxList[k].MySPercent;

                    // GetPercent.Text = Getpercent.ToString();
                    //正常パーセント以下の時異常
                    if (percentOfSusses < BoxPercent)
                    {
                        //異常の対象ボックスの色を赤にする
                        MyBoxList[k].ChangeColor(Color.Red);

                        //一つの対象が異常があります
                        haveFail = true;

                        //数列中に異常を記録
                        OkOrFail[k] = false;
                    }

                    //対象名あるの時
                    if (BoxNameList.Count > 0)
                    {

                        //命名あるなら名前表示
                        if (BoxNameList[k] != "")
                        {
                            if (OkOrFail[k])
                            {
                                CheckPerList.Items.Add(BoxNameList[k] + " : " + Getpercent.ToString() + "%"
                                + "/ " + BoxPercent.ToString() + "%" + " 一致");
                            }
                            else
                            {
                                CheckPerList.Items.Add(BoxNameList[k] + " : " + Getpercent.ToString() + "%"
                               + "/ " + BoxPercent.ToString() + "%" + " 不一致");
                            }
                        }
                        //命名してないなら番号表示
                        else
                        {
                            if (OkOrFail[k])
                            {
                                CheckPerList.Items.Add((k + 1).ToString() + " : " + Getpercent.ToString() + "%"
                                + "/" + BoxPercent.ToString() + "%" + " 一致");
                            }
                            else
                            {
                                CheckPerList.Items.Add((k + 1).ToString() + " : " + Getpercent.ToString() + "%"
                                + "/" + BoxPercent.ToString() + "%" + " 不一致");
                            }
                        }
                    }
                    //対象名ないのとき対象番号表示
                    else
                    {
                        if (OkOrFail[k])
                        {
                            CheckPerList.Items.Add((k + 1).ToString() + " : " + Getpercent.ToString() + "%"
                                + "/" + BoxPercent.ToString() + "%" + " 一致");
                        }
                        else
                        {
                            CheckPerList.Items.Add((k + 1).ToString() + " : " + Getpercent.ToString() + "%"
                                + "/" + BoxPercent.ToString() + "%" + "不一致");
                        }
                    }

                }

                //正常　
                if (!haveFail)
                {
                    //ループモードではない判定
                    if (LoopBtnFlag)
                    {
                        //正常音
                        Player = new SoundPlayer(SussesSound);
                        Player.Play();
                    }

                    //背景緑に変換
                    this.BackColor = Color.Blue;
                }
                //異常
                else
                {
                    //異常音
                    Player = new SoundPlayer(FailSound);
                    Player.Play();

                    //背景赤に変換
                    this.BackColor = Color.Red;
                    //Ans.Text = "FAIL";
                }

                //GetAnser初期化
                if (GetAnser.Count > 1)
                {
                    GetAnser.Clear();
                }

                //結果表示データ取得
                for (int i = 0; i < OkOrFail.Length; i++)
                {
                    GetAnser.Add(OkOrFail[i]);
                }

                //CSVに保存
                SaveDataOnCsv(OkOrFail);

            }
            catch
            {
                MessageBox.Show("画像データを選択してください");
            }
        }

        /// <summary>
        ///マスター画像選択ボタン
        /// </summary>
        private void GetPic_Click(object sender, EventArgs e)
        {
            //OpenFileDialog宣言
            OpenFileDialog ofd = new OpenFileDialog();

            //EXE位置取得
            string path = System.Windows.Forms.Application.StartupPath;
            //ダイアログ開始位置設定
            ofd.InitialDirectory = path + @"\Pic";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fileStream = File.OpenRead(ofd.FileName))
                {

                    // 画像データの検証なしで読み込む
                    Image image = Image.FromStream(fileStream, true, true);

                    //マスタイメージをimageにする
                    MasterImage = image;

                    //CutPicイメージをマスターイメージ
                    CutPic.Image = MasterImage;

                    //使用データ名記録
                    SaveDataname = ofd.FileName;

                    //データ名を副名以外取る
                    string[] name = SaveDataname.Split('.');
                    //対象状態データ名
                    string dataSpace = name[0] + ".bat";

                    //結果データリストをクリア
                    GetAnser.Clear();

                    //対象状態データ存在の時
                    if (File.Exists(dataSpace))
                    {
                        //現在対象情報をクリア
                        MyBoxList.Clear();
                        BoxNameCombo.Items.Clear();
                        CutPic.Controls.Clear();
                        BoxNameList.Clear();

                        //読み込みカウンター
                        int line_cnt = 0;
                        //読む文字一時置く用
                        string line;
                        //読むデータ保存リスト
                        List<string> DataList = new List<string>();

                        //データ読む
                        using (StreamReader sr = new StreamReader(dataSpace))
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

                        //対象数取得
                        int nums = Convert.ToInt32(DataList[0]);
                        BoxNum = nums;

                        //対象数に応じるループ
                        for (int i = 0; i < nums; i++)
                        {
                            //新しいボックス生成
                            MyBox box = new MyBox();
                            CutPic.Controls.Add(box);

                            //名前を読む
                            string[] names = DataList[(i * 8) + 1].Split(':');
                            box.MyNumber.Text = names[1];
                            BoxNameList.Add(names[1]);
                            MyBoxList.Add(box);
                            BoxNameCombo.Items.Add(names[1]);

                            //位置を読む
                            string[] Posstr = DataList[(i * 8) + 2].Split(':', ',');
                            int PosX = Convert.ToInt32(Posstr[1]);
                            int PosY = Convert.ToInt32(Posstr[2]);
                            box.Location = new System.Drawing.Point(PosX, PosY);

                            //サイズを読む
                            string[] Size = DataList[(i * 8) + 3].Split(':', ',');
                            int w = Convert.ToInt32(Size[1]);
                            int h = Convert.ToInt32(Size[2]);
                            box.Size = new System.Drawing.Size(w, h);

                            //色指定チェックボックスFLAG
                            string Checked = DataList[(i * 8) + 4];
                            if (Checked == "BoxCheckedFalse")
                            {
                                box.BoxChecked = false;
                            }
                            else if (Checked == "BoxCheckedTrue")
                            {
                                box.BoxChecked = true;
                            }

                            //色合いの値
                            string[] col = DataList[(i * 8) + 5].Split(':', ',');
                            int SR = Convert.ToInt32(col[1]);
                            int SG = Convert.ToInt32(col[2]);
                            int SB = Convert.ToInt32(col[3]);
                            box.Red = SR;
                            box.Green = SG;
                            box.Blue = SB;

                            //正常パーセント
                            string[] SPercent = DataList[(i * 8) + 6].Split(':', ',');
                            box.MySPercent = Convert.ToInt32(SPercent[1]);

                            //モード
                            string[] Smode = DataList[(i * 8) + 7].Split(':', ',');
                            box.MyBoxMode = (MyBox.BoxMode)Convert.ToInt32(Smode[1]);

                            //指定色用色
                            string[] SCheckBoxCol = DataList[(i * 8) + 8].Split(':', ',');
                            box.UsedCol = Color.FromArgb(Convert.ToInt32(SCheckBoxCol[1]), Convert.ToInt32(SCheckBoxCol[2])
                                , Convert.ToInt32(SCheckBoxCol[3]));

                            //ボックス番号を付け
                            box.MyNum = i + 1;
                        }

                        //コンボボックスのインデックスを0にする
                        BoxNameCombo.SelectedIndex = 0;

                    }

                    //画像変更してないと今マスタ画像選択してない
                    if (NowName == "" || NowName == ofd.FileName)
                    {
                        //データ名を記録
                        NowName = ofd.FileName;
                    }
                    //新のマスタ画像選択した時
                    else
                    {
                        //状態保存データないの画像なら対象ボックスを一つに戻る
                        if (!File.Exists(dataSpace))
                        {
                            //1以外の対象ボックスをクリアそして初期化
                            if (MyBoxList.Count > 1)
                            {
                                //MyBox数量取得
                                int BoxNum = MyBoxList.Count;

                                //1以外のボックスを削除
                                for (int i = 1; i < BoxNum; i++)
                                {
                                    MyBoxList.RemoveAt(i);

                                }
                                //ボックス数1に戻す
                                BoxNum = 1;

                                //対象ボックス初期化
                                CutPic.Controls.Clear();
                                CutPic.Controls.Add(MyBoxList[0]);
                                MyBoxList[0].Name = "";
                                MyBoxList[0].MyNumber.Text = "1";

                                //ボックス名リストのクリア
                                BoxNameList.Clear();

                                //コンボボックスの初期化
                                BoxNameCombo.Items.Clear();
                                BoxNameCombo.Items.Add("1");
                                BoxNameCombo.SelectedIndex = 0;
                            }
                        }

                        //データ名を記録
                        NowName = ofd.FileName;
                    }
                    //ChangePic.Image = MasterImage;
                }

                //現在のマスタイメージの記録
                GetCutPicNow = CutPic.Image;
                GetColor = new Bitmap(CutPic.Image);

            }

          
        }

        /// <summary>
        ///カメラ画像を保存
        /// </summary>
        private void SavePicBtn_Click(object sender, EventArgs e)
        {
            //セーフデータ宣言
            SaveFileDialog sfd = new SaveFileDialog();

            //EXE位置取得
            string path = System.Windows.Forms.Application.StartupPath;
            //ダイアログ開始位置設定
            sfd.InitialDirectory = path + @"\Pic";


            //データ名(また自分で変更)
            sfd.FileName = "newMaster";

            //データ形式
            sfd.Filter = "JPEG形式|*.jpg";

            //保存位置
            string dc = Directory.GetCurrentDirectory() + @"\Pic";
            sfd.InitialDirectory = dc;

            //保存クリックしたら
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //img.SaveImage(sfd.FileName);
                    Bitmap bmp = new Bitmap(img.ToBitmap());
                    bmp.Save(sfd.FileName, ImageFormat.Jpeg);

                    //保存した画像をマスタ画像にする
                    CutPic.Image = bmp;
                    MasterImage = CutPic.Image;
                    GetCutPicNow = CutPic.Image;
                    GetColor = new Bitmap(CutPic.Image);

                    //1以外の対象ボックスをクリアそして初期化
                    if (MyBoxList.Count > 1)
                    {
                        //MyBox数量取得
                        int BoxNum = MyBoxList.Count;

                        //1以外のボックスを削除
                        for (int i = 1; i < BoxNum; i++)
                        {
                            MyBoxList.RemoveAt(i);
                        }
                        //ボックス数1に戻す
                        BoxNum = 1;

                        //対象ボックス初期化
                        CutPic.Controls.Clear();
                        CutPic.Controls.Add(MyBoxList[0]);
                        MyBoxList[0].Name = "";
                        MyBoxList[0].MyNumber.Text = "1";

                        //ボックス名リストのクリア
                        BoxNameList.Clear();

                        //コンボボックスの初期化
                        BoxNameCombo.Items.Clear();
                        BoxNameCombo.Items.Add("1");
                        BoxNameCombo.SelectedIndex = 0;
                    }

                    //保存したデータ名を記録
                    SaveDataname = sfd.FileName;

                    //結果データリストをクリア
                    GetAnser.Clear();

                    //上書きの時に対象状態ファイルを消す

                    string[] getname = SaveDataname.Split('.');
                    string Batname = getname[0] + ".bat";
                    if (File.Exists(Batname))
                    {
                        DialogResult DeleteBat = MessageBox.Show("同じ名の対象状態データあります、状態データを削除しますか", "", MessageBoxButtons.YesNo);
                        if (DeleteBat == DialogResult.Yes)
                        {
                            File.Delete(Batname);
                        }
                        else
                        {
                            //現在対象情報をクリア
                            MyBoxList.Clear();
                            BoxNameCombo.Items.Clear();
                            CutPic.Controls.Clear();
                            BoxNameList.Clear();

                            //読み込みカウンター
                            int line_cnt = 0;
                            //読む文字一時置く用
                            string line;
                            //読むデータ保存リスト
                            List<string> DataList = new List<string>();

                            //データ読む
                            using (StreamReader sr = new StreamReader(Batname))
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

                            //対象数取得
                            int nums = Convert.ToInt32(DataList[0]);
                            BoxNum = nums;

                            //対象数に応じるループ
                            for (int i = 0; i < nums; i++)
                            {
                                //新しいボックス生成
                                MyBox box = new MyBox();
                                CutPic.Controls.Add(box);

                                //名前を読む
                                string[] names = DataList[(i * 8) + 1].Split(':');
                                box.MyNumber.Text = names[1];
                                BoxNameList.Add(names[1]);
                                MyBoxList.Add(box);
                                BoxNameCombo.Items.Add(names[1]);

                                //位置を読む
                                string[] Posstr = DataList[(i * 8) + 2].Split(':', ',');
                                int PosX = Convert.ToInt32(Posstr[1]);
                                int PosY = Convert.ToInt32(Posstr[2]);
                                box.Location = new System.Drawing.Point(PosX, PosY);

                                //サイズを読む
                                string[] Size = DataList[(i * 8) + 3].Split(':', ',');
                                int w = Convert.ToInt32(Size[1]);
                                int h = Convert.ToInt32(Size[2]);
                                box.Size = new System.Drawing.Size(w, h);

                                //色指定チェックボックスFLAG
                                string Checked = DataList[(i * 8) + 4];
                                if (Checked == "BoxCheckedFalse")
                                {
                                    box.BoxChecked = false;
                                }
                                else if (Checked == "BoxCheckedTrue")
                                {
                                    box.BoxChecked = true;
                                }

                                //色合いの値
                                string[] col = DataList[(i * 8) + 5].Split(':', ',');
                                int SR = Convert.ToInt32(col[1]);
                                int SG = Convert.ToInt32(col[2]);
                                int SB = Convert.ToInt32(col[3]);
                                box.Red = SR;
                                box.Green = SG;
                                box.Blue = SB;

                                //正常パーセント
                                string[] SPercent = DataList[(i * 8) + 6].Split(':', ',');
                                box.MySPercent = Convert.ToInt32(SPercent[1]);

                                //モード
                                string[] Smode = DataList[(i * 8) + 7].Split(':', ',');
                                box.MyBoxMode = (MyBox.BoxMode)Convert.ToInt32(Smode[1]);

                                //指定色用色
                                string[] SCheckBoxCol = DataList[(i * 8) + 8].Split(':', ',');
                                box.UsedCol = Color.FromArgb(Convert.ToInt32(SCheckBoxCol[1]), Convert.ToInt32(SCheckBoxCol[2])
                                    , Convert.ToInt32(SCheckBoxCol[3]));

                                //ボックス番号を付け
                                box.MyNum = i + 1;
                            }

                            //コンボボックスのインデックスを0にする
                            BoxNameCombo.SelectedIndex = 0;
                        }
                    }


                }
                catch (NullReferenceException a)
                {
                    //エーラ表示
                    MessageBox.Show(a.ToString());
                }
            }

        }

        /// <summary>
        ///マスター画像サイズ変更処理
        /// </summary>
        private void CSComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            //背景色を戻す
            this.BackColor = SystemColors.Control;

            //各対象のDRAWBOXを非表示
            for (int i = 0; i < MyBoxList.Count; i++)
            {
                MyBoxList[i].Drawbox.Visible = false;
            }

            try
            {
                //100%モード
                if (CSComboBox.SelectedIndex == (int)CutSize.OnehundredPer)
                {
                    //サイズを640*360にする
                    CutPic.Width = Cam_Width;
                    CutPic.Height = Cam_Height;

                    //マスタ画像存在確認
                    if (MasterImage != null)
                    {
                        //各対象位置とサイズ取得用数列
                        double[] bx = new double[MyBoxList.Count];
                        double[] by = new double[MyBoxList.Count];
                        double[] bw = new double[MyBoxList.Count];
                        double[] bh = new double[MyBoxList.Count];

                        //現在各対象ボックスのステータス取得
                        GetNowBoxStatus(bx, by, bw, bh);
                        // Image GetCutPic = CutPic.Image;

                        //CutPicのイメージサイズを640*360にする
                        CutPic.Image = new Bitmap(CutPic.Width, CutPic.Height);

                        //100％サイズの画像を描画する
                        using (var bmp = new Bitmap(GetCutPicNow))
                        using (var g = Graphics.FromImage(CutPic.Image))
                        {
                            // 補間モードの設定（各画素が見えるように） 
                            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                            // 描画  
                            g.DrawImage(bmp, 0, 0, Cam_Width, Cam_Height);
                        }

                        //各対象をサイズ変更後の位置とサイズ計算
                        for (int i = 0; i < MyBoxList.Count; i++)
                        {
                            double x, y;
                            x = Math.Round(bx[i] / BMul);
                            y = Math.Round(by[i] / BMul);
                            MyBoxList[i].Location = new System.Drawing.Point((int)x, (int)y);
                            MyBoxList[i].Width = (int)Math.Round(bw[i] / BMul);
                            MyBoxList[i].Height = (int)Math.Round(bh[i] / BMul);

                        }

                    }

                    //掛け率設定
                    BMul = 1;

                }

                //200%
                if (CSComboBox.SelectedIndex == (int)CutSize.TwohundredPer)
                {
                    //各対象位置とサイズ取得用数列
                    double[] bx = new double[MyBoxList.Count];
                    double[] by = new double[MyBoxList.Count];
                    double[] bw = new double[MyBoxList.Count];
                    double[] bh = new double[MyBoxList.Count];

                    //現在各対象ボックスのステータス取得
                    GetNowBoxStatus(bx, by, bw, bh);

                    //CutPicのイメージサイズを1280*720にする
                    CutPic.Width = Cam_Width * 2;
                    CutPic.Height = Cam_Height * 2;
                    CutPic.Image = new Bitmap(CutPic.Width, CutPic.Height);

                    //200％サイズの画像を描画する
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

                    //現サイズのビットマップ取得
                    GetColor = new Bitmap(CutPic.Image);

                    //各対象をサイズ変更後の位置とサイズ計算
                    for (int i = 0; i < MyBoxList.Count; i++)
                    {
                        //100%から変更
                        if (BMul == 1)
                        {

                            MyBoxList[i].Location = new System.Drawing.Point((int)bx[i] * 2, (int)by[i] * 2);
                            MyBoxList[i].Width = (int)bw[i] * 2;
                            MyBoxList[i].Height = (int)bh[i] * 2;
                        }

                        //400%から変更
                        if (BMul == 4)
                        {
                            double x, y;
                            x = Math.Round(bx[i] / 2);
                            y = Math.Round(by[i] / 2);
                            MyBoxList[i].Location = new System.Drawing.Point((int)x, (int)y);
                            MyBoxList[i].Width = (int)Math.Round(bw[i] / 2);
                            MyBoxList[i].Height = (int)Math.Round(bh[i] / 2);
                        }

                        //800%から変更
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

                    //掛け率設定
                    BMul = 2;

                }

                //400%
                if (CSComboBox.SelectedIndex == (int)CutSize.FourhundredPer)
                {
                    //各対象位置とサイズ取得用数列
                    double[] bx = new double[MyBoxList.Count];
                    double[] by = new double[MyBoxList.Count];
                    double[] bw = new double[MyBoxList.Count];
                    double[] bh = new double[MyBoxList.Count];

                    // 現在各対象ボックスのステータス取得
                    GetNowBoxStatus(bx, by, bw, bh);

                    //CutPicのイメージサイズを2560*1440にする
                    CutPic.Width = Cam_Width * 4;
                    CutPic.Height = Cam_Height * 4;
                    CutPic.Image = new Bitmap(CutPic.Width, CutPic.Height);

                    //400％サイズの画像を描画する
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

                    //現サイズのビットマップ取得
                    GetColor = new Bitmap(CutPic.Image);

                    //各対象をサイズ変更後の位置とサイズ計算
                    for (int i = 0; i < MyBoxList.Count; i++)
                    {
                        //100%から変更
                        if (BMul == 1)
                        {
                            MyBoxList[i].Location = new System.Drawing.Point((int)bx[i] * 4, (int)by[i] * 4);
                            MyBoxList[i].Width = (int)bw[i] * 4;
                            MyBoxList[i].Height = (int)bh[i] * 4;
                        }

                        //200%から変更
                        if (BMul == 2)
                        {
                            MyBoxList[i].Location = new System.Drawing.Point((int)bx[i] * 2, (int)by[i] * 2);
                            MyBoxList[i].Width = (int)bw[i] * 2;
                            MyBoxList[i].Height = (int)bh[i] * 2;
                        }

                        //800%から変更
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

                    //掛け率設定
                    BMul = 4;

                }

                //800%
                if (CSComboBox.SelectedIndex == (int)CutSize.EighthundredPer)
                {
                    //各対象位置とサイズ取得用数列
                    double[] bx = new double[MyBoxList.Count];
                    double[] by = new double[MyBoxList.Count];
                    double[] bw = new double[MyBoxList.Count];
                    double[] bh = new double[MyBoxList.Count];

                    //現在各対象ボックスのステータス取得
                    GetNowBoxStatus(bx, by, bw, bh);

                    //CutPicのイメージサイズを5120*2880にする
                    CutPic.Width = Cam_Width * 8;
                    CutPic.Height = Cam_Height * 8;
                    CutPic.Image = new Bitmap(CutPic.Width, CutPic.Height);

                    //800％サイズの画像を描画する
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

                    //現サイズのビットマップ取得
                    GetColor = new Bitmap(CutPic.Image);

                    //各対象をサイズ変更後の位置とサイズ計算
                    for (int i = 0; i < MyBoxList.Count; i++)
                    {
                        //100%から変更
                        if (BMul == 1)
                        {
                            MyBoxList[i].Location = new System.Drawing.Point((int)bx[i] * 8, (int)by[i] * 8);
                            MyBoxList[i].Width = (int)bw[i] * 8;
                            MyBoxList[i].Height = (int)bh[i] * 8;
                        }

                        //200%から変更
                        if (BMul == 2)
                        {
                            MyBoxList[i].Location = new System.Drawing.Point((int)bx[i] * 4, (int)by[i] * 4);
                            MyBoxList[i].Width = (int)bw[i] * 4;
                            MyBoxList[i].Height = (int)bh[i] * 4;
                        }

                        //400%から変更
                        if (BMul == 4)
                        {
                            MyBoxList[i].Location = new System.Drawing.Point((int)bx[i] * 2, (int)by[i] * 2);
                            MyBoxList[i].Width = (int)bw[i] * 2;
                            MyBoxList[i].Height = (int)bh[i] * 2;
                        }

                    }

                    //掛け率設定
                    BMul = 8;

                }
            }
            catch
            {
                MessageBox.Show("お先に画像を選択してください");
                CSComboBox.SelectedIndex = (int)CutSize.OnehundredPer;
            }
        }

        /// <summary>
        ///対象の位置とサイズを取得
        /// </summary>
        public void GetNowBoxStatus(double[] x, double[] y, double[] w, double[] h)
        {
            //x軸　ｙ軸　横(w) 縦(h)
            for (int i = 0; i < MyBoxList.Count; i++)
            {
                x[i] = MyBoxList[i].Location.X;
                y[i] = MyBoxList[i].Location.Y;
                w[i] = MyBoxList[i].Width;
                h[i] = MyBoxList[i].Height;
            }
        }

        /// <summary>
        ///対象の増加ボタン
        /// </summary>
        private void AddBox_Click(object sender, EventArgs e)
        {

            //対象数++
            BoxNum++;

            //新しいボックス生成
            MyBox box = new MyBox();

            //対象ボックス番号設定
            box.MyNum = BoxNum;

            //ボックスの親をCutPicにする
            CutPic.Controls.Add(box);

            //ボックスのの番号を書く
            box.MyNumber.Text = BoxNum.ToString();

            //ボックスリストに加入
            MyBoxList.Add(box);

            //コンボボックスに加入
            BoxNameCombo.Items.Add(BoxNum.ToString());
            //BoxNameList.Add(BoxNum.ToString());

        }

        /// <summary>
        ///対象の消すボタン
        /// </summary>
        private void DelectBox_Click(object sender, EventArgs e)
        {

            //対象ボックスは一個以上の時消す
            if (MyBoxList.Count > 1)
            {
                //選択した対象ボックス消す
                MyBoxList.RemoveAt(BoxNameCombo.SelectedIndex);
                CutPic.Controls.RemoveAt(BoxNameCombo.SelectedIndex);

                //ボックス数量減る
                BoxNum--;

                //対象名付けているボックス存在しないの時
                if (BoxNameList.Count == 0)
                {
                    //コンボボックスをクリア
                    BoxNameCombo.Items.Clear();

                    //数字１から対象ボックスに名を付ける
                    for (int i = 0; i < BoxNum; i++)
                    {
                        MyBoxList[i].MyNumber.Text = (i + 1).ToString();
                        BoxNameCombo.Items.Add((i + 1).ToString());
                        MyBoxList[i].MyNum = i + 1;
                    }
                }
                //既に名を付けるボックス存在の時
                else
                {

                    if (BoxNameCombo.SelectedIndex < BoxNameList.Count)
                    {
                        //選択した対象名を名前リストから消す
                        BoxNameList.RemoveAt(BoxNameCombo.SelectedIndex);
                    }

                    //コンボボックスクリア
                    BoxNameCombo.Items.Clear();

                    //対象数ループ
                    for (int i = 0; i < BoxNum; i++)
                    {
                        //対象ボックス番号設定
                        MyBoxList[i].MyNum = i + 1;

                        //対象名は空白ではないの時
                        if (BoxNameList[i] != "")
                        {
                            //名前を入れる
                            MyBoxList[i].MyNumber.Text = BoxNameList[i];
                            BoxNameCombo.Items.Add(BoxNameList[i]);
                            //if (i < BoxNameList.Count - 1)
                            //{
                            //    MyBoxList[i].MyNumber.Text = BoxNameList[i];
                            //    BoxNameCombo.Items.Add(BoxNameList[i]);
                            //}
                            //else
                            //{
                            //    MyBoxList[i].MyNumber.Text = (i + 1).ToString();
                            //    BoxNameCombo.Items.Add((i + 1).ToString());
                            //}
                        }
                        //対象名は空白の時
                        else
                        {
                            //数字を入れる
                            MyBoxList[i].MyNumber.Text = (i + 1).ToString();
                            BoxNameCombo.Items.Add((i + 1).ToString());
                        }
                    }

                }

               
            }
            //BoxList.Clear();
            //コンボボックスのインデックスを0にする
            BoxNameCombo.SelectedIndex = 0;

        }

        /// <summary>
        ///CSVデータ保存
        /// </summary>
        private void SaveDataOnCsv(bool[] ok)
        {
            //今日の日を取得
            DateTime dt = new DateTime();
            dt = DateTime.Now;

            if (DataName.Text == "")
            {
                DataName.Text = "監視データ";
            }

            //データ名
            string Path = "SaveData/" + dt.Year + "." + dt.Month + "." + dt.Day + DataName.Text + ".csv";
            StreamWriter sw;

            //データ存在確認
            if (!File.Exists(Path))
            {
                sw = new StreamWriter(Path, false, Encoding.GetEncoding("utf-8"));

                sw.WriteLine("日時/対象名" +
                    "," +
                    "判定状態" +
                    "," +
                    "判定結果");

                //今の時間を書く
                sw.WriteLine(DateTime.Now);

                //チェック項目数ループ
                for (int i = 0; i < ok.Length; i++)
                {
                    //対象名リストは０なら
                    if (BoxNameList.Count == 0)
                    {
                        //正常
                        if (ok[i])
                        {
                            //サーモテープモード
                            if (MyBoxList[i].MyBoxMode == MyBox.BoxMode.Samontape)
                            {
                                sw.WriteLine((i + 1).ToString() + "," + "温度正常");
                            }
                            //点灯モード
                            else if (MyBoxList[i].MyBoxMode == MyBox.BoxMode.LampOn)
                            {
                                sw.WriteLine((i + 1).ToString() + "," + "点灯");
                            }
                            //消灯モード
                            else if (MyBoxList[i].MyBoxMode == MyBox.BoxMode.LampOff)
                            {
                                sw.WriteLine((i + 1).ToString() + "," + "消灯");
                            }
                        }
                        //異常
                        else
                        {
                            //サーモテープモード
                            if (MyBoxList[i].MyBoxMode == 0)
                            {
                                sw.WriteLine((i + 1).ToString() + "," + "温度高" + "," + "異常判定");
                            }
                            //点灯モード
                            else if (MyBoxList[i].MyBoxMode == MyBox.BoxMode.LampOn)
                            {
                                sw.WriteLine((i + 1).ToString() + "," + "消灯" + "," + "異常判定");
                            }
                            //消灯モード
                            else if (MyBoxList[i].MyBoxMode == MyBox.BoxMode.LampOff)
                            {
                                sw.WriteLine((i + 1).ToString() + "," + "点灯" + "," + "異常判定");
                            }
                        }
                    }
                    //対象名あるなら
                    else
                    {
                        //正常
                        if (ok[i])
                        {
                            //サーモテープモード
                            if (MyBoxList[i].MyBoxMode == 0)
                            {
                                sw.WriteLine(BoxNameList[i] + "," + "温度正常");
                            }
                            //点灯モード
                            else if (MyBoxList[i].MyBoxMode == MyBox.BoxMode.LampOn)
                            {
                                sw.WriteLine(BoxNameList[i] + "," + "点灯");
                            }
                            //消灯モード
                            else if (MyBoxList[i].MyBoxMode == MyBox.BoxMode.LampOff)
                            {
                                sw.WriteLine(BoxNameList[i] + "," + "消灯");
                            }

                        }
                        //異常
                        else
                        {
                            //サーモテープモード
                            if (MyBoxList[i].MyBoxMode == 0)
                            {
                                sw.WriteLine(BoxNameList[i] + "," + "温度高" + "," + "異常判定");
                            }
                            //点灯モード
                            else if (MyBoxList[i].MyBoxMode == MyBox.BoxMode.LampOn)
                            {
                                sw.WriteLine(BoxNameList[i] + "," + "消灯" + "," + "異常判定");
                            }
                            //消灯モード
                            else if (MyBoxList[i].MyBoxMode == MyBox.BoxMode.LampOff)
                            {
                                sw.WriteLine(BoxNameList[i] + "," + "点灯" + "," + "異常判定");
                            }
                        }
                    }
                }
            }

            //既に保存データ存在の場合
            else
            {
                //ファイル開く
                sw = File.AppendText(Path);
                //現在時間を書く

                sw.WriteLine(DateTime.Now);

                //チェック項目数ループ
                for (int i = 0; i < ok.Length; i++)
                {
                    //対象名リストは０なら
                    if (BoxNameList.Count == 0)
                    {
                        //正常
                        if (ok[i])
                        {
                            //サーモテープモード
                            if (MyBoxList[i].MyBoxMode == MyBox.BoxMode.Samontape)
                            {
                                sw.WriteLine((i + 1).ToString() + "," + "温度正常");
                            }
                            //点灯モード
                            else if (MyBoxList[i].MyBoxMode == MyBox.BoxMode.LampOn)
                            {
                                sw.WriteLine((i + 1).ToString() + "," + "点灯");
                            }
                            //消灯モード
                            else if (MyBoxList[i].MyBoxMode == MyBox.BoxMode.LampOff)
                            {
                                sw.WriteLine((i + 1).ToString() + "," + "消灯");
                            }
                        }
                        //異常
                        else
                        {
                            //サーモテープモード
                            if (MyBoxList[i].MyBoxMode == 0)
                            {
                                sw.WriteLine((i + 1).ToString() + "," + "温度高" + "," + "異常判定");
                            }
                            //点灯モード
                            else if (MyBoxList[i].MyBoxMode == MyBox.BoxMode.LampOn)
                            {
                                sw.WriteLine((i + 1).ToString() + "," + "消灯" + "," + "異常判定");
                            }
                            //消灯モード
                            else if (MyBoxList[i].MyBoxMode == MyBox.BoxMode.LampOff)
                            {
                                sw.WriteLine((i + 1).ToString() + "," + "点灯" + "," + "異常判定");
                            }
                        }
                    }
                    //対象名あるなら
                    else
                    {
                        //正常
                        if (ok[i])
                        {
                            //サーモテープモード
                            if (MyBoxList[i].MyBoxMode == 0)
                            {
                                sw.WriteLine(BoxNameList[i] + "," + "温度正常");
                            }
                            //点灯モード
                            else if (MyBoxList[i].MyBoxMode == MyBox.BoxMode.LampOn)
                            {
                                sw.WriteLine(BoxNameList[i] + "," + "点灯");
                            }
                            //消灯モード
                            else if (MyBoxList[i].MyBoxMode == MyBox.BoxMode.LampOff)
                            {
                                sw.WriteLine(BoxNameList[i] + "," + "消灯");
                            }

                        }
                        //異常
                        else
                        {
                            //サーモテープモード
                            if (MyBoxList[i].MyBoxMode == 0)
                            {
                                sw.WriteLine(BoxNameList[i] + "," + "温度高" + "," + "異常判定");
                            }
                            //点灯モード
                            else if (MyBoxList[i].MyBoxMode == MyBox.BoxMode.LampOn)
                            {
                                sw.WriteLine(BoxNameList[i] + "," + "消灯" + "," + "異常判定");
                            }
                            //消灯モード
                            else if (MyBoxList[i].MyBoxMode == MyBox.BoxMode.LampOff)
                            {
                                sw.WriteLine(BoxNameList[i] + "," + "点灯" + "," + "異常判定");
                            }
                        }
                    }
                }
            }
            //保存終了
            sw.Close();
        }

        /// <summary>
        ///対象名設定ボタン
        /// </summary>
        private void SettingName_Click(object sender, EventArgs e)
        {
            //設定ボックスフォーム宣言
            SettingBoxName SBN = new SettingBoxName();
            SBN.Owner = this;

            //ボックス数を渡す
            SBN.Boxnum = MyBoxList.Count;

            //DialogとしてSettingBoxNameフォームを呼び出す
            SBN.ShowDialog();

            //名前リストをクリア
            BoxNameList.Clear();

            //コンボボックスをクリア
            BoxNameCombo.Items.Clear();

            //書いた名前の設定
            for (int i = 0; i < SBN.TextBox.Count; i++)
            {
                //ボックス名リストに追加
                BoxNameList.Add(SBN.TextBox[i].Text);

                //入力している
                if (SBN.TextBox[i].Text != "")
                {

                    BoxNameCombo.Items.Add(SBN.TextBox[i].Text);
                    MyBoxList[i].MyNumber.Text = SBN.TextBox[i].Text;

                }

                //空白の場合
                else
                {
                    BoxNameCombo.Items.Add((i + 1).ToString());
                    MyBoxList[i].MyNumber.Text = (i + 1).ToString();
                }
            }

            //ボックスコンボボックスのインデックス0にします
            BoxNameCombo.SelectedIndex = 0;

        }

        /// <summary>
        ///対象選択したイベント
        /// </summary>
        private void BoxNameCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            //全対象ボックスの色を青いにする
            for (int i = 0; i < MyBoxList.Count; i++)
            {
                MyBoxList[i]._borderColor = Color.Blue;
                MyBoxList[i].Invalidate();
            }

            //選択した対象ボックスの色をLightSeaGreenにする
            MyBoxList[BoxNameCombo.SelectedIndex]._borderColor = Color.LightSeaGreen;
            MyBoxList[BoxNameCombo.SelectedIndex].Invalidate();

            //選択した対象ボックスのRGB色合い値を取得
            RedTrack.Value = MyBoxList[BoxNameCombo.SelectedIndex].Red;
            GreenTrack.Value = MyBoxList[BoxNameCombo.SelectedIndex].Green;
            BlueTrack.Value = MyBoxList[BoxNameCombo.SelectedIndex].Blue;

            //RGBテキストボックス設定
            RSetText.Text = RedTrack.Value.ToString();
            GSetText.Text = GreenTrack.Value.ToString();
            BSetText.Text = BlueTrack.Value.ToString();

            //選択した対象ボックスの正常パーセント
            //取得
            int BoxPercent = MyBoxList[BoxNameCombo.SelectedIndex].MySPercent;
            //設定
            SetSusscePercent.Text = BoxPercent.ToString();

            //選択した対象ボックスのモード取得そして設定
            CheckMode.SelectedIndex = (int)MyBoxList[BoxNameCombo.SelectedIndex].MyBoxMode;

            //選択した対象ボックスの指定色使用FALG取得そして設定
            UseThisCol.Checked = MyBoxList[BoxNameCombo.SelectedIndex].BoxChecked;

            //Group名を現在選択した対象ボックスの名前に設定
            BoxSetting.Text = BoxNameCombo.SelectedItem.ToString() + "の設定";

            //選択した対象ボックスの指定色取得そして設定
            UseCol.BackColor = MyBoxList[BoxNameCombo.SelectedIndex].UsedCol;
        }

        /// <summary>
        ///RGB値の変更
        /// </summary>

        /// <summary>
        ///色合いの値R（赤）スライドしたイベント
        /// </summary>
        private void RedTrack_ValueChanged(object sender, EventArgs e)
        {
            //対象ボックスの赤色合い量設定
            MyBoxList[BoxNameCombo.SelectedIndex].Red = RedTrack.Value;
        }

        /// <summary>
        ///色合いの値G（緑）スライドしたイベント
        /// </summary>
        private void GreenTrack_ValueChanged(object sender, EventArgs e)
        {
            //対象ボックスの緑色合い量設定
            MyBoxList[BoxNameCombo.SelectedIndex].Green = GreenTrack.Value;

        }

        /// <summary>
        ///色合いの値B（青い）スライドしたイベント
        /// </summary>
        private void BlueTrack_ValueChanged(object sender, EventArgs e)
        {
            //対象ボックスの青い色合い量設定
            MyBoxList[BoxNameCombo.SelectedIndex].Blue = BlueTrack.Value;
        }

        /// <summary>
        ///色合いの値R（赤）入力したイベント
        /// </summary>
        private void RSetText_TextChanged(object sender, EventArgs e)
        {
            //入力テキストボックス取得
            TextBox text = (TextBox)sender;

            //テキストボックスに空白ではない
            if (text.Text != "")
            {
                //数字は０以下255以上の時
                if (Convert.ToInt32(text.Text) < 0 || Convert.ToInt32(text.Text) > 255)
                {
                    MessageBox.Show("0~255にしてください");
                    //255以上の時255にします
                    if (Convert.ToInt32(text.Text) > 255)
                    {
                        text.Text = "255";
                    }
                    //0以下の時0にします
                    else if (Convert.ToInt32(text.Text) < 0)
                    {
                        text.Text = "0";
                    }
                }
                else
                {
                    //対象ボックスの赤色合い量設定
                    RedTrack.Value = Convert.ToInt32(text.Text);
                }
            }
        }

        /// <summary>
        ///色合いの値G（緑）入力したイベント
        /// </summary>
        private void GSetText_TextChanged(object sender, EventArgs e)
        {
            //入力テキストボックス取得
            TextBox text = (TextBox)sender;

            //テキストボックスに空白ではない
            if (text.Text != "")
            {
                if (Convert.ToInt32(text.Text) < 0 || Convert.ToInt32(text.Text) > 255)
                {
                    MessageBox.Show("0~255にしてください");
                    //255以上の時255にします
                    if (Convert.ToInt32(text.Text) > 255)
                    {
                        text.Text = "255";
                    }
                    //0以下の時0にします
                    else if (Convert.ToInt32(text.Text) < 0)
                    {
                        text.Text = "0";
                    }
                }
                else
                {
                    //対象ボックスの緑色合い量設定
                    GreenTrack.Value = Convert.ToInt32(text.Text);
                }
            }
        }

        /// <summary>
        ///色合いの値B（青）入力したイベント
        /// </summary>
        private void BSetText_TextChanged(object sender, EventArgs e)
        {
            //入力テキストボックス取得
            TextBox text = (TextBox)sender;

            //テキストボックスに空白ではない
            if (text.Text != "")
            {
                //数字は０以下255以上の時
                if (Convert.ToInt32(text.Text) < 0 || Convert.ToInt32(text.Text) > 255)
                {
                    MessageBox.Show("0~255にしてください");
                    //255以上の時255にします
                    if (Convert.ToInt32(text.Text) > 255)
                    {
                        text.Text = "255";
                    }
                    //0以下の時0にします
                    else if (Convert.ToInt32(text.Text) < 0)
                    {
                        text.Text = "0";
                    }
                }
                else
                {
                    //対象ボックスの青い色合い量設定
                    BlueTrack.Value = Convert.ToInt32(text.Text);
                }
            }
        }

        /// <summary>
        ///RGB値の変更END
        /// </summary>

        /// <summary>
        ///入力を数字に限定する関数
        /// </summary>
        private void OnlyInputNum(object sender, KeyPressEventArgs e)
        {
            //数字の時
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            //数字以外の時
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        ///成功パーセント設定入力したイベント
        /// </summary>
        private void SetSusscePercent_TextChanged(object sender, EventArgs e)
        {
            //入力テキストボックス取得
            TextBox text = (TextBox)sender;

            //テキストボックスに空白ではない
            if (text.Text != "")
            {
                //数字は０以下100以上の時
                if (Convert.ToInt32(text.Text) < 0 || Convert.ToInt32(text.Text) > 100)
                {
                    MessageBox.Show("0~100にしてください");
                    //100以上の時100にします
                    if (Convert.ToInt32(text.Text) > 100)
                    {
                        text.Text = "100";
                    }
                    //0以下の時0にします
                    else if (Convert.ToInt32(text.Text) < 0)
                    {
                        text.Text = "0";
                    }
                }
                else
                {
                    //パーセントを設定
                    MyBoxList[BoxNameCombo.SelectedIndex].MySPercent = Convert.ToInt32(text.Text);
                }
            }
        }

        /// <summary>
        ///検査結果画面クリアボタン
        /// </summary>
        private void ClearCheckScene_Click(object sender, EventArgs e)
        {
            if (!LoopCheckLock)
            {
                //背景色戻す
                this.BackColor = SystemColors.Control;

                MyBoxList[BoxNameCombo.SelectedIndex]._borderColor = Color.LightSeaGreen;
                MyBoxList[BoxNameCombo.SelectedIndex].Invalidate();
                //対象ボックスの正常部分緑を塗る用pictureboxを非表示
                for (int i = 0; i < MyBoxList.Count; i++)
                {
                    MyBoxList[i].Drawbox.Visible = false;
                    //MyBoxList[i].Drawbox.BackColor = Color.Transparent;
                    if (i != BoxNameCombo.SelectedIndex)
                    {
                        MyBoxList[i]._borderColor = Color.Blue;
                        MyBoxList[i].Invalidate();
                    }

                }

                //結果表示をクリア
                CheckPerList.Items.Clear();
                GetAnser.Clear();

                //選択対象を前頭1に戻る
                //NowBox = 1;
                //ClickBoxNum.Text = NowBox.ToString();

            }
        }

        /// <summary>
        /// モードの切り替え
        /// </summary>
        private void CheckMode_SelectedValueChanged(object sender, EventArgs e)
        {
            //モード変更
            MyBoxList[BoxNameCombo.SelectedIndex].MyBoxMode = (MyBox.BoxMode)CheckMode.SelectedIndex;
        }

        /// <summary>
        /// フォーム閉める時
        /// </summary>
        private void MainScene_FormClosing(object sender, FormClosingEventArgs e)
        {
            //閉める時に対象ボックス情報保存確認
            DialogResult result = MessageBox.Show("対象情報を保存しますか？ ", "", MessageBoxButtons.YesNo);

            //保存したいなら
            if (result == DialogResult.Yes)
            {
                //対象ボックス情報保存関数
                SaveBoxSetting();
            }

            //親フォーム表示
            this.Owner.Visible = true;

        }

        /// <summary>
        /// ボックス情報保存関数
        /// </summary>
        private void SaveBoxSetting()
        {
            //CutPicは画像存在確認
            if (CutPic.Image != null)
            {
                //現画像データ名取得
                string[] name = SaveDataname.Split('.');
                //保存データ名
                string Path = name[0] + ".bat";

                //保存データ名NULL確認
                if (SaveDataname != "")
                {
                    using (StreamWriter sw = new StreamWriter(Path, false, Encoding.GetEncoding("utf-8")))
                    {
                        //対象ボックス数量書く
                        sw.WriteLine(BoxNum.ToString());
                        for (int i = 0; i < BoxNum; i++)
                        {
                            //対象ボックス名書く
                            sw.WriteLine("name:" + BoxNameCombo.Items[i].ToString());

                            //対象ボックス位置書く
                            sw.WriteLine("pos:" + MyBoxList[i].Location.X + "," + MyBoxList[i].Location.Y);

                            //対象ボックスサイズ書く
                            sw.WriteLine("size:" + MyBoxList[i].Width + "," + MyBoxList[i].Height);

                            //対象ボックス指定色使用チェック状態書く
                            sw.WriteLine("BoxChecked" + MyBoxList[i].BoxChecked);

                            //対象ボックスRGB
                            //RGB取得
                            int _赤 = MyBoxList[i].Red;
                            int _緑 = MyBoxList[i].Green;
                            int _青 = MyBoxList[i].Blue;
                            //対象ボックスRGB書く
                            sw.WriteLine("RGB:" + _赤.ToString() + "," + _緑.ToString() + "," + _青.ToString());

                            //正常パーセント
                            //パーセント取得
                            int _パーセント = MyBoxList[i].MySPercent;
                            //パーセント書く
                            sw.WriteLine("%:" + _パーセント.ToString());

                            //対象ボックスモード書く
                            sw.WriteLine("Mode:" + ((int)MyBoxList[i].MyBoxMode).ToString());

                            //対象ボックス指定色
                            //指定色取得
                            Color Col = MyBoxList[i].UsedCol;
                            //指定色書く
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
            //CutPicイメージ存在確認
            if (CutPic.Image != null)
            {
                //保存とかの質問のMessageBox
                DialogResult result = MessageBox.Show("対象情報を保存しますか？ ", "", MessageBoxButtons.YesNo);

                //保存したいなら
                if (result == DialogResult.Yes)
                {
                    //ボックス情報の保存関数
                    SaveBoxSetting();
                }
            }
            else
            {
                MessageBox.Show("まずは画像選択とか画像保存してください。");
            }

        }

        /// <summary>
        /// 指定色参照使用するかのチェックボックス
        /// </summary>
        private void UseThisCol_CheckedChanged(object sender, EventArgs e)
        {
            //指定色チェック使用FALGをTRUEする
            if (UseThisCol.Checked)
            {
                MyBoxList[BoxNameCombo.SelectedIndex].BoxChecked = true;
            }
            //指定色チェック使用FALGをFALSEする
            else
            {
                MyBoxList[BoxNameCombo.SelectedIndex].BoxChecked = false;
            }
        }

        /// <summary>
        /// 指定色選択ボタン
        /// </summary>
        private void ChooseCol_Click(object sender, EventArgs e)
        {  //CutPicイメージ存在確認
            if (CutPic.Image != null)
            {
                //指定色ボックス検査色選択FLAGをTRUEする
                StarChooseCol = true;
            }
            else
            {
                MessageBox.Show("まずは画像選択とか画像保存してください。");
            }
        }

        /// <summary>
        /// 自動対象目標設定ボタン
        /// </summary>
        private void AutoLock_Click(object sender, EventArgs e)
        {
            try
            {
                if (OneTimeAuto)
                {
                    //CutPicイメージ存在確認
                    if (CutPic.Image != null)
                    {
                        OneTimeAuto = false;

                        CSComboBox.SelectedIndex = (int)CutSize.OnehundredPer;

                        //マスター画像bitmap取得
                        Bitmap CheackBT = (Bitmap)MasterImage.Clone();

                        //目標色設定
                        int R = AutoCol.BackColor.R;
                        int G = AutoCol.BackColor.G;
                        int B = AutoCol.BackColor.B;

                        if (NeerNumbers(R, G, B, 5))
                        {
                            MessageBox.Show("黒、白、灰色は使用できない");
                        }

                        if (!NeerNumbers(R, G, B, 5))
                        {
                            this.Cursor = Cursors.WaitCursor;
                            ////ボックス番号
                            //int boxnum = 0;
                            //ボックス数
                            int Boxlimit = Convert.ToInt32(CheckLockNum.Text);

                            //ボックス番号
                            BoxNum = 1;

                            //横縦計算用int
                            int w = 0, h = 0;

                            //ボックス判定用四角保存リスト
                            List<Rectangle> rectList = new List<Rectangle>();

                            //現存ボックスクリア
                            BoxNameCombo.Items.Clear();
                            MyBoxList.Clear();
                            CutPic.Controls.Clear();

                            //対象名リセット
                            BoxNameList.Clear();

                            //最初の位置探す用色合い基準
                            int firstLimitR = Convert.ToInt32(AutoColRedNums.Text);
                            int firstLimitG = Convert.ToInt32(AutoColGreenNums.Text);
                            int firstLimitB = Convert.ToInt32(AutoColBlueNums.Text);

                            //横幅測量基準色合い
                            int IroAi = 50;


                            //検索ループ
                            for (int i = 0; i < CutPic.Width; i++)
                            {
                                for (int j = 0; j < CutPic.Height; j++)
                                {
                                    //検索したピクセルのRGB取得
                                    int CR = CheackBT.GetPixel(i, j).R;
                                    int CG = CheackBT.GetPixel(i, j).G;
                                    int CB = CheackBT.GetPixel(i, j).B;

                                    //最初の対象ボックス
                                    if (BoxNum == 1)
                                    {
                                        //ボックスの左上の点を取得条件
                                        if (CR >= R - firstLimitR && CR <= R + firstLimitR &&
                                        CG >= G - firstLimitG && CG <= G + firstLimitG &&
                                        CB >= B - firstLimitB && CB <= B + firstLimitB)
                                        {
                                            //横幅計算
                                            for (int k = i; k < CutPic.Width; k++)
                                            {
                                                //左上の点の右の点の色RGBを取得
                                                int KR = CheackBT.GetPixel(k, j).R;
                                                int KG = CheackBT.GetPixel(k, j).G;
                                                int KB = CheackBT.GetPixel(k, j).B;

                                                //右に行って色合い以内ならば横幅(w)++
                                                if (KR >= R - IroAi && KR <= R + IroAi &&
                                                    KG >= G - IroAi && KG <= G + IroAi &&
                                                    KB >= B - IroAi && KB <= B + IroAi)
                                                {
                                                    w++;
                                                }
                                                else
                                                {
                                                    //違いますなら計算終了
                                                    break;
                                                }
                                            }

                                            //縦幅計算
                                            for (int l = j; l < CutPic.Height; l++)
                                            {
                                                //左上の点の下の点の色RGBを取得
                                                int lR = CheackBT.GetPixel(i, l).R;
                                                int lG = CheackBT.GetPixel(i, l).G;
                                                int lB = CheackBT.GetPixel(i, l).B;
                                                //下に行って色合い以内ならば縦幅(h)++
                                                if (lR >= R - IroAi && lR <= R + IroAi &&
                                                    lG >= G - IroAi && lG <= G + IroAi &&
                                                    lB >= B - IroAi && lB <= B + IroAi)
                                                {
                                                    h++;
                                                }
                                                else
                                                {
                                                    //違いますなら計算終了
                                                    break;
                                                }
                                            }

                                            //欲し長さ
                                            int r = 0;
                                            //いい横幅
                                            bool goodbuildW = true;
                                            //いい縦幅
                                            bool goodbuildR = true;
                                            //正方形とか
                                            bool notrangle = false;

                                            //横幅縦幅同じ確認
                                            if (w > h)
                                            {
                                                notrangle = true;
                                            }
                                            else if (h > w)
                                            {
                                                notrangle = true;
                                            }
                                            else if (h == w)
                                            {
                                                r = h;
                                                notrangle = false;


                                            }

                                            //正方形なら
                                            if (!notrangle)
                                            {
                                                //取得点中心としてもう一度計算


                                                if (i - (r / 2) > 0)
                                                {
                                                    for (int k = i - (r / 2); k < i + r; k++)
                                                    {
                                                        if (i + r < CutPic.Width)
                                                        {
                                                            //左上の点の右の点の色RGBを取得
                                                            int KR = CheackBT.GetPixel(k, j).R;
                                                            int KG = CheackBT.GetPixel(k, j).G;
                                                            int KB = CheackBT.GetPixel(k, j).B;

                                                            //右に行って色合い以内ならば横幅(w)++
                                                            if (KR >= R - IroAi && KR <= R + IroAi &&
                                                                KG >= G - IroAi && KG <= G + IroAi &&
                                                                KB >= B - IroAi && KB <= B + IroAi)
                                                            {
                                                                goodbuildW = true;
                                                            }
                                                            else
                                                            {
                                                                goodbuildW = false;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            goodbuildW = false;
                                                            break;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    goodbuildW = false;
                                                }

                                                if (j - (r / 2) > 0)
                                                {
                                                    //縦幅計算
                                                    for (int l = j - (r / 2); l < j + r; l++)
                                                    {
                                                        if (j + r < CutPic.Height)
                                                        {
                                                            //左上の点の下の点の色RGBを取得
                                                            int lR = CheackBT.GetPixel(i, l).R;
                                                            int lG = CheackBT.GetPixel(i, l).G;
                                                            int lB = CheackBT.GetPixel(i, l).B;
                                                            //下に行って色合い以内ならば縦幅(h)++
                                                            if (lR >= R - IroAi && lR <= R + IroAi &&
                                                                lG >= G - IroAi && lG <= G + IroAi &&
                                                                lB >= B - IroAi && lB <= B + IroAi)
                                                            {
                                                                goodbuildR = true;
                                                            }
                                                            else
                                                            {
                                                                goodbuildR = false;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            goodbuildR = false;
                                                            break;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    goodbuildR = false;
                                                }
                                            }


                                            if (goodbuildW && goodbuildR && !notrangle)
                                            {

                                                ////ボックス番号++
                                                //BoxNum++;
                                                //対象ボックス生成
                                                MyBox box = new MyBox();

                                                //対象ボックス番号設定
                                                box.MyNum = BoxNum;

                                                //対象ボックスをCutPicの子にする
                                                CutPic.Controls.Add(box);

                                                //ボックス番号テキスト
                                                box.MyNumber.Text = BoxNum.ToString();

                                                //ボックスリストに追加
                                                MyBoxList.Add(box);

                                                //ボックスコンボボックスに追加
                                                BoxNameCombo.Items.Add(BoxNum.ToString());

                                                ////ボックス名リストに追加
                                                //BoxNameList.Add(BoxNum.ToString());

                                                //ボックス判定用四角生成
                                                Rectangle angle = new Rectangle(i - (w / 2), j - (w / 2), w * 2, h * 2);

                                                //判定用四角をリストに追加
                                                rectList.Add(angle);

                                                //対象ボックスの位置とサイズ設定
                                                MyBoxList[BoxNum - 1].Location = new System.Drawing.Point(i, j);
                                                MyBoxList[BoxNum - 1].Width = w;
                                                MyBoxList[BoxNum - 1].Height = h;

                                                //ボックス計数器++
                                                BoxNum++;
                                            }

                                            //横縦計算用intを0にする
                                            w = 0;
                                            h = 0;
                                        }

                                    }

                                    //二個目以降の対象ボックス
                                    else if (/*BoxNum <= Boxlimit &&*/ BoxNum != 1)
                                    {
                                        if (CR >= R - firstLimitR && CR <= R + firstLimitR &&
                                            CG >= G - firstLimitG && CG <= G + firstLimitG &&
                                            CB >= B - firstLimitB && CB <= B + firstLimitB)
                                        {

                                            //横幅計算
                                            for (int k = i; k < CutPic.Width; k++)
                                            {
                                                //左上の点の右の点の色RGBを取得
                                                int KR = CheackBT.GetPixel(k, j).R;
                                                int KG = CheackBT.GetPixel(k, j).G;
                                                int KB = CheackBT.GetPixel(k, j).B;

                                                //右に行って色合い以内ならば横幅(w)++
                                                if (KR >= R - IroAi && KR <= R + IroAi &&
                                                    KG >= G - IroAi && KG <= G + IroAi &&
                                                    KB >= B - IroAi && KB <= B + IroAi)
                                                {
                                                    w++;
                                                }
                                                else
                                                {
                                                    //違いますなら計算終了
                                                    break;
                                                }
                                            }

                                            //縦幅計算
                                            for (int l = j; l < CutPic.Height; l++)
                                            {
                                                //左上の点の下の点の色RGBを取得
                                                int lR = CheackBT.GetPixel(i, l).R;
                                                int lG = CheackBT.GetPixel(i, l).G;
                                                int lB = CheackBT.GetPixel(i, l).B;

                                                //下に行って色合い以内ならば縦幅(h)++
                                                if (lR >= R - IroAi && lR <= R + IroAi &&
                                                    lG >= G - IroAi && lG <= G + IroAi &&
                                                    lB >= B - IroAi && lB <= B + IroAi)
                                                {
                                                    h++;
                                                }
                                                else
                                                {
                                                    //違いますなら計算終了
                                                    break;
                                                }
                                            }
                                            //欲し長さ
                                            int ro = 0;
                                            //いい横幅
                                            bool goodbuildW = true;
                                            //いい縦幅
                                            bool goodbuildR = true;
                                            //正方形とか
                                            bool notrangle = false;

                                            //横幅縦幅同じ確認
                                            if (w > h)
                                            {
                                                ro = w;
                                                notrangle = true;
                                            }
                                            else if (h > w)
                                            {
                                                ro = h;
                                                notrangle = true;
                                            }
                                            else if (h == w)
                                            {
                                                ro = h;
                                                notrangle = false;

                                            }

                                            //正方形なら
                                            if (!notrangle)
                                            {
                                                //取得の点を中心店としても一度計算

                                                if (i - (ro / 2) > 0)
                                                {

                                                    for (int k = i - (ro / 2); k < i + ro; k++)
                                                    {
                                                        if (i + ro < CutPic.Width)
                                                        {
                                                            //左上の点の右の点の色RGBを取得
                                                            int KR = CheackBT.GetPixel(k, j).R;
                                                            int KG = CheackBT.GetPixel(k, j).G;
                                                            int KB = CheackBT.GetPixel(k, j).B;

                                                            //右に行って色合い以内ならば横幅(w)++
                                                            if (KR >= R - IroAi && KR <= R + IroAi &&
                                                                KG >= G - IroAi && KG <= G + IroAi &&
                                                                KB >= B - IroAi && KB <= B + IroAi)
                                                            {
                                                                goodbuildW = true;
                                                            }
                                                            else
                                                            {
                                                                goodbuildW = false;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            goodbuildW = false;
                                                            break;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    goodbuildW = false;
                                                }

                                                if (j - (ro / 2) > 0)
                                                {
                                                    //縦幅計算
                                                    for (int l = j - (ro / 2); l < j + ro; l++)
                                                    {
                                                        if (j + ro < CutPic.Height)
                                                        {
                                                            //左上の点の下の点の色RGBを取得
                                                            int lR = CheackBT.GetPixel(i, l).R;
                                                            int lG = CheackBT.GetPixel(i, l).G;
                                                            int lB = CheackBT.GetPixel(i, l).B;
                                                            //下に行って色合い以内ならば縦幅(h)++
                                                            if (lR >= R - IroAi && lR <= R + IroAi &&
                                                                lG >= G - IroAi && lG <= G + IroAi &&
                                                                lB >= B - IroAi && lB <= B + IroAi)
                                                            {
                                                                goodbuildR = true;
                                                            }
                                                            else
                                                            {
                                                                goodbuildR = false;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            goodbuildR = false;
                                                            break;
                                                        }
                                                    }
                                                }
                                            }
                                            if (goodbuildW && goodbuildR && !notrangle)
                                            {

                                                //生成必要判定FLAG
                                                bool canbuild = true;

                                                //生成済みの対象と判定　同じ場所なら生成必要ない
                                                for (int r = 0; r < rectList.Count; r++)
                                                {
                                                    if (rectList[r].Contains((i + (i + w)) / 2, (j + (j + h)) / 2) ||
                                                        rectList[r].Contains(i + 5, j - 5) ||
                                                        rectList[r].Contains(i + 5, j + 5) ||
                                                        rectList[r].Contains(i - 5, j - 5) ||
                                                        rectList[r].Contains(i - 5, j + 5))
                                                    {
                                                        w = 0;
                                                        h = 0;
                                                        canbuild = false;
                                                    }

                                                }

                                                //生成必要
                                                if (canbuild)
                                                {
                                                    //ボックス数量は指定数量を超えるか判定
                                                    //if (MyBoxList.Count < Boxlimit)
                                                    //{
                                                        ////ボックス番号++
                                                        //BoxNum++;
                                                        //対象ボックス生成
                                                        MyBox box = new MyBox();

                                                        //対象ボックス番号設定
                                                        box.MyNum = BoxNum;

                                                        //対象ボックスをCutPicの子にする
                                                        CutPic.Controls.Add(box);

                                                        //ボックス番号テキスト
                                                        box.MyNumber.Text = BoxNum.ToString();

                                                        //ボックスリストに追加
                                                        MyBoxList.Add(box);

                                                        //ボックスコンボボックスに対象ボックス名追加
                                                        BoxNameCombo.Items.Add(BoxNum.ToString());

                                                        ////ボックス名リストに追加
                                                        //BoxNameList.Add(BoxNum.ToString());
                                                        //ボックス判定用四角生成
                                                        Rectangle angle = new Rectangle(i - (w / 2), j - (w / 2), w * 2, h * 2);

                                                        //判定用四角をリストに追加
                                                        rectList.Add(angle);

                                                        //対象ボックスの位置とサイズ設定
                                                        MyBoxList[BoxNum - 1].Location = new System.Drawing.Point(i, j);
                                                        MyBoxList[BoxNum - 1].Width = w;
                                                        MyBoxList[BoxNum - 1].Height = h;

                                                        //ボックス計数器++
                                                        if (BoxNum != 1)
                                                        {
                                                            BoxNum++;
                                                        }

                                                    //}
                                                    //横縦計算用intを0にする
                                                    w = 0;
                                                    h = 0;
                                                }
                                            }

                                            w = 0;
                                            h = 0;

                                        }

                                    }

                                }

                            }

                            if (BoxNameCombo.Items.Count > 0)
                            {
                                //ボックスコンボボックスのインデックス0にします
                                BoxNameCombo.SelectedIndex = 0;
                            }

                            CheckLockNum.Text = (BoxNum-1).ToString();

                        }

                        this.Cursor = Cursors.Default;
                        OneTimeAuto = true;
                    }
                    else
                    {
                        MessageBox.Show("まずは画像選択とか画像保存してください。");
                    }
                }

            }
            catch
            {

            }

        }

        /// <summary>
        /// 自動対象目標設定色選択ボタン
        /// </summary>
        private void AutoColSelectBtn_Click(object sender, EventArgs e)
        {

            //CutPicイメージ存在確認
            if (CutPic.Image != null)
            {

                //自動対象検索用色選択FLAGをTRUEにする
                StarChooseAutoCol = true;
            }
            else
            {
                MessageBox.Show("まずは画像選択とか画像保存してください。");
            }
        }

        /// <summary>
        /// マウスでマスタ画像から参照したい色を決める
        /// </summary>
        private void CutPic_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                //指定色ボックス検査色
                if (StarChooseCol)
                {
                    //マスターが画像bitmap取得
                    Bitmap bmp = new Bitmap(CutPic.Image);

                    //マウス指す場所色を取得そして設定
                    Color color = bmp.GetPixel(e.X, e.Y);
                    UseCol.BackColor = Color.FromArgb(color.R, color.G, color.B);
                    MyBoxList[BoxNameCombo.SelectedIndex].UsedCol = CheckCol = color;

                    //選択FLAG閉める
                    StarChooseCol = false;

                    this.Cursor = Cursors.Default;
                }

                //自動対象検索用色
                if (StarChooseAutoCol)
                {
                    //マスターが画像bitmap取得
                    Bitmap bmp = new Bitmap(CutPic.Image);

                    //マウス指す場所色を取得そして設定
                    Color color = bmp.GetPixel(e.X, e.Y);
                    AutoCol.BackColor = Color.FromArgb(color.R, color.G, color.B);

                    //選択FLAG閉める
                    StarChooseAutoCol = false;
                    this.Cursor = Cursors.Default;
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// マウスでマスタ画像から参照したい色をみる
        /// </summary>
        private void CutPic_MouseMove(object sender, MouseEventArgs e)
        { //CutPicイメージ存在確認
            if (CutPic.Image != null)
            {

                ////マスターが画像bitmap取得
                //GetColor = new Bitmap(CutPic.Image);

                //マウス指す場所色を取得そして表示
                Color color = GetColor.GetPixel(e.X, e.Y);

                //指定色ボックス検査色
                if (StarChooseCol)
                {
                    this.Cursor = Cursors.Hand;
                    UseCol.BackColor = Color.FromArgb(color.R, color.G, color.B);
                }
                //自動対象検索用色
                if (StarChooseAutoCol)
                {
                    this.Cursor = Cursors.Hand;
                    AutoCol.BackColor = Color.FromArgb(color.R, color.G, color.B);
                }

                MouseRGB.Text = "R:" + color.R + " G:" + color.G + " B:" + color.B;
                MouseRGB.ForeColor = color;
            }
        }

        /// <summary>
        /// マウスがCutPicから離れる時の処理
        /// </summary>
        private void CutPic_MouseLeave(object sender, EventArgs e)
        {
            //指定色ボックス検査色
            if (StarChooseCol)
            {
                this.Cursor = Cursors.Default;

            }
            //自動対象検索用色
            if (StarChooseAutoCol)
            {
                this.Cursor = Cursors.Default;
            }

            //マウス指したRGB値を表示オフ　
            MouseRGB.Text = null;
        }

        /// <summary>
        /// 対象ボックスを一つに戻すボタン
        /// </summary>
        private void CleanObj_Click(object sender, EventArgs e)
        {
            //ボックス数量を取る
            int MyboxNums = MyBoxList.Count;

            //最後の一つから消す
            //for (int i = (MyboxNums - 1); i > 0; i--)
            //{
            //    MyBoxList.RemoveAt(i);
            //    CutPic.Controls.RemoveAt(i);
            //    BoxNameCombo.Items.RemoveAt(i);

            //    if (BoxNameList.Count > 1)
            //    {
            //        BoxNameList.RemoveAt(i);
            //    }

            //}

            //すべてのボックス削除
            MyBoxList.Clear();
            CutPic.Controls.Clear();
            BoxNameCombo.Items.Clear();
            BoxNameList.Clear();

            //もう一つ新しいボックス生成
            BoxNum = 1;
            MyBox box = new MyBox();
            CutPic.Controls.Add(box);
            BoxNameCombo.Items.Add("1");
            box.MyNum = 1;
            MyBoxList.Add(box);
            if(BoxNameCombo.Items.Count > 0)
            {
                BoxNameCombo.SelectedIndex = 0;
            }

        }

        /// <summary>
        /// 選択した対象ボックスに切り替え
        /// </summary>
        private void ClickBoxNum_TextChanged(object sender, EventArgs e)
        {
            BoxNameCombo.SelectedIndex = NowBox - 1;
        }

        /// <summary>
        /// 結果リスト色付け
        /// </summary>
        private void CheckPerList_DrawItem(object sender, DrawItemEventArgs e)
        {
            //赤ブラシ
            var Redbrush = new SolidBrush(Color.Red);
            //青ブラシ
            var Blackbrush = new SolidBrush(Color.Blue);

            if (GetAnser.Count >= 1)
            {
                //正常
                if (GetAnser[e.Index])
                {
                    e.Graphics.DrawString(CheckPerList.Items[e.Index].ToString(), e.Font, Blackbrush, e.Bounds, StringFormat.GenericDefault);
                }
                //異常
                else
                {
                    e.Graphics.DrawString(CheckPerList.Items[e.Index].ToString(), e.Font, Redbrush, e.Bounds, StringFormat.GenericDefault);
                }
            }

        }

        /// <summary>
        /// 三つの数値が近いの検査関数
        /// </summary>
        private bool NeerNumbers(int a, int b, int c, int limint)
        {
            if (a + limint > b && a + limint > c &&
                b + limint > a && b + limint > c &&
                c + limint > a && c + limint > b &&
                a - limint < b && a - limint < c &&
                b - limint < a && b - limint < c &&
                c - limint < a && c - limint < b)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// マウス指した色RGB値取得
        /// </summary>
        private void CameraPic_MouseMove(object sender, MouseEventArgs e)
        {
            if (CameraPic.Image != null)
            {
                //マウス指す場所色を取得そして表示
                Color color = ((Bitmap)CameraPic.Image).GetPixel(e.X, e.Y);

                //指定色ボックス検査色
                if (StarChooseCol)
                {
                    this.Cursor = Cursors.Hand;
                    UseCol.BackColor = Color.FromArgb(color.R, color.G, color.B);
                }
                //自動対象検索用色
                if (StarChooseAutoCol)
                {
                    this.Cursor = Cursors.Hand;
                    AutoCol.BackColor = Color.FromArgb(color.R, color.G, color.B);
                }


                MouseRGB.Text = "R:" + color.R + " G:" + color.G + " B:" + color.B;
                MouseRGB.ForeColor = color;
            }
        }

        /// <summary>
        /// マウスがCameraPicから離す時に指すRGB値の表示を閉める
        /// </summary>
        private void CameraPic_MouseLeave(object sender, EventArgs e)
        {
            MouseRGB.Text = null;
        }

        private void CameraPic_MouseDown(object sender, MouseEventArgs e)
        {
            //指定色ボックス検査色
            if (StarChooseCol)
            {
                //マスターが画像bitmap取得
                Bitmap bmp = new Bitmap(CutPic.Image);

                //マウス指す場所色を取得そして設定
                Color color = bmp.GetPixel(e.X, e.Y);
                UseCol.BackColor = Color.FromArgb(color.R, color.G, color.B);
                MyBoxList[BoxNameCombo.SelectedIndex].UsedCol = CheckCol = color;

                //選択FLAG閉める
                StarChooseCol = false;

                this.Cursor = Cursors.Default;
            }

            //自動対象検索用色
            if (StarChooseAutoCol)
            {
                //マスターが画像bitmap取得
                Bitmap bmp = new Bitmap(CutPic.Image);

                //マウス指す場所色を取得そして設定
                Color color = bmp.GetPixel(e.X, e.Y);
                AutoCol.BackColor = Color.FromArgb(color.R, color.G, color.B);

                //選択FLAG閉める
                StarChooseAutoCol = false;
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 自動ガンマ計算
        /// </summary>
        private void GamamTimer_Tick(object sender, EventArgs e)
        {
            //自動ガンマ調整
            if (StarGamamCheck)
            {
                //カメラ画像
                Bitmap bmp = new Bitmap(img.ToBitmap());

                for (int i = 0; i < CameraPic.Width; i++)
                {
                    //ピクセル単位でRGB値を取得
                    for (int j = 0; j < CameraPic.Height; j++)
                    {
                        NowR.Add(bmp.GetPixel(i, j).R);
                        NowG.Add(bmp.GetPixel(i, j).G);
                        NowB.Add(bmp.GetPixel(i, j).B);
                    }
                }


                //全画素平均RGB値を取得
                int AvgR = (int)NowR.Average();
                int AvgG = (int)NowG.Average();
                int AvgB = (int)NowB.Average();

                //RGB値の平均
                double Avg = (((double)AvgR + (double)AvgG + (double)AvgB) / 3.0) / 100.0;
                double GetAvg = Math.Round(Avg, 2, MidpointRounding.AwayFromZero);

                GetGamma = (GetAvg + 1.15) / 2;

                //label10.Text = GetAvg.ToString();
                NowGamma.Text = GetGamma.ToString();
            }
        }

        /// <summary>
        /// セーフデータフォルダ開くボタン
        /// </summary>
        private void OpenSaveFolder_Click(object sender, EventArgs e)
        {
            //フォルダ開く
            Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"\SaveData");
        }


    }
}