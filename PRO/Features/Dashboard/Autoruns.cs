using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Dashboard
{
	// Token: 0x0200006B RID: 107
	public class Autoruns : IFeature
	{
		// Token: 0x06000348 RID: 840 RVA: 0x0002F3C0 File Offset: 0x0002D5C0
		public void Execute()
		{
			Utils.NeedDownload(Utils.AppData + "\\Felipe\\NSudoLC.exe", "https://cdn.discordapp.com/attachments/766680501284241460/783493940875231262/NSudoLC.exe");
			if (File.Exists(Utils.AppData + "\\Felipe\\Autoruns.exe"))
			{
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\NSudoLC.exe", "-U:T -P:E %AppData%\\Felipe\\Autoruns.exe /accepteula", false, false);
				return;
			}
			Utils.Status("Downloading Autoruns...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/773065487990784021/773092229529993226/Autoruns.exe"), Utils.AppData + "\\Felipe\\Autoruns.exe");
		}

		// Token: 0x06000349 RID: 841 RVA: 0x0002F47C File Offset: 0x0002D67C
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Autoruns: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (1MB)");
		}

		// Token: 0x0600034A RID: 842 RVA: 0x0002F4D0 File Offset: 0x0002D6D0
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\NSudoLC.exe", "-U:T -P:E %AppData%\\Felipe\\Autoruns.exe /accepteula", false, true);
			if (Environment.OSVersion.Version.Major == 10)
			{
				Utils.ExecuteProcess("ms-settings:startupapps", "", false, false);
			}
		}
	}
}
