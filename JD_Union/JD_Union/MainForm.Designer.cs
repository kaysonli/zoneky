/*
 * Created by SharpDevelop.
 * User: lzk
 * Date: 2014/8/21
 * Time: 21:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace JD_Union
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
			this.btnConvert = new System.Windows.Forms.Button();
			this.txtItems = new System.Windows.Forms.TextBox();
			this.rdoJS = new System.Windows.Forms.RadioButton();
			this.rdoUrl = new System.Windows.Forms.RadioButton();
			this.SuspendLayout();
			// 
			// btnConvert
			// 
			this.btnConvert.Location = new System.Drawing.Point(12, 444);
			this.btnConvert.Name = "btnConvert";
			this.btnConvert.Size = new System.Drawing.Size(75, 25);
			this.btnConvert.TabIndex = 0;
			this.btnConvert.Text = "Get Code";
			this.btnConvert.UseVisualStyleBackColor = true;
			this.btnConvert.Click += new System.EventHandler(this.Button1Click);
			// 
			// txtItems
			// 
			this.txtItems.Location = new System.Drawing.Point(13, 35);
			this.txtItems.Multiline = true;
			this.txtItems.Name = "txtItems";
			this.txtItems.Size = new System.Drawing.Size(467, 391);
			this.txtItems.TabIndex = 1;
			// 
			// rdoJS
			// 
			this.rdoJS.Checked = true;
			this.rdoJS.Location = new System.Drawing.Point(22, 5);
			this.rdoJS.Name = "rdoJS";
			this.rdoJS.Size = new System.Drawing.Size(104, 24);
			this.rdoJS.TabIndex = 2;
			this.rdoJS.TabStop = true;
			this.rdoJS.Text = "智能图文";
			this.rdoJS.UseVisualStyleBackColor = true;
			// 
			// rdoUrl
			// 
			this.rdoUrl.Location = new System.Drawing.Point(157, 5);
			this.rdoUrl.Name = "rdoUrl";
			this.rdoUrl.Size = new System.Drawing.Size(104, 24);
			this.rdoUrl.TabIndex = 2;
			this.rdoUrl.Text = "链接";
			this.rdoUrl.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(492, 492);
			this.Controls.Add(this.rdoUrl);
			this.Controls.Add(this.rdoJS);
			this.Controls.Add(this.txtItems);
			this.Controls.Add(this.btnConvert);
			this.Name = "MainForm";
			this.Text = "JD Helper";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.RadioButton rdoUrl;
		private System.Windows.Forms.RadioButton rdoJS;
		private System.Windows.Forms.TextBox txtItems;
		private System.Windows.Forms.Button btnConvert;
	}
}
