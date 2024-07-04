using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace PRO
{
	// Token: 0x02000002 RID: 2
	public partial class Agreement : Form
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public Agreement()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002074 File Offset: 0x00000274
		private void ButtonAgree_Click(object sender, EventArgs e)
		{
			this.Settings.SetValue("Accepted", "True", RegistryValueKind.String);
			base.Close();
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002092 File Offset: 0x00000292
		private void ButtonDecline_Click(object sender, EventArgs e)
		{
			base.Close();
			Application.Exit();
			Environment.Exit(0);
		}

		// Token: 0x04000001 RID: 1
		private RegistryKey Settings = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Felipe", true);
	}
}
