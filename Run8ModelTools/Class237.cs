using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;

namespace Run8ModelTools
{
    internal class Class237
    {
		public Class237()
		{
		}

		// Token: 0x0600129D RID: 4765 RVA: 0x00073210 File Offset: 0x00071410
		internal void method_0(float float_0)
		{
			if (this.quaternion_0.Length < 2)
			{
				this.quaternion_1 = Quaternion.Identity;
				this.vector3_1 = Vector3.Zero;
				return;
			}
			int num = MathUtil.Clamp((int)(float_0 * (float)this.quaternion_0.Length - 2f), 0, this.quaternion_0.Length - 2);
			int num2 = MathUtil.Clamp(num + 1, 0, this.quaternion_0.Length - 1);
			Quaternion quaternion = this.quaternion_0[num];
			Quaternion quaternion2 = this.quaternion_0[num2];
			Vector3 start = this.vector3_0[num];
			Vector3 end = this.vector3_0[num2];
			float num3 = 1f / (float)(this.quaternion_0.Length - 1);
			float amount = MathUtil.Lerp(0f, 1f, float_0 - num3 * (float)num / num3);
			if (quaternion != quaternion2)
			{
				this.quaternion_1 = Quaternion.Lerp(quaternion, quaternion2, amount);
			}
			else
			{
				this.quaternion_1 = quaternion;
			}
			this.vector3_1 = Vector3.Lerp(start, end, amount);
		}

		// Token: 0x04000FD1 RID: 4049
		internal Quaternion[] quaternion_0;

		// Token: 0x04000FD2 RID: 4050
		internal Vector3[] vector3_0;

		// Token: 0x04000FD3 RID: 4051
		internal Quaternion quaternion_1;

		// Token: 0x04000FD4 RID: 4052
		internal Vector3 vector3_1;
	}
}
