namespace RemindDrinking
{
    partial class TipsForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TipsForm));
			this.TmrBackHome = new System.Windows.Forms.Timer(this.components);
			this.LabMsg = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// TmrBackHome
			// 
			this.TmrBackHome.Interval = 1000;
			this.TmrBackHome.Tick += new System.EventHandler(this.TmrBackHome_Tick);
			// 
			// LabMsg
			// 
			this.LabMsg.AutoSize = true;
			this.LabMsg.BackColor = System.Drawing.Color.Transparent;
			this.LabMsg.Font = new System.Drawing.Font("LiSu", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.LabMsg.ForeColor = System.Drawing.Color.White;
			this.LabMsg.Location = new System.Drawing.Point(593, 95);
			this.LabMsg.Name = "LabMsg";
			this.LabMsg.Size = new System.Drawing.Size(118, 48);
			this.LabMsg.TabIndex = 0;
			this.LabMsg.Text = "喝水";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(929, 211);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(195, 130);
			this.button1.TabIndex = 1;
			this.button1.Text = "我喝好了";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// TipsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1136, 353);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.LabMsg);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TipsForm";
			this.Text = "TipsForm";
			this.TopMost = true;
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.TipsForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer TmrBackHome;
        private System.Windows.Forms.Label LabMsg;
		private System.Windows.Forms.Button button1;
	}
}