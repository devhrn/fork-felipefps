using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Installers
{
	// Token: 0x0200004D RID: 77
	public class Notepad : IFeature
	{
		// Token: 0x060002D4 RID: 724 RVA: 0x0002B660 File Offset: 0x00029860
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\npp.8.0.Installer.x64.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "npp.8.0.Installer.x64.exe", "/S", false);
				return;
			}
			Utils.Status("Downloading Notepad++...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/852896109092405308/npp.8.0.Installer.x64.exe"), Utils.AppData + "\\Felipe\\npp.8.0.Installer.x64.exe");
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x0002B704 File Offset: 0x00029904
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Notepad++: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (4.1MB)");
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x0002B755 File Offset: 0x00029955
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "npp.8.0.Installer.x64.exe", "/S", true);
		}
	}
}
