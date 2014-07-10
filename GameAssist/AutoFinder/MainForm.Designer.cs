using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

/*
 * Created by SharpDevelop.
 * User: lzk
 * Date: 2014/7/6
 * Time: 13:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AutoFinder
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.btnMonitor = new System.Windows.Forms.Button();
			this.btnHide = new System.Windows.Forms.Button();
			this.btnHelp = new System.Windows.Forms.Button();
			this.checkBoxSaveImg = new System.Windows.Forms.CheckBox();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.lblAdTitle = new System.Windows.Forms.Label();
			this.lnkAd = new System.Windows.Forms.LinkLabel();
			this.lnkDonate = new System.Windows.Forms.LinkLabel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "火眼金睛QQ找茬辅助";
			this.notifyIcon1.Visible = true;
			this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1MouseDoubleClick);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 35);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(415, 377);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.PictureBox1Click);
			// 
			// btnMonitor
			// 
			this.btnMonitor.Location = new System.Drawing.Point(9, 455);
			this.btnMonitor.Name = "btnMonitor";
			this.btnMonitor.Size = new System.Drawing.Size(75, 23);
			this.btnMonitor.TabIndex = 2;
			this.btnMonitor.Text = "开始找茬";
			this.btnMonitor.UseVisualStyleBackColor = true;
			this.btnMonitor.Click += new System.EventHandler(this.BtnMonitorClick);
			// 
			// btnHide
			// 
			this.btnHide.Location = new System.Drawing.Point(105, 455);
			this.btnHide.Name = "btnHide";
			this.btnHide.Size = new System.Drawing.Size(75, 23);
			this.btnHide.TabIndex = 3;
			this.btnHide.Text = "隐藏";
			this.btnHide.UseVisualStyleBackColor = true;
			this.btnHide.Click += new System.EventHandler(this.BtnHideClick);
			// 
			// btnHelp
			// 
			this.btnHelp.Location = new System.Drawing.Point(199, 455);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new System.Drawing.Size(75, 23);
			this.btnHelp.TabIndex = 4;
			this.btnHelp.Text = "帮助";
			this.btnHelp.UseVisualStyleBackColor = true;
			this.btnHelp.Click += new System.EventHandler(this.BtnHelpClick);
			// 
			// checkBoxSaveImg
			// 
			this.checkBoxSaveImg.Location = new System.Drawing.Point(296, 454);
			this.checkBoxSaveImg.Name = "checkBoxSaveImg";
			this.checkBoxSaveImg.Size = new System.Drawing.Size(104, 24);
			this.checkBoxSaveImg.TabIndex = 5;
			this.checkBoxSaveImg.Text = "保存游戏图片";
			this.checkBoxSaveImg.UseVisualStyleBackColor = true;
			// 
			// radioButton1
			// 
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(129, 418);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(104, 24);
			this.radioButton1.TabIndex = 6;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "美女找茬";
			this.radioButton1.UseVisualStyleBackColor = true;
			this.radioButton1.CheckedChanged += new System.EventHandler(this.RadioButton1CheckedChanged);
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(227, 418);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(104, 24);
			this.radioButton2.TabIndex = 7;
			this.radioButton2.Text = "大家来找茬";
			this.radioButton2.UseVisualStyleBackColor = true;
			this.radioButton2.CheckedChanged += new System.EventHandler(this.RadioButton2CheckedChanged);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.Location = new System.Drawing.Point(9, 419);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 8;
			this.label1.Text = "你玩的是：";
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
			// 
			// lblAdTitle
			// 
			this.lblAdTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblAdTitle.Location = new System.Drawing.Point(3, 9);
			this.lblAdTitle.Name = "lblAdTitle";
			this.lblAdTitle.Size = new System.Drawing.Size(406, 23);
			this.lblAdTitle.TabIndex = 9;
			this.lblAdTitle.Text = "...";
			// 
			// lnkAd
			// 
			this.lnkAd.Font = new System.Drawing.Font("微软雅黑", 10F);
			this.lnkAd.LinkColor = System.Drawing.Color.Red;
			this.lnkAd.Location = new System.Drawing.Point(9, 485);
			this.lnkAd.Name = "lnkAd";
			this.lnkAd.Size = new System.Drawing.Size(265, 23);
			this.lnkAd.TabIndex = 10;
			this.lnkAd.TabStop = true;
			this.lnkAd.Text = "官网";
			this.lnkAd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkAdLinkClicked);
			// 
			// lnkDonate
			// 
			this.lnkDonate.Font = new System.Drawing.Font("宋体", 10F);
			this.lnkDonate.LinkColor = System.Drawing.Color.Blue;
			this.lnkDonate.Location = new System.Drawing.Point(330, 485);
			this.lnkDonate.Name = "lnkDonate";
			this.lnkDonate.Size = new System.Drawing.Size(70, 23);
			this.lnkDonate.TabIndex = 11;
			this.lnkDonate.TabStop = true;
			this.lnkDonate.Text = "关闭广告";
			this.lnkDonate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkDonateLinkClicked);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(415, 511);
			this.Controls.Add(this.lnkDonate);
			this.Controls.Add(this.lnkAd);
			this.Controls.Add(this.lblAdTitle);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.radioButton2);
			this.Controls.Add(this.radioButton1);
			this.Controls.Add(this.checkBoxSaveImg);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.btnHide);
			this.Controls.Add(this.btnMonitor);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Location = new System.Drawing.Point(10, 10);
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "火眼金睛QQ找茬辅助";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.SizeChanged += new System.EventHandler(this.MainFormSizeChanged);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.LinkLabel lnkDonate;
		private System.Windows.Forms.LinkLabel lnkAd;
		private System.Windows.Forms.Label lblAdTitle;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.CheckBox checkBoxSaveImg;
		private System.Windows.Forms.Button btnHelp;
		private System.Windows.Forms.Button btnHide;
		private System.Windows.Forms.Button btnMonitor;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		
		void MainFormSizeChanged(object sender, System.EventArgs e)
		{
			if (base.WindowState == System.Windows.Forms.FormWindowState.Minimized)
			{
				base.Hide();
				this.notifyIcon1.Visible = true;
			}
		}
		
		void NotifyIcon1MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			base.Visible = true;
			base.WindowState = System.Windows.Forms.FormWindowState.Normal;
			this.notifyIcon1.Visible = false;
		}
		
		void BtnMonitorClick(object sender, System.EventArgs e)
		{
			if(IsLatestVersion() == false)
			{
				var result = MessageBox.Show("当前不是最新版本，无法继续使用。请点击确定下载最新版", "版本更新", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
				if(result == DialogResult.OK)
				{
					System.Diagnostics.Process.Start(configLoader.DownloadPage);
				}
				return;
			}
			ComponentResourceManager manager = new ComponentResourceManager(typeof(MainForm));
			this.pictureBox1.Image = (System.Drawing.Image) manager.GetObject("pictureBox1.Image");
			if (this.btnMonitor.Text == "开始找茬")
			{
				InterceptKeys.RunHook();
				this.btnMonitor.Text = "不玩了";
			}
			else
			{
				InterceptKeys.UnHook();
				this.blobWnd.Hide();
				this.btnMonitor.Text = "开始找茬";
				
			}
		}
		
		void PictureBox1Click(object sender, System.EventArgs e)
		{
			if(pictureBox1.Tag == null)
			{
				return;
			}
			string clickUrl = pictureBox1.Tag.ToString();
			System.Diagnostics.Process.Start(clickUrl);
		}
		
		void BtnHideClick(object sender, System.EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}
		
		void LnkDonateLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Donate dialog = new Donate();
			dialog.HelpPage = configLoader.HelpPage;
			dialog.ShowDialog();
		}
	}
}
