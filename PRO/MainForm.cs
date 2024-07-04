using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using PRO.Core;
using PRO.Features.Benchmark;
using PRO.Features.Dashboard;
using PRO.Features.Games;
using PRO.Features.Installers;
using PRO.Features.Programs;
using PRO.Features.Tweaks;
using PRO.Properties;

namespace PRO
{
	// Token: 0x02000004 RID: 4
	public partial class MainForm : Form
	{
		// Token: 0x0600000B RID: 11 RVA: 0x00002B05 File Offset: 0x00000D05
		public static bool SpyCheck()
		{
			return Process.GetProcesses().Any((Process x) => MainForm.BlackList.Contains(x.ProcessName.ToLower()) || MainForm._entries.Contains(x.ProcessName.ToLower()));
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002B30 File Offset: 0x00000D30
		public void ExecuteDirect(IFeature feature)
		{
			feature.Execute();
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002B38 File Offset: 0x00000D38
		public MainForm()
		{
			this.InitializeComponent();
			if (MainForm.Settings.GetValue("Accepted") != null)
			{
				string text = MainForm.Settings.GetValue("Accepted") as string;
				if (text != null && text == "False")
				{
					MainForm.Agreement.ShowDialog(this);
				}
			}
			else
			{
				MainForm.Agreement.ShowDialog(this);
			}
			MainForm.Main = this;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002BA8 File Offset: 0x00000DA8
		private void MainForm_Load(object sender, EventArgs e)
		{
			base.Visible = false;
			base.Visible = true;
			this.DashboardButton.Enabled = true;
			this.TweaksButton.Enabled = true;
			this.InstallersButton.Enabled = true;
			this.ProgramsButton.Enabled = true;
			this.BenchmarksButton.Enabled = true;
			this.DashboardPanel.Visible = true;
			this.TweaksButton.ForeColor = Color.FromArgb(64, 64, 64);
			this.InstallersButton.ForeColor = Color.FromArgb(64, 64, 64);
			this.ProgramsButton.ForeColor = Color.FromArgb(64, 64, 64);
			this.BenchmarksButton.ForeColor = Color.FromArgb(64, 64, 64);
			this.GamesButton.ForeColor = Color.FromArgb(64, 64, 64);
			this.DashboardButton.ForeColor = Color.FromArgb(255, 251, 252);
			this.DashboardButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold | FontStyle.Underline);
			this.TweaksButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold);
			this.InstallersButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold);
			this.ProgramsButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold);
			this.BenchmarksButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold);
			this.GamesButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold);
			this.DashboardPanel.Visible = true;
			this.TweaksPanel.Visible = false;
			this.InstallersPanel.Visible = false;
			this.ProgramsPanel.Visible = false;
			this.BenchmarksPanel.Visible = false;
			this.GamesPanel.Visible = false;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002D84 File Offset: 0x00000F84
		private void MainForm_Shown(object sender, EventArgs e)
		{
			foreach (string name in MainForm.RegistryKeys)
			{
				if (Registry.CurrentUser.OpenSubKey(name) != null)
				{
					string[] valueNames = Registry.CurrentUser.OpenSubKey(name).GetValueNames();
					for (int j = 0; j < valueNames.Length; j++)
					{
						string text = Path.GetFileNameWithoutExtension(valueNames[j].Replace(".FriendlyAppName", "").Replace(".ApplicationCompany", "")).ToLower();
						MainForm._entries.Add(text);
						Console.WriteLine(text);
					}
				}
			}
			Utils.CreateFolder(Utils.AppData + "\\Felipe");
			Utils.NeedDownload(Utils.AppData + "\\Felipe\\NSudoLC.exe", "https://cdn.discordapp.com/attachments/766680501284241460/783493940875231262/NSudoLC.exe");
			Utils.ExecuteProcess("sc.exe", "config TrustedInstaller start= demand", false, false);
			Utils.ExecuteProcess("sc.exe", "config Winmgmt start= demand", false, false);
			if (Utils.SystemInformation.GPUName.ToString() != null && Utils.SystemInformation.GPUName.Contains("AMD"))
			{
				this.button49.Image = Resources.amd32;
				this.button50.Image = Resources.amdx32;
				this.button80.Image = Resources.amddriver32;
			}
			if (Utils.SystemInformation.SocketDesignation.ToString() != null && Utils.SystemInformation.SocketDesignation.Contains("AM4"))
			{
				this.button19.Image = Resources.zentimings32;
				this.button19.Text = "            ZenTimings";
			}
			if (MainForm.Settings.GetValue("AudioSvchost") != null)
			{
				this.button65.BackColor = Color.FromArgb(5, 88, 10);
			}
			if (MainForm.Settings.GetValue("Autotuning") != null)
			{
				this.button64.BackColor = Color.FromArgb(5, 88, 10);
			}
			if (MainForm.Settings.GetValue("BareDrivers") != null)
			{
				this.button8.BackColor = Color.FromArgb(5, 88, 10);
			}
			if (MainForm.Settings.GetValue("Defender") != null)
			{
				this.button58.BackColor = Color.FromArgb(5, 88, 10);
			}
			if (MainForm.Settings.GetValue("DEP") != null)
			{
				this.button56.BackColor = Color.FromArgb(5, 88, 10);
			}
			if (MainForm.Settings.GetValue("FSE") != null)
			{
				this.button63.BackColor = Color.FromArgb(5, 88, 10);
			}
			if (MainForm.Settings.GetValue("TaskmgrPE") != null)
			{
				this.button39.BackColor = Color.FromArgb(5, 88, 10);
			}
			if (MainForm.Settings.GetValue("VisualFX") != null)
			{
				this.button66.BackColor = Color.FromArgb(5, 88, 10);
			}
			if (MainForm.Settings.GetValue("GameBar") != null)
			{
				this.button62.BackColor = Color.FromArgb(5, 88, 10);
			}
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00003070 File Offset: 0x00001270
		private void DashboardButton_Click(object sender, EventArgs e)
		{
			this.TweaksButton.ForeColor = Color.FromArgb(64, 64, 64);
			this.InstallersButton.ForeColor = Color.FromArgb(64, 64, 64);
			this.ProgramsButton.ForeColor = Color.FromArgb(64, 64, 64);
			this.BenchmarksButton.ForeColor = Color.FromArgb(64, 64, 64);
			this.GamesButton.ForeColor = Color.FromArgb(64, 64, 64);
			this.DashboardButton.ForeColor = Color.FromArgb(255, 251, 252);
			this.DashboardButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold | FontStyle.Underline);
			this.TweaksButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold);
			this.InstallersButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold);
			this.ProgramsButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold);
			this.BenchmarksButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold);
			this.GamesButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold);
			this.DashboardPanel.Visible = true;
			this.TweaksPanel.Visible = false;
			this.InstallersPanel.Visible = false;
			this.ProgramsPanel.Visible = false;
			this.BenchmarksPanel.Visible = false;
			this.GamesPanel.Visible = false;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000031F4 File Offset: 0x000013F4
		private void TweaksButton_Click(object sender, EventArgs e)
		{
			this.DashboardButton.ForeColor = Color.FromArgb(64, 64, 64);
			this.InstallersButton.ForeColor = Color.FromArgb(64, 64, 64);
			this.ProgramsButton.ForeColor = Color.FromArgb(64, 64, 64);
			this.BenchmarksButton.ForeColor = Color.FromArgb(64, 64, 64);
			this.GamesButton.ForeColor = Color.FromArgb(64, 64, 64);
			this.TweaksButton.ForeColor = Color.FromArgb(255, 251, 252);
			this.TweaksButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold | FontStyle.Underline);
			this.DashboardButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold);
			this.InstallersButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold);
			this.ProgramsButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold);
			this.BenchmarksButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold);
			this.GamesButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold);
			this.DashboardPanel.Visible = false;
			this.TweaksPanel.Visible = true;
			this.InstallersPanel.Visible = false;
			this.ProgramsPanel.Visible = false;
			this.BenchmarksPanel.Visible = false;
			this.GamesPanel.Visible = false;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00003378 File Offset: 0x00001578
		private void InstallersButton_Click(object sender, EventArgs e)
		{
			this.DashboardButton.ForeColor = Color.FromArgb(64, 64, 64);
			this.TweaksButton.ForeColor = Color.FromArgb(64, 64, 64);
			this.ProgramsButton.ForeColor = Color.FromArgb(64, 64, 64);
			this.BenchmarksButton.ForeColor = Color.FromArgb(64, 64, 64);
			this.GamesButton.ForeColor = Color.FromArgb(64, 64, 64);
			this.InstallersButton.ForeColor = Color.FromArgb(255, 251, 252);
			this.InstallersButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold | FontStyle.Underline);
			this.DashboardButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold);
			this.TweaksButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold);
			this.ProgramsButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold);
			this.BenchmarksButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold);
			this.GamesButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold);
			this.DashboardPanel.Visible = false;
			this.TweaksPanel.Visible = false;
			this.InstallersPanel.Visible = true;
			this.ProgramsPanel.Visible = false;
			this.BenchmarksPanel.Visible = false;
			this.GamesPanel.Visible = false;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000034FC File Offset: 0x000016FC
		private void ProgramsButton_Click(object sender, EventArgs e)
		{
			this.DashboardButton.ForeColor = Color.FromArgb(64, 64, 64);
			this.TweaksButton.ForeColor = Color.FromArgb(64, 64, 64);
			this.InstallersButton.ForeColor = Color.FromArgb(64, 64, 64);
			this.BenchmarksButton.ForeColor = Color.FromArgb(64, 64, 64);
			this.GamesButton.ForeColor = Color.FromArgb(64, 64, 64);
			this.ProgramsButton.ForeColor = Color.FromArgb(255, 251, 252);
			this.ProgramsButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold | FontStyle.Underline);
			this.DashboardButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold);
			this.TweaksButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold);
			this.InstallersButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold);
			this.BenchmarksButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold);
			this.GamesButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold);
			this.DashboardPanel.Visible = false;
			this.TweaksPanel.Visible = false;
			this.InstallersPanel.Visible = false;
			this.ProgramsPanel.Visible = true;
			this.BenchmarksPanel.Visible = false;
			this.GamesPanel.Visible = false;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00003680 File Offset: 0x00001880
		private void BenchmarksButton_Click(object sender, EventArgs e)
		{
			this.DashboardButton.ForeColor = Color.FromArgb(64, 64, 64);
			this.TweaksButton.ForeColor = Color.FromArgb(64, 64, 64);
			this.InstallersButton.ForeColor = Color.FromArgb(64, 64, 64);
			this.ProgramsButton.ForeColor = Color.FromArgb(64, 64, 64);
			this.GamesButton.ForeColor = Color.FromArgb(64, 64, 64);
			this.BenchmarksButton.ForeColor = Color.FromArgb(255, 251, 252);
			this.BenchmarksButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold | FontStyle.Underline);
			this.DashboardButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold);
			this.TweaksButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold);
			this.InstallersButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold);
			this.ProgramsButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold);
			this.GamesButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold);
			this.DashboardPanel.Visible = false;
			this.TweaksPanel.Visible = false;
			this.InstallersPanel.Visible = false;
			this.ProgramsPanel.Visible = false;
			this.BenchmarksPanel.Visible = true;
			this.GamesPanel.Visible = false;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00003804 File Offset: 0x00001A04
		private void GamesButton_Click(object sender, EventArgs e)
		{
			this.DashboardButton.ForeColor = Color.FromArgb(64, 64, 64);
			this.TweaksButton.ForeColor = Color.FromArgb(64, 64, 64);
			this.InstallersButton.ForeColor = Color.FromArgb(64, 64, 64);
			this.ProgramsButton.ForeColor = Color.FromArgb(64, 64, 64);
			this.BenchmarksButton.ForeColor = Color.FromArgb(64, 64, 64);
			this.GamesButton.ForeColor = Color.FromArgb(255, 251, 252);
			this.GamesButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold | FontStyle.Underline);
			this.DashboardButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold);
			this.TweaksButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold);
			this.InstallersButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold);
			this.ProgramsButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold);
			this.BenchmarksButton.Font = new Font("Calibri", 9.75f, FontStyle.Bold);
			this.DashboardPanel.Visible = false;
			this.TweaksPanel.Visible = false;
			this.InstallersPanel.Visible = false;
			this.ProgramsPanel.Visible = false;
			this.BenchmarksPanel.Visible = false;
			this.GamesPanel.Visible = true;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00003988 File Offset: 0x00001B88
		private void ButtonMinimize_MouseEnter(object sender, EventArgs e)
		{
			this.ButtonMinimize.BackColor = Color.FromArgb(190, 190, 190);
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000039A9 File Offset: 0x00001BA9
		private void ButtonMinimize_MouseLeave(object sender, EventArgs e)
		{
			this.ButtonMinimize.BackColor = Color.FromArgb(4, 8, 12);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000039BF File Offset: 0x00001BBF
		private void MainForm_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				WinAPI.ReleaseCapture();
				WinAPI.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000039BF File Offset: 0x00001BBF
		private void Status_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				WinAPI.ReleaseCapture();
				WinAPI.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000039E9 File Offset: 0x00001BE9
		private void ButtonClose_MouseEnter(object sender, EventArgs e)
		{
			this.ButtonClose.BackColor = Color.FromArgb(190, 190, 190);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00003A0A File Offset: 0x00001C0A
		private void ButtonClose_MouseLeave(object sender, EventArgs e)
		{
			this.ButtonClose.BackColor = Color.FromArgb(4, 8, 12);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00003A20 File Offset: 0x00001C20
		private void ButtonClose_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00003A27 File Offset: 0x00001C27
		private void ButtonMinimize_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00003A30 File Offset: 0x00001C30
		private void button8_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new OCCT());
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00003A30 File Offset: 0x00001C30
		private void button9_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new OCCT());
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00003A3D File Offset: 0x00001C3D
		private void button10_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new CPUZ());
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00003A4A File Offset: 0x00001C4A
		private void button11_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new HWiNFO());
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00003A57 File Offset: 0x00001C57
		private void button12_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new AIDA64());
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00003A64 File Offset: 0x00001C64
		private void button13_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new GPUZ());
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00003A71 File Offset: 0x00001C71
		private void button14_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Afterburner());
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00003A7E File Offset: 0x00001C7E
		private void button16_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Linpack());
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00003A8B File Offset: 0x00001C8B
		private void button17_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Prime95());
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00003A98 File Offset: 0x00001C98
		private void button38_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Firestarter());
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00003AA5 File Offset: 0x00001CA5
		private void button37_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new LinX());
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00003AB2 File Offset: 0x00001CB2
		private void button18_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Taiphoon());
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00003AC0 File Offset: 0x00001CC0
		private void button19_Click(object sender, EventArgs e)
		{
			if (Utils.SystemInformation.SocketDesignation.ToString() != null)
			{
				if (Utils.SystemInformation.SocketDesignation.Contains("LGA1200"))
				{
					this.ExecuteDirect(new Asrock1200());
					return;
				}
				if (Utils.SystemInformation.SocketDesignation.Contains("AM4"))
				{
					this.ExecuteDirect(new ZenTimings());
					return;
				}
				this.ExecuteDirect(new Asrock());
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00003B21 File Offset: 0x00001D21
		private void button20_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new TurboV());
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00003B2E File Offset: 0x00001D2E
		private void button21_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new TM5());
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00003B3B File Offset: 0x00001D3B
		private void button22_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new LinpackExtended());
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00003B48 File Offset: 0x00001D48
		private void button23_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new TM5Arshia());
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00003B55 File Offset: 0x00001D55
		private void button15_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new DeviceManager());
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00003B62 File Offset: 0x00001D62
		private void button24_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new NetworkSettings());
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00003B6F File Offset: 0x00001D6F
		private void button25_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new PowerSettings());
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00003B7C File Offset: 0x00001D7C
		private void button26_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new StartupFolder());
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00003B89 File Offset: 0x00001D89
		private void button27_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Everything());
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00003B96 File Offset: 0x00001D96
		private void button29_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new ProcessLasso());
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00003BA3 File Offset: 0x00001DA3
		private void button28_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new ProcessMonitor());
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00003BB0 File Offset: 0x00001DB0
		private void button30_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new ProcessExplorer());
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00003BBD File Offset: 0x00001DBD
		private void button31_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new ProcessHacker());
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00003BCA File Offset: 0x00001DCA
		private void button32_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new VirusTotal());
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00003BD7 File Offset: 0x00001DD7
		private void button33_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new NSudo());
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00003BE4 File Offset: 0x00001DE4
		private void button34_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Autoruns());
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00003BF1 File Offset: 0x00001DF1
		private void button35_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new RegistryWorkshop());
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00003BFE File Offset: 0x00001DFE
		private void button36_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new ServiWin());
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00003C0B File Offset: 0x00001E0B
		private void button40_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Services());
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00003C18 File Offset: 0x00001E18
		private void button41_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Drivers());
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00003C25 File Offset: 0x00001E25
		private void button42_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new CustomServices());
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00003C32 File Offset: 0x00001E32
		private void button48_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new ResetServices());
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00003C3F File Offset: 0x00001E3F
		private void button44_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Troubleshoot());
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00003C4C File Offset: 0x00001E4C
		private void button45_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new MSITool());
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00003C59 File Offset: 0x00001E59
		private void button46_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new InterruptAffinity());
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00003C66 File Offset: 0x00001E66
		private void button47_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new PCIUtil());
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00003C73 File Offset: 0x00001E73
		private void button43_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new EasyGRUB());
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00003C80 File Offset: 0x00001E80
		private void button7_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new ClearTemp());
			MainForm._entries.Clear();
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00003C97 File Offset: 0x00001E97
		private void button49_Click(object sender, EventArgs e)
		{
			if (Utils.SystemInformation.GPUName.ToString() != null)
			{
				if (Utils.SystemInformation.GPUName.Contains("AMD"))
				{
					this.ExecuteDirect(new GPUAMD());
					return;
				}
				this.ExecuteDirect(new GPUNVIDIA());
			}
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00003CD0 File Offset: 0x00001ED0
		private void button50_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new ResetGPU());
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00003CDD File Offset: 0x00001EDD
		private void button51_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new RestartGraphics());
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00003CEA File Offset: 0x00001EEA
		private void button52_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new CRU());
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00003CF7 File Offset: 0x00001EF7
		private void button53_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new CRURestart());
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00003D04 File Offset: 0x00001F04
		private void button54_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new CRUReset());
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00003D11 File Offset: 0x00001F11
		private void button57_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Powerplan());
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00003D1E File Offset: 0x00001F1E
		private void button55_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new DefaultPrograms());
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00003D2B File Offset: 0x00001F2B
		private void button60_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Edge());
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00003D38 File Offset: 0x00001F38
		private void button61_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new OneDrive());
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00003D45 File Offset: 0x00001F45
		private void button59_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Basics());
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00003D52 File Offset: 0x00001F52
		private void button58_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new ToggleDefender());
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00003D5F File Offset: 0x00001F5F
		private void button62_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new ToggleXbox());
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00003D6C File Offset: 0x00001F6C
		private void button63_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new ToggleFullscreen());
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00003D79 File Offset: 0x00001F79
		private void button65_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new ToggleAudioSvchost());
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00003D86 File Offset: 0x00001F86
		private void button66_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new ToggleVisualFX());
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00003D93 File Offset: 0x00001F93
		private void button56_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new ToggleDEP());
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00003DA0 File Offset: 0x00001FA0
		private void button64_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new ToggleAutotuning());
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00003DAD File Offset: 0x00001FAD
		private void button39_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new ToggleTaskmgr());
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00003DBA File Offset: 0x00001FBA
		private void button8_Click_1(object sender, EventArgs e)
		{
			if (MessageBox.Show("This is for really advanced users, few stuff like capture cards and other uncommon devices might not work!", "Disclaimer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
			{
				this.ExecuteDirect(new ToggleBareDrivers());
			}
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00003DDE File Offset: 0x00001FDE
		private void button70_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new DirectX());
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00003DEB File Offset: 0x00001FEB
		private void button71_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new VCRedist());
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00003DF8 File Offset: 0x00001FF8
		private void button72_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new NET35());
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00003E05 File Offset: 0x00002005
		private void button73_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new NET50());
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00003E12 File Offset: 0x00002012
		private void button74_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new KMS());
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00003E1F File Offset: 0x0000201F
		private void button75_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new StartIsBack());
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00003E2C File Offset: 0x0000202C
		private void button76_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new OpenShell());
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00003E39 File Offset: 0x00002039
		private void button77_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Unlocker());
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00003E46 File Offset: 0x00002046
		private void button67_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Cleanmgr());
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00003E53 File Offset: 0x00002053
		private void button78_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new VisualStudio());
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00003E60 File Offset: 0x00002060
		private void button79_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new SDIO());
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00003E6D File Offset: 0x0000206D
		private void button84_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new NvCleanstall());
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00003E7A File Offset: 0x0000207A
		private void button80_Click(object sender, EventArgs e)
		{
			if (Utils.SystemInformation.GPUName.ToString() != null)
			{
				if (Utils.SystemInformation.GPUName.Contains("NVIDIA"))
				{
					this.ExecuteDirect(new DriverNVIDIA());
					return;
				}
				this.ExecuteDirect(new DriverAMD());
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00003EB3 File Offset: 0x000020B3
		private void button83_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Geek());
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00003EC0 File Offset: 0x000020C0
		private void button85_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Rufus());
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00003ECD File Offset: 0x000020CD
		private void button86_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Ventoy());
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00003EDA File Offset: 0x000020DA
		private void button81_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new OBS());
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00003EE7 File Offset: 0x000020E7
		private void button82_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Streamlabs());
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00003EF4 File Offset: 0x000020F4
		private void button87_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Medal());
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00003F01 File Offset: 0x00002101
		private void button69_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new DDU());
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00003F0E File Offset: 0x0000210E
		private void button88_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new SevenZip());
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00003F1B File Offset: 0x0000211B
		private void button89_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Notepad());
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00003F28 File Offset: 0x00002128
		private void button90_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Google());
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00003F35 File Offset: 0x00002135
		private void button91_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Firefox());
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00003F42 File Offset: 0x00002142
		private void button92_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Discord());
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00003F4F File Offset: 0x0000214F
		private void button93_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Teamspeak());
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00003F5C File Offset: 0x0000215C
		private void button94_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new qBitTorrent());
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00003F69 File Offset: 0x00002169
		private void button95_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new VLC());
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00003F76 File Offset: 0x00002176
		private void button96_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Stremio());
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00003F83 File Offset: 0x00002183
		private void button68_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Freezer());
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00003F90 File Offset: 0x00002190
		private void button101_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new OCAT());
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00003F9D File Offset: 0x0000219D
		private void button102_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new PresentMon());
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00003FAA File Offset: 0x000021AA
		private void button100_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new CapframeX());
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00003FB7 File Offset: 0x000021B7
		private void button103_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new PMT());
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00003FC4 File Offset: 0x000021C4
		private void button104_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new FrameView());
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00003FD1 File Offset: 0x000021D1
		private void button110_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Liblavalava());
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00003FDE File Offset: 0x000021DE
		private void button109_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Liblavatriangle());
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00003FEB File Offset: 0x000021EB
		private void button111_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new GFXTest());
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00003FF8 File Offset: 0x000021F8
		private void button105_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new WPA());
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00004005 File Offset: 0x00002205
		private void button106_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new xperf());
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00004012 File Offset: 0x00002212
		private void button107_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new hrping());
		}

		// Token: 0x06000084 RID: 132 RVA: 0x0000401F File Offset: 0x0000221F
		private void button112_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new iperf());
		}

		// Token: 0x06000085 RID: 133 RVA: 0x0000402C File Offset: 0x0000222C
		private void button98_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new trianglebin());
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00004039 File Offset: 0x00002239
		private void button113_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new IntelVTune());
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00004046 File Offset: 0x00002246
		private void button114_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new FrogPursuit());
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00004053 File Offset: 0x00002253
		private void button115_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new TestUFO());
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00004060 File Offset: 0x00002260
		private void button116_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new LatencyMon());
		}

		// Token: 0x0600008A RID: 138 RVA: 0x0000406D File Offset: 0x0000226D
		private void button117_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new MouseTester());
		}

		// Token: 0x0600008B RID: 139 RVA: 0x0000407A File Offset: 0x0000227A
		private void button108_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Cinebench());
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00004087 File Offset: 0x00002287
		private void button118_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new UserBenchmark());
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00004094 File Offset: 0x00002294
		private void button119_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new FurMark());
		}

		// Token: 0x0600008E RID: 142 RVA: 0x000040A1 File Offset: 0x000022A1
		private void button120_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Superposition());
		}

		// Token: 0x0600008F RID: 143 RVA: 0x000040AE File Offset: 0x000022AE
		private void button121_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new CrystalDisk());
		}

		// Token: 0x06000090 RID: 144 RVA: 0x000040BB File Offset: 0x000022BB
		private void button122_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new DNSBenchmark());
		}

		// Token: 0x06000091 RID: 145 RVA: 0x000040C8 File Offset: 0x000022C8
		private void button123_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new RivaTuner());
		}

		// Token: 0x06000092 RID: 146 RVA: 0x000040D5 File Offset: 0x000022D5
		private void button160_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Steam());
		}

		// Token: 0x06000093 RID: 147 RVA: 0x000040E2 File Offset: 0x000022E2
		private void button161_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Origin());
		}

		// Token: 0x06000094 RID: 148 RVA: 0x000040EF File Offset: 0x000022EF
		private void button162_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new EpicGames());
		}

		// Token: 0x06000095 RID: 149 RVA: 0x000040FC File Offset: 0x000022FC
		private void button163_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Battlenet());
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00004109 File Offset: 0x00002309
		private void button164_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Valorant());
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00004116 File Offset: 0x00002316
		private void button165_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Legendary());
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00004123 File Offset: 0x00002323
		private void button169_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new QLUnlockFPS());
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00004130 File Offset: 0x00002330
		private void button171_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new QLConfig());
		}

		// Token: 0x0600009A RID: 154 RVA: 0x0000413D File Offset: 0x0000233D
		private void button170_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new ApexConfig());
		}

		// Token: 0x0600009B RID: 155 RVA: 0x0000414A File Offset: 0x0000234A
		private void button125_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new MLCw5());
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00004157 File Offset: 0x00002357
		private void button126_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new MLCadam());
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00004164 File Offset: 0x00002364
		private void button99_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new MLC());
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00004171 File Offset: 0x00002371
		private void button156_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new LosslessCut());
		}

		// Token: 0x0600009F RID: 159 RVA: 0x0000417E File Offset: 0x0000237E
		private void button149_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new SPPT());
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0000418B File Offset: 0x0000238B
		private void button148_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new MorePowerTool());
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00004198 File Offset: 0x00002398
		private void button150_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new OverdriveNTool());
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x000041A5 File Offset: 0x000023A5
		private void button151_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new RadeonMod());
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x000041B2 File Offset: 0x000023B2
		private void button152_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new NvidiaInspector());
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x000041BF File Offset: 0x000023BF
		private void button153_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new InSpectre());
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x000041CC File Offset: 0x000023CC
		private void button154_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new AdwCleaner());
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x000041D9 File Offset: 0x000023D9
		private void button155_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Blurbusters());
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x000041E6 File Offset: 0x000023E6
		private void button139_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new FSETester());
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x000041F3 File Offset: 0x000023F3
		private void button140_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Win32PS());
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00004200 File Offset: 0x00002400
		private void button141_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new VRTTester());
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000420D File Offset: 0x0000240D
		private void button130_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new DeviceCleanUp());
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0000421A File Offset: 0x0000241A
		private void button131_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new DeviceRemover());
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00004227 File Offset: 0x00002427
		private void button132_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new DevManView());
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00004234 File Offset: 0x00002434
		private void button133_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new UsbTreeView());
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00004241 File Offset: 0x00002441
		private void button134_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new RW());
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000424E File Offset: 0x0000244E
		private void button135_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new ThermSpyGPU());
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x0000425B File Offset: 0x0000245B
		private void button136_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new AntiMicro());
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00004268 File Offset: 0x00002468
		private void button137_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Keys2xInput());
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00004275 File Offset: 0x00002475
		private void button138_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new Wooting());
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00004282 File Offset: 0x00002482
		private void button127_Click(object sender, EventArgs e)
		{
			this.ExecuteDirect(new hidusbf());
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000428F File Offset: 0x0000248F
		private void DashboardButton_GotFocus(object sender, EventArgs e)
		{
			this.DashboardButton.NotifyDefault(false);
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x0000429D File Offset: 0x0000249D
		private void TweaksButton_GotFocus(object sender, EventArgs e)
		{
			this.TweaksButton.NotifyDefault(false);
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x000042AB File Offset: 0x000024AB
		private void InstallersButton_GotFocus(object sender, EventArgs e)
		{
			this.InstallersButton.NotifyDefault(false);
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x000042B9 File Offset: 0x000024B9
		private void ProgramsButton_GotFocus(object sender, EventArgs e)
		{
			this.ProgramsButton.NotifyDefault(false);
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x000042C7 File Offset: 0x000024C7
		private void BenchmarksButton_GotFocus(object sender, EventArgs e)
		{
			this.BenchmarksButton.NotifyDefault(false);
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x000042D5 File Offset: 0x000024D5
		private void GamesButton_GotFocus(object sender, EventArgs e)
		{
			this.GamesButton.NotifyDefault(false);
		}

		// Token: 0x060000BA RID: 186 RVA: 0x000042E3 File Offset: 0x000024E3
		private void button9_GotFocus(object sender, EventArgs e)
		{
			this.button9.NotifyDefault(false);
		}

		// Token: 0x060000BB RID: 187 RVA: 0x000042F1 File Offset: 0x000024F1
		private void button10_GotFocus(object sender, EventArgs e)
		{
			this.button10.NotifyDefault(false);
		}

		// Token: 0x060000BC RID: 188 RVA: 0x000042FF File Offset: 0x000024FF
		private void button11_GotFocus(object sender, EventArgs e)
		{
			this.button11.NotifyDefault(false);
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0000430D File Offset: 0x0000250D
		private void button12_GotFocus(object sender, EventArgs e)
		{
			this.button12.NotifyDefault(false);
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000431B File Offset: 0x0000251B
		private void button13_GotFocus(object sender, EventArgs e)
		{
			this.button13.NotifyDefault(false);
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00004329 File Offset: 0x00002529
		private void button14_GotFocus(object sender, EventArgs e)
		{
			this.button14.NotifyDefault(false);
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00004337 File Offset: 0x00002537
		private void button15_GotFocus(object sender, EventArgs e)
		{
			this.button15.NotifyDefault(false);
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00004345 File Offset: 0x00002545
		private void button16_GotFocus(object sender, EventArgs e)
		{
			this.button16.NotifyDefault(false);
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00004353 File Offset: 0x00002553
		private void button17_GotFocus(object sender, EventArgs e)
		{
			this.button17.NotifyDefault(false);
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00004361 File Offset: 0x00002561
		private void button18_GotFocus(object sender, EventArgs e)
		{
			this.button18.NotifyDefault(false);
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000436F File Offset: 0x0000256F
		private void button19_GotFocus(object sender, EventArgs e)
		{
			this.button19.NotifyDefault(false);
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x0000437D File Offset: 0x0000257D
		private void button20_GotFocus(object sender, EventArgs e)
		{
			this.button20.NotifyDefault(false);
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000438B File Offset: 0x0000258B
		private void button21_GotFocus(object sender, EventArgs e)
		{
			this.button21.NotifyDefault(false);
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00004399 File Offset: 0x00002599
		private void button22_GotFocus(object sender, EventArgs e)
		{
			this.button22.NotifyDefault(false);
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x000043A7 File Offset: 0x000025A7
		private void button23_GotFocus(object sender, EventArgs e)
		{
			this.button23.NotifyDefault(false);
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x000043B5 File Offset: 0x000025B5
		private void button24_GotFocus(object sender, EventArgs e)
		{
			this.button24.NotifyDefault(false);
		}

		// Token: 0x060000CA RID: 202 RVA: 0x000043C3 File Offset: 0x000025C3
		private void button25_GotFocus(object sender, EventArgs e)
		{
			this.button25.NotifyDefault(false);
		}

		// Token: 0x060000CB RID: 203 RVA: 0x000043D1 File Offset: 0x000025D1
		private void button26_GotFocus(object sender, EventArgs e)
		{
			this.button26.NotifyDefault(false);
		}

		// Token: 0x060000CC RID: 204 RVA: 0x000043DF File Offset: 0x000025DF
		private void button27_GotFocus(object sender, EventArgs e)
		{
			this.button27.NotifyDefault(false);
		}

		// Token: 0x060000CD RID: 205 RVA: 0x000043ED File Offset: 0x000025ED
		private void button28_GotFocus(object sender, EventArgs e)
		{
			this.button28.NotifyDefault(false);
		}

		// Token: 0x060000CE RID: 206 RVA: 0x000043FB File Offset: 0x000025FB
		private void button29_GotFocus(object sender, EventArgs e)
		{
			this.button29.NotifyDefault(false);
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00004409 File Offset: 0x00002609
		private void button30_GotFocus(object sender, EventArgs e)
		{
			this.button30.NotifyDefault(false);
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00004417 File Offset: 0x00002617
		private void button31_GotFocus(object sender, EventArgs e)
		{
			this.button31.NotifyDefault(false);
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00004425 File Offset: 0x00002625
		private void button32_GotFocus(object sender, EventArgs e)
		{
			this.button32.NotifyDefault(false);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00004433 File Offset: 0x00002633
		private void button33_GotFocus(object sender, EventArgs e)
		{
			this.button33.NotifyDefault(false);
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00004441 File Offset: 0x00002641
		private void button34_GotFocus(object sender, EventArgs e)
		{
			this.button34.NotifyDefault(false);
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x0000444F File Offset: 0x0000264F
		private void button35_GotFocus(object sender, EventArgs e)
		{
			this.button35.NotifyDefault(false);
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0000445D File Offset: 0x0000265D
		private void button36_GotFocus(object sender, EventArgs e)
		{
			this.button36.NotifyDefault(false);
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0000446B File Offset: 0x0000266B
		private void button37_GotFocus(object sender, EventArgs e)
		{
			this.button37.NotifyDefault(false);
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00004479 File Offset: 0x00002679
		private void button38_GotFocus(object sender, EventArgs e)
		{
			this.button38.NotifyDefault(false);
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00004487 File Offset: 0x00002687
		private void button39_GotFocus(object sender, EventArgs e)
		{
			this.button39.NotifyDefault(false);
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00004495 File Offset: 0x00002695
		private void button40_GotFocus(object sender, EventArgs e)
		{
			this.button40.NotifyDefault(false);
		}

		// Token: 0x060000DA RID: 218 RVA: 0x000044A3 File Offset: 0x000026A3
		private void button41_GotFocus(object sender, EventArgs e)
		{
			this.button41.NotifyDefault(false);
		}

		// Token: 0x060000DB RID: 219 RVA: 0x000044B1 File Offset: 0x000026B1
		private void button42_GotFocus(object sender, EventArgs e)
		{
			this.button42.NotifyDefault(false);
		}

		// Token: 0x060000DC RID: 220 RVA: 0x000044BF File Offset: 0x000026BF
		private void button43_GotFocus(object sender, EventArgs e)
		{
			this.button43.NotifyDefault(false);
		}

		// Token: 0x060000DD RID: 221 RVA: 0x000044CD File Offset: 0x000026CD
		private void button44_GotFocus(object sender, EventArgs e)
		{
			this.button44.NotifyDefault(false);
		}

		// Token: 0x060000DE RID: 222 RVA: 0x000044DB File Offset: 0x000026DB
		private void button45_GotFocus(object sender, EventArgs e)
		{
			this.button45.NotifyDefault(false);
		}

		// Token: 0x060000DF RID: 223 RVA: 0x000044E9 File Offset: 0x000026E9
		private void button46_GotFocus(object sender, EventArgs e)
		{
			this.button46.NotifyDefault(false);
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x000044F7 File Offset: 0x000026F7
		private void button47_GotFocus(object sender, EventArgs e)
		{
			this.button47.NotifyDefault(false);
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00004505 File Offset: 0x00002705
		private void button48_GotFocus(object sender, EventArgs e)
		{
			this.button48.NotifyDefault(false);
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00004513 File Offset: 0x00002713
		private void button49_GotFocus(object sender, EventArgs e)
		{
			this.button49.NotifyDefault(false);
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00004521 File Offset: 0x00002721
		private void button50_GotFocus(object sender, EventArgs e)
		{
			this.button50.NotifyDefault(false);
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x0000452F File Offset: 0x0000272F
		private void button51_GotFocus(object sender, EventArgs e)
		{
			this.button51.NotifyDefault(false);
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x0000453D File Offset: 0x0000273D
		private void button52_GotFocus(object sender, EventArgs e)
		{
			this.button52.NotifyDefault(false);
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x0000454B File Offset: 0x0000274B
		private void button53_GotFocus(object sender, EventArgs e)
		{
			this.button53.NotifyDefault(false);
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00004559 File Offset: 0x00002759
		private void button54_GotFocus(object sender, EventArgs e)
		{
			this.button54.NotifyDefault(false);
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00004567 File Offset: 0x00002767
		private void button55_GotFocus(object sender, EventArgs e)
		{
			this.button55.NotifyDefault(false);
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00004575 File Offset: 0x00002775
		private void button56_GotFocus(object sender, EventArgs e)
		{
			this.button56.NotifyDefault(false);
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00004583 File Offset: 0x00002783
		private void button57_GotFocus(object sender, EventArgs e)
		{
			this.button57.NotifyDefault(false);
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00004591 File Offset: 0x00002791
		private void button58_GotFocus(object sender, EventArgs e)
		{
			this.button58.NotifyDefault(false);
		}

		// Token: 0x060000EC RID: 236 RVA: 0x0000459F File Offset: 0x0000279F
		private void button59_GotFocus(object sender, EventArgs e)
		{
			this.button59.NotifyDefault(false);
		}

		// Token: 0x060000ED RID: 237 RVA: 0x000045AD File Offset: 0x000027AD
		private void button60_GotFocus(object sender, EventArgs e)
		{
			this.button60.NotifyDefault(false);
		}

		// Token: 0x060000EE RID: 238 RVA: 0x000045BB File Offset: 0x000027BB
		private void button61_GotFocus(object sender, EventArgs e)
		{
			this.button61.NotifyDefault(false);
		}

		// Token: 0x060000EF RID: 239 RVA: 0x000045C9 File Offset: 0x000027C9
		private void button62_GotFocus(object sender, EventArgs e)
		{
			this.button62.NotifyDefault(false);
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x000045D7 File Offset: 0x000027D7
		private void button63_GotFocus(object sender, EventArgs e)
		{
			this.button63.NotifyDefault(false);
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x000045E5 File Offset: 0x000027E5
		private void button64_GotFocus(object sender, EventArgs e)
		{
			this.button64.NotifyDefault(false);
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x000045F3 File Offset: 0x000027F3
		private void button65_GotFocus(object sender, EventArgs e)
		{
			this.button65.NotifyDefault(false);
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00004601 File Offset: 0x00002801
		private void button66_GotFocus(object sender, EventArgs e)
		{
			this.button66.NotifyDefault(false);
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x0000460F File Offset: 0x0000280F
		private void button67_GotFocus(object sender, EventArgs e)
		{
			this.button67.NotifyDefault(false);
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x0000461D File Offset: 0x0000281D
		private void button68_GotFocus(object sender, EventArgs e)
		{
			this.button68.NotifyDefault(false);
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x0000462B File Offset: 0x0000282B
		private void button69_GotFocus(object sender, EventArgs e)
		{
			this.button69.NotifyDefault(false);
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00004639 File Offset: 0x00002839
		private void button70_GotFocus(object sender, EventArgs e)
		{
			this.button70.NotifyDefault(false);
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00004647 File Offset: 0x00002847
		private void button71_GotFocus(object sender, EventArgs e)
		{
			this.button71.NotifyDefault(false);
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00004655 File Offset: 0x00002855
		private void button72_GotFocus(object sender, EventArgs e)
		{
			this.button72.NotifyDefault(false);
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00004663 File Offset: 0x00002863
		private void button73_GotFocus(object sender, EventArgs e)
		{
			this.button73.NotifyDefault(false);
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00004671 File Offset: 0x00002871
		private void button74_GotFocus(object sender, EventArgs e)
		{
			this.button74.NotifyDefault(false);
		}

		// Token: 0x060000FC RID: 252 RVA: 0x0000467F File Offset: 0x0000287F
		private void button75_GotFocus(object sender, EventArgs e)
		{
			this.button75.NotifyDefault(false);
		}

		// Token: 0x060000FD RID: 253 RVA: 0x0000468D File Offset: 0x0000288D
		private void button76_GotFocus(object sender, EventArgs e)
		{
			this.button76.NotifyDefault(false);
		}

		// Token: 0x060000FE RID: 254 RVA: 0x0000469B File Offset: 0x0000289B
		private void button77_GotFocus(object sender, EventArgs e)
		{
			this.button77.NotifyDefault(false);
		}

		// Token: 0x060000FF RID: 255 RVA: 0x000046A9 File Offset: 0x000028A9
		private void button78_GotFocus(object sender, EventArgs e)
		{
			this.button78.NotifyDefault(false);
		}

		// Token: 0x06000100 RID: 256 RVA: 0x000046B7 File Offset: 0x000028B7
		private void button79_GotFocus(object sender, EventArgs e)
		{
			this.button79.NotifyDefault(false);
		}

		// Token: 0x06000101 RID: 257 RVA: 0x000046C5 File Offset: 0x000028C5
		private void button80_GotFocus(object sender, EventArgs e)
		{
			this.button80.NotifyDefault(false);
		}

		// Token: 0x06000102 RID: 258 RVA: 0x000046D3 File Offset: 0x000028D3
		private void button81_GotFocus(object sender, EventArgs e)
		{
			this.button81.NotifyDefault(false);
		}

		// Token: 0x06000103 RID: 259 RVA: 0x000046E1 File Offset: 0x000028E1
		private void button82_GotFocus(object sender, EventArgs e)
		{
			this.button82.NotifyDefault(false);
		}

		// Token: 0x06000104 RID: 260 RVA: 0x000046EF File Offset: 0x000028EF
		private void button83_GotFocus(object sender, EventArgs e)
		{
			this.button83.NotifyDefault(false);
		}

		// Token: 0x06000105 RID: 261 RVA: 0x000046FD File Offset: 0x000028FD
		private void button84_GotFocus(object sender, EventArgs e)
		{
			this.button84.NotifyDefault(false);
		}

		// Token: 0x06000106 RID: 262 RVA: 0x0000470B File Offset: 0x0000290B
		private void button85_GotFocus(object sender, EventArgs e)
		{
			this.button85.NotifyDefault(false);
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00004719 File Offset: 0x00002919
		private void button86_GotFocus(object sender, EventArgs e)
		{
			this.button86.NotifyDefault(false);
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00004727 File Offset: 0x00002927
		private void button87_GotFocus(object sender, EventArgs e)
		{
			this.button87.NotifyDefault(false);
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00004735 File Offset: 0x00002935
		private void button88_GotFocus(object sender, EventArgs e)
		{
			this.button88.NotifyDefault(false);
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00004743 File Offset: 0x00002943
		private void button89_GotFocus(object sender, EventArgs e)
		{
			this.button89.NotifyDefault(false);
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00004751 File Offset: 0x00002951
		private void button90_GotFocus(object sender, EventArgs e)
		{
			this.button90.NotifyDefault(false);
		}

		// Token: 0x0600010C RID: 268 RVA: 0x0000475F File Offset: 0x0000295F
		private void button91_GotFocus(object sender, EventArgs e)
		{
			this.button91.NotifyDefault(false);
		}

		// Token: 0x0600010D RID: 269 RVA: 0x0000476D File Offset: 0x0000296D
		private void button92_GotFocus(object sender, EventArgs e)
		{
			this.button92.NotifyDefault(false);
		}

		// Token: 0x0600010E RID: 270 RVA: 0x0000477B File Offset: 0x0000297B
		private void button93_GotFocus(object sender, EventArgs e)
		{
			this.button93.NotifyDefault(false);
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00004789 File Offset: 0x00002989
		private void button94_GotFocus(object sender, EventArgs e)
		{
			this.button94.NotifyDefault(false);
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00004797 File Offset: 0x00002997
		private void button95_GotFocus(object sender, EventArgs e)
		{
			this.button95.NotifyDefault(false);
		}

		// Token: 0x06000111 RID: 273 RVA: 0x000047A5 File Offset: 0x000029A5
		private void button96_GotFocus(object sender, EventArgs e)
		{
			this.button96.NotifyDefault(false);
		}

		// Token: 0x06000112 RID: 274 RVA: 0x000047B3 File Offset: 0x000029B3
		private void button97_GotFocus(object sender, EventArgs e)
		{
			this.button97.NotifyDefault(false);
		}

		// Token: 0x06000113 RID: 275 RVA: 0x000047C1 File Offset: 0x000029C1
		private void button98_GotFocus(object sender, EventArgs e)
		{
			this.button98.NotifyDefault(false);
		}

		// Token: 0x06000114 RID: 276 RVA: 0x000047CF File Offset: 0x000029CF
		private void button99_GotFocus(object sender, EventArgs e)
		{
			this.button99.NotifyDefault(false);
		}

		// Token: 0x06000115 RID: 277 RVA: 0x000047DD File Offset: 0x000029DD
		private void button100_GotFocus(object sender, EventArgs e)
		{
			this.button100.NotifyDefault(false);
		}

		// Token: 0x06000116 RID: 278 RVA: 0x000047EB File Offset: 0x000029EB
		private void button101_GotFocus(object sender, EventArgs e)
		{
			this.button101.NotifyDefault(false);
		}

		// Token: 0x06000117 RID: 279 RVA: 0x000047F9 File Offset: 0x000029F9
		private void button102_GotFocus(object sender, EventArgs e)
		{
			this.button102.NotifyDefault(false);
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00004807 File Offset: 0x00002A07
		private void button103_GotFocus(object sender, EventArgs e)
		{
			this.button103.NotifyDefault(false);
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00004815 File Offset: 0x00002A15
		private void button104_GotFocus(object sender, EventArgs e)
		{
			this.button104.NotifyDefault(false);
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00004823 File Offset: 0x00002A23
		private void button105_GotFocus(object sender, EventArgs e)
		{
			this.button105.NotifyDefault(false);
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00004831 File Offset: 0x00002A31
		private void button106_GotFocus(object sender, EventArgs e)
		{
			this.button106.NotifyDefault(false);
		}

		// Token: 0x0600011C RID: 284 RVA: 0x0000483F File Offset: 0x00002A3F
		private void button107_GotFocus(object sender, EventArgs e)
		{
			this.button107.NotifyDefault(false);
		}

		// Token: 0x0600011D RID: 285 RVA: 0x0000484D File Offset: 0x00002A4D
		private void button108_GotFocus(object sender, EventArgs e)
		{
			this.button108.NotifyDefault(false);
		}

		// Token: 0x0600011E RID: 286 RVA: 0x0000485B File Offset: 0x00002A5B
		private void button109_GotFocus(object sender, EventArgs e)
		{
			this.button109.NotifyDefault(false);
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00004869 File Offset: 0x00002A69
		private void button110_GotFocus(object sender, EventArgs e)
		{
			this.button110.NotifyDefault(false);
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00004877 File Offset: 0x00002A77
		private void button111_GotFocus(object sender, EventArgs e)
		{
			this.button111.NotifyDefault(false);
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00004885 File Offset: 0x00002A85
		private void button112_GotFocus(object sender, EventArgs e)
		{
			this.button112.NotifyDefault(false);
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00004893 File Offset: 0x00002A93
		private void button113_GotFocus(object sender, EventArgs e)
		{
			this.button113.NotifyDefault(false);
		}

		// Token: 0x06000123 RID: 291 RVA: 0x000048A1 File Offset: 0x00002AA1
		private void button114_GotFocus(object sender, EventArgs e)
		{
			this.button114.NotifyDefault(false);
		}

		// Token: 0x06000124 RID: 292 RVA: 0x000048AF File Offset: 0x00002AAF
		private void button115_GotFocus(object sender, EventArgs e)
		{
			this.button115.NotifyDefault(false);
		}

		// Token: 0x06000125 RID: 293 RVA: 0x000048BD File Offset: 0x00002ABD
		private void button116_GotFocus(object sender, EventArgs e)
		{
			this.button116.NotifyDefault(false);
		}

		// Token: 0x06000126 RID: 294 RVA: 0x000048CB File Offset: 0x00002ACB
		private void button117_GotFocus(object sender, EventArgs e)
		{
			this.button117.NotifyDefault(false);
		}

		// Token: 0x06000127 RID: 295 RVA: 0x000048D9 File Offset: 0x00002AD9
		private void button118_GotFocus(object sender, EventArgs e)
		{
			this.button118.NotifyDefault(false);
		}

		// Token: 0x06000128 RID: 296 RVA: 0x000048E7 File Offset: 0x00002AE7
		private void button119_GotFocus(object sender, EventArgs e)
		{
			this.button119.NotifyDefault(false);
		}

		// Token: 0x06000129 RID: 297 RVA: 0x000048F5 File Offset: 0x00002AF5
		private void button120_GotFocus(object sender, EventArgs e)
		{
			this.button120.NotifyDefault(false);
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00004903 File Offset: 0x00002B03
		private void button121_GotFocus(object sender, EventArgs e)
		{
			this.button121.NotifyDefault(false);
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00004911 File Offset: 0x00002B11
		private void button122_GotFocus(object sender, EventArgs e)
		{
			this.button122.NotifyDefault(false);
		}

		// Token: 0x0600012C RID: 300 RVA: 0x0000491F File Offset: 0x00002B1F
		private void button123_GotFocus(object sender, EventArgs e)
		{
			this.button123.NotifyDefault(false);
		}

		// Token: 0x0600012D RID: 301 RVA: 0x0000492D File Offset: 0x00002B2D
		private void button124_GotFocus(object sender, EventArgs e)
		{
			this.button124.NotifyDefault(false);
		}

		// Token: 0x0600012E RID: 302 RVA: 0x0000493B File Offset: 0x00002B3B
		private void button125_GotFocus(object sender, EventArgs e)
		{
			this.button125.NotifyDefault(false);
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00004949 File Offset: 0x00002B49
		private void button126_GotFocus(object sender, EventArgs e)
		{
			this.button126.NotifyDefault(false);
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00004957 File Offset: 0x00002B57
		private void button127_GotFocus(object sender, EventArgs e)
		{
			this.button127.NotifyDefault(false);
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00004965 File Offset: 0x00002B65
		private void button128_GotFocus(object sender, EventArgs e)
		{
			this.button128.NotifyDefault(false);
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00004973 File Offset: 0x00002B73
		private void button129_GotFocus(object sender, EventArgs e)
		{
			this.button129.NotifyDefault(false);
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00004981 File Offset: 0x00002B81
		private void button130_GotFocus(object sender, EventArgs e)
		{
			this.button130.NotifyDefault(false);
		}

		// Token: 0x06000134 RID: 308 RVA: 0x0000498F File Offset: 0x00002B8F
		private void button131_GotFocus(object sender, EventArgs e)
		{
			this.button131.NotifyDefault(false);
		}

		// Token: 0x06000135 RID: 309 RVA: 0x0000499D File Offset: 0x00002B9D
		private void button132_GotFocus(object sender, EventArgs e)
		{
			this.button132.NotifyDefault(false);
		}

		// Token: 0x06000136 RID: 310 RVA: 0x000049AB File Offset: 0x00002BAB
		private void button133_GotFocus(object sender, EventArgs e)
		{
			this.button133.NotifyDefault(false);
		}

		// Token: 0x06000137 RID: 311 RVA: 0x000049B9 File Offset: 0x00002BB9
		private void button134_GotFocus(object sender, EventArgs e)
		{
			this.button134.NotifyDefault(false);
		}

		// Token: 0x06000138 RID: 312 RVA: 0x000049C7 File Offset: 0x00002BC7
		private void button135_GotFocus(object sender, EventArgs e)
		{
			this.button135.NotifyDefault(false);
		}

		// Token: 0x06000139 RID: 313 RVA: 0x000049D5 File Offset: 0x00002BD5
		private void button136_GotFocus(object sender, EventArgs e)
		{
			this.button136.NotifyDefault(false);
		}

		// Token: 0x0600013A RID: 314 RVA: 0x000049E3 File Offset: 0x00002BE3
		private void button137_GotFocus(object sender, EventArgs e)
		{
			this.button137.NotifyDefault(false);
		}

		// Token: 0x0600013B RID: 315 RVA: 0x000049F1 File Offset: 0x00002BF1
		private void button138_GotFocus(object sender, EventArgs e)
		{
			this.button138.NotifyDefault(false);
		}

		// Token: 0x0600013C RID: 316 RVA: 0x000049FF File Offset: 0x00002BFF
		private void button139_GotFocus(object sender, EventArgs e)
		{
			this.button139.NotifyDefault(false);
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00004A0D File Offset: 0x00002C0D
		private void button140_GotFocus(object sender, EventArgs e)
		{
			this.button140.NotifyDefault(false);
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00004A1B File Offset: 0x00002C1B
		private void button141_GotFocus(object sender, EventArgs e)
		{
			this.button141.NotifyDefault(false);
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00004A29 File Offset: 0x00002C29
		private void button142_GotFocus(object sender, EventArgs e)
		{
			this.button142.NotifyDefault(false);
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00004A37 File Offset: 0x00002C37
		private void button143_GotFocus(object sender, EventArgs e)
		{
			this.button143.NotifyDefault(false);
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00004A45 File Offset: 0x00002C45
		private void button144_GotFocus(object sender, EventArgs e)
		{
			this.button144.NotifyDefault(false);
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00004A53 File Offset: 0x00002C53
		private void button145_GotFocus(object sender, EventArgs e)
		{
			this.button145.NotifyDefault(false);
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00004A61 File Offset: 0x00002C61
		private void button146_GotFocus(object sender, EventArgs e)
		{
			this.button146.NotifyDefault(false);
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00004A6F File Offset: 0x00002C6F
		private void button147_GotFocus(object sender, EventArgs e)
		{
			this.button147.NotifyDefault(false);
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00004A7D File Offset: 0x00002C7D
		private void button148_GotFocus(object sender, EventArgs e)
		{
			this.button148.NotifyDefault(false);
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00004A8B File Offset: 0x00002C8B
		private void button149_GotFocus(object sender, EventArgs e)
		{
			this.button149.NotifyDefault(false);
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00004A99 File Offset: 0x00002C99
		private void button150_GotFocus(object sender, EventArgs e)
		{
			this.button150.NotifyDefault(false);
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00004AA7 File Offset: 0x00002CA7
		private void button151_GotFocus(object sender, EventArgs e)
		{
			this.button151.NotifyDefault(false);
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00004AB5 File Offset: 0x00002CB5
		private void button152_GotFocus(object sender, EventArgs e)
		{
			this.button152.NotifyDefault(false);
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00004AC3 File Offset: 0x00002CC3
		private void button153_GotFocus(object sender, EventArgs e)
		{
			this.button153.NotifyDefault(false);
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00004AD1 File Offset: 0x00002CD1
		private void button154_GotFocus(object sender, EventArgs e)
		{
			this.button154.NotifyDefault(false);
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00004ADF File Offset: 0x00002CDF
		private void button155_GotFocus(object sender, EventArgs e)
		{
			this.button155.NotifyDefault(false);
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00004AED File Offset: 0x00002CED
		private void button156_GotFocus(object sender, EventArgs e)
		{
			this.button156.NotifyDefault(false);
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00004AFB File Offset: 0x00002CFB
		private void button157_GotFocus(object sender, EventArgs e)
		{
			this.button157.NotifyDefault(false);
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00004B09 File Offset: 0x00002D09
		private void button158_GotFocus(object sender, EventArgs e)
		{
			this.button158.NotifyDefault(false);
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00004B17 File Offset: 0x00002D17
		private void button159_GotFocus(object sender, EventArgs e)
		{
			this.button159.NotifyDefault(false);
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00004B25 File Offset: 0x00002D25
		private void button160_GotFocus(object sender, EventArgs e)
		{
			this.button160.NotifyDefault(false);
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00004B33 File Offset: 0x00002D33
		private void button161_GotFocus(object sender, EventArgs e)
		{
			this.button161.NotifyDefault(false);
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00004B41 File Offset: 0x00002D41
		private void button162_GotFocus(object sender, EventArgs e)
		{
			this.button162.NotifyDefault(false);
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00004B4F File Offset: 0x00002D4F
		private void button163_GotFocus(object sender, EventArgs e)
		{
			this.button163.NotifyDefault(false);
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00004B5D File Offset: 0x00002D5D
		private void button164_GotFocus(object sender, EventArgs e)
		{
			this.button164.NotifyDefault(false);
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00004B6B File Offset: 0x00002D6B
		private void button165_GotFocus(object sender, EventArgs e)
		{
			this.button165.NotifyDefault(false);
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00004B79 File Offset: 0x00002D79
		private void button166_GotFocus(object sender, EventArgs e)
		{
			this.button166.NotifyDefault(false);
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00004B87 File Offset: 0x00002D87
		private void button167_GotFocus(object sender, EventArgs e)
		{
			this.button167.NotifyDefault(false);
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00004B95 File Offset: 0x00002D95
		private void button168_GotFocus(object sender, EventArgs e)
		{
			this.button168.NotifyDefault(false);
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00004BA3 File Offset: 0x00002DA3
		private void button169_GotFocus(object sender, EventArgs e)
		{
			this.button169.NotifyDefault(false);
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00004BB1 File Offset: 0x00002DB1
		private void button170_GotFocus(object sender, EventArgs e)
		{
			this.button170.NotifyDefault(false);
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00004BBF File Offset: 0x00002DBF
		private void button171_GotFocus(object sender, EventArgs e)
		{
			this.button171.NotifyDefault(false);
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00004BCD File Offset: 0x00002DCD
		private void button172_GotFocus(object sender, EventArgs e)
		{
			this.button172.NotifyDefault(false);
		}

		// Token: 0x0600015E RID: 350 RVA: 0x00004BDB File Offset: 0x00002DDB
		private void button173_GotFocus(object sender, EventArgs e)
		{
			this.button173.NotifyDefault(false);
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00004BE9 File Offset: 0x00002DE9
		private void button174_GotFocus(object sender, EventArgs e)
		{
			this.button174.NotifyDefault(false);
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00004BF7 File Offset: 0x00002DF7
		private void button175_GotFocus(object sender, EventArgs e)
		{
			this.button175.NotifyDefault(false);
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00004C05 File Offset: 0x00002E05
		private void button176_GotFocus(object sender, EventArgs e)
		{
			this.button176.NotifyDefault(false);
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00004C13 File Offset: 0x00002E13
		private void button177_GotFocus(object sender, EventArgs e)
		{
			this.button177.NotifyDefault(false);
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00004C21 File Offset: 0x00002E21
		private void button178_GotFocus(object sender, EventArgs e)
		{
			this.button178.NotifyDefault(false);
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00004C2F File Offset: 0x00002E2F
		private void button179_GotFocus(object sender, EventArgs e)
		{
			this.button179.NotifyDefault(false);
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00004C3D File Offset: 0x00002E3D
		private void button180_GotFocus(object sender, EventArgs e)
		{
			this.button180.NotifyDefault(false);
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00004C4B File Offset: 0x00002E4B
		private void button181_GotFocus(object sender, EventArgs e)
		{
			this.button181.NotifyDefault(false);
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00004C59 File Offset: 0x00002E59
		private void button182_GotFocus(object sender, EventArgs e)
		{
			this.button182.NotifyDefault(false);
		}

		// Token: 0x06000168 RID: 360 RVA: 0x00004C67 File Offset: 0x00002E67
		private void button183_GotFocus(object sender, EventArgs e)
		{
			this.button183.NotifyDefault(false);
		}

		// Token: 0x06000169 RID: 361 RVA: 0x00004C75 File Offset: 0x00002E75
		private void button184_GotFocus(object sender, EventArgs e)
		{
			this.button184.NotifyDefault(false);
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00004C83 File Offset: 0x00002E83
		private void button185_GotFocus(object sender, EventArgs e)
		{
			this.button185.NotifyDefault(false);
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00004C91 File Offset: 0x00002E91
		private void button186_GotFocus(object sender, EventArgs e)
		{
			this.button186.NotifyDefault(false);
		}

		// Token: 0x04000012 RID: 18
		public static MainForm Main;

		// Token: 0x04000013 RID: 19
		public static Agreement Agreement = new Agreement();

		// Token: 0x04000014 RID: 20
		public static RegistryKey Settings = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Felipe", true);

		// Token: 0x04000015 RID: 21
		public static IList<string> _entries = new List<string>();

		// Token: 0x04000016 RID: 22
		private static readonly string[] RegistryKeys = new string[]
		{
			"SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache",
			"SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store",
			"SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers",
			"SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Persisted"
		};

		// Token: 0x04000017 RID: 23
		private static readonly string[] BlackList = new string[]
		{
			"yeetfuscator",
			"ch_tweaks",
			"chtweaks",
			"cloud",
			"spyme",
			"regshot",
			"inctrl5",
			"systracer",
			"regfromapp",
			"installspy",
			"whatchanged",
			"installwatch",
			"trackwinstall",
			"sysinternals",
			"regcool",
			"systracer",
			"whatchanged",
			"registrychangesview",
			"ch1_tweaks",
			"senin_tweaker",
			"gputweaks",
			"nvidia tweaks",
			"dgofps"
		};
	}
}
