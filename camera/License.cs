using System;
using System.Windows.Forms;
using System.IO;

namespace camera
{
    public partial class License : Form
    {
        //認証完成FLAG
        public bool Finish=false;

        public License()
        {
            InitializeComponent();

            //生成した時に画面の真中にする
            this.StartPosition = FormStartPosition.CenterScreen;

            //ID入力桁数上限
            MyID.MaxLength = 10;


            //PASS入力桁数上限
            MyPass.MaxLength = 10;
            //passの表示は**にします
            MyPass.PasswordChar = '*';
        }


        //完成ボタンクリック
        private void check_Click(object sender, EventArgs e)
        {
            Login();
        }

        //ロード
        private void License_Load(object sender, EventArgs e)
        {
            // サイズ変更不可の直線ウィンドウに変更する
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //Openscene隠し
            this.Owner.Visible = false;
            
        }

        //pass入力の時にEnterキー押す
        private void MyPass_KeyDown(object sender, KeyEventArgs e)
        {
            //Enterキー
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }           
        }

        private void Login()
        {
            //入力資料NULLではないの確認
            if (MyID.Text != "" && MyPass.Text != "")
            {
                //OpenScene取得
                OpenScene os = (OpenScene)this.Owner;

                //IDとPassの確認
                if (MyID.Text == os.LiID && MyPass.Text == os.LiPass)
                {

                    //フォルダ存在確認
                    if (!Directory.Exists(os.Foldpath))
                    {
                        Directory.CreateDirectory(os.Foldpath);
                    }

                    //IDとPASSの保存
                    using (StreamWriter sr = new StreamWriter(os.Lipath))
                    {
                        sr.WriteLine(MyID.Text);
                        sr.WriteLine(MyPass.Text);
                    }

                    //認証完成
                    Finish = true;

                    //このフォーム閉じる
                    this.Close();
                }
                else
                {
                    MessageBox.Show("IDがPassが間違いました");
                }
            }
            else
            {
                MessageBox.Show("IDとPass入力してください");
            }

        }

        //ID入力の時にEnterキー押す
        private void MyID_KeyDown(object sender, KeyEventArgs e)
        {
            //Enterキー
            if (e.KeyCode == Keys.Enter)
            {
                //TABボタン信号呼ぶ
                SendKeys.Send("{TAB}");
            }
        }
    }
}
