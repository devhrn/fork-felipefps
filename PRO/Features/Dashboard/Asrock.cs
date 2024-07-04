using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Windows.Forms;
using PRO.Core;

namespace PRO.Features.Dashboard
{
	// Token: 0x02000069 RID: 105
	public class Asrock : IFeature
	{
		// Token: 0x06000340 RID: 832 RVA: 0x0002F034 File Offset: 0x0002D234
		public void Execute()
		{
			if (File.Exists(Utils.AppData + "\\Felipe\\Asrock Timing Configurator\\4.0.3 (z170 z270 z490)\\AsrTC.exe"))
			{
				DialogResult dialogResult = MessageBox.Show("Different versions of Asrock Timing Configurator per motherboard\n\nAre you in Z170 / Z270?", "Asrock Timing Configuration 4.0.3", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					Utils.StartProcess(Utils.AppData + "\\Felipe\\Asrock Timing Configurator\\4.0.3 (z170 z270 z490)\\", "AsrTC.exe", "", false);
					return;
				}
				if (dialogResult == DialogResult.No)
				{
					DialogResult dialogResult2 = MessageBox.Show("Different versions of Asrock Timing Configurator per motherboard\n\nAre you in Z370 / Z390?", "Asrock Timing Configuration 4.0.4", MessageBoxButtons.YesNo);
					if (dialogResult2 == DialogResult.Yes)
					{
						Utils.StartProcess(Utils.AppData + "\\Felipe\\Asrock Timing Configurator\\4.0.4 (z370 z390)\\", "AsrTC.exe", "", false);
						return;
					}
					if (dialogResult2 == DialogResult.No && MessageBox.Show("Different versions of Asrock Timing Configurator per motherboard\n\nAre you in Z97?", "Asrock Timing Configuration 2.0.7", MessageBoxButtons.YesNo) == DialogResult.Yes)
					{
						Utils.StartProcess(Utils.AppData + "\\Felipe\\Asrock Timing Configurator\\2.0.7 (z97)\\", "AsrTC.exe", "", false);
						return;
					}
				}
			}
			else
			{
				Utils.Status("Downloading Asrock Timing Configurator...");
				WebClient webClient = new WebClient();
				webClient.Headers.Add("User-Agent: Other");
				webClient.DownloadProgressChanged += this.DownloadProgressChanged;
				webClient.DownloadFileCompleted += this.DownloadCompleted;
				webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/762398248655913004/839022352062611456/AsrockTCPack.zip"), Path.GetTempPath() + "\\AsrockTCPack.zip");
			}
		}

		// Token: 0x06000341 RID: 833 RVA: 0x0002F174 File Offset: 0x0002D374
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Asrock Timing Configurator: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (12MB)");
		}

		// Token: 0x06000342 RID: 834 RVA: 0x0002F1C8 File Offset: 0x0002D3C8
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.UnZip("AsrockTCPack", false);
			DialogResult dialogResult = MessageBox.Show("Different versions of Asrock Timing Configurator per motherboard\n\nAre you in Z170 / Z270?", "Asrock Timing Configuration 4.0.3", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\Asrock Timing Configurator\\4.0.3 (z170 z270 z490)\\", "AsrTC.exe", "", false);
			}
			else if (dialogResult == DialogResult.No)
			{
				DialogResult dialogResult2 = MessageBox.Show("Different versions of Asrock Timing Configurator per motherboard\n\nAre you in Z370 / Z390?", "Asrock Timing Configuration 4.0.4", MessageBoxButtons.YesNo);
				if (dialogResult2 == DialogResult.Yes)
				{
					Utils.StartProcess(Utils.AppData + "\\Felipe\\Asrock Timing Configurator\\4.0.4 (z370 z390)\\", "AsrTC.exe", "", false);
				}
				else if (dialogResult2 == DialogResult.No && MessageBox.Show("Different versions of Asrock Timing Configurator per motherboard\n\nAre you in Z97?", "Asrock Timing Configuration 2.0.7", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					Utils.StartProcess(Utils.AppData + "\\Felipe\\Asrock Timing Configurator\\2.0.7 (z97)\\", "AsrTC.exe", "", false);
				}
			}
			Utils.ResetStatus();
		}
	}
}
