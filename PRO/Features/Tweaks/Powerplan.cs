using System;
using PRO.Core;

namespace PRO.Features.Tweaks
{
	// Token: 0x02000018 RID: 24
	public class Powerplan : IFeature
	{
		// Token: 0x0600021B RID: 539 RVA: 0x0001D26C File Offset: 0x0001B46C
		public void Execute()
		{
			Utils.Status("Tweaking Powerplan...");
			Utils.ExecuteProcess("powercfg.exe", "/restoredefaultschemes", true, false);
			Utils.ExecuteProcess("powercfg.exe", "-duplicatescheme 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c 00000000-0000-0000-0000-000000000000", true, false);
			Utils.ExecuteProcess("powercfg.exe", "-setactive 00000000-0000-0000-0000-000000000000", true, false);
			Utils.ExecuteProcess("powercfg.exe", "-changename 00000000-0000-0000-0000-000000000000 \"High Performance\" \"by Felipe\"", true, false);
			Utils.ExecuteProcess("powercfg.exe", "-hibernate off", false, false);
			Utils.ExecuteProcess("powercfg.exe", "-setacvalueindex 00000000-0000-0000-0000-000000000000 fea3413e-7e05-4911-9a71-700331f1c294 0e796bdb-100d-47d6-a2d5-f7d2daa51f51 0", true, false);
			Utils.ExecuteProcess("powercfg.exe", "-setacvalueindex 00000000-0000-0000-0000-000000000000 0d7dbae2-4294-402a-ba8e-26777e8488cd 309dce9b-bef4-4119-9921-a851fb12f0f4 1", true, false);
			Utils.ExecuteProcess("powercfg.exe", "-setacvalueindex 00000000-0000-0000-0000-000000000000 2a737441-1930-4402-8d77-b2bebba308a3 48e6b7a6-50f5-4782-a5d4-53bb8f07e226 0", true, false);
			Utils.ExecuteProcess("powercfg.exe", "-setacvalueindex 00000000-0000-0000-0000-000000000000 2a737441-1930-4402-8d77-b2bebba308a3 d4e98f31-5ffe-4ce1-be31-1b38b384c009 0", true, false);
			Utils.ExecuteProcess("powercfg.exe", "-setacvalueindex 00000000-0000-0000-0000-000000000000 48672f38-7a9a-4bb2-8bf8-3d85be19de4e 2bfc24f9-5ea2-4801-8213-3dbae01aa39d 4", true, false);
			Utils.ExecuteProcess("powercfg.exe", "-setacvalueindex 00000000-0000-0000-0000-000000000000 238c9fa8-0aad-41ed-83f4-97be242c8f20 bd3b718a-0680-4d9d-8ab2-e1d2b4ac806d 0", true, false);
			Utils.ExecuteProcess("powercfg.exe", "-setacvalueindex 00000000-0000-0000-0000-000000000000 54533251-82be-4824-96c1-47b60b740d00 3b04d4fd-1cc7-4f23-ab1c-d1337819c4bb 0", true, false);
			Utils.ExecuteProcess("powercfg.exe", "-setacvalueindex 00000000-0000-0000-0000-000000000000 238c9fa8-0aad-41ed-83f4-97be242c8f20 25dfa149-5dd1-4736-b5ab-e8a37b5b8187 0", true, false);
			Utils.ExecuteProcess("powercfg.exe", "-setacvalueindex 00000000-0000-0000-0000-000000000000 54533251-82be-4824-96c1-47b60b740d00 5d76a2ca-e8c0-402f-a133-2158492d58ad 1", true, false);
			Utils.ExecuteProcess("powercfg.exe", "-setacvalueindex 00000000-0000-0000-0000-000000000000 2a737441-1930-4402-8d77-b2bebba308a3 0853a681-27c8-4100-a2fd-82013e970683 186a0", true, false);
			Utils.ExecuteProcess("powercfg.exe", "-setacvalueindex 00000000-0000-0000-0000-000000000000 0012ee47-9041-4b5d-9b77-535fba8b1442 d639518a-e56d-4345-8af2-b9f32fb26109 0", true, false);
			Utils.ExecuteProcess("powercfg.exe", "-setacvalueindex 00000000-0000-0000-0000-000000000000 0012ee47-9041-4b5d-9b77-535fba8b1442 6738e2c4-e8a5-4a42-b16a-e040e769756e 0", true, false);
			if (Utils.SystemInformation.NumberOfLogicalProcessors.ToString() == Utils.SystemInformation.NumberOfCores.ToString())
			{
				Utils.ExecuteProcess("powercfg.exe", "-setacvalueindex scheme_current sub_processor 5d76a2ca-e8c0-402f-a133-2158492d58ad 1", true, false);
				Utils.ExecuteProcess("powercfg.exe", "-setactive scheme_current", true, false);
			}
			Utils.ResetStatus();
		}
	}
}
