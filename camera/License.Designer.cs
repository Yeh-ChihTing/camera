
namespace camera
{
    partial class License
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
            this.check = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.MyID = new System.Windows.Forms.TextBox();
            this.MyPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // check
            // 
            this.check.Location = new System.Drawing.Point(99, 116);
            this.check.Name = "check";
            this.check.Size = new System.Drawing.Size(75, 23);
            this.check.TabIndex = 0;
            this.check.Text = "確認";
            this.check.UseVisualStyleBackColor = true;
            this.check.Click += new System.EventHandler(this.check_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID";
            // 
            // MyID
            // 
            this.MyID.Location = new System.Drawing.Point(74, 24);
            this.MyID.Name = "MyID";
            this.MyID.Size = new System.Drawing.Size(143, 19);
            this.MyID.TabIndex = 2;
            this.MyID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MyID_KeyDown);
            // 
            // MyPass
            // 
            this.MyPass.Location = new System.Drawing.Point(74, 70);
            this.MyPass.Name = "MyPass";
            this.MyPass.Size = new System.Drawing.Size(143, 19);
            this.MyPass.TabIndex = 4;
            this.MyPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MyPass_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pass";
            // 
            // License
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 159);
            this.Controls.Add(this.MyPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MyID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.check);
            this.Name = "License";
            this.Text = "認証";
            this.Load += new System.EventHandler(this.License_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button check;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MyID;
        private System.Windows.Forms.TextBox MyPass;
        private System.Windows.Forms.Label label2;
    }
}