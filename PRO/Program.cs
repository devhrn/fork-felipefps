using System;
using System.Windows.Forms;

namespace PRO
{
	// Token: 0x02000005 RID: 5
	internal static class Program
	{
		// Token: 0x0600016F RID: 367 RVA: 0x0001641B File Offset: 0x0001461B
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Login());
		}
	}
}
