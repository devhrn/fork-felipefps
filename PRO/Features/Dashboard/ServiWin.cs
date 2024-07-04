using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Dashboard
{
	// Token: 0x02000080 RID: 128
	public class ServiWin : IFeature
	{
		// Token: 0x06000396 RID: 918 RVA: 0x00031990 File Offset: 0x0002FB90
		public void Execute()
		{
			Utils.NeedDownload(Utils.AppData + "\\Felipe\\NSudoLC.exe", "https://cdn.discordapp.com/attachments/766680501284241460/783493940875231262/NSudoLC.exe");
			if (File.Exists(Utils.AppData + "\\Felipe\\ServiWin.exe"))
			{
				Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\NSudoLC.exe", "-U:T -P:E %AppData%\\Felipe\\ServiWin.exe", false, true);
				return;
			}
			Utils.Status("Downloading ServiWin...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/773065487990784021/773092489808052224/ServiWin.exe"), Utils.AppData + "\\Felipe\\ServiWin.exe");
		}

		// Token: 0x06000397 RID: 919 RVA: 0x00031A4C File Offset: 0x0002FC4C
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading ServiWin: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (110KB)");
		}

		// Token: 0x06000398 RID: 920 RVA: 0x00031A9D File Offset: 0x0002FC9D
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.ExecuteProcess(Utils.AppData + "\\Felipe\\NSudoLC.exe", "-U:T -P:E %AppData%\\Felipe\\ServiWin.exe", false, true);
		}
	}
}
