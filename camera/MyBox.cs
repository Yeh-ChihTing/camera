using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace camera
{
    public partial class MyBox : UserControl 
    {

        /// <summary>
        ///　public変数
        /// </summary>

        /// <summary>
        ///　粋番号
        /// </summary>
        public int MyNum = 1;
   
        /// <summary>
        ///　BoxのRed参照値
        /// </summary>
        public int Red = 20;
        /// <summary>
        ///　BoxのGreen参照値
        /// </summary>
        public int Green = 20;
        /// <summary>
        ///　BoxのBlue参照値
        /// </summary>
        public int Blue = 20;
        /// <summary>
        ///　Boxの合格パーセント参照値
        /// </summary>
        public int MySPercent = 80;

        /// <summary>
        /// 枠線
        /// </summary>
        public Color _borderColor = Color.Blue;
        public Color BorderColor
        {
            get { return this._borderColor; }
            set
            {
                this._borderColor = value;

            }
        }

        public enum BoxMode
        {
            Samontape=0,
            LampOn=1,
            LampOff=2
        }

        public BoxMode MyBoxMode;

        /// <summary>
        /// private
        /// </summary>
        
        /// <summary>
        ///　サイズ調整Boxの基礎横幅
        /// </summary>
        private int BROW = 15;
        /// <summary>
        ///　サイズ調整Boxの基礎縦幅
        /// </summary>
        private int BROH = 15;
        /// <summary>
        ///　サイズ調整Boxの変更倍率
        /// </summary>
        private int BRSizeLevel = 7;


        /// <summary>
        ///　親フォームの横幅値を取得用
        /// </summary>
        private int PWeight = 0;
        /// <summary>
        ///　親フォームの縦幅値を取得用
        /// </summary>
        private int PHeight = 0;

        /// <summary>
        ///　マウスクリックした初期位置
        /// </summary>
        private Point OriginPoint;

        public MyBox()
        {
            InitializeComponent();
            // ダブルバッファリングを有効
            SetStyle(ControlStyles.DoubleBuffer, true);

            //グループボックスの描画をオーナードローにする
            SetStyle(ControlStyles.UserPaint, true);

            //this.BackColor = Color.Transparent;

            //粋番号を表示する
            MyNumber.Text = MyNum.ToString();

            //DrawBoxの位置を初期化します
            Drawbox.Location = new Point(this.Location.X + 5, this.Location.Y + 5);
            Drawbox.Width = this.Width - 10;
            Drawbox.Height = this.Height - 10;
            Drawbox.Controls.Add(MyNumber);
            MyBoxMode = BoxMode.Samontape;
            MyNumber.ForeColor = Color.LightSalmon;
           
        }


        //描画命令
        protected override void OnPaint(PaintEventArgs e)
        {

            int right = this.ClientRectangle.Right - 5;
            int bottom = this.ClientRectangle.Bottom - 5;

            Pen pen = new Pen(this._borderColor,5);

            // 四角を描画
            Graphics g = this.CreateGraphics();
            g.DrawLine(pen, 0, 0, right, 0); // 上辺
            g.DrawLine(pen, 0, 0, 0, bottom); // 左辺
            g.DrawLine(pen, right, 0, right, bottom); // 右辺
            g.DrawLine(pen, 0, bottom, right, bottom); // 下辺


            //Pen p = new Pen(Color.FromArgb(255, Color.Blue), 5);
            ////四角を描画する
            //e.Graphics.DrawRectangle(p, new Rectangle(0, 0, this.Width-1, this.Height-1));
            //p.Dispose();

        }

        //コントロールのサイズ変化の時
        protected override void OnSizeChanged(EventArgs e)
        {
            // 描画をクリア
            this.Refresh();

            base.OnSizeChanged(e);
        }

        private void MyBox_MouseDown(object sender, MouseEventArgs e)
        {
            //マウス左クリック
            if(e.Button== MouseButtons.Left)
            {
                OriginPoint = e.Location;
                PWeight = this.Parent.Width;
                PHeight = this.Parent.Height;
            }
        }

        //Box移動用
        private void MyBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.Location.X + this.Width <= PWeight && this.Location.X >= 0 &&
                    this.Location.Y >= 0 && this.Location.Y <= PHeight)
                {
                    Point mp = new Point(e.X - OriginPoint.X + this.Location.X, e.Y - OriginPoint.Y + this.Location.Y);
                    this.Location = mp;
                }
                if (this.Location.X + this.Width > this.Parent.Width)
                {
                    this.Location = new Point(PWeight - this.Width, this.Location.Y);
                }
                if (this.Location.X < 0)
                {
                    this.Location = new Point(0, this.Location.Y);
                }
                if (this.Location.Y + this.Height > this.Parent.Height)
                {
                    this.Location = new Point(this.Location.X, PHeight-this.Height);
                }
                if (this.Location.Y < 0)
                {
                    this.Location = new Point(this.Location.X, 0);
                }

            }
        }

        //
        private void timer1_Tick(object sender, EventArgs e)
        {
            //背景色を常にColor.Transparent
            this.BackColor = Color.Transparent;
            
            //DrawBoxの表示と非表示時のMyNumberレベル状態の切り替え
            if (Drawbox.Visible)
            {
                if (Drawbox.Controls.Count == 0)
                {
                    this.Controls.Remove(MyNumber);
                    Drawbox.Controls.Add(MyNumber);
                }
            }
            else
            {
                if (Drawbox.Controls.Count == 1)
                {
                    Drawbox.Controls.Clear();
                    this.Controls.Add(MyNumber);
                }
            }
        }

        //サイズ変更用ボックスにマウスダウン
        private void BottonRight_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                OriginPoint = e.Location;              
            }
        }

        //サイズ変更用ボックスの移動
        private void BottonRight_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
               
                if (this.Size.Width >= 30 & this.Size.Height >= 30)
                {
                    Point mp = new Point(e.X - OriginPoint.X + BottonRight.Location.X, e.Y - OriginPoint.Y + BottonRight.Location.Y);
                    BottonRight.Location = mp;
                    int CsX = BottonRight.Location.X + BottonRight.Width;
                    int CsY = BottonRight.Location.Y + BottonRight.Height;
                    this.Size = new Size(CsX, CsY);
                }
                else if(this.Size.Width < 30&& this.Size.Height < 30)
                {
                    this.Size = new Size(30, 30);
                    BottonRight.Location = new Point(this.Width - BottonRight.Size.Width, this.Height - BottonRight.Size.Height);
                }
                else if(this.Size.Width<30)
                {
                    this.Size = new Size(30, this.Size.Height);
                    BottonRight.Location = new Point(this.Width-BottonRight.Size.Width, BottonRight.Location.Y);
                }
                else if (this.Size.Height < 30)
                {
                    this.Size = new Size(this.Size.Width,30);
                    BottonRight.Location = new Point(BottonRight.Width, this.Height-BottonRight.Size.Height);
                }

            }
        }

        //サイズ変更のイベント反応
        private void MyBox_SizeChanged(object sender, EventArgs e)
        {
            BottonRight.Size = new Size(this.Width / BRSizeLevel, this.Height / BRSizeLevel);

            BottonRight.Location = new Point(this.Width - BottonRight.Width, this.Height - BottonRight.Height);

            Drawbox.Location = new Point(5, 5);
            Drawbox.Width = this.Width - 10;
            Drawbox.Height = this.Height - 10;
            MyNumber.Font = new Font(MyNumber.Font.FontFamily, Drawbox.Width/6);
        }

        //粋線色設定
        public void SetColor(Color col)
        {
            BorderColor = col;
        }

        //サイズ変更用ボックスの位置リーセット
        public void setBottonRight(int mul)
        {
            BottonRight.Size = new Size(this.Width / BRSizeLevel, this.Height / BRSizeLevel);

            if (mul == 1)
            {
                MyNumber.Font = new Font("Serif", 12, FontStyle.Bold);
                BottonRight.Width = BROW;
                BottonRight.Height = BROH;
            }
            else
            {
                MyNumber.Font = new Font("Serif", 12 *(mul / 2), FontStyle.Bold);
                //BottonRight.Width = BROW;
                //BottonRight.Height = BROH;
                BottonRight.Width = BROW * (mul / 2);
                BottonRight.Height = BROH * (mul / 2);
            }


            BottonRight.Location = new Point(this.Width - BottonRight.Width, this.Height - BottonRight.Height);
        }

        private void MyBox_MouseClick(object sender, MouseEventArgs e)
        {
            //MainScene main = (MainScene)this.FindForm();
            //main.RedTrack.Value = Red;
            //main.GreenTrack.Value = Green;
            //main.BlueTrack.Value = Blue;

            //_borderColor = Color.Purple;
            //this.Invalidate();
        }

        public void ChangeColor(Color col)
        {
            _borderColor = col;
            this.Invalidate();
        }

        //DrawBoxにクリック
        private void Drawbox_MouseClick(object sender, MouseEventArgs e)
        {
            //MainScene main = (MainScene)this.FindForm();
            //main.RedTrack.Value = Red;
            //main.GreenTrack.Value = Green;
            //main.BlueTrack.Value = Blue;

            //_borderColor = Color.Purple;
            //this.Invalidate();

            //if (e.Button == MouseButtons.Left)
            //{
            //    if (this.Location.X + this.Width <= PWeight && this.Location.X >= 0 &&
            //        this.Location.Y >= 0 && this.Location.Y <= PHeight)
            //    {
            //        Point mp = new Point(e.X - OriginPoint.X + this.Location.X, e.Y - OriginPoint.Y + this.Location.Y);
            //        this.Location = mp;
            //    }
            //    if (this.Location.X + this.Width > this.Parent.Width)
            //    {
            //        this.Location = new Point(PWeight - this.Width, this.Location.Y);
            //    }
            //    if (this.Location.X < 0)
            //    {
            //        this.Location = new Point(0, this.Location.Y);
            //    }
            //    if (this.Location.Y + this.Height > this.Parent.Height)
            //    {
            //        this.Location = new Point(this.Location.X, PHeight - this.Height);
            //    }
            //    if (this.Location.Y < 0)
            //    {
            //        this.Location = new Point(this.Location.X, 0);
            //    }

            //}
        }

        //マウスダウンの時Box位置記録
        private void Drawbox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                OriginPoint = e.Location;
                PWeight = this.Parent.Width;
                PHeight = this.Parent.Height;
            }
        }

        //Box移動用
        private void Drawbox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.Location.X + this.Width <= PWeight && this.Location.X >= 0 &&
                    this.Location.Y >= 0 && this.Location.Y <= PHeight)
                {
                    Point mp = new Point(e.X - OriginPoint.X + this.Location.X, e.Y - OriginPoint.Y + this.Location.Y);
                    this.Location = mp;
                }
                if (this.Location.X + this.Width > this.Parent.Width)
                {
                    this.Location = new Point(PWeight - this.Width, this.Location.Y);
                }
                if (this.Location.X < 0)
                {
                    this.Location = new Point(0, this.Location.Y);
                }
                if (this.Location.Y + this.Height > this.Parent.Height)
                {
                    this.Location = new Point(this.Location.X, PHeight - this.Height);
                }
                if (this.Location.Y < 0)
                {
                    this.Location = new Point(this.Location.X, 0);
                }

            }
        }
    }
}
