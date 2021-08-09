
namespace camera
{
    partial class MyBox
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BottonRight = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.MyNumber = new System.Windows.Forms.Label();
            this.Drawbox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BottonRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Drawbox)).BeginInit();
            this.SuspendLayout();
            // 
            // BottonRight
            // 
            this.BottonRight.BackColor = System.Drawing.Color.Brown;
            this.BottonRight.Location = new System.Drawing.Point(137, 136);
            this.BottonRight.Name = "BottonRight";
            this.BottonRight.Size = new System.Drawing.Size(15, 15);
            this.BottonRight.TabIndex = 2;
            this.BottonRight.TabStop = false;
            this.BottonRight.Visible = false;
            this.BottonRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BottonRight_MouseDown);
            this.BottonRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BottonRight_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MyNumber
            // 
            this.MyNumber.AutoSize = true;
            this.MyNumber.BackColor = System.Drawing.Color.Transparent;
            this.MyNumber.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MyNumber.ForeColor = System.Drawing.Color.Black;
            this.MyNumber.Location = new System.Drawing.Point(3, 3);
            this.MyNumber.Name = "MyNumber";
            this.MyNumber.Size = new System.Drawing.Size(52, 16);
            this.MyNumber.TabIndex = 3;
            this.MyNumber.Text = "label1";
            // 
            // Drawbox
            // 
            this.Drawbox.BackColor = System.Drawing.Color.Transparent;
            this.Drawbox.Location = new System.Drawing.Point(3, 3);
            this.Drawbox.Name = "Drawbox";
            this.Drawbox.Size = new System.Drawing.Size(144, 144);
            this.Drawbox.TabIndex = 4;
            this.Drawbox.TabStop = false;
            this.Drawbox.Visible = false;
            this.Drawbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Drawbox_MouseClick);
            this.Drawbox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drawbox_MouseDown);
            this.Drawbox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Drawbox_MouseMove);
            // 
            // MyBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.MyNumber);
            this.Controls.Add(this.BottonRight);
            this.Controls.Add(this.Drawbox);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Name = "MyBox";
            this.SizeChanged += new System.EventHandler(this.MyBox_SizeChanged);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MyBox_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MyBox_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MyBox_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MyBox_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.BottonRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Drawbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox BottonRight;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label MyNumber;
        public System.Windows.Forms.PictureBox Drawbox;
    }
}
