/*
 * Created by SharpDevelop.
 * User: lzk
 * Date: 2014/7/9
 * Time: 22:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AutoFinder
{
	partial class Donate
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtMacID = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.lnkHomePage = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "序列号";
			// 
			// txtMacID
			// 
			this.txtMacID.ForeColor = System.Drawing.Color.Green;
			this.txtMacID.Location = new System.Drawing.Point(75, 13);
			this.txtMacID.Name = "txtMacID";
			this.txtMacID.ReadOnly = true;
			this.txtMacID.Size = new System.Drawing.Size(180, 21);
			this.txtMacID.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label2.Location = new System.Drawing.Point(13, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(258, 66);
			this.label2.TabIndex = 2;
			this.label2.Text = "嫌广告烦？体谅下作者吧，开发一个软件不容易。如果有心帮助作者，请复制上面的序列号，然后";
			// 
			// lnkHomePage
			// 
			this.lnkHomePage.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lnkHomePage.LinkColor = System.Drawing.Color.Red;
			this.lnkHomePage.Location = new System.Drawing.Point(151, 79);
			this.lnkHomePage.Name = "lnkHomePage";
			this.lnkHomePage.Size = new System.Drawing.Size(73, 23);
			this.lnkHomePage.TabIndex = 3;
			this.lnkHomePage.TabStop = true;
			this.lnkHomePage.Text = "点击这里";
			this.lnkHomePage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkHomePageLinkClicked);
			// 
			// Donate
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(266, 110);
			this.Controls.Add(this.lnkHomePage);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtMacID);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Donate";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "赞助作者";
			this.Load += new System.EventHandler(this.DonateLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.LinkLabel lnkHomePage;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtMacID;
		private System.Windows.Forms.Label label1;
	}
}
