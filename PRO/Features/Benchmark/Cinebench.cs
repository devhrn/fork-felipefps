using System;
using System.Diagnostics;
using PRO.Core;

namespace PRO.Features.Benchmark
{
	// Token: 0x02000089 RID: 137
	public class Cinebench : IFeature
	{
		// Token: 0x060003B8 RID: 952 RVA: 0x000322C1 File Offset: 0x000304C1
		public void Execute()
		{
			Process.Start("https://www.maxon.net/en/cinebench");
		}
	}
}
