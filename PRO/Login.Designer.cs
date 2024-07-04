namespace PRO
{
	// Token: 0x02000003 RID: 3
	public partial class Login : global::System.Windows.Forms.Form
	{
		// Token: 0x06000009 RID: 9 RVA: 0x0000247E File Offset: 0x0000067E
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000024A4 File Offset: 0x000006A4
		private void InitializeComponent()
		{
			this.button1 = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			this.textBox1 = new global::System.Windows.Forms.TextBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.title = new global::System.Windows.Forms.Label();
			this.top = new global::System.Windows.Forms.Label();
			this.bot = new global::System.Windows.Forms.Label();
			this.left = new global::System.Windows.Forms.Label();
			this.right = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.button1.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new global::System.Drawing.Font("Calibri", 9.75f);
			this.button1.ForeColor = global::System.Drawing.Color.White;
			this.button1.Location = new global::System.Drawing.Point(136, 67);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(94, 26);
			this.button1.TabIndex = 0;
			this.button1.Text = "&Send";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.label1.Font = new global::System.Drawing.Font("Calibri", 9.75f);
			this.label1.ForeColor = global::System.Drawing.Color.White;
			this.label1.Location = new global::System.Drawing.Point(20, 38);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(75, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Discord Tag:";
			this.textBox1.BackColor = global::System.Drawing.Color.White;
			this.textBox1.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox1.Font = new global::System.Drawing.Font("Calibri", 9.75f);
			this.textBox1.ForeColor = global::System.Drawing.Color.Black;
			this.textBox1.Location = new global::System.Drawing.Point(92, 36);
			this.textBox1.MaxLength = 200;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new global::System.Drawing.Size(234, 23);
			this.textBox1.TabIndex = 3;
			this.textBox1.WordWrap = false;
			this.label4.Font = new global::System.Drawing.Font("Calibri", 9.75f);
			this.label4.ForeColor = global::System.Drawing.Color.White;
			this.label4.Location = new global::System.Drawing.Point(20, 73);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(110, 15);
			this.label4.TabIndex = 7;
			this.label4.Text = "Please be patient";
			this.label4.TextAlign = global::System.Drawing.ContentAlignment.TopCenter;
			this.title.Font = new global::System.Drawing.Font("Calibri", 9.75f);
			this.title.Location = new global::System.Drawing.Point(0, 2);
			this.title.Name = "title";
			this.title.Size = new global::System.Drawing.Size(350, 23);
			this.title.TabIndex = 9;
			this.title.Text = "Payment Confirmation";
			this.title.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.top.BackColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.top.Location = new global::System.Drawing.Point(0, 0);
			this.top.Name = "top";
			this.top.Size = new global::System.Drawing.Size(350, 2);
			this.top.TabIndex = 10;
			this.bot.BackColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.bot.Location = new global::System.Drawing.Point(0, 102);
			this.bot.Name = "bot";
			this.bot.Size = new global::System.Drawing.Size(350, 2);
			this.bot.TabIndex = 11;
			this.left.BackColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.left.Location = new global::System.Drawing.Point(0, 0);
			this.left.Name = "left";
			this.left.Size = new global::System.Drawing.Size(2, 156);
			this.left.TabIndex = 12;
			this.right.BackColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.right.Location = new global::System.Drawing.Point(348, 0);
			this.right.Name = "right";
			this.right.Size = new global::System.Drawing.Size(2, 156);
			this.right.TabIndex = 13;
			this.label7.BackColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.label7.Location = new global::System.Drawing.Point(0, 24);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(350, 2);
			this.label7.TabIndex = 14;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(5, 8, 10);
			base.ClientSize = new global::System.Drawing.Size(350, 105);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.right);
			base.Controls.Add(this.left);
			base.Controls.Add(this.bot);
			base.Controls.Add(this.top);
			base.Controls.Add(this.title);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.textBox1);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.button1);
			this.ForeColor = global::System.Drawing.Color.White;
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "Login";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Authentication";
			base.Load += new global::System.EventHandler(this.Login_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000007 RID: 7
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000008 RID: 8
		private global::System.Windows.Forms.Button button1;

		// Token: 0x04000009 RID: 9
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400000A RID: 10
		private global::System.Windows.Forms.TextBox textBox1;

		// Token: 0x0400000B RID: 11
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400000C RID: 12
		private global::System.Windows.Forms.Label title;

		// Token: 0x0400000D RID: 13
		private global::System.Windows.Forms.Label top;

		// Token: 0x0400000E RID: 14
		private global::System.Windows.Forms.Label bot;

		// Token: 0x0400000F RID: 15
		private global::System.Windows.Forms.Label left;

		// Token: 0x04000010 RID: 16
		private global::System.Windows.Forms.Label right;

		// Token: 0x04000011 RID: 17
		private global::System.Windows.Forms.Label label7;
	}
}
