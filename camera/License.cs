using System;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Text;

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

                    string array = Encrypt(MyID.Text + "," + MyPass.Text + "," + Environment.MachineName);

                    //IDとPASSの保存
                    using (StreamWriter sr = new StreamWriter(os.Lipath))
                    {
                        //sr.WriteLine(MyID.Text);
                        //sr.WriteLine(MyPass.Text);
                        //sr.WriteLine(Environment.MachineName);
                        sr.WriteLine(array);
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


        static string Encrypt(string array)
        {
            try
            {
                //string textToEncrypt = "WaterWorld";
                string ToReturn = "";
                string publickey = "15876432";
                string secretkey = "23467851";
                byte[] secretkeyByte = { };
                secretkeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);
                byte[] publickeybyte = { };
                publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = System.Text.Encoding.UTF8.GetBytes(array);
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    ToReturn = Convert.ToBase64String(ms.ToArray());
                }
                return ToReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public string Decrypt(string array)
        {
            try
            {
                //string textToDecrypt = "6+PXxVWlBqcUnIdqsMyUHA==";
                string ToReturn = "";
                string publickey = "15876432";
                string secretkey = "23467851";
                byte[] privatekeyByte = { };
                privatekeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);
                byte[] publickeybyte = { };
                publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = new byte[array.Replace(" ", "+").Length];
                inputbyteArray = Convert.FromBase64String(array.Replace(" ", "+"));
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateDecryptor(publickeybyte, privatekeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    Encoding encoding = Encoding.UTF8;
                    ToReturn = encoding.GetString(ms.ToArray());
                }
                return ToReturn;
            }
            catch (Exception ae)
            {
                //throw new Exception(ae.Message, ae.InnerException);
                return "";
            }
}
    }
}
