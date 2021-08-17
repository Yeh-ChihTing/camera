﻿
namespace camera
{
    partial class MainScene
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScene));
            this.CameraPic = new System.Windows.Forms.PictureBox();
            this.PColor = new System.Windows.Forms.Panel();
            this.RedTrack = new System.Windows.Forms.TrackBar();
            this.Rtracktext = new System.Windows.Forms.Label();
            this.数値変化チェック = new System.Windows.Forms.Timer(this.components);
            this.Gtracktext = new System.Windows.Forms.Label();
            this.GreenTrack = new System.Windows.Forms.TrackBar();
            this.BlueTrack = new System.Windows.Forms.TrackBar();
            this.Btracktext = new System.Windows.Forms.Label();
            this.CutPic = new System.Windows.Forms.PictureBox();
            this.GetPicBtn = new System.Windows.Forms.Button();
            this.CheckBtn = new System.Windows.Forms.Button();
            this.BNums = new System.Windows.Forms.Label();
            this.GNums = new System.Windows.Forms.Label();
            this.RNums = new System.Windows.Forms.Label();
            this.BLUE = new System.Windows.Forms.Label();
            this.GREEN = new System.Windows.Forms.Label();
            this.RED = new System.Windows.Forms.Label();
            this.DelectBoxBtn = new System.Windows.Forms.Button();
            this.SavePicBtn = new System.Windows.Forms.Button();
            this.CSComboBox = new System.Windows.Forms.ComboBox();
            this.AddBoxBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Redlabel = new System.Windows.Forms.Label();
            this.GreenLabel = new System.Windows.Forms.Label();
            this.BlueLabel = new System.Windows.Forms.Label();
            this.SettingNameBtn = new System.Windows.Forms.Button();
            this.BoxNameCombo = new System.Windows.Forms.ComboBox();
            this.BoxNameListlabel = new System.Windows.Forms.Label();
            this.CheckLoopBtn = new System.Windows.Forms.Button();
            this.LoopTimer = new System.Windows.Forms.Timer(this.components);
            this.MinText = new System.Windows.Forms.TextBox();
            this.SecText = new System.Windows.Forms.TextBox();
            this.HourText = new System.Windows.Forms.TextBox();
            this.HourLabel = new System.Windows.Forms.Label();
            this.MinLabel = new System.Windows.Forms.Label();
            this.SecLabel = new System.Windows.Forms.Label();
            this.CheckPerList = new System.Windows.Forms.ListBox();
            this.AllPercentShow = new System.Windows.Forms.Label();
            this.RSetText = new System.Windows.Forms.TextBox();
            this.GSetText = new System.Windows.Forms.TextBox();
            this.BSetText = new System.Windows.Forms.TextBox();
            this.RGBLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SetSusscePercent = new System.Windows.Forms.TextBox();
            this.ClearCheckScene = new System.Windows.Forms.Button();
            this.BoxSetting = new System.Windows.Forms.GroupBox();
            this.ChooseCol = new System.Windows.Forms.Button();
            this.UseCol = new System.Windows.Forms.PictureBox();
            this.UseThisCol = new System.Windows.Forms.CheckBox();
            this.CheckMode = new System.Windows.Forms.ComboBox();
            this.SaveBoxData = new System.Windows.Forms.Button();
            this.AutoLock = new System.Windows.Forms.Button();
            this.CheckLockNum = new System.Windows.Forms.TextBox();
            this.AutoColSelectBtn = new System.Windows.Forms.Button();
            this.AutoCol = new System.Windows.Forms.PictureBox();
            this.AutoGroup = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.AutoColNums = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CleanObj = new System.Windows.Forms.Button();
            this.CheckSetting = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.CameraPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CutPic)).BeginInit();
            this.panel1.SuspendLayout();
            this.BoxSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UseCol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoCol)).BeginInit();
            this.AutoGroup.SuspendLayout();
            this.CheckSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // CameraPic
            // 
            this.CameraPic.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CameraPic.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CameraPic.InitialImage = null;
            this.CameraPic.Location = new System.Drawing.Point(12, 12);
            this.CameraPic.Name = "CameraPic";
            this.CameraPic.Size = new System.Drawing.Size(640, 360);
            this.CameraPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CameraPic.TabIndex = 0;
            this.CameraPic.TabStop = false;
            // 
            // PColor
            // 
            this.PColor.Location = new System.Drawing.Point(9, 251);
            this.PColor.Name = "PColor";
            this.PColor.Size = new System.Drawing.Size(39, 32);
            this.PColor.TabIndex = 7;
            // 
            // RedTrack
            // 
            this.RedTrack.Location = new System.Drawing.Point(21, 33);
            this.RedTrack.Maximum = 255;
            this.RedTrack.Name = "RedTrack";
            this.RedTrack.Size = new System.Drawing.Size(104, 45);
            this.RedTrack.TabIndex = 1;
            this.RedTrack.Value = 30;
            this.RedTrack.ValueChanged += new System.EventHandler(this.RedTrack_ValueChanged);
            // 
            // Rtracktext
            // 
            this.Rtracktext.AutoSize = true;
            this.Rtracktext.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Rtracktext.Location = new System.Drawing.Point(131, 45);
            this.Rtracktext.Name = "Rtracktext";
            this.Rtracktext.Size = new System.Drawing.Size(26, 16);
            this.Rtracktext.TabIndex = 256;
            this.Rtracktext.Text = "30";
            // 
            // 数値変化チェック
            // 
            this.数値変化チェック.Enabled = true;
            this.数値変化チェック.Tick += new System.EventHandler(this._数値変化チェック_Tick);
            // 
            // Gtracktext
            // 
            this.Gtracktext.AutoSize = true;
            this.Gtracktext.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Gtracktext.Location = new System.Drawing.Point(133, 97);
            this.Gtracktext.Name = "Gtracktext";
            this.Gtracktext.Size = new System.Drawing.Size(26, 16);
            this.Gtracktext.TabIndex = 258;
            this.Gtracktext.Text = "30";
            // 
            // GreenTrack
            // 
            this.GreenTrack.Location = new System.Drawing.Point(23, 84);
            this.GreenTrack.Maximum = 255;
            this.GreenTrack.Name = "GreenTrack";
            this.GreenTrack.Size = new System.Drawing.Size(104, 45);
            this.GreenTrack.TabIndex = 257;
            this.GreenTrack.Value = 30;
            this.GreenTrack.ValueChanged += new System.EventHandler(this.GreenTrack_ValueChanged);
            // 
            // BlueTrack
            // 
            this.BlueTrack.Location = new System.Drawing.Point(23, 145);
            this.BlueTrack.Maximum = 255;
            this.BlueTrack.Name = "BlueTrack";
            this.BlueTrack.Size = new System.Drawing.Size(104, 45);
            this.BlueTrack.TabIndex = 259;
            this.BlueTrack.Value = 30;
            this.BlueTrack.ValueChanged += new System.EventHandler(this.BlueTrack_ValueChanged);
            // 
            // Btracktext
            // 
            this.Btracktext.AutoSize = true;
            this.Btracktext.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Btracktext.Location = new System.Drawing.Point(133, 156);
            this.Btracktext.Name = "Btracktext";
            this.Btracktext.Size = new System.Drawing.Size(26, 16);
            this.Btracktext.TabIndex = 260;
            this.Btracktext.Text = "30";
            // 
            // CutPic
            // 
            this.CutPic.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CutPic.Location = new System.Drawing.Point(0, 0);
            this.CutPic.Name = "CutPic";
            this.CutPic.Size = new System.Drawing.Size(640, 360);
            this.CutPic.TabIndex = 261;
            this.CutPic.TabStop = false;
            this.CutPic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CutPic_MouseDown);
            this.CutPic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CutPic_MouseMove);
            // 
            // GetPicBtn
            // 
            this.GetPicBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GetPicBtn.Location = new System.Drawing.Point(6, 45);
            this.GetPicBtn.Name = "GetPicBtn";
            this.GetPicBtn.Size = new System.Drawing.Size(79, 23);
            this.GetPicBtn.TabIndex = 262;
            this.GetPicBtn.Text = "画像を選択";
            this.GetPicBtn.UseVisualStyleBackColor = true;
            this.GetPicBtn.Click += new System.EventHandler(this.GetPic_Click);
            // 
            // CheckBtn
            // 
            this.CheckBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CheckBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.CheckBtn.ForeColor = System.Drawing.Color.Black;
            this.CheckBtn.Location = new System.Drawing.Point(773, 69);
            this.CheckBtn.Name = "CheckBtn";
            this.CheckBtn.Size = new System.Drawing.Size(80, 40);
            this.CheckBtn.TabIndex = 263;
            this.CheckBtn.Text = "一回チェック";
            this.CheckBtn.UseVisualStyleBackColor = false;
            this.CheckBtn.Click += new System.EventHandler(this.Check_Click);
            // 
            // BNums
            // 
            this.BNums.AutoSize = true;
            this.BNums.Location = new System.Drawing.Point(174, 260);
            this.BNums.Name = "BNums";
            this.BNums.Size = new System.Drawing.Size(11, 12);
            this.BNums.TabIndex = 12;
            this.BNums.Text = "0";
            // 
            // GNums
            // 
            this.GNums.AutoSize = true;
            this.GNums.Location = new System.Drawing.Point(128, 260);
            this.GNums.Name = "GNums";
            this.GNums.Size = new System.Drawing.Size(11, 12);
            this.GNums.TabIndex = 11;
            this.GNums.Text = "0";
            // 
            // RNums
            // 
            this.RNums.AutoSize = true;
            this.RNums.Location = new System.Drawing.Point(81, 260);
            this.RNums.Name = "RNums";
            this.RNums.Size = new System.Drawing.Size(11, 12);
            this.RNums.TabIndex = 10;
            this.RNums.Text = "0";
            // 
            // BLUE
            // 
            this.BLUE.AutoSize = true;
            this.BLUE.Location = new System.Drawing.Point(155, 260);
            this.BLUE.Name = "BLUE";
            this.BLUE.Size = new System.Drawing.Size(13, 12);
            this.BLUE.TabIndex = 9;
            this.BLUE.Text = "B";
            // 
            // GREEN
            // 
            this.GREEN.AutoSize = true;
            this.GREEN.Location = new System.Drawing.Point(109, 260);
            this.GREEN.Name = "GREEN";
            this.GREEN.Size = new System.Drawing.Size(13, 12);
            this.GREEN.TabIndex = 8;
            this.GREEN.Text = "G";
            // 
            // RED
            // 
            this.RED.AutoSize = true;
            this.RED.Location = new System.Drawing.Point(62, 260);
            this.RED.Name = "RED";
            this.RED.Size = new System.Drawing.Size(13, 12);
            this.RED.TabIndex = 7;
            this.RED.Text = "R";
            // 
            // DelectBoxBtn
            // 
            this.DelectBoxBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DelectBoxBtn.Location = new System.Drawing.Point(96, 84);
            this.DelectBoxBtn.Name = "DelectBoxBtn";
            this.DelectBoxBtn.Size = new System.Drawing.Size(75, 45);
            this.DelectBoxBtn.TabIndex = 265;
            this.DelectBoxBtn.Text = "対象消去";
            this.DelectBoxBtn.UseVisualStyleBackColor = true;
            this.DelectBoxBtn.Click += new System.EventHandler(this.DelectBox_Click);
            // 
            // SavePicBtn
            // 
            this.SavePicBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SavePicBtn.Location = new System.Drawing.Point(96, 45);
            this.SavePicBtn.Name = "SavePicBtn";
            this.SavePicBtn.Size = new System.Drawing.Size(75, 23);
            this.SavePicBtn.TabIndex = 266;
            this.SavePicBtn.Text = "画像保存";
            this.SavePicBtn.UseVisualStyleBackColor = true;
            this.SavePicBtn.Click += new System.EventHandler(this.SavePicBtn_Click);
            // 
            // CSComboBox
            // 
            this.CSComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CSComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CSComboBox.FormattingEnabled = true;
            this.CSComboBox.Items.AddRange(new object[] {
            "100%",
            "200%",
            "400%",
            "800%"});
            this.CSComboBox.Location = new System.Drawing.Point(67, 11);
            this.CSComboBox.Name = "CSComboBox";
            this.CSComboBox.Size = new System.Drawing.Size(121, 20);
            this.CSComboBox.TabIndex = 267;
            this.CSComboBox.SelectedValueChanged += new System.EventHandler(this.CSComboBox_SelectedValueChanged);
            // 
            // AddBoxBtn
            // 
            this.AddBoxBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AddBoxBtn.Location = new System.Drawing.Point(5, 84);
            this.AddBoxBtn.Name = "AddBoxBtn";
            this.AddBoxBtn.Size = new System.Drawing.Size(80, 45);
            this.AddBoxBtn.TabIndex = 268;
            this.AddBoxBtn.Text = "対象追加";
            this.AddBoxBtn.UseVisualStyleBackColor = true;
            this.AddBoxBtn.Click += new System.EventHandler(this.AddBox_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.CutPic);
            this.panel1.Location = new System.Drawing.Point(12, 399);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(640, 360);
            this.panel1.TabIndex = 276;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 12);
            this.label1.TabIndex = 277;
            this.label1.Text = "画像サイズ";
            // 
            // Redlabel
            // 
            this.Redlabel.AutoSize = true;
            this.Redlabel.Location = new System.Drawing.Point(5, 45);
            this.Redlabel.Name = "Redlabel";
            this.Redlabel.Size = new System.Drawing.Size(13, 12);
            this.Redlabel.TabIndex = 278;
            this.Redlabel.Text = "R";
            // 
            // GreenLabel
            // 
            this.GreenLabel.AutoSize = true;
            this.GreenLabel.Location = new System.Drawing.Point(4, 97);
            this.GreenLabel.Name = "GreenLabel";
            this.GreenLabel.Size = new System.Drawing.Size(13, 12);
            this.GreenLabel.TabIndex = 279;
            this.GreenLabel.Text = "G";
            // 
            // BlueLabel
            // 
            this.BlueLabel.AutoSize = true;
            this.BlueLabel.Location = new System.Drawing.Point(5, 156);
            this.BlueLabel.Name = "BlueLabel";
            this.BlueLabel.Size = new System.Drawing.Size(13, 12);
            this.BlueLabel.TabIndex = 280;
            this.BlueLabel.Text = "B";
            // 
            // SettingNameBtn
            // 
            this.SettingNameBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SettingNameBtn.Location = new System.Drawing.Point(6, 133);
            this.SettingNameBtn.Name = "SettingNameBtn";
            this.SettingNameBtn.Size = new System.Drawing.Size(79, 23);
            this.SettingNameBtn.TabIndex = 282;
            this.SettingNameBtn.Text = "対象名設定";
            this.SettingNameBtn.UseVisualStyleBackColor = true;
            this.SettingNameBtn.Click += new System.EventHandler(this.SettingName_Click);
            // 
            // BoxNameCombo
            // 
            this.BoxNameCombo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BoxNameCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BoxNameCombo.FormattingEnabled = true;
            this.BoxNameCombo.Items.AddRange(new object[] {
            "1"});
            this.BoxNameCombo.Location = new System.Drawing.Point(158, 135);
            this.BoxNameCombo.Name = "BoxNameCombo";
            this.BoxNameCombo.Size = new System.Drawing.Size(121, 20);
            this.BoxNameCombo.TabIndex = 283;
            this.BoxNameCombo.SelectedValueChanged += new System.EventHandler(this.BoxNameCombo_SelectedValueChanged);
            // 
            // BoxNameListlabel
            // 
            this.BoxNameListlabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BoxNameListlabel.AutoSize = true;
            this.BoxNameListlabel.Location = new System.Drawing.Point(87, 140);
            this.BoxNameListlabel.Name = "BoxNameListlabel";
            this.BoxNameListlabel.Size = new System.Drawing.Size(65, 12);
            this.BoxNameListlabel.TabIndex = 284;
            this.BoxNameListlabel.Text = "対象名リスト";
            // 
            // CheckLoopBtn
            // 
            this.CheckLoopBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CheckLoopBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.CheckLoopBtn.ForeColor = System.Drawing.Color.Black;
            this.CheckLoopBtn.Location = new System.Drawing.Point(838, 2);
            this.CheckLoopBtn.Name = "CheckLoopBtn";
            this.CheckLoopBtn.Size = new System.Drawing.Size(80, 40);
            this.CheckLoopBtn.TabIndex = 285;
            this.CheckLoopBtn.Text = "連続チェック";
            this.CheckLoopBtn.UseVisualStyleBackColor = false;
            this.CheckLoopBtn.Click += new System.EventHandler(this.CheckLoopBtn_Click);
            // 
            // LoopTimer
            // 
            this.LoopTimer.Tick += new System.EventHandler(this.LoopTimer_Tick);
            // 
            // MinText
            // 
            this.MinText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MinText.Location = new System.Drawing.Point(719, 12);
            this.MinText.MaxLength = 2;
            this.MinText.Name = "MinText";
            this.MinText.Size = new System.Drawing.Size(30, 19);
            this.MinText.TabIndex = 286;
            this.MinText.Text = "0";
            this.MinText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyInputNum);
            // 
            // SecText
            // 
            this.SecText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SecText.Location = new System.Drawing.Point(771, 12);
            this.SecText.MaxLength = 2;
            this.SecText.Name = "SecText";
            this.SecText.Size = new System.Drawing.Size(32, 19);
            this.SecText.TabIndex = 287;
            this.SecText.Text = "0";
            this.SecText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyInputNum);
            // 
            // HourText
            // 
            this.HourText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HourText.Location = new System.Drawing.Point(667, 12);
            this.HourText.MaxLength = 2;
            this.HourText.Name = "HourText";
            this.HourText.Size = new System.Drawing.Size(29, 19);
            this.HourText.TabIndex = 288;
            this.HourText.Text = "0";
            this.HourText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyInputNum);
            // 
            // HourLabel
            // 
            this.HourLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HourLabel.AutoSize = true;
            this.HourLabel.Location = new System.Drawing.Point(697, 12);
            this.HourLabel.Name = "HourLabel";
            this.HourLabel.Size = new System.Drawing.Size(17, 12);
            this.HourLabel.TabIndex = 289;
            this.HourLabel.Text = "時";
            // 
            // MinLabel
            // 
            this.MinLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MinLabel.AutoSize = true;
            this.MinLabel.Location = new System.Drawing.Point(750, 12);
            this.MinLabel.Name = "MinLabel";
            this.MinLabel.Size = new System.Drawing.Size(17, 12);
            this.MinLabel.TabIndex = 290;
            this.MinLabel.Text = "分";
            // 
            // SecLabel
            // 
            this.SecLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SecLabel.AutoSize = true;
            this.SecLabel.Location = new System.Drawing.Point(809, 12);
            this.SecLabel.Name = "SecLabel";
            this.SecLabel.Size = new System.Drawing.Size(17, 12);
            this.SecLabel.TabIndex = 291;
            this.SecLabel.Text = "秒";
            // 
            // CheckPerList
            // 
            this.CheckPerList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CheckPerList.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CheckPerList.FormattingEnabled = true;
            this.CheckPerList.ItemHeight = 20;
            this.CheckPerList.Location = new System.Drawing.Point(666, 115);
            this.CheckPerList.Name = "CheckPerList";
            this.CheckPerList.Size = new System.Drawing.Size(252, 124);
            this.CheckPerList.TabIndex = 292;
            // 
            // AllPercentShow
            // 
            this.AllPercentShow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AllPercentShow.AutoSize = true;
            this.AllPercentShow.Location = new System.Drawing.Point(667, 97);
            this.AllPercentShow.Name = "AllPercentShow";
            this.AllPercentShow.Size = new System.Drawing.Size(100, 12);
            this.AllPercentShow.TabIndex = 293;
            this.AllPercentShow.Text = "各自結果パーセント";
            // 
            // RSetText
            // 
            this.RSetText.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RSetText.Location = new System.Drawing.Point(186, 42);
            this.RSetText.MaxLength = 3;
            this.RSetText.Name = "RSetText";
            this.RSetText.Size = new System.Drawing.Size(44, 23);
            this.RSetText.TabIndex = 294;
            this.RSetText.TextChanged += new System.EventHandler(this.RSetText_TextChanged);
            this.RSetText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyInputNum);
            // 
            // GSetText
            // 
            this.GSetText.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GSetText.Location = new System.Drawing.Point(186, 90);
            this.GSetText.MaxLength = 3;
            this.GSetText.Name = "GSetText";
            this.GSetText.Size = new System.Drawing.Size(44, 23);
            this.GSetText.TabIndex = 295;
            this.GSetText.TextChanged += new System.EventHandler(this.GSetText_TextChanged);
            this.GSetText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyInputNum);
            // 
            // BSetText
            // 
            this.BSetText.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BSetText.Location = new System.Drawing.Point(186, 153);
            this.BSetText.MaxLength = 3;
            this.BSetText.Name = "BSetText";
            this.BSetText.Size = new System.Drawing.Size(44, 23);
            this.BSetText.TabIndex = 296;
            this.BSetText.TextChanged += new System.EventHandler(this.BSetText_TextChanged);
            this.BSetText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyInputNum);
            // 
            // RGBLabel
            // 
            this.RGBLabel.AutoSize = true;
            this.RGBLabel.Location = new System.Drawing.Point(7, 15);
            this.RGBLabel.Name = "RGBLabel";
            this.RGBLabel.Size = new System.Drawing.Size(77, 12);
            this.RGBLabel.TabIndex = 297;
            this.RGBLabel.Text = "RGB参照設定";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 12);
            this.label2.TabIndex = 298;
            this.label2.Text = "合格パーセント設定";
            // 
            // SetSusscePercent
            // 
            this.SetSusscePercent.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SetSusscePercent.Location = new System.Drawing.Point(5, 196);
            this.SetSusscePercent.MaxLength = 3;
            this.SetSusscePercent.Name = "SetSusscePercent";
            this.SetSusscePercent.Size = new System.Drawing.Size(32, 23);
            this.SetSusscePercent.TabIndex = 299;
            this.SetSusscePercent.TextChanged += new System.EventHandler(this.SetSusscePercent_TextChanged);
            this.SetSusscePercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyInputNum);
            // 
            // ClearCheckScene
            // 
            this.ClearCheckScene.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ClearCheckScene.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClearCheckScene.Location = new System.Drawing.Point(859, 69);
            this.ClearCheckScene.Name = "ClearCheckScene";
            this.ClearCheckScene.Size = new System.Drawing.Size(80, 40);
            this.ClearCheckScene.TabIndex = 300;
            this.ClearCheckScene.Text = "画面リセット";
            this.ClearCheckScene.UseVisualStyleBackColor = false;
            this.ClearCheckScene.Click += new System.EventHandler(this.ClearCheckScene_Click);
            // 
            // BoxSetting
            // 
            this.BoxSetting.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BoxSetting.Controls.Add(this.ChooseCol);
            this.BoxSetting.Controls.Add(this.UseCol);
            this.BoxSetting.Controls.Add(this.UseThisCol);
            this.BoxSetting.Controls.Add(this.CheckMode);
            this.BoxSetting.Controls.Add(this.SetSusscePercent);
            this.BoxSetting.Controls.Add(this.RGBLabel);
            this.BoxSetting.Controls.Add(this.RedTrack);
            this.BoxSetting.Controls.Add(this.Rtracktext);
            this.BoxSetting.Controls.Add(this.label2);
            this.BoxSetting.Controls.Add(this.GreenTrack);
            this.BoxSetting.Controls.Add(this.Gtracktext);
            this.BoxSetting.Controls.Add(this.BSetText);
            this.BoxSetting.Controls.Add(this.BlueTrack);
            this.BoxSetting.Controls.Add(this.GSetText);
            this.BoxSetting.Controls.Add(this.Btracktext);
            this.BoxSetting.Controls.Add(this.RSetText);
            this.BoxSetting.Controls.Add(this.Redlabel);
            this.BoxSetting.Controls.Add(this.GreenLabel);
            this.BoxSetting.Controls.Add(this.BlueLabel);
            this.BoxSetting.Controls.Add(this.PColor);
            this.BoxSetting.Controls.Add(this.RED);
            this.BoxSetting.Controls.Add(this.GREEN);
            this.BoxSetting.Controls.Add(this.BLUE);
            this.BoxSetting.Controls.Add(this.BNums);
            this.BoxSetting.Controls.Add(this.RNums);
            this.BoxSetting.Controls.Add(this.GNums);
            this.BoxSetting.Location = new System.Drawing.Point(664, 250);
            this.BoxSetting.Name = "BoxSetting";
            this.BoxSetting.Size = new System.Drawing.Size(277, 227);
            this.BoxSetting.TabIndex = 301;
            this.BoxSetting.TabStop = false;
            this.BoxSetting.Text = "groupBox1";
            // 
            // ChooseCol
            // 
            this.ChooseCol.Location = new System.Drawing.Point(186, 196);
            this.ChooseCol.Name = "ChooseCol";
            this.ChooseCol.Size = new System.Drawing.Size(56, 23);
            this.ChooseCol.TabIndex = 305;
            this.ChooseCol.Text = "色選択";
            this.ChooseCol.UseVisualStyleBackColor = true;
            this.ChooseCol.Click += new System.EventHandler(this.ChooseCol_Click);
            // 
            // UseCol
            // 
            this.UseCol.BackColor = System.Drawing.Color.Red;
            this.UseCol.Location = new System.Drawing.Point(248, 198);
            this.UseCol.Name = "UseCol";
            this.UseCol.Size = new System.Drawing.Size(21, 18);
            this.UseCol.TabIndex = 304;
            this.UseCol.TabStop = false;
            // 
            // UseThisCol
            // 
            this.UseThisCol.AutoSize = true;
            this.UseThisCol.Location = new System.Drawing.Point(121, 200);
            this.UseThisCol.Name = "UseThisCol";
            this.UseThisCol.Size = new System.Drawing.Size(60, 16);
            this.UseThisCol.TabIndex = 303;
            this.UseThisCol.Text = "指定色";
            this.UseThisCol.UseVisualStyleBackColor = true;
            this.UseThisCol.CheckedChanged += new System.EventHandler(this.UseThisCol_CheckedChanged);
            // 
            // CheckMode
            // 
            this.CheckMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CheckMode.FormattingEnabled = true;
            this.CheckMode.Items.AddRange(new object[] {
            "サーモテープ",
            "ランプ点灯モード",
            "ランプ消灯モード"});
            this.CheckMode.Location = new System.Drawing.Point(96, 12);
            this.CheckMode.Name = "CheckMode";
            this.CheckMode.Size = new System.Drawing.Size(134, 20);
            this.CheckMode.TabIndex = 302;
            this.CheckMode.SelectedValueChanged += new System.EventHandler(this.CheckMode_SelectedValueChanged);
            // 
            // SaveBoxData
            // 
            this.SaveBoxData.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveBoxData.Location = new System.Drawing.Point(188, 40);
            this.SaveBoxData.Name = "SaveBoxData";
            this.SaveBoxData.Size = new System.Drawing.Size(75, 32);
            this.SaveBoxData.TabIndex = 302;
            this.SaveBoxData.Text = "対象情報保存";
            this.SaveBoxData.UseVisualStyleBackColor = true;
            this.SaveBoxData.Click += new System.EventHandler(this.SaveBoxData_Click);
            // 
            // AutoLock
            // 
            this.AutoLock.Location = new System.Drawing.Point(80, 44);
            this.AutoLock.Name = "AutoLock";
            this.AutoLock.Size = new System.Drawing.Size(94, 23);
            this.AutoLock.TabIndex = 303;
            this.AutoLock.Text = "自動対象検出";
            this.AutoLock.UseVisualStyleBackColor = true;
            this.AutoLock.Click += new System.EventHandler(this.AutoLock_Click);
            // 
            // CheckLockNum
            // 
            this.CheckLockNum.Location = new System.Drawing.Point(47, 45);
            this.CheckLockNum.Name = "CheckLockNum";
            this.CheckLockNum.Size = new System.Drawing.Size(31, 19);
            this.CheckLockNum.TabIndex = 304;
            this.CheckLockNum.Text = "1";
            this.CheckLockNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyInputNum);
            // 
            // AutoColSelectBtn
            // 
            this.AutoColSelectBtn.Location = new System.Drawing.Point(80, 18);
            this.AutoColSelectBtn.Name = "AutoColSelectBtn";
            this.AutoColSelectBtn.Size = new System.Drawing.Size(56, 23);
            this.AutoColSelectBtn.TabIndex = 307;
            this.AutoColSelectBtn.Text = "色選択";
            this.AutoColSelectBtn.UseVisualStyleBackColor = true;
            this.AutoColSelectBtn.Click += new System.EventHandler(this.AutoColSelectBtn_Click);
            // 
            // AutoCol
            // 
            this.AutoCol.BackColor = System.Drawing.Color.Red;
            this.AutoCol.Location = new System.Drawing.Point(142, 20);
            this.AutoCol.Name = "AutoCol";
            this.AutoCol.Size = new System.Drawing.Size(21, 18);
            this.AutoCol.TabIndex = 306;
            this.AutoCol.TabStop = false;
            // 
            // AutoGroup
            // 
            this.AutoGroup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AutoGroup.Controls.Add(this.label4);
            this.AutoGroup.Controls.Add(this.AutoColNums);
            this.AutoGroup.Controls.Add(this.label3);
            this.AutoGroup.Controls.Add(this.AutoColSelectBtn);
            this.AutoGroup.Controls.Add(this.AutoLock);
            this.AutoGroup.Controls.Add(this.CheckLockNum);
            this.AutoGroup.Controls.Add(this.AutoCol);
            this.AutoGroup.Location = new System.Drawing.Point(663, 679);
            this.AutoGroup.Name = "AutoGroup";
            this.AutoGroup.Size = new System.Drawing.Size(281, 80);
            this.AutoGroup.TabIndex = 308;
            this.AutoGroup.TabStop = false;
            this.AutoGroup.Text = "自動対象設定用";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 12);
            this.label4.TabIndex = 310;
            this.label4.Text = "色合い";
            // 
            // AutoColNums
            // 
            this.AutoColNums.Location = new System.Drawing.Point(47, 20);
            this.AutoColNums.Name = "AutoColNums";
            this.AutoColNums.Size = new System.Drawing.Size(31, 19);
            this.AutoColNums.TabIndex = 309;
            this.AutoColNums.Text = "5";
            this.AutoColNums.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyInputNum);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 308;
            this.label3.Text = "総数";
            // 
            // CleanObj
            // 
            this.CleanObj.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CleanObj.Location = new System.Drawing.Point(188, 95);
            this.CleanObj.Name = "CleanObj";
            this.CleanObj.Size = new System.Drawing.Size(75, 23);
            this.CleanObj.TabIndex = 309;
            this.CleanObj.Text = "全対象クリア";
            this.CleanObj.UseVisualStyleBackColor = true;
            this.CleanObj.Click += new System.EventHandler(this.CleanObj_Click);
            // 
            // CheckSetting
            // 
            this.CheckSetting.Controls.Add(this.label1);
            this.CheckSetting.Controls.Add(this.CleanObj);
            this.CheckSetting.Controls.Add(this.GetPicBtn);
            this.CheckSetting.Controls.Add(this.DelectBoxBtn);
            this.CheckSetting.Controls.Add(this.SaveBoxData);
            this.CheckSetting.Controls.Add(this.SavePicBtn);
            this.CheckSetting.Controls.Add(this.CSComboBox);
            this.CheckSetting.Controls.Add(this.AddBoxBtn);
            this.CheckSetting.Controls.Add(this.SettingNameBtn);
            this.CheckSetting.Controls.Add(this.BoxNameCombo);
            this.CheckSetting.Controls.Add(this.BoxNameListlabel);
            this.CheckSetting.Location = new System.Drawing.Point(663, 492);
            this.CheckSetting.Name = "CheckSetting";
            this.CheckSetting.Size = new System.Drawing.Size(286, 170);
            this.CheckSetting.TabIndex = 310;
            this.CheckSetting.TabStop = false;
            // 
            // MainScene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(956, 791);
            this.Controls.Add(this.CheckSetting);
            this.Controls.Add(this.AutoGroup);
            this.Controls.Add(this.BoxSetting);
            this.Controls.Add(this.ClearCheckScene);
            this.Controls.Add(this.AllPercentShow);
            this.Controls.Add(this.CheckPerList);
            this.Controls.Add(this.SecLabel);
            this.Controls.Add(this.MinLabel);
            this.Controls.Add(this.HourLabel);
            this.Controls.Add(this.HourText);
            this.Controls.Add(this.SecText);
            this.Controls.Add(this.MinText);
            this.Controls.Add(this.CheckLoopBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CheckBtn);
            this.Controls.Add(this.CameraPic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainScene";
            this.Text = "画像検査";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainScene_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CameraPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CutPic)).EndInit();
            this.panel1.ResumeLayout(false);
            this.BoxSetting.ResumeLayout(false);
            this.BoxSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UseCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoCol)).EndInit();
            this.AutoGroup.ResumeLayout(false);
            this.AutoGroup.PerformLayout();
            this.CheckSetting.ResumeLayout(false);
            this.CheckSetting.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox CameraPic;
        private System.Windows.Forms.Panel PColor;
        private System.Windows.Forms.Label Rtracktext;
        private System.Windows.Forms.Timer 数値変化チェック;
        private System.Windows.Forms.Label Gtracktext;
        private System.Windows.Forms.Label Btracktext;
        private System.Windows.Forms.PictureBox CutPic;
        private System.Windows.Forms.Button GetPicBtn;
        private System.Windows.Forms.Button CheckBtn;
        private System.Windows.Forms.Label BNums;
        private System.Windows.Forms.Label GNums;
        private System.Windows.Forms.Label RNums;
        private System.Windows.Forms.Label BLUE;
        private System.Windows.Forms.Label GREEN;
        private System.Windows.Forms.Label RED;
        private System.Windows.Forms.Button DelectBoxBtn;
        private System.Windows.Forms.Button SavePicBtn;
        private System.Windows.Forms.ComboBox CSComboBox;
        private System.Windows.Forms.Button AddBoxBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Redlabel;
        private System.Windows.Forms.Label GreenLabel;
        private System.Windows.Forms.Label BlueLabel;
        public System.Windows.Forms.TrackBar RedTrack;
        public System.Windows.Forms.TrackBar GreenTrack;
        public System.Windows.Forms.TrackBar BlueTrack;
        private System.Windows.Forms.Button SettingNameBtn;
        private System.Windows.Forms.ComboBox BoxNameCombo;
        private System.Windows.Forms.Label BoxNameListlabel;
        private System.Windows.Forms.Button CheckLoopBtn;
        private System.Windows.Forms.Timer LoopTimer;
        private System.Windows.Forms.TextBox MinText;
        private System.Windows.Forms.TextBox SecText;
        private System.Windows.Forms.TextBox HourText;
        private System.Windows.Forms.Label HourLabel;
        private System.Windows.Forms.Label MinLabel;
        private System.Windows.Forms.Label SecLabel;
        private System.Windows.Forms.ListBox CheckPerList;
        private System.Windows.Forms.Label AllPercentShow;
        private System.Windows.Forms.TextBox RSetText;
        private System.Windows.Forms.TextBox GSetText;
        private System.Windows.Forms.TextBox BSetText;
        private System.Windows.Forms.Label RGBLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SetSusscePercent;
        private System.Windows.Forms.Button ClearCheckScene;
        private System.Windows.Forms.GroupBox BoxSetting;
        private System.Windows.Forms.ComboBox CheckMode;
        private System.Windows.Forms.Button SaveBoxData;
        private System.Windows.Forms.PictureBox UseCol;
        private System.Windows.Forms.CheckBox UseThisCol;
        private System.Windows.Forms.Button ChooseCol;
        private System.Windows.Forms.Button AutoLock;
        private System.Windows.Forms.TextBox CheckLockNum;
        private System.Windows.Forms.Button AutoColSelectBtn;
        private System.Windows.Forms.PictureBox AutoCol;
        private System.Windows.Forms.GroupBox AutoGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox AutoColNums;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CleanObj;
        private System.Windows.Forms.GroupBox CheckSetting;
    }
}

