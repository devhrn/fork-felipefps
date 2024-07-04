using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Benchmark
{
	// Token: 0x02000092 RID: 146
	public class iperf : IFeature
	{
		// Token: 0x060003DA RID: 986 RVA: 0x00032BB4 File Offset: 0x00030DB4
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\iperf\\iperf3.exe"))
			{
				Utils.StartProcessCmd(Environment.ExpandEnvironmentVariables(Utils.WinDrive), "/k " + Utils.AppData + "\\Felipe\\iperf\\iperf3.exe -h", true);
				return;
			}
			Utils.Status("Downloading iperf...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/852950814720917545/iperf.zip"), Path.GetTempPath() + "\\iperf.zip");
		}

		// Token: 0x060003DB RID: 987 RVA: 0x00032C60 File Offset: 0x00030E60
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading iperf: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (1.2MB)");
		}

		// Token: 0x060003DC RID: 988 RVA: 0x00032CB1 File Offset: 0x00030EB1
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("iperf", false);
			Utils.StartProcessCmd(Environment.ExpandEnvironmentVariables(Utils.WinDrive), "/k " + Utils.AppData + "\\Felipe\\iperf\\iperf3.exe -h", true);
		}
	}
}
