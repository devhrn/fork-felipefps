using System;
using System.IO;
using Microsoft.Win32;
using PRO.Core;

namespace PRO.Features.Tweaks
{
	// Token: 0x02000016 RID: 22
	public class OneDrive : IFeature
	{
		// Token: 0x06000215 RID: 533 RVA: 0x0001D0AC File Offset: 0x0001B2AC
		public void Execute()
		{
			Utils.Status("Uninstalling OneDrive...");
			Utils.NeedDownload(Utils.AppData + "\\Felipe\\NSudoLC.exe", "https://cdn.discordapp.com/attachments/1258236120354000896/1258238388436336660/NSudoLC.exe?ex=66875150&is=6685ffd0&hm=5bcd0730110a96d5836e1e4e2db9675915131d69202e894a0286cffd2075f605&");
			Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\OneSyncSvc", true).SetValue("Start", "4", RegistryValueKind.DWord);
			if (File.Exists(Utils.WinDrive + "Windows\\SysWOW64\\OneDriveSetup.exe"))
			{
				Utils.ExecuteProcess(Utils.WinDrive + "Windows\\SysWOW64\\OneDriveSetup.exe", "/uninstall", false, false);
			}
			Registry.ClassesRoot.DeleteSubKeyTree("CLSID\\{018D5C66-4533-4307-9B53-224DE2ED1FE6}", false);
			Registry.ClassesRoot.DeleteSubKeyTree("Wow6432Node\\CLSID\\{018D5C66-4533-4307-9B53-224DE2ED1FE6}", false);
			Utils.ResetStatus();
		}
	}
}
