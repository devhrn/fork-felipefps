using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using Microsoft.Win32;
using PRO.Core;

namespace PRO.Features.Installers
{
	// Token: 0x02000040 RID: 64
	public class DDU : IFeature
	{
		// Token: 0x060002A4 RID: 676 RVA: 0x0002A724 File Offset: 0x00028924
		public void Execute()
		{
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\WindowsUpdate\\UX\\Settings", true).SetValue("ExcludeWUDriversInQualityUpdate", "1", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DriverSearching", true).SetValue("SearchOrderConfig", "0", RegistryValueKind.DWord);
			if (File.Exists(Utils.AppData + "\\Felipe\\DDU\\Display Driver Uninstaller.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\DDU\\", "Display Driver Uninstaller.exe", "", false);
				return;
			}
			Utils.Status("Downloading Display Driver Uninstaller...");
			WebClient webClient = new WebClient();
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398293686485024/880200390652624956/DDU.zip"), Path.GetTempPath() + "\\DDU.zip");
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x0002A7F8 File Offset: 0x000289F8
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Display Driver Uninstaller: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (1.28MB)");
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x0002A849 File Offset: 0x00028A49
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("DDU", false);
			Utils.StartProcess(Utils.AppData + "\\Felipe\\DDU\\", "Display Driver Uninstaller.exe", "", true);
		}
	}
}
