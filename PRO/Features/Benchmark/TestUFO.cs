using System;
using System.Diagnostics;
using PRO.Core;

namespace PRO.Features.Benchmark
{
	// Token: 0x0200009D RID: 157
	public class TestUFO : IFeature
	{
		// Token: 0x06000406 RID: 1030 RVA: 0x00033802 File Offset: 0x00031A02
		public void Execute()
		{
			Process.Start("https://www.testufo.com/ghosting");
		}
	}
}
