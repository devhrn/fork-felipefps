using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using Microsoft.Win32;
using PRO.Core;

namespace PRO.Features.Installers
{
	// Token: 0x02000045 RID: 69
	public class Firefox : IFeature
	{
		// Token: 0x060002B4 RID: 692 RVA: 0x0002AC80 File Offset: 0x00028E80
		public void Execute()
		{
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Mozilla\\Firefox", true).SetValue("DisableAppUpdate", "1", RegistryValueKind.DWord);
			if (File.Exists(Utils.AppData + "\\Felipe\\Firefox_Installer.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "Firefox_Installer.exe", "", false);
				return;
			}
			Utils.Status("Downloading Firefox...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398293686485024/847515530964238353/Firefox_Installer.exe"), Utils.AppData + "\\Felipe\\Firefox_Installer.exe");
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x0002AD44 File Offset: 0x00028F44
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Firefox: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (326KB)");
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x0002AD95 File Offset: 0x00028F95
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "Firefox_Installer.exe", "", true);
		}
	}
}
