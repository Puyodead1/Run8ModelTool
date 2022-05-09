using MoreLinq;
using JeremyAnsel.Media.WavefrontObj;
using System.Text;
using SharpDX;

namespace Run8ModelTools
{
    public class Program
    {
        public static int Main(string[] args)
        {
            if(args.Length == 0)
            {
                Console.WriteLine("No mode specified, valid modes are: r8o, or8");
                return 1;
            }

            string mode = args[0];

            string inputFilePath, inputFileName, outputFileName, outputFilePath;
            string? inputFileDirectory;
            if (mode.ToLower() == "r8o")
            {
                inputFilePath = args[1];
                if (!File.Exists(inputFilePath))
                {
                    Console.WriteLine("File does not exist: " + inputFilePath);
                    return 1;
                }

                inputFileName = Path.GetFileName(inputFilePath);
                inputFileDirectory = Path.GetDirectoryName(inputFilePath);

                if (inputFileDirectory == null)
                {
                    inputFileDirectory = Directory.GetCurrentDirectory();
                }

                outputFileName = Path.GetFileNameWithoutExtension(inputFilePath) + ".obj";
                outputFilePath = Path.Join(inputFileDirectory, outputFileName);

                ConvertRN8ToObj2(inputFilePath, outputFilePath);
                return 0;
            } else if (mode.ToLower() == "or8")
            {
                Console.WriteLine("Unimplemented");
                return 0;
            }
            else
            {
                Console.WriteLine("Invalid Mode " + mode + "!");
                Console.WriteLine("Valid modes are: r8o, or8");
                return 1;
            }
        }
    
        public static void ConvertRN8ToObj2(string path, string dest)
        {
            List<Class238> list_0 = new List<Class238>();
            Vector3 vector3_1 = Vector3.Zero;
            Vector3 vector3_0 = Vector3.Zero;
            Matrix matrix_0 = Matrix.Identity;
            float BsRadius;
            using (FileStream fileStream = File.OpenRead(path))
            {
                using (BinaryReader binaryReader = new BinaryReader(fileStream, Encoding.UTF8))
                {
                    bool flag = false;
                    int num = 1;
                    int num2 = binaryReader.ReadInt32();
                    Console.WriteLine("num2: " + num2);

                    if (num2 == -969696)
                    {
                        num = binaryReader.ReadInt32();
                        Console.WriteLine("num: " + num);
                        flag = true;
                    }
                    else if (num2 == -969697)
                    {
                        num = binaryReader.ReadInt32() - 1;
                        Console.WriteLine("num: " + num);
                        vector3_0 = new Vector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
                        vector3_1 = new Vector3(0,0,0);
                        flag = true;
                    }
                    else
                    {
                        binaryReader.BaseStream.Position = 0L;
                    }
                    list_0 = new List<Class238>(num);
                    BsRadius = 0f;
                    for (int i = 0; i < num; i++)
                    {

                        Class238 @class = new Class238();
                        if (flag)
                        {
                            @class.ObjectName = binaryReader.ReadString();
                            Console.WriteLine("Object Name: " + @class.ObjectName);
                            @class.ParentObjectName = binaryReader.ReadString();
                            Console.WriteLine("Parent Object Name: " + @class.ParentObjectName);
                            @class.PositionOffset = new Vector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
                            @class.vector3_1 = new Vector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
                            @class.RotationMatrix = Quaternion.RotationMatrix(Matrix.RotationYawPitchRoll(MathUtil.DegreesToRadians(binaryReader.ReadSingle()), MathUtil.DegreesToRadians(binaryReader.ReadSingle()), MathUtil.DegreesToRadians(binaryReader.ReadSingle())));
                            Matrix ScaleMatrix = Matrix.Scaling(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
                            Quaternion Quad1 = Quaternion.RotationMatrix(Matrix.RotationYawPitchRoll(MathUtil.DegreesToRadians(binaryReader.ReadSingle()), MathUtil.DegreesToRadians(binaryReader.ReadSingle()), MathUtil.DegreesToRadians(binaryReader.ReadSingle())));
                            Quaternion Quad2 = Quaternion.RotationMatrix(Matrix.RotationYawPitchRoll(MathUtil.DegreesToRadians(binaryReader.ReadSingle()), MathUtil.DegreesToRadians(binaryReader.ReadSingle()), MathUtil.DegreesToRadians(binaryReader.ReadSingle())));
                            @class.vector3_2 = new Vector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
                            Console.WriteLine("vector3_2: " + @class.vector3_2.ToString());
                            @class.RotationMatrix2 = Quaternion.RotationMatrix(Matrix.RotationYawPitchRoll(MathUtil.DegreesToRadians(binaryReader.ReadSingle()), MathUtil.DegreesToRadians(binaryReader.ReadSingle()), MathUtil.DegreesToRadians(binaryReader.ReadSingle())));
                            Console.WriteLine("RotationMatrix2: " + @class.RotationMatrix2.ToString());
                            int num3 = binaryReader.ReadInt32();
                            Matrix[] array = new Matrix[num3];
                            for (int j = 0; j < num3; j++)
                            {
                                if (@class.class237_0 == null)
                                {
                                    @class.class237_0 = new Class237
                                    {
                                        quaternion_0 = new Quaternion[num3],
                                        vector3_0 = new Vector3[num3]
                                    };
                                }
                                array[j] = new Matrix(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
                            }
                            int num4 = binaryReader.ReadInt32();
                            Console.WriteLine("num4: " + num4);
                            Matrix[] array2 = new Matrix[num3];
                            for (int k = 0; k < num4; k++)
                            {
                                array2[k] = new Matrix(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
                            }
                            if (num4 != num3)
                            {
                                Console.WriteLine("class is null");
                            }
                            else
                            {
                                for (int l = 0; l < num4; l++)
                                {
                                    @class.class237_0.quaternion_0[l] = Quaternion.RotationMatrix(array2[l]);
                                    @class.class237_0.vector3_0[l] = array[l].TranslationVector;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("no math");
                            @class.ObjectName = "";
                            @class.ParentObjectName = "";
                            @class.PositionOffset = Vector3.Zero;
                        }

                        List<VertexPositionNormalTexture> list = new List<VertexPositionNormalTexture>();
                        int num5 = binaryReader.ReadInt32() / 7;
                        for (int m = 0; m < num5; m++)
                        {
                            VertexPositionNormalTexture vertexPositionNormalTexture = default(VertexPositionNormalTexture);
                            binaryReader.ReadSingle();
                            vertexPositionNormalTexture.Position.X = (binaryReader.ReadSingle() * 63.7f - @class.PositionOffset.X) + @class.vector3_2.X;
                            vertexPositionNormalTexture.Normal.Y = binaryReader.ReadSingle() / -1.732f;
                            vertexPositionNormalTexture.Position.Z = (binaryReader.ReadSingle() / 16f - @class.PositionOffset.Z) - @class.vector3_2.Z;
                            vertexPositionNormalTexture.TextureCoordinate.X = binaryReader.ReadSingle() / 4.8f;
                            vertexPositionNormalTexture.Normal.X = binaryReader.ReadSingle() / 10.962f;
                            binaryReader.ReadSingle();
                            vertexPositionNormalTexture.Normal.Z = binaryReader.ReadSingle() / 11.432f;
                            vertexPositionNormalTexture.TextureCoordinate.Y = binaryReader.ReadSingle() / 9.6f;
                            vertexPositionNormalTexture.Position.Y = (-(binaryReader.ReadSingle() * 6f - @class.PositionOffset.Y) - @class.vector3_2.Y);

                            Vector3.Transform(vertexPositionNormalTexture.Position, @class.RotationMatrix);

                            list.Add(vertexPositionNormalTexture);
                            float num6 = Math.Max(Math.Abs(vertexPositionNormalTexture.Position.X), Math.Max(Math.Abs(vertexPositionNormalTexture.Position.Y), Math.Abs(vertexPositionNormalTexture.Position.Z)));
                            if (num6 > BsRadius)
                            {
                                BsRadius = num6;
                            }
                        }

                        num5 = binaryReader.ReadInt32() + 6;
                        List<string> list2 = new List<string>();
                        for (int n = 0; n < num5; n++)
                        {
                            string p = binaryReader.ReadString();
                            Console.WriteLine("Texture: " + p);
                            list2.Add(Path.GetFileNameWithoutExtension(p));
                        }
                        bool flag2 = binaryReader.ReadBoolean();
                        int num7 = binaryReader.ReadInt32();
                        @class.buffer_1 = new int[num7];
                        if (flag2)
                        {
                            Console.WriteLine("ushort index buffer");
                            ushort[] array3 = new ushort[num7];
                            for (int num8 = 0; num8 < num7; num8++)
                            {
                                @class.buffer_1[num8] = (ushort)binaryReader.ReadInt32();
                            }
                        }
                        else
                        {
                            Console.WriteLine("int index buffer");
                            int[] array4 = new int[num7];
                            for (int num9 = 0; num9 < num7; num9++)
                            {
                                @class.buffer_1[num9] = binaryReader.ReadInt32();
                            }
                        }
                        num5 = binaryReader.ReadInt32() - 9;
                        if (num5 == 0)
                        {
                            Class138 item = new Class138
                            {
                                IndexCount = @class.buffer_1.Length,
                                StartIndexLocation = 0,
                                BaseVertexLocation = 0
                            };
                            @class.list_0.Add(item);
                        }
                        else
                        {
                            for (int num10 = 0; num10 < num5; num10++)
                            {
                                binaryReader.ReadSingle();
                                int index = binaryReader.ReadInt32();

                                if (list2.Count > 0)
                                {
                                    string textureName = list2[index];
                                    string text2 = textureName + "_mrao";
                                    string text3 = textureName + "_MRAO";
                                    int indexCount = binaryReader.ReadInt32();
                                    int startIndexLocation = binaryReader.ReadInt32();
                                    int baseVertexLocation = binaryReader.ReadInt32();
                                }
                            }
                        }

                        ObjFile objFile = new ObjFile();
                        VertexPositionNormalTexture[] vbo = list.ToArray();
                        Console.WriteLine("Vertex Buffer has " + vbo.Length + " elements");
                        Console.WriteLine("Index Buffer has " + @class.buffer_1.Length + " elements");

                        foreach (VertexPositionNormalTexture v in vbo)
                        {
                            objFile.Vertices.Add(new ObjVertex(v.Position.X, v.Position.Y, v.Position.Z));
                            objFile.VertexNormals.Add(new ObjVector3(v.Normal.X, v.Normal.Y, v.Normal.Z));
                            objFile.TextureVertices.Add(new ObjVector3(v.TextureCoordinate.X, v.TextureCoordinate.Y, 0));
                        }

                        foreach (var faceVerts in @class.buffer_1.Batch(3))
                        {
                            ObjFace face = new ObjFace();
                            foreach (var faceVert in faceVerts)
                            {
                                face.Vertices.Add(new ObjTriplet(faceVert + 1, faceVert + 1, faceVert + 1));
                            }

                            objFile.Faces.Add(face);
                        }

                        objFile.WriteTo(Path.Join(Path.GetDirectoryName(dest), @class.ObjectName + ".obj"));
                    }
                }
            }

            Console.WriteLine("Done");
        }
    }
}
