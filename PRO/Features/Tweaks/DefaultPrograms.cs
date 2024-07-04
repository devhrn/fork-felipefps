using System;
using System.Diagnostics;
using PRO.Core;

namespace PRO.Features.Tweaks
{
	// Token: 0x0200000E RID: 14
	public class DefaultPrograms : IFeature
	{
		// Token: 0x06000203 RID: 515 RVA: 0x0001B810 File Offset: 0x00019A10
		public void Execute()
		{
			Utils.Status("Default Programs...");
			Utils.NeedDownload(Utils.AppData + "\\Felipe\\SetUserFTA.exe", "https://cdn.discordapp.com/attachments/773065487990784021/800016202172071956/SetUserFTA.exe");
			Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\SetUserFTA.exe", "http \"\"", false, false);
			Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\SetUserFTA.exe", "https \"\"", false, false);
			Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\SetUserFTA.exe", ".bmp PhotoViewer.FileAssoc.Tiff", false, false);
			Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\SetUserFTA.exe", ".gif PhotoViewer.FileAssoc.Tiff", false, false);
			Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\SetUserFTA.exe", ".jpeg PhotoViewer.FileAssoc.Tiff", false, false);
			Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\SetUserFTA.exe", ".jpg PhotoViewer.FileAssoc.Tiff", false, false);
			Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\SetUserFTA.exe", ".png PhotoViewer.FileAssoc.Tiff", false, false);
			Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\SetUserFTA.exe", ".tif PhotoViewer.FileAssoc.Tiff", false, false);
			Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\SetUserFTA.exe", ".tiff PhotoViewer.FileAssoc.Tiff", false, false);
			Process.Start("rundll32.exe", "shell32.dll,Control_RunDLL appwiz.cpl,,3");
			Utils.ResetStatus();
		}
	}
}
