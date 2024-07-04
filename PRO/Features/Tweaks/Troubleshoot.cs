using System;
using System.Windows.Forms;
using Microsoft.Win32;
using PRO.Core;

namespace PRO.Features.Tweaks
{
	// Token: 0x02000026 RID: 38
	public class Troubleshoot : IFeature
	{
		// Token: 0x06000240 RID: 576 RVA: 0x000286F4 File Offset: 0x000268F4
		public void Execute()
		{
			if (MessageBox.Show("Restore Bluetooth?", "Bluetooth", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\BluetoothUserService", true).SetValue("Start", "3", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\BTAGService", true).SetValue("Start", "3", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\BthA2dp", true).SetValue("Start", "3", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\BthAvctpSvc", true).SetValue("Start", "3", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\BthEnum", true).SetValue("Start", "3", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\BthHFEnum", true).SetValue("Start", "3", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\BthLEEnum", true).SetValue("Start", "3", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\BthMini", true).SetValue("Start", "3", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\BthPan", true).SetValue("Start", "3", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\BTHPORT", true).SetValue("Start", "3", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\bthserv", true).SetValue("Start", "3", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\BTHUSB", true).SetValue("Start", "3", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\ConsentUxUserSvc", true).SetValue("Start", "3", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\DeviceAssociationBrokerSvc", true).SetValue("Start", "3", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\HidBth", true).SetValue("Start", "3", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\Microsoft_Bluetooth_AvrcpTransport", true).SetValue("Start", "3", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\RFCOMM", true).SetValue("Start", "3", RegistryValueKind.DWord);
			}
			if (MessageBox.Show("Restore HDD?", "HDD", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management", true).SetValue("EnablePrefetcher", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management", true).SetValue("EnableSuperfetch", "1", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management\\PrefetchParameters", true).SetValue("EnablePrefetcher", "3", RegistryValueKind.DWord);
				Utils.RegService("SysMain", "2");
				Utils.RegService("FontCache", "2");
			}
			if (MessageBox.Show("Restore Printer?", "Printer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\Spooler", true).SetValue("Start", "2", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\http", true).SetValue("Start", "3", RegistryValueKind.DWord);
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Services\\MsQuic", true).SetValue("Start", "3", RegistryValueKind.DWord);
			}
		}
	}
}
