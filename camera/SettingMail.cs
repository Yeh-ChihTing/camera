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
    public partial class SettingMail : Form
    {
        public string SetFromAdd, SetPass, SetSendAdd, SetTitle, SetMsg, SetPicPath;



        public SettingMail()
        {
            InitializeComponent();
        }

        private void Msg_TextChanged(object sender, EventArgs e)
        {
            //SetMsg = Msg.Text;
        }

        private void PicPath_TextChanged(object sender, EventArgs e)
        {
            //SetPicPath = PicPath.Text;
        }

        private void SettingMail_Load(object sender, EventArgs e)
        {
            FromAdd.Text = SetFromAdd;

            Pass.Text = SetPass;

            SendAdd.Text = SetSendAdd;

            Title.Text = SetTitle;

            Msg.Text = SetMsg;

           // PicPath.Text = SetPicPath;
        }


        private void FromAdd_TextChanged(object sender, EventArgs e)
        {
            SetFromAdd = FromAdd.Text;
        }

        private void Title_TextChanged(object sender, EventArgs e)
        {
            SetTitle = Title.Text;
        }

        private void SendAdd_TextChanged(object sender, EventArgs e)
        {
            SetSendAdd = SendAdd.Text;

        }

        private void Pass_TextChanged(object sender, EventArgs e)
        {
            SetPass = Pass.Text;
        }



        private void Complete_Click(object sender, EventArgs e)
        {
            MainScene Ms = (MainScene)this.Owner;
            Ms.SaveMailSetting(SetFromAdd,SetPass,SetSendAdd,SetTitle,SetMsg);
            
            this.Close();
        }

   


    }
}
