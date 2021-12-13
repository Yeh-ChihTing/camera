
namespace camera
{
    partial class SettingMail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FromAdd = new System.Windows.Forms.TextBox();
            this.Pass = new System.Windows.Forms.TextBox();
            this.SendAdd = new System.Windows.Forms.TextBox();
            this.Title = new System.Windows.Forms.TextBox();
            this.Msg = new System.Windows.Forms.TextBox();
            this.PicPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Complete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FromAdd
            // 
            this.FromAdd.Location = new System.Drawing.Point(99, 25);
            this.FromAdd.Name = "FromAdd";
            this.FromAdd.Size = new System.Drawing.Size(162, 19);
            this.FromAdd.TabIndex = 0;
            this.FromAdd.TextChanged += new System.EventHandler(this.FromAdd_TextChanged);
            // 
            // Pass
            // 
            this.Pass.Location = new System.Drawing.Point(99, 64);
            this.Pass.Name = "Pass";
            this.Pass.Size = new System.Drawing.Size(162, 19);
            this.Pass.TabIndex = 1;
            this.Pass.TextChanged += new System.EventHandler(this.Pass_TextChanged);
            // 
            // SendAdd
            // 
            this.SendAdd.Location = new System.Drawing.Point(99, 107);
            this.SendAdd.Name = "SendAdd";
            this.SendAdd.Size = new System.Drawing.Size(162, 19);
            this.SendAdd.TabIndex = 2;
            this.SendAdd.TextChanged += new System.EventHandler(this.SendAdd_TextChanged);
            // 
            // Title
            // 
            this.Title.Location = new System.Drawing.Point(99, 154);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(162, 19);
            this.Title.TabIndex = 3;
            this.Title.TextChanged += new System.EventHandler(this.Title_TextChanged);
            // 
            // Msg
            // 
            this.Msg.Location = new System.Drawing.Point(99, 199);
            this.Msg.Name = "Msg";
            this.Msg.Size = new System.Drawing.Size(162, 19);
            this.Msg.TabIndex = 4;
            this.Msg.Visible = false;
            this.Msg.TextChanged += new System.EventHandler(this.Msg_TextChanged);
            // 
            // PicPath
            // 
            this.PicPath.Location = new System.Drawing.Point(99, 247);
            this.PicPath.Name = "PicPath";
            this.PicPath.Size = new System.Drawing.Size(162, 19);
            this.PicPath.TabIndex = 5;
            this.PicPath.Visible = false;
            this.PicPath.TextChanged += new System.EventHandler(this.PicPath_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "メールアドレス";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "パスワード";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "宛先";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "件名";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "本文";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 247);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "画像位置";
            this.label6.Visible = false;
            // 
            // Complete
            // 
            this.Complete.Location = new System.Drawing.Point(186, 283);
            this.Complete.Name = "Complete";
            this.Complete.Size = new System.Drawing.Size(75, 23);
            this.Complete.TabIndex = 12;
            this.Complete.Text = "完了";
            this.Complete.UseVisualStyleBackColor = true;
            this.Complete.Click += new System.EventHandler(this.Complete_Click);
            // 
            // SettingMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 330);
            this.ControlBox = false;
            this.Controls.Add(this.Complete);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PicPath);
            this.Controls.Add(this.Msg);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.SendAdd);
            this.Controls.Add(this.Pass);
            this.Controls.Add(this.FromAdd);
            this.Name = "SettingMail";
            this.Text = "メール設定";
            this.Load += new System.EventHandler(this.SettingMail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Complete;
        public System.Windows.Forms.TextBox FromAdd;
        public System.Windows.Forms.TextBox Pass;
        public System.Windows.Forms.TextBox SendAdd;
        public System.Windows.Forms.TextBox Title;
        public System.Windows.Forms.TextBox Msg;
        public System.Windows.Forms.TextBox PicPath;
    }
}