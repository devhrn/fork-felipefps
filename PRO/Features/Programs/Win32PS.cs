using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Programs
{
	// Token: 0x0200003D RID: 61
	public class Win32PS : IFeature
	{
		// Token: 0x06000298 RID: 664 RVA: 0x0002A3D0 File Offset: 0x000285D0
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\Win32PS.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "Win32PS.exe", "", false);
				return;
			}
			Utils.Status("Downloading Win32PS...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/832042144356499486/Win32PS.exe"), Utils.AppData + "\\Felipe\\Win32PS.exe");
		}

		// Token: 0x06000299 RID: 665 RVA: 0x0002A474 File Offset: 0x00028674
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Win32PS: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (216KB)");
		}

		// Token: 0x0600029A RID: 666 RVA: 0x0002A4C5 File Offset: 0x000286C5
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "Win32PS.exe", "", true);
		}
	}
}
