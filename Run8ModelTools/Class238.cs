using System;
using System.Collections.Generic;
using SharpDX;

namespace Run8ModelTools
{
    internal class Class238
    {
		public Class238()
		{
		}

		// Token: 0x0600129F RID: 4767 RVA: 0x0000C45D File Offset: 0x0000A65D
		internal void Dispose()
		{
			//this.buffer_0.Dispose();
			//this.buffer_1.Dispose();
		}

		// Token: 0x060012A0 RID: 4768 RVA: 0x00073380 File Offset: 0x00071580
		internal void method_1(float float_0)
		{
			Vector3 value = Vector3.Transform(Vector3.ForwardRH, this.class238_0.quaternion_0);
			Vector3 value2 = Vector3.Transform(Vector3.Up, this.class238_0.quaternion_0);
			Vector3 value3 = Vector3.Transform(Vector3.Right, this.class238_0.quaternion_0);
			if (this.class237_0 != null)
			{
				this.class237_0.method_0(float_0);
				this.quaternion_0 = this.class238_0.quaternion_0 * this.class237_0.quaternion_1 * this.RotationMatrix2 * this.RotationMatrix;
				this.vector3_0 = this.class238_0.vector3_0;
				this.vector3_0 += value3 * this.class237_0.vector3_1.X;
				this.vector3_0 += value2 * this.class237_0.vector3_1.Y;
				this.vector3_0 += value * this.class237_0.vector3_1.Z;
			}
			else
			{
				this.quaternion_0 = this.class238_0.quaternion_0;
				this.vector3_0 = this.class238_0.vector3_0;
				this.vector3_0 += value3 * this.vector3_2.X;
				this.vector3_0 += value2 * this.vector3_2.Y;
				this.vector3_0 += value * this.vector3_2.Z;
			}
			Vector3 vector = this.PositionOffset - this.class238_0.PositionOffset + this.vector3_1;
			this.vector3_0 += value3 * vector.X;
			this.vector3_0 += value2 * vector.Y;
			this.vector3_0 += value * -vector.Z;
		}

        // Token: 0x04000FE5 RID: 4069
        internal Enum39 enum39_0;

        // Token: 0x04000FE6 RID: 4070
        internal string ObjectName;

		// Token: 0x04000FE7 RID: 4071
		internal string ParentObjectName;

		// Token: 0x04000FE8 RID: 4072
		internal VertexPositionNormalTexture[] buffer_0;

        // Token: 0x04000FE9 RID: 4073
        internal int[] buffer_1;

        // Token: 0x04000FEA RID: 4074
        internal List<Class138> list_0 = new List<Class138>();

		// Token: 0x04000FEB RID: 4075
		internal Quaternion quaternion_0 = Quaternion.Identity;

		// Token: 0x04000FEC RID: 4076
		internal Vector3 vector3_0 = Vector3.Zero;

		// Token: 0x04000FED RID: 4077
		internal Vector3 vector3_1 = Vector3.Zero;

		// Token: 0x04000FEE RID: 4078
		internal Quaternion RotationMatrix = Quaternion.Identity;

		// Token: 0x04000FEF RID: 4079
		internal Quaternion RotationMatrix2 = Quaternion.Identity;

		// Token: 0x04000FF0 RID: 4080
		internal Vector3 vector3_2 = Vector3.Zero;

		// Token: 0x04000FF1 RID: 4081
		internal Vector3 PositionOffset = Vector3.Zero;

		// Token: 0x04000FF2 RID: 4082
		internal Class237 class237_0;

		// Token: 0x04000FF3 RID: 4083
		internal Class238 class238_0;

		// Token: 0x04000FF4 RID: 4084
		internal bool bool_0 = true;

        public List<VertexPositionNormalTexture> VBO { get; internal set; }
    }
}
