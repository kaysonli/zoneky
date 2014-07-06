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
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(415, 381);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// btnMonitor
			// 
			this.btnMonitor.Location = new System.Drawing.Point(12, 424);
			this.btnMonitor.Name = "btnMonitor";
			this.btnMonitor.Size = new System.Drawing.Size(75, 23);
			this.btnMonitor.TabIndex = 2;
			this.btnMonitor.Text = "开始找茬";
			this.btnMonitor.UseVisualStyleBackColor = true;
			this.btnMonitor.Click += new System.EventHandler(this.BtnMonitorClick);
			// 
			// btnHide
			// 
			this.btnHide.Location = new System.Drawing.Point(108, 424);
			this.btnHide.Name = "btnHide";
			this.btnHide.Size = new System.Drawing.Size(75, 23);
			this.btnHide.TabIndex = 3;
			this.btnHide.Text = "隐藏";
			this.btnHide.UseVisualStyleBackColor = true;
			// 
			// btnHelp
			// 
			this.btnHelp.Location = new System.Drawing.Point(202, 424);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new System.Drawing.Size(75, 23);
			this.btnHelp.TabIndex = 4;
			this.btnHelp.Text = "帮助";
			this.btnHelp.UseVisualStyleBackColor = true;
			// 
			// checkBoxSaveImg
			// 
			this.checkBoxSaveImg.Location = new System.Drawing.Point(299, 423);
			this.checkBoxSaveImg.Name = "checkBoxSaveImg";
			this.checkBoxSaveImg.Size = new System.Drawing.Size(104, 24);
			this.checkBoxSaveImg.TabIndex = 5;
			this.checkBoxSaveImg.Text = "保存游戏图片";
			this.checkBoxSaveImg.UseVisualStyleBackColor = true;
			// 
			// radioButton1
			// 
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(132, 387);
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
			this.radioButton2.Location = new System.Drawing.Point(230, 387);
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
			this.label1.Location = new System.Drawing.Point(12, 388);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 8;
			this.label1.Text = "你玩的是：";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(415, 462);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.radioButton2);
			this.Controls.Add(this.radioButton1);
			this.Controls.Add(this.checkBoxSaveImg);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.btnHide);
			this.Controls.Add(this.btnMonitor);
			this.Controls.Add(this.pictureBox1);
			this.Location = new System.Drawing.Point(10, 10);
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "火眼金睛QQ找茬辅助";
			this.SizeChanged += new System.EventHandler(this.MainFormSizeChanged);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
		}
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
                ComponentResourceManager manager = new ComponentResourceManager(typeof(MainForm));
                this.pictureBox1.Image = (System.Drawing.Image) manager.GetObject("pictureBox1.Image");
            }
		}
	}
}
