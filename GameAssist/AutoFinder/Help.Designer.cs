/*
 * Created by SharpDevelop.
 * User: lzk
 * Date: 2014/7/8
 * Time: 7:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AutoFinder
{
	partial class Help
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Help));
			this.label1 = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.label2 = new System.Windows.Forms.Label();
			this.txtMacId = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnCopy = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
			this.label1.ForeColor = System.Drawing.Color.Blue;
			this.label1.Location = new System.Drawing.Point(12, 10);
			this.label1.Name = "label1";
			this.label1.Padding = new System.Windows.Forms.Padding(10, 11, 10, 11);
			this.label1.Size = new System.Drawing.Size(410, 178);
			this.label1.TabIndex = 0;
			this.label1.Text = "1. 点击”开始找茬“。\r\n2. 打开游戏窗口。\r\n3. 按下左边的Ctrl键，游戏窗口中右边的图就出现白色遮罩，      点击空白部分就找出了不同。\r\n4. " +
			"当不需要遮罩时按下Esc键。\r\n5. 如果想保存游戏图片，勾上“保存游戏图片”。\r\n6. 如果不想用了，按下“不玩了”即可。";
			// 
			// linkLabel1
			// 
			this.linkLabel1.Font = new System.Drawing.Font("宋体", 12F);
			this.linkLabel1.Location = new System.Drawing.Point(225, 191);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(45, 25);
			this.linkLabel1.TabIndex = 1;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "官网";
			this.linkLabel1.Click += new System.EventHandler(this.LinkLabel1Click);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label2.ForeColor = System.Drawing.Color.Red;
			this.label2.Location = new System.Drawing.Point(12, 187);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(207, 25);
			this.label2.TabIndex = 2;
			this.label2.Text = "获取更多帮助和信息，请去";
			// 
			// txtMacId
			// 
			this.txtMacId.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.txtMacId.Location = new System.Drawing.Point(92, 212);
			this.txtMacId.Name = "txtMacId";
			this.txtMacId.ReadOnly = true;
			this.txtMacId.Size = new System.Drawing.Size(198, 20);
			this.txtMacId.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 215);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "机器码：";
			// 
			// btnCopy
			// 
			this.btnCopy.Location = new System.Drawing.Point(310, 212);
			this.btnCopy.Name = "btnCopy";
			this.btnCopy.Size = new System.Drawing.Size(75, 23);
			this.btnCopy.TabIndex = 5;
			this.btnCopy.Text = "复制";
			this.btnCopy.UseVisualStyleBackColor = true;
			this.btnCopy.Click += new System.EventHandler(this.BtnCopyClick);
			// 
			// Help
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(435, 244);
			this.Controls.Add(this.btnCopy);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtMacId);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Help";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "帮助";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button btnCopy;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtMacId;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Label label1;
	}
}
