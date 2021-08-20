using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace camera
{
    public partial class SettingBoxName : Form
    {
        //各ラベルとテキストボックスのY差値
        private readonly int blankLocateY = 30;
        //ボックスNUMBER
        public int Boxnum = 0;

        //ラベル位置
        private Point LPoint;
        //テキストボックス位置
        private Point TPoint;

        //ラベルリスト
        public List<Label> LabelList = new List<Label>();
        //テキストボックスリスト
        public List<TextBox> TextBox = new List<TextBox>();

        public SettingBoxName()
        {
            InitializeComponent();
            LabelList.Add(Nums);
            TextBox.Add(Boxname);
        }

        //新しいラベル作成
        public Point BuildNewlabel(Point p, string s, List<Label> l)
        {
            Label label = new Label();
            label.Location = new Point(p.X, p.Y + blankLocateY);
            label.AutoSize = true;
            label.Text = s;
            Controls.Add(label);
            l.Add(label);
            //p = label.Location;
            return label.Location;
        }

        //新しいテキストボックス作成
        public Point BuildNewTextBox(Point p, string s, List<TextBox> l)
        {
            TextBox text = new TextBox();
            text.Location = new Point(p.X, p.Y + blankLocateY);
            text.AutoSize = true;
            text.Text = s;
            Controls.Add(text);
            l.Add(text);
            //p = label.Location;
            return text.Location;
        }

        //Load
        private void SettingBoxName_Load(object sender, EventArgs e)
        {
            //最初のテキストとラベルの位置を取得
            LPoint = Nums.Location;
            TPoint = Boxname.Location;

            //必要の数量生成ループ
            for (int i = 1; i < Boxnum; i++)
            {
                LPoint = BuildNewlabel(LPoint, (i + 1).ToString(), LabelList);

                TPoint = BuildNewTextBox(TPoint, null, TextBox);
            }

            //メインシーンを取得
            MainScene main = (MainScene)this.Owner;

            //既に名前ある対象名を取得
            if (main.BoxNameList.Count != 0)
            {
                for (int i = 0; i < main.BoxNameList.Count; i++)
                {

                    TextBox[i].Text = main.BoxNameList[i];
                }
            }
        }

        //完成ボタン
        private void CompleteBtn_Click(object sender, EventArgs e)
        {
            //このフォームを終了
            this.Close();
        }
    }
}