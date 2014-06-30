/*
 * Created by SharpDevelop.
 * User: lzk
 * Date: 6/30/2014
 * Time: 8:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace WebDownloader
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
			this.txtUrls = new System.Windows.Forms.TextBox();
			this.btnFetch = new System.Windows.Forms.Button();
			this.txtYAML = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtUrls
			// 
			this.txtUrls.Location = new System.Drawing.Point(31, 13);
			this.txtUrls.Multiline = true;
			this.txtUrls.Name = "txtUrls";
			this.txtUrls.Size = new System.Drawing.Size(602, 146);
			this.txtUrls.TabIndex = 0;
			// 
			// btnFetch
			// 
			this.btnFetch.Location = new System.Drawing.Point(31, 334);
			this.btnFetch.Name = "btnFetch";
			this.btnFetch.Size = new System.Drawing.Size(75, 23);
			this.btnFetch.TabIndex = 1;
			this.btnFetch.Text = "Fetch";
			this.btnFetch.UseVisualStyleBackColor = true;
			this.btnFetch.Click += new System.EventHandler(this.BtnFetchClick);
			// 
			// txtYAML
			// 
			this.txtYAML.Location = new System.Drawing.Point(31, 193);
			this.txtYAML.Multiline = true;
			this.txtYAML.Name = "txtYAML";
			this.txtYAML.Size = new System.Drawing.Size(592, 135);
			this.txtYAML.TabIndex = 2;
			this.txtYAML.Text = "---\r\nlayout: post\r\ntitle: {0}\r\ncategory : 字符画\r\ntags : {0}\r\n---\r\n{{% include JB/se" +
			"tup %}}\r\n# {0}\r\n---";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(31, 167);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "YAML:";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(664, 369);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtYAML);
			this.Controls.Add(this.btnFetch);
			this.Controls.Add(this.txtUrls);
			this.Name = "MainForm";
			this.Text = "WebDownloader";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtYAML;
		private System.Windows.Forms.Button btnFetch;
		private System.Windows.Forms.TextBox txtUrls;
	}
}
