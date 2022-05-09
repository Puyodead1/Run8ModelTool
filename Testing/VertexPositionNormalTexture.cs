using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDX;
using System.Threading.Tasks;

namespace Run8TerrainTools
{
    //
    // Summary:
    //     Describes a custom vertex format structure that contains position and color information.
    public struct VertexPositionNormalTexture : IEquatable<VertexPositionNormalTexture>
    {
        //
        // Summary:
        //     XYZ position.
        public Vector3 Position;

        //
        // Summary:
        //     The vertex normal.
        public Vector3 Normal;

        //
        // Summary:
        //     UV texture coordinates.
        public Vector2 TextureCoordinate;

        //
        // Summary:
        //     Defines structure byte size.
        public static readonly int Size = 32;

        //
        // Summary:
        //     Initializes a new SharpDX.Toolkit.Graphics.VertexPositionNormalTexture instance.
        //
        // Parameters:
        //   position:
        //     The position of this vertex.
        //
        //   normal:
        //     The vertex normal.
        //
        //   textureCoordinate:
        //     UV texture coordinates.
        public VertexPositionNormalTexture(Vector3 position, Vector3 normal, Vector2 textureCoordinate)
        {
            this = default(VertexPositionNormalTexture);
            Position = position;
            Normal = normal;
            TextureCoordinate = textureCoordinate;
        }

        public bool Equals(VertexPositionNormalTexture other)
        {
            if (Position.Equals(other.Position) && Normal.Equals(other.Normal))
            {
                return TextureCoordinate.Equals(other.TextureCoordinate);
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(null, obj))
            {
                return false;
            }

            if (obj is VertexPositionNormalTexture)
            {
                return Equals((VertexPositionNormalTexture)obj);
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hashCode = Position.GetHashCode();
            hashCode = ((hashCode * 397) ^ Normal.GetHashCode());
            return (hashCode * 397) ^ TextureCoordinate.GetHashCode();
        }

        public static bool operator ==(VertexPositionNormalTexture left, VertexPositionNormalTexture right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(VertexPositionNormalTexture left, VertexPositionNormalTexture right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            return $"Position: {Position}, Normal: {Normal}, Texcoord: {TextureCoordinate}";
        }
    }
}
