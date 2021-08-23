
namespace camera
{
    partial class OpenScene
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenScene));
            this.StartnetCamera = new System.Windows.Forms.Button();
            this.PASS = new System.Windows.Forms.Label();
            this.PassWord = new System.Windows.Forms.TextBox();
            this.ID = new System.Windows.Forms.Label();
            this.UserID = new System.Windows.Forms.TextBox();
            this.IP = new System.Windows.Forms.Label();
            this.IpAdress = new System.Windows.Forms.TextBox();
            this.StartWebCamera = new System.Windows.Forms.Button();
            this.SelectcamText = new System.Windows.Forms.Label();
            this.WebCamSelect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CGIConment = new System.Windows.Forms.TextBox();
            this.version = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // StartnetCamera
            // 
            this.StartnetCamera.Location = new System.Drawing.Point(103, 114);
            this.StartnetCamera.Name = "StartnetCamera";
            this.StartnetCamera.Size = new System.Drawing.Size(88, 23);
            this.StartnetCamera.TabIndex = 282;
            this.StartnetCamera.Text = "ネットカメラ起動";
            this.StartnetCamera.UseVisualStyleBackColor = true;
            this.StartnetCamera.Click += new System.EventHandler(this.StartnetCamera_Click);
            // 
            // PASS
            // 
            this.PASS.AutoSize = true;
            this.PASS.Location = new System.Drawing.Point(18, 67);
            this.PASS.Name = "PASS";
            this.PASS.Size = new System.Drawing.Size(34, 12);
            this.PASS.TabIndex = 281;
            this.PASS.Text = "PASS";
            // 
            // PassWord
            // 
            this.PassWord.Location = new System.Drawing.Point(53, 64);
            this.PassWord.Name = "PassWord";
            this.PassWord.Size = new System.Drawing.Size(197, 19);
            this.PassWord.TabIndex = 280;
            this.PassWord.Text = "root";
            // 
            // ID
            // 
            this.ID.AutoSize = true;
            this.ID.Location = new System.Drawing.Point(32, 39);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(16, 12);
            this.ID.TabIndex = 279;
            this.ID.Text = "ID";
            // 
            // UserID
            // 
            this.UserID.Location = new System.Drawing.Point(53, 39);
            this.UserID.Name = "UserID";
            this.UserID.Size = new System.Drawing.Size(197, 19);
            this.UserID.TabIndex = 278;
            this.UserID.Text = "root";
            // 
            // IP
            // 
            this.IP.AutoSize = true;
            this.IP.Location = new System.Drawing.Point(32, 14);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(15, 12);
            this.IP.TabIndex = 277;
            this.IP.Text = "IP";
            // 
            // IpAdress
            // 
            this.IpAdress.Location = new System.Drawing.Point(53, 14);
            this.IpAdress.Name = "IpAdress";
            this.IpAdress.Size = new System.Drawing.Size(197, 19);
            this.IpAdress.TabIndex = 276;
            this.IpAdress.Text = "169.254.154.96";
            // 
            // StartWebCamera
            // 
            this.StartWebCamera.Location = new System.Drawing.Point(172, 161);
            this.StartWebCamera.Name = "StartWebCamera";
            this.StartWebCamera.Size = new System.Drawing.Size(83, 23);
            this.StartWebCamera.TabIndex = 283;
            this.StartWebCamera.Text = "Webカメラ起動";
            this.StartWebCamera.UseVisualStyleBackColor = true;
            this.StartWebCamera.Click += new System.EventHandler(this.StartWebCamera_Click);
            // 
            // SelectcamText
            // 
            this.SelectcamText.AutoSize = true;
            this.SelectcamText.Location = new System.Drawing.Point(32, 149);
            this.SelectcamText.Name = "SelectcamText";
            this.SelectcamText.Size = new System.Drawing.Size(75, 12);
            this.SelectcamText.TabIndex = 284;
            this.SelectcamText.Text = "Webカメラ選択";
            // 
            // WebCamSelect
            // 
            this.WebCamSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WebCamSelect.FormattingEnabled = true;
            this.WebCamSelect.Location = new System.Drawing.Point(34, 164);
            this.WebCamSelect.Name = "WebCamSelect";
            this.WebCamSelect.Size = new System.Drawing.Size(121, 20);
            this.WebCamSelect.TabIndex = 285;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 12);
            this.label1.TabIndex = 287;
            this.label1.Text = "CGI";
            // 
            // CGIConment
            // 
            this.CGIConment.Location = new System.Drawing.Point(53, 89);
            this.CGIConment.Name = "CGIConment";
            this.CGIConment.Size = new System.Drawing.Size(197, 19);
            this.CGIConment.TabIndex = 286;
            this.CGIConment.Text = "cgi-bin/camera?resolution=640*360";
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.Location = new System.Drawing.Point(284, 188);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(27, 12);
            this.version.TabIndex = 288;
            this.version.Text = "1.0.0";
            // 
            // OpenScene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 209);
            this.Controls.Add(this.version);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CGIConment);
            this.Controls.Add(this.WebCamSelect);
            this.Controls.Add(this.SelectcamText);
            this.Controls.Add(this.StartWebCamera);
            this.Controls.Add(this.StartnetCamera);
            this.Controls.Add(this.PASS);
            this.Controls.Add(this.PassWord);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.UserID);
            this.Controls.Add(this.IP);
            this.Controls.Add(this.IpAdress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OpenScene";
            this.Text = "カメラ選択と設定";
            this.Load += new System.EventHandler(this.OpenScene_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartnetCamera;
        private System.Windows.Forms.Label PASS;
        private System.Windows.Forms.TextBox PassWord;
        private System.Windows.Forms.Label ID;
        private System.Windows.Forms.TextBox UserID;
        private System.Windows.Forms.Label IP;
        private System.Windows.Forms.TextBox IpAdress;
        private System.Windows.Forms.Button StartWebCamera;
        private System.Windows.Forms.Label SelectcamText;
        private System.Windows.Forms.ComboBox WebCamSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CGIConment;
        public System.Windows.Forms.Label version;
    }
}