using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Games
{
	// Token: 0x02000061 RID: 97
	public class Legendary : IFeature
	{
		// Token: 0x06000322 RID: 802 RVA: 0x0002E7D4 File Offset: 0x0002C9D4
		public void Execute()
		{
			if (File.Exists(Utils.WinDrive + "\\legendary.exe"))
			{
				Utils.StartProcessCmd(Environment.ExpandEnvironmentVariables(Utils.WinDrive), "/k " + Utils.WinDrive + "\\legendary.exe -h", true);
				return;
			}
			Utils.Status("Downloading Legendary...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/839015005377921024/legendary.exe"), Utils.WinDrive + "\\legendary.exe");
		}

		// Token: 0x06000323 RID: 803 RVA: 0x0002E880 File Offset: 0x0002CA80
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Legendary: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (7.73MB)");
		}

		// Token: 0x06000324 RID: 804 RVA: 0x0002E8D1 File Offset: 0x0002CAD1
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcessCmd(Environment.ExpandEnvironmentVariables(Utils.WinDrive), "/k " + Utils.WinDrive + "\\legendary.exe -h", true);
		}
	}
}
