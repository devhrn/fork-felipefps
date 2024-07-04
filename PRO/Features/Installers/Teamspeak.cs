using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using PRO.Core;

namespace PRO.Features.Installers
{
	// Token: 0x02000058 RID: 88
	public class Teamspeak : IFeature
	{
		// Token: 0x06000300 RID: 768 RVA: 0x0002DEB8 File Offset: 0x0002C0B8
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\TeamSpeak3-Client-win64-3.5.6.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "TeamSpeak3-Client-win64-3.5.6.exe", "", false);
				return;
			}
			Utils.Status("Downloading Teamspeak...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/817694743621926942/TeamSpeak3-Client-win64-3.5.6.exe"), Utils.AppData + "\\Felipe\\TeamSpeak3-Client-win64-3.5.6.exe");
		}

		// Token: 0x06000301 RID: 769 RVA: 0x0002DF5C File Offset: 0x0002C15C
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Teamspeak: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (86.5MB)");
		}

		// Token: 0x06000302 RID: 770 RVA: 0x0002DFAD File Offset: 0x0002C1AD
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "TeamSpeak3-Client-win64-3.5.6.exe", "", true);
		}
	}
}
