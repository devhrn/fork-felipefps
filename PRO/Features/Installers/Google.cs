using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using Microsoft.Win32;
using PRO.Core;

namespace PRO.Features.Installers
{
	// Token: 0x02000048 RID: 72
	public class Google : IFeature
	{
		// Token: 0x060002C0 RID: 704 RVA: 0x0002AFE8 File Offset: 0x000291E8
		public void Execute()
		{
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Google\\Update", true).SetValue("AutoUpdateCheckPeriodMinutes", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Google\\Update", true).SetValue("InstallDefault", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Google\\Update", true).SetValue("UpdateDefault", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Google\\Update", true).SetValue("Install{F69EABDD-A4BB-4555-BE7E-1EA5F59BBA24}", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Google\\Update", true).SetValue("Update{F69EABDD-A4BB-4555-BE7E-1EA5F59BBA24}", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Google\\Chrome", true).SetValue("SpellCheckServiceEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Google\\Chrome", true).SetValue("SpellcheckEnabled", "0", RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Google\\Chrome\\Recommended", true).SetValue("SpellCheckServiceEnabled", "0", RegistryValueKind.DWord);
			if (File.Exists(Utils.AppData + "\\Felipe\\ChromeSetup.exe"))
			{
				Utils.StartProcess(Utils.AppData + "\\Felipe\\", "ChromeSetup.exe", "", false);
				return;
			}
			Utils.Status("Downloading Google Chrome...");
			WebClient webClient = new WebClient();
			webClient.Headers.Add("User-Agent: Other");
			webClient.DownloadProgressChanged += this.DownloadProgressChanged;
			webClient.DownloadFileCompleted += this.DownloadCompleted;
			webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/773065487990784021/773092241187143700/ChromeSetup.exe"), Utils.AppData + "\\Felipe\\ChromeSetup.exe");
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x0002B18C File Offset: 0x0002938C
		private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
		{
			Tuple<DateTime, long, long> tuple = new Tuple<DateTime, long, long>(DateTime.Now, downloadProgressChangedEventArgs.TotalBytesToReceive, downloadProgressChangedEventArgs.BytesReceived);
			Utils.Status("Downloading Google Chrome: " + (tuple.Item3 * 100L / tuple.Item2).ToString() + "% (1.2MB)");
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x0002B1DD File Offset: 0x000293DD
		public void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Utils.StartProcess(Utils.AppData + "\\Felipe\\", "ChromeSetup.exe", "", true);
		}
	}
}
