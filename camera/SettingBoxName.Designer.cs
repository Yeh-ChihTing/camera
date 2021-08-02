
namespace camera
{
    partial class SettingBoxName
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingBoxName));
            this.CompleteBtn = new System.Windows.Forms.Button();
            this.Nums = new System.Windows.Forms.Label();
            this.Boxname = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CompleteBtn
            // 
            this.CompleteBtn.Location = new System.Drawing.Point(202, 12);
            this.CompleteBtn.Name = "CompleteBtn";
            this.CompleteBtn.Size = new System.Drawing.Size(75, 23);
            this.CompleteBtn.TabIndex = 0;
            this.CompleteBtn.Text = "完了";
            this.CompleteBtn.UseVisualStyleBackColor = true;
            this.CompleteBtn.Click += new System.EventHandler(this.CompleteBtn_Click);
            // 
            // Nums
            // 
            this.Nums.AutoSize = true;
            this.Nums.Location = new System.Drawing.Point(13, 22);
            this.Nums.Name = "Nums";
            this.Nums.Size = new System.Drawing.Size(11, 12);
            this.Nums.TabIndex = 1;
            this.Nums.Text = "1";
            // 
            // Boxname
            // 
            this.Boxname.Location = new System.Drawing.Point(30, 19);
            this.Boxname.Name = "Boxname";
            this.Boxname.Size = new System.Drawing.Size(100, 19);
            this.Boxname.TabIndex = 2;
            // 
            // SettingBoxName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(286, 327);
            this.ControlBox = false;
            this.Controls.Add(this.Boxname);
            this.Controls.Add(this.Nums);
            this.Controls.Add(this.CompleteBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingBoxName";
            this.Text = "粋の名前を設定";
            this.Load += new System.EventHandler(this.SettingBoxName_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CompleteBtn;
        private System.Windows.Forms.Label Nums;
        private System.Windows.Forms.TextBox Boxname;
    }
}