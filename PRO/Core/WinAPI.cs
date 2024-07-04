using System;
using System.Runtime.InteropServices;

namespace PRO.Core
{
	// Token: 0x020000A3 RID: 163
	public class WinAPI
	{
		// Token: 0x0600042A RID: 1066
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		// Token: 0x0600042B RID: 1067
		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		// Token: 0x0600042C RID: 1068
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool Wow64DisableWow64FsRedirection(ref IntPtr ptr);

		// Token: 0x0600042D RID: 1069
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool Wow64RevertWow64FsRedirection(IntPtr ptr);

		// Token: 0x040000F9 RID: 249
		public const int WM_NCLBUTTONDOWN = 161;

		// Token: 0x040000FA RID: 250
		public const int HT_CAPTION = 2;

		// Token: 0x040000FB RID: 251
		public const int CS_DROPSHADOW = 131072;
	}
}
