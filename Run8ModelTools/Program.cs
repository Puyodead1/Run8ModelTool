using MoreLinq;
using JeremyAnsel.Media.WavefrontObj;
using System.Text;

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
            ObjVector3 vector3_1 = new ObjVector3(0, 0, 0);
            ObjVector3 vector3_0 = vector3_1;
            ObjVector3 vector3_3;
            string string_0;
            string string_1;
            ObjFile objFile = new ObjFile();

            float BsRadius;
            using (FileStream fileStream = File.OpenRead(path))
            {
                using (BinaryReader binaryReader = new BinaryReader(fileStream, Encoding.UTF8))
                {
                    bool flag = false;
                    int num = 1;
                    int num2 = binaryReader.ReadInt32();

                    if (num2 == -969696)
                    {
                        num = binaryReader.ReadInt32();
                        flag = true;
                    }
                    else if (num2 == -969697)
                    {
                        num = binaryReader.ReadInt32() - 1;
                        vector3_0 = new ObjVector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
                        vector3_1 = new ObjVector3(0,0,0);
                        flag = true;
                    }
                    else
                    {
                        binaryReader.BaseStream.Position = 0L;
                    }
                    //this.list_0 = new List<Class238>(num);
                    BsRadius = 0f;
                    for (int i = 0; i < num; i++)
                    {
                        //Class238 @class = new Class238();
                        if (flag)
                        {
                            Console.WriteLine("quaternion shit");
                            string_0 = binaryReader.ReadString();
                            string_1 = binaryReader.ReadString();
                            vector3_3 = new ObjVector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
                            vector3_1 = new ObjVector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
                            ObjVector3 quaternion_1 = new ObjVector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
                            var oskd = new ObjVector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
                            var olsd = new ObjVector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
                            var laps = new ObjVector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
                            ObjVector3 vector3_2 = new ObjVector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
                            ObjVector3 quaternion_2 = new ObjVector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
                            var kais = new ObjVector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
                            int num3 = binaryReader.ReadInt32();
                            Matrix[] array = new Matrix[num3];
                            for (int j = 0; j < num3; j++)
                            {
                                //if (@class.class237_0 == null)
                                //{
                                //    @class.class237_0 = new Class237
                                //    {
                                //        quaternion_0 = new Quaternion[num3],
                                //        vector3_0 = new Vector3[num3]
                                //    };
                                //}
                                array[j] = new Matrix(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
                            }
                            int num4 = binaryReader.ReadInt32();
                            Matrix[] array2 = new Matrix[num3];
                            for (int k = 0; k < num4; k++)
                            {
                                array2[k] = new Matrix(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
                            }
                            if (num4 != num3)
                            {
                                //@class.class237_0 = null;
                                Console.WriteLine("class is null");
                            }
                            else
                            {
                                for (int l = 0; l < num4; l++)
                                {
                                    //@class.class237_0.quaternion_0[l] = Quaternion.RotationMatrix(array2[l]);
                                    //@class.class237_0.vector3_0[l] = array[l].TranslationVector;
                                    Console.WriteLine("set quaternion0 and vector30");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("no math");
                            string_0 = "";
                            string_1 = "";
                            vector3_3 = new ObjVector3(0,0,0);
                        }
                        List<VertexPositionNormalTexture> list = new List<VertexPositionNormalTexture>();
                        int num5 = binaryReader.ReadInt32() / 7;
                        for (int m = 0; m < num5; m++)
                        {
                            ObjVector3 Position = new ObjVector3();
                            ObjVector3 Normal = new ObjVector3();
                            ObjVector3 TextureCoordinate = new ObjVector3();

                            binaryReader.ReadSingle();
                            Position.X = binaryReader.ReadSingle() * 63.7f - vector3_3.X;
                            Normal.Y = binaryReader.ReadSingle() / -1.732f;
                            Position.Z = binaryReader.ReadSingle() / 16f - vector3_3.Z;
                            TextureCoordinate.X = binaryReader.ReadSingle() / 4.8f;
                            Normal.X = binaryReader.ReadSingle() / 10.962f;
                            binaryReader.ReadSingle();
                            Normal.Z = binaryReader.ReadSingle() / 11.432f;
                            TextureCoordinate.Y = -binaryReader.ReadSingle() / 9.6f;
                            Position.Y = -binaryReader.ReadSingle() * 6f - vector3_3.Y;

                            VertexPositionNormalTexture vertexPositionNormalTexture = new VertexPositionNormalTexture(Position, Normal, TextureCoordinate);
                            list.Add(vertexPositionNormalTexture);
                            float num6 = Math.Max(Math.Abs(vertexPositionNormalTexture.Position.X), Math.Max(Math.Abs(vertexPositionNormalTexture.Position.Y), Math.Abs(vertexPositionNormalTexture.Position.Z)));
                            if (num6 > BsRadius)
                            {
                                BsRadius = num6;
                            }
                        }
                        //@class.buffer_0 = SharpDX.Toolkit.Graphics.Buffer.Vertex.New<VertexPositionNormalTexture>(graphicsDevice_0, list.ToArray(), ResourceUsage.Immutable);

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
                        int[] buffer_1 = new int[num7];
                        if (flag2)
                        {
                            Console.WriteLine("ushort index buffer");
                            ushort[] array3 = new ushort[num7];
                            for (int num8 = 0; num8 < num7; num8++)
                            {
                                buffer_1[num8] = (ushort)binaryReader.ReadInt32();
                            }
                            //@class.buffer_1 = SharpDX.Toolkit.Graphics.Buffer.Index.New<ushort>(graphicsDevice_0, array3, ResourceUsage.Immutable);
                        }
                        else
                        {
                            Console.WriteLine("int index buffer");
                            int[] array4 = new int[num7];
                            for (int num9 = 0; num9 < num7; num9++)
                            {
                                buffer_1[num9] = binaryReader.ReadInt32();
                            }
                            //@class.buffer_1 = SharpDX.Toolkit.Graphics.Buffer.Index.New<int>(graphicsDevice_0, array4, ResourceUsage.Immutable);
                        }
                        num5 = binaryReader.ReadInt32() - 9;
                        if (num5 == 0)
                        {
                            //Class138 item = new Class138
                            //{
                            //    int_2 = @class.buffer_1.ElementCount,
                            //    int_0 = 0,
                            //    int_1 = 0
                            //};
                            //@class.list_0.Add(item);
                            Console.WriteLine("Create new class138");
                        }
                        else
                        {
                            Console.WriteLine("texture crap");
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
                        //this.list_0.Add(@class);
                        VertexPositionNormalTexture[] vbo = list.ToArray();
                        Console.WriteLine("Vertex Buffer has " + vbo.Length + " elements");
                        Console.WriteLine("Index Buffer has " + buffer_1.Length + " elements");

                        foreach (VertexPositionNormalTexture v in vbo)
                        {
                            objFile.Vertices.Add(new ObjVertex(v.Position.X, v.Position.Y, v.Position.Z));
                            objFile.VertexNormals.Add(v.Normal);
                            objFile.TextureVertices.Add(v.TextureCoordinate);
                        }

                        foreach (var faceVerts in buffer_1.Batch(3))
                        {
                            ObjFace face = new ObjFace();
                            foreach (var faceVert in faceVerts)
                            {
                                ObjTriplet v = new ObjTriplet(faceVert + 1, faceVert + 1, faceVert + 1);
                                face.Vertices.Add(v);
                            }
                            objFile.Faces.Add(face);
                        }

                        objFile.WriteTo(@dest);
                    }
                }
            }
        }
    }
}
