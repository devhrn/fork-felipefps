using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PRO.Core;

namespace PRO
{
	// Token: 0x02000003 RID: 3
	public partial class Login : Form
	{
		// Token: 0x06000006 RID: 6 RVA: 0x0000234C File Offset: 0x0000054C
		public Login()
		{
			this.InitializeComponent();
			Login.login = this;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002360 File Offset: 0x00000560
		private void button1_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(this.textBox1.Text))
			{
				MessageBox.Show("Digite sua tag do Discord!", "Type your discord tag!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			string content = string.Concat(new string[]
			{
				Utils.getid("PartNumber", "Win32_PhysicalMemory"),
				Utils.getid("UUID", "Win32_ComputerSystemProduct"),
				Utils.getid("SerialNumber", "Win32_BaseBoard"),
				Utils.getid("ProcessorID", "Win32_Processor"),
				Utils.getid("UniqueId", "Win32_Processor"),
				Utils.getid("Product", "Win32_BaseBoard").Replace("F", "9").Replace("0", "7").Replace("4", "A").Replace("B", "2")
			});
			string text = this.textBox1.Text;
			Utils.DiscordSendMessage("https://discord.com/api/webhooks/855454511720038422/s78qsbX_L6cHuQ5AJUjaEqUgriqjDuoBWyFlSC9sGBP5YWUY8iZ7pZgD2CxvBYn72vbd", text, content);
			Application.Exit();
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002464 File Offset: 0x00000664
		private void Login_Load(object sender, EventArgs e)
		{
			base.Visible = false;
			new MainForm().ShowDialog();
			base.Close();
		}

		// Token: 0x04000006 RID: 6
		public static Login login;
	}
}
