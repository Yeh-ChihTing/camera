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

        public bool BoxChecked = false;

        public Color UsedCol;

        /// <summary>
        /// private
        /// </summary>
        
        ///// <summary>
        /////　サイズ調整Boxの基礎横幅
        ///// </summary>
        //private int BROW = 15;
        ///// <summary>
        /////　サイズ調整Boxの基礎縦幅
        ///// </summary>
        //private int BROH = 15;
        ///// <summary>
        /////　サイズ調整Boxの変更倍率
        ///// </summary>
        //private int BRSizeLevel = 7;


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

        private Size OriginSize;
        public enum CursorPos
        {
            None,
            LeftTop,
            Top,
            RightTop,
            LeftBottom,
            Bottom,
            RightBottom
        }

        public enum ResizeDirection
        {
            None = 0,
            Top = 1,
            Left = 2,
            Bottom = 4,
            Right = 8,
            All = 15
        }

        //// サイズ変更が有効になる枠
        //ResizeDirection resizeDirection;

        //// サイズ変更中を表す状態
        //ResizeDirection resizeStatus;

        CursorPos CurPos;

        // 標準のカーソル
        private Cursor defaultCursor;
        private bool ReSize = false;

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
            defaultCursor = this.Cursor;

            
        }


        //描画命令
        protected override void OnPaint(PaintEventArgs e)
        {
            //Drawbox.SendToBack();

            int right = this.ClientRectangle.Right - 3;
            int bottom = this.ClientRectangle.Bottom - 3;

            Pen pen = new Pen(this._borderColor, 3);

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
                OriginSize = this.Size;
                this.Capture = true;
            }
        }

        //Box移動用
        private void MyBox_MouseMove(object sender, MouseEventArgs e)
        {
           

            ResizeDirection cursorPos = ResizeDirection.None;
           
            //上の判定
            //if ((resizeDirection & ResizeDirection.Top) == ResizeDirection.Top)
            //{
            Rectangle topRect = new Rectangle(0, -5, this.Width, 10);
            if (topRect.Contains(e.Location))
            {
                cursorPos |= ResizeDirection.Top;
            }
            // }
            // 左の判定
            //if ((resizeDirection & ResizeDirection.Left) == ResizeDirection.Left)
            //{
            Rectangle leftRect = new Rectangle(-5, 0, 10, this.Height);
            if (leftRect.Contains(e.Location))
            {
                cursorPos |= ResizeDirection.Left;
            }
            // }

            // 下の判定
            //if ((resizeDirection & ResizeDirection.Bottom) == ResizeDirection.Bottom)
            //{
            Rectangle bottomRect = new Rectangle(0, this.Height - 10, this.Width, this.Height);
            if (bottomRect.Contains(e.Location))
            {
                cursorPos |= ResizeDirection.Bottom;
            }
            //  }

            // 右の判定
            //if ((resizeDirection & ResizeDirection.Right) == ResizeDirection.Right)
            //{
            Rectangle rightRect = new Rectangle(this.Width - 10, 0, this.Width, this.Height);
            if (rightRect.Contains(e.Location))
            {
                cursorPos |= ResizeDirection.Right;
            }

            // カーソルを変更
            //左上
            if ((cursorPos & ResizeDirection.Top) == ResizeDirection.Top
            && (cursorPos & ResizeDirection.Left) == ResizeDirection.Left)
            {
                this.Cursor = Cursors.SizeNWSE;
            }
            //右上
            else if ((cursorPos & ResizeDirection.Top) == ResizeDirection.Top
                && (cursorPos & ResizeDirection.Right) == ResizeDirection.Right)
            {
                this.Cursor = Cursors.SizeNESW;
            }

            //左下
            else if((cursorPos & ResizeDirection.Bottom) == ResizeDirection.Bottom
                && (cursorPos & ResizeDirection.Left) == ResizeDirection.Left)
            {
                this.Cursor = Cursors.SizeNESW;
            }
            //右下
            else if((cursorPos & ResizeDirection.Bottom) == ResizeDirection.Bottom
                && (cursorPos & ResizeDirection.Right) == ResizeDirection.Right)
            {
                this.Cursor = Cursors.SizeNWSE;
            }

            // 上
            else if ((cursorPos & ResizeDirection.Top) == ResizeDirection.Top)
            {
                this.Cursor = Cursors.SizeNS;
            }
            //　下
            else if ((cursorPos & ResizeDirection.Bottom) == ResizeDirection.Bottom)
            {
                this.Cursor = Cursors.SizeNS;
            }
            // 左
            else if ((cursorPos & ResizeDirection.Left) == ResizeDirection.Left)
            {
                this.Cursor = Cursors.SizeWE;
            }
            //　右
            else if ((cursorPos & ResizeDirection.Right) == ResizeDirection.Right)
            {
                this.Cursor = Cursors.SizeWE;
            }

            else
            {
                this.Cursor = defaultCursor;
            }


       

            if (e.Button == MouseButtons.Left)
            {

                int diffX = e.X - OriginPoint.X;
                int diffY = e.Y - OriginPoint.Y;

                //左上
                if ((cursorPos & ResizeDirection.Top) == ResizeDirection.Top
            && (cursorPos & ResizeDirection.Left) == ResizeDirection.Left)
                {
                    //this.Cursor = Cursors.SizeNWSE;
                    //左
                    int w = this.Width;
                    this.Width -= diffX;
                    this.Left += w - this.Width;
                    //上
                    int h = this.Height;
                    this.Height -= diffY;
                    this.Top += h - this.Height;
                    ReSize = true;
                }
                //右上
                else if ((cursorPos & ResizeDirection.Top) == ResizeDirection.Top
                    && (cursorPos & ResizeDirection.Right) == ResizeDirection.Right)
                {
                    //this.Cursor = Cursors.SizeNESW;
                    //右
                    this.Height = OriginSize.Height + diffY;
                    //上
                    int h = this.Height;
                    this.Height -= diffY;
                    this.Top += h - this.Height;
                    ReSize = true;
                }

                //左下
                else if ((cursorPos & ResizeDirection.Bottom) == ResizeDirection.Bottom
                    && (cursorPos & ResizeDirection.Left) == ResizeDirection.Left)
                {
                    //this.Cursor = Cursors.SizeNESW;
                    //左
                    int w = this.Width;
                    this.Width -= diffX;
                    this.Left += w - this.Width;
                    //下
                    this.Width = OriginSize.Width + diffX;
                    ReSize = true;
                }
                //右下
                else if ((cursorPos & ResizeDirection.Bottom) == ResizeDirection.Bottom
                    && (cursorPos & ResizeDirection.Right) == ResizeDirection.Right)
                {
                    //this.Cursor = Cursors.SizeNWSE;
                    //右
                    this.Height = OriginSize.Height + diffY;
                    //下
                    this.Width = OriginSize.Width + diffX;
                    ReSize = true;
                }

                // 上
                else if (cursorPos == ResizeDirection.Top)
                {
                    //this.Cursor = Cursors.SizeNS;
                    int h = this.Height;
                    this.Height -= diffY;
                    this.Top += h - this.Height;
                    ReSize = true;

                }
                //　下
                else if (cursorPos == ResizeDirection.Bottom)
                {
                    //this.Cursor = Cursors.SizeNS;
                    this.Height = OriginSize.Height + diffY;
                    ReSize = true;
                }
                // 左
                else if (cursorPos == ResizeDirection.Left)
                {
                    //this.Cursor = Cursors.SizeWE;
                    int w = this.Width;
                    this.Width -= diffX;
                    this.Left += w - this.Width;
                    ReSize = true;
                }
                //　右
                else if (cursorPos == ResizeDirection.Right)
                {
                    //this.Cursor = Cursors.SizeWE;
                    this.Width = OriginSize.Width + diffX;
                    ReSize = true;

                }

                else
                {
                    
                    if (!ReSize)
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
               
                //if (this.Size.Width >= 30 & this.Size.Height >= 30)
                //{
                //    Point mp = new Point(e.X - OriginPoint.X + BottonRight.Location.X, e.Y - OriginPoint.Y + BottonRight.Location.Y);
                //    BottonRight.Location = mp;
                //    int CsX = BottonRight.Location.X + BottonRight.Width;
                //    int CsY = BottonRight.Location.Y + BottonRight.Height;
                //    this.Size = new Size(CsX, CsY);
                //}
                //else if(this.Size.Width < 30&& this.Size.Height < 30)
                //{
                //    this.Size = new Size(30, 30);
                //    BottonRight.Location = new Point(this.Width - BottonRight.Size.Width, this.Height - BottonRight.Size.Height);
                //}
                //else if(this.Size.Width<30)
                //{
                //    this.Size = new Size(30, this.Size.Height);
                //    BottonRight.Location = new Point(this.Width-BottonRight.Size.Width, BottonRight.Location.Y);
                //}
                //else if (this.Size.Height < 30)
                //{
                //    this.Size = new Size(this.Size.Width,30);
                //    BottonRight.Location = new Point(BottonRight.Width, this.Height-BottonRight.Size.Height);
                //}

            }
        }

        //サイズ変更のイベント反応
        private void MyBox_SizeChanged(object sender, EventArgs e)
        {
            //BottonRight.Size = new Size(this.Width / BRSizeLevel, this.Height / BRSizeLevel);

            //BottonRight.Location = new Point(this.Width - BottonRight.Width, this.Height - BottonRight.Height);

            //Drawbox.Location = new Point(5, 5);
            //Drawbox.Width = this.Width - 10;
            //Drawbox.Height = this.Height - 10;
            if ((int)(this.Width / 10) > 1)
            {
                MyNumber.Font = new Font(MyNumber.Font.FontFamily, (int)(this.Width / 10));
            }
            else
            {
                MyNumber.Font = new Font(MyNumber.Font.FontFamily, 1);
            }

            string a ="Pw:"+this.Parent.Width+"PH:"+this.Parent.Height+ 
                "       Width:" + this.Width + "Height:" + this.Height;
            this.Parent.Parent.Parent.Text = a;

        }

        //粋線色設定
        public void SetColor(Color col)
        {
            BorderColor = col;
        }

        //サイズ変更用ボックスの位置リーセット
        public void setBottonRight(int mul)
        {
            //BottonRight.Size = new Size(this.Width / BRSizeLevel, this.Height / BRSizeLevel);

            //if (mul == 1)
            //{
            //    MyNumber.Font = new Font("Serif", 12, FontStyle.Bold);
            //    BottonRight.Width = BROW;
            //    BottonRight.Height = BROH;
            //}
            //else
            //{
            //    MyNumber.Font = new Font("Serif", 12 *(mul / 2), FontStyle.Bold);
            //    //BottonRight.Width = BROW;
            //    //BottonRight.Height = BROH;
            //    BottonRight.Width = BROW * (mul / 2);
            //    BottonRight.Height = BROH * (mul / 2);
            //}


            //BottonRight.Location = new Point(this.Width - BottonRight.Width, this.Height - BottonRight.Height);
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
            //if(e.Location.X>BottonRight.Location.X&&e.Location.X<(BottonRight.Location.X+BottonRight.Width)&&
            //    e.Location.Y > BottonRight.Location.Y && e.Location.Y < (BottonRight.Location.Y + BottonRight.Height))
            //{
            //    this.Cursor = Cursors.SizeNWSE;
            //}
            this.Cursor = defaultCursor;

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

        private void MyBox_MouseUp(object sender, MouseEventArgs e)
        {
            this.Capture = false;
            ReSize = false;
        }
    }
}
