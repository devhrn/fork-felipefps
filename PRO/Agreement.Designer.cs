namespace PRO
{
	// Token: 0x02000002 RID: 2
	public partial class Agreement : global::System.Windows.Forms.Form
	{
		// Token: 0x06000004 RID: 4 RVA: 0x000020A5 File Offset: 0x000002A5
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020CC File Offset: 0x000002CC
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::PRO.Agreement));
			this.License = new global::System.Windows.Forms.RichTextBox();
			this.ButtonDecline = new global::System.Windows.Forms.Button();
			this.ButtonAgree = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.License.Location = new global::System.Drawing.Point(13, 12);
			this.License.Name = "License";
			this.License.ReadOnly = true;
			this.License.Size = new global::System.Drawing.Size(441, 238);
			this.License.TabIndex = 0;
			this.License.Text = componentResourceManager.GetString("License.Text");
			this.ButtonDecline.FlatStyle = global::System.Windows.Forms.FlatStyle.System;
			this.ButtonDecline.Location = new global::System.Drawing.Point(379, 261);
			this.ButtonDecline.Name = "ButtonDecline";
			this.ButtonDecline.Size = new global::System.Drawing.Size(75, 21);
			this.ButtonDecline.TabIndex = 61;
			this.ButtonDecline.Text = "Decline";
			this.ButtonDecline.UseVisualStyleBackColor = true;
			this.ButtonDecline.Click += new global::System.EventHandler(this.ButtonDecline_Click);
			this.ButtonAgree.FlatStyle = global::System.Windows.Forms.FlatStyle.System;
			this.ButtonAgree.Location = new global::System.Drawing.Point(298, 261);
			this.ButtonAgree.Name = "ButtonAgree";
			this.ButtonAgree.Size = new global::System.Drawing.Size(75, 21);
			this.ButtonAgree.TabIndex = 62;
			this.ButtonAgree.Text = "Agree";
			this.ButtonAgree.UseVisualStyleBackColor = true;
			this.ButtonAgree.Click += new global::System.EventHandler(this.ButtonAgree_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(466, 291);
			base.Controls.Add(this.ButtonAgree);
			base.Controls.Add(this.ButtonDecline);
			base.Controls.Add(this.License);
			this.Font = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Agreement";
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Felipe Tool Rules & NDA Agreement";
			base.ResumeLayout(false);
		}

		// Token: 0x04000002 RID: 2
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000003 RID: 3
		private global::System.Windows.Forms.RichTextBox License;

		// Token: 0x04000004 RID: 4
		public global::System.Windows.Forms.Button ButtonDecline;

		// Token: 0x04000005 RID: 5
		public global::System.Windows.Forms.Button ButtonAgree;
	}
}
