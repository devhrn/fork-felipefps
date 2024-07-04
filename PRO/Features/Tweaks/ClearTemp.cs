using System;
using System.Threading;
using PRO.Core;

namespace PRO.Features.Tweaks
{
	// Token: 0x02000009 RID: 9
	public class ClearTemp : IFeature
	{
		// Token: 0x060001F9 RID: 505 RVA: 0x0001ABF4 File Offset: 0x00018DF4
		public void Execute()
		{
			Utils.Status("Cleaning Temporary Files and Exiting...");
			Utils.SysNativeCmd("del /s /f /q %appdata%\\Felipe\\*.*");
			Utils.SysNativeCmd("del /s /f /q %userprofile%\\Recent\\*.*");
			Utils.SysNativeCmd("del /s /f /q %windir%\\Prefetch\\*.*");
			Utils.SysNativeCmd("del /s /f /q %windir%\\Temp\\*.*");
			Utils.SysNativeCmd("del /s /f /q %USERPROFILE%\\appdata\\local\\temp\\*.*");
			Utils.SysNativeCmd("del /s /f /q %userprofile%\\Recent\\*.*");
			Thread.Sleep(1000);
			Utils.ResetStatus();
		}
	}
}
