using JeremyAnsel.Media.WavefrontObj;

namespace Run8ModelTools
{
	[Serializable]
	public struct VertexPositionNormalTexture
	{
		/// <summary>
		/// XYZ position.
		/// </summary>
		public ObjVector3 Position { get; set; }

		/// <summary>
		/// The vertex normal.
		/// </summary>
		// Token: 0x040003C8 RID: 968
		public ObjVector3 Normal { get; set; }

		/// <summary>
		/// UV texture coordinates.
		/// </summary>
		public ObjVector3 TextureCoordinate { get; set; }

		public VertexPositionNormalTexture(ObjVector3 Position, ObjVector3 Normal, ObjVector3 TextureCoordinates)
		{
			this.Position = Position;
			this.Normal = Normal;
			this.TextureCoordinate = TextureCoordinates;
		}

		public VertexPositionNormalTexture(ObjVector3 Position, ObjVector3 Normal)
		{
			this.Position = Position;
			this.Normal = Normal;
			this.TextureCoordinate = new ObjVector3(0, 0, 0);
		}
	}

}
