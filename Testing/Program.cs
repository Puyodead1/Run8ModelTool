using System.IO.Compression;
using MoreLinq;
using JeremyAnsel.Media.WavefrontObj;
using SharpDX;

namespace Run8TerrainTools
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No mode specified, valid modes are: t4o, decomp, test");
                return 1;
            }

            string mode = args[0];

            string inputFilePath, inputFileName, outputFileName, outputFilePath;
            string? inputFileDirectory;

            if (mode.ToLower() == "t4o")
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

                try
                {
                    ConvertTr4ToObj(inputFilePath, outputFilePath);
                } catch (Exception ex)
                {
                    Console.WriteLine("Failed to convert " + inputFileName + ": " + ex.Message);
                    return 1;
                }
                return 0;
            } else if (mode.ToLower() == "decomp")
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

                outputFileName = Path.GetFileNameWithoutExtension(inputFilePath) + ".bin";
                outputFilePath = Path.Join(inputFileDirectory, outputFileName);

                try
                {
                    Decompress(inputFilePath, outputFilePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to decompress " + inputFileName + ": " + ex.Message);
                    return 1;
                }
                return 0;
            }
            else if (mode.ToLower() == "test")
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

                outputFileName = Path.GetFileNameWithoutExtension(inputFilePath) + ".bin";
                outputFilePath = Path.Join(inputFileDirectory, outputFileName);

                try
                {
                    ConvertTr4ToObj(inputFilePath, outputFilePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to convert " + inputFileName + ": " + ex.Message);
                    return 1;
                }
                return 0;
            }
            else
            {
                Console.WriteLine("Invalid Mode " + mode + "!");
                Console.WriteLine("Valid modes are: t4o, decomp, test");
                return 1;
            }
        }

        static void Decompress(string input, string output)
        {
            using (FileStream fileStream = new FileStream(@input, FileMode.Open, FileAccess.Read))
            {
                using (DeflateStream deflateStream = new DeflateStream(fileStream, CompressionMode.Decompress))
                {
                    using (FileStream outStream = new FileStream(output, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        deflateStream.CopyTo(outStream);
                        outStream.Dispose();
                        deflateStream.Dispose();
                        fileStream.Dispose();
                    }
                }
            }
        }

        static void ConvertTr4ToObj(string input, string output)
        {
            string filename = Path.GetFileNameWithoutExtension (input);
            Vector2 TileXY = new Vector2(Convert.ToInt32(filename.Split("_")[0]), Convert.ToInt32(filename.Split("_")[1]));
            Console.WriteLine("TileXY: " + TileXY.ToString());

            using (FileStream fileStream = new FileStream(@input, FileMode.Open, FileAccess.Read))
            {
                using (DeflateStream deflateStream = new DeflateStream(fileStream, CompressionMode.Decompress))
                {
                    using (BinaryReader binaryReader = new BinaryReader(deflateStream))
                    {
                        string string_0 = binaryReader.ReadString();
                        string string_1 = binaryReader.ReadString();
                        string string_2 = binaryReader.ReadString();
                        string string_3 = binaryReader.ReadString();

                        Console.WriteLine("String_0: " + string_0);
                        Console.WriteLine("String_1: " + string_1);
                        Console.WriteLine("String_2: " + string_2);
                        Console.WriteLine("String_3: " + string_3);

                        (int[] buffer, VertexPositionNormalTexture[] VBO) = smethod_1(binaryReader);

                        // load world items
                        List<Class239> list_4 = new List<Class239>();
                        int NumberOfWorldItems = binaryReader.ReadInt32();
                        Console.WriteLine("NumberOfWorldItems: " + NumberOfWorldItems);
                        for (int i = 0; i < NumberOfWorldItems; i++)
                        {
                            Class239 @class = new Class239
                            {
                                list_0 = new List<Class487>()
                            };
                            int num2 = binaryReader.ReadInt32();
                            Console.WriteLine("num2: " + num2);
                            for (int j = 0; j < num2; j++)
                            {
                                Vector3 v = new Vector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
                                Console.WriteLine("j[" + j + "]v:" + v.ToString());
                                Class487 class2 = new Class487
                                {
                                    vector3_2 = v
                                };
                                int num3 = binaryReader.ReadInt32();
                                Console.WriteLine("num3: " + num3);
                                for (int k = 0; k < num3; k++)
                                {
                                    int asd = binaryReader.ReadInt32();
                                    class2.list_0.Add(asd);
                                    Console.WriteLine("k[" + k + "]int:" + asd);
                                }
                                class2.vector3_0 = new Vector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
                                Console.WriteLine("j[" + j + "]vector3_0:" + class2.vector3_0.ToString());
                                class2.vector3_1 = new Vector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
                                Console.WriteLine("j[" + j + "]vector3_1:" + class2.vector3_1.ToString());
                                class2.float_0 = binaryReader.ReadSingle();
                                Console.WriteLine("j[" + j + "]float_0:" + class2.float_0);
                                class2.string_0 = binaryReader.ReadString();
                                Console.WriteLine("j[" + j + "]string_0:" + class2.string_0);
                                //if (class2.string_0.EndsWith("_VerticalJWG"))
                                //{
                                //    class2.enum50_0 = Enum50.const_1;
                                //    class2.string_0 = class2.string_0.Replace("_VerticalJWG", "");
                                //}
                                @class.list_0.Add(class2);
                            }
                            @class.bool_0 = binaryReader.ReadBoolean();
                            Console.WriteLine("i[" + i + "]bool_0:" + @class.bool_0);
                            @class.string_0 = binaryReader.ReadString();
                            Console.WriteLine("i[" + i + "]string_0:" + @class.string_0);
                            @class.vector3_0 = new Vector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
                            Console.WriteLine("i[" + i + "]vector3_0:" + @class.vector3_0.ToString());
                            @class.vector3_1 = new Vector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
                            Console.WriteLine("i[" + i + "]vector3_1:" + @class.vector3_1.ToString());
                            @class.vector3_2 = new Vector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
                            Console.WriteLine("i[" + i + "]vector3_2:" + @class.vector3_2.ToString());
                            @class.tileIndex_0 = new Vector2(binaryReader.ReadInt32(), binaryReader.ReadInt32());
                            Console.WriteLine("i[" + i + "]TileXY:" + @class.tileIndex_0.ToString());
                            list_4.Add(@class);

                            bool bool_6 = false;
                            @class.vector3_1.X = MathUtil.DegreesToRadians(@class.vector3_1.X);
                            @class.vector3_1.Y = MathUtil.DegreesToRadians(@class.vector3_1.Y);
                            @class.vector3_1.Z = MathUtil.DegreesToRadians(@class.vector3_1.Z);
                            Matrix matrix = Matrix.RotationYawPitchRoll(@class.vector3_1.Y * (bool_6 ? -1f : 1f), @class.vector3_1.X, @class.vector3_1.Z);

                            @class.vector3_0 += matrix.Up * 67.8052f;
                            @class.vector3_0 += matrix.Up * 67.8052f;
                            @class.vector3_0 += matrix.Forward * -6.4f;
                            @class.vector3_0 += matrix.Right * 0.5f;

                            Console.WriteLine("i[" + i + "]vector3_1:" + @class.vector3_1.ToString());
                            Console.WriteLine("i[" + i + "]vector3_0:" + @class.vector3_0.ToString());
                        }

                        //if(list_4.Count == 0)
                        //{
                        //    Console.WriteLine("no world items, cant get tile coordinates");
                        //    return;
                        //}

                        Console.WriteLine("Index Buffer has " + buffer.Length + " elements");
                        Console.WriteLine("VBO has " + VBO.Length + " elements");

                        for (int i = 0; i < VBO.Length; i++)
                        {
                            VBO[i].TextureCoordinate.X = VBO[i].Position.X / 844.3211f;
                            VBO[i].TextureCoordinate.Y = -VBO[i].Position.Z / 1026.0822f;

                            VBO[i].Position.X = (VBO[i].Position.X + (TileXY.X * 844.3211f));
                            VBO[i].Position.Z = (VBO[i].Position.Z - (TileXY.Y * 1026.0822f));
                        }

                        ObjFile objFile = new ObjFile();

                        foreach (VertexPositionNormalTexture v in VBO)
                        {
                            objFile.Vertices.Add(new ObjVertex(v.Position.X, v.Position.Y, v.Position.Z));
                            objFile.VertexNormals.Add(new ObjVector3(v.Normal.X, v.Normal.Y, v.Normal.Z));
                            objFile.TextureVertices.Add(new ObjVector3(v.TextureCoordinate.X, v.TextureCoordinate.Y, 0));
                        }

                        foreach (var faceVerts in buffer.Batch(3))
                        {
                            ObjFace face = new ObjFace();
                            foreach (var faceVert in faceVerts)
                            {
                                ObjTriplet v = new ObjTriplet(faceVert + 1, faceVert + 1, faceVert + 1);
                                face.Vertices.Add(v);
                            }
                            objFile.Faces.Add(face);
                        }

                        objFile.WriteTo(@output);
                    }
                }
            }
        }

        static (int[], VertexPositionNormalTexture[]) smethod_1(BinaryReader binaryReader)
        {
            Class482[,] class482_0 = new Class482[25, 25];
            int num_0 = 0;
            for (byte b = 0; b < 25; b++)
            {
                for (byte b2 = 0; b2 < 25; b2++)
                {
                    class482_0[b, b2] = new Class482();
                    class482_0[b, b2].short_0 = (short)binaryReader.ReadInt32();
                    // Console.WriteLine(b + "," + b2 + "; short_0: " + class482_0[b, b2].short_0);
                    class482_0[b, b2].float_0 = new float[class482_0[b, b2].short_0, class482_0[b, b2].short_0];
                    class482_0[b, b2].byte_0 = b;
                    class482_0[b, b2].byte_1 = b2;

                    for (int i = 0; i < class482_0[b, b2].short_0; i++)
                    {
                        for (int j = 0; j < class482_0[b, b2].short_0; j++)
                        {
                            class482_0[b, b2].float_0[i, j] = binaryReader.ReadSingle();
                            // Console.WriteLine(b + "," + b2 + "; float_0[" + i + "," + j + "]: " + class482_0[b, b2].float_0[i, j]);
                            if (class482_0[b, b2].float_0[i, j] <= 1.4f)
                            {
                                num_0++;
                            }
                        }
                    }
                }
            }

            bool bool_0 = num_0 > 100;
            try
            {
                float float_2 = binaryReader.ReadSingle();
                float float_3 = binaryReader.ReadSingle();
                float float_4 = binaryReader.ReadSingle();
                float float_5 = binaryReader.ReadSingle();
                string string_5 = binaryReader.ReadString();

                Console.WriteLine("float_2: " + float_2);
                Console.WriteLine("float_3: " + float_3);
                Console.WriteLine("float_4: " + float_4);
                Console.WriteLine("float_5: " + float_5);
                Console.WriteLine("string_5: " + string_5);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to read");
            }

            return smethod_13(class482_0);
        }

        static (int[], VertexPositionNormalTexture[]) smethod_13(Class482[,] class482_0)
        {
            float num = 33.772842f;
            float num2 = 41.043285f;
            List<int> list = new List<int>();
            int num3 = 0;


            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    int num4 = 0;
                    class482_0[i, j].vertexPositionNormalTexture_0 = new VertexPositionNormalTexture[(int)(class482_0[i, j].short_0 * class482_0[i, j].short_0)];
                    for (int k = 0; k < class482_0[i, j].short_0; k++)
                    {
                        for (int l = 0; l < class482_0[i, j].short_0; l++)
                        {
                            VertexPositionNormalTexture vertexPositionNormalTexture = default(VertexPositionNormalTexture);

                            vertexPositionNormalTexture.Position.X = i * num + num / (class482_0[i, j].short_0 - 1) * k;
                            vertexPositionNormalTexture.Position.Z = -(j * num2 + num2 / (class482_0[i, j].short_0 - 1) * l);
                            vertexPositionNormalTexture.Position.Y = class482_0[i, j].float_0[k, l];
                            vertexPositionNormalTexture.TextureCoordinate.X = vertexPositionNormalTexture.Position.X / 844.3211f;
                            vertexPositionNormalTexture.TextureCoordinate.Y = -vertexPositionNormalTexture.Position.Z / 1026.0822f;

                            class482_0[i, j].vertexPositionNormalTexture_0[num4] = vertexPositionNormalTexture;
                            num3++;
                            num4++;
                        }
                    }
                    smethod_11(class482_0[i, j].short_0, num3, list);
                    CalculateNormals(class482_0[i, j].vertexPositionNormalTexture_0);
                }
            }

            List<VertexPositionNormalTexture> list2 = new List<VertexPositionNormalTexture>(num3);

            for (int m = 0; m < 25; m++)
            {
                for (int n = 0; n < 25; n++)
                {
                    for (int num5 = 0; num5 < class482_0[m, n].vertexPositionNormalTexture_0.Length; num5++)
                    {
                        list2.Add(class482_0[m, n].vertexPositionNormalTexture_0[num5]);
                    }
                    class482_0[m, n].vertexPositionNormalTexture_0 = null;
                }
            }

            VertexPositionNormalTexture[] vertexPositionNormalTexture_0 = list2.ToArray();

            Vector2 vector2_0 = new Vector2(422.16055f, 513.0411f);
            float float_0 = (float)((double)(vertexPositionNormalTexture_0[0].Position.Y + vertexPositionNormalTexture_0[vertexPositionNormalTexture_0.Length - 1].Position.Y) / 2.0);

            return (list.ToArray(), vertexPositionNormalTexture_0);
        }

        static void CalculateNormals(VertexPositionNormalTexture[] vertexPositionNormalTexture_0)
        {
            for (int i = 0; i < vertexPositionNormalTexture_0.Length; i++)
            {
                vertexPositionNormalTexture_0[i].Normal = Vector3.Zero;
            }
            int num = (int)Math.Sqrt(vertexPositionNormalTexture_0.Length);
            for (int j = 0; j < num - 1; j++)
            {
                for (int k = 0; k < num - 1; k++)
                {
                    Vector3 right = vertexPositionNormalTexture_0[j * num + k + 1].Position - vertexPositionNormalTexture_0[j * num + k].Position;
                    Vector3 right2 = Vector3.Cross(vertexPositionNormalTexture_0[(j + 1) * num + k].Position - vertexPositionNormalTexture_0[j * num + k].Position, right);
                    int num2 = j * num + k + 1;
                    vertexPositionNormalTexture_0[num2].Normal = vertexPositionNormalTexture_0[num2].Normal + right2;
                    int num3 = j * num + k;
                    vertexPositionNormalTexture_0[num3].Normal = vertexPositionNormalTexture_0[num3].Normal + right2;
                    int num4 = (j + 1) * num + k;
                    vertexPositionNormalTexture_0[num4].Normal = vertexPositionNormalTexture_0[num4].Normal + right2;
                    right = vertexPositionNormalTexture_0[(j + 1) * num + k].Position - vertexPositionNormalTexture_0[(j + 1) * num + (k + 1)].Position;
                    right2 = Vector3.Cross(vertexPositionNormalTexture_0[j * num + k + 1].Position - vertexPositionNormalTexture_0[(j + 1) * num + (k + 1)].Position, right);
                    int num5 = (j + 1) * num + k;
                    vertexPositionNormalTexture_0[num5].Normal = vertexPositionNormalTexture_0[num5].Normal + right2;
                    int num6 = (j + 1) * num + (k + 1);
                    vertexPositionNormalTexture_0[num6].Normal = vertexPositionNormalTexture_0[num6].Normal + right2;
                    int num7 = j * num + k + 1;
                    vertexPositionNormalTexture_0[num7].Normal = vertexPositionNormalTexture_0[num7].Normal + right2;
                }
            }
            for (int l = 0; l < vertexPositionNormalTexture_0.Length; l++)
            {
                vertexPositionNormalTexture_0[l].Normal.Normalize();
            }
        }

        static void smethod_11(int int_0, int int_1, List<int> list_0)
        {
            int num = int_1 - int_0 * int_0;
            for (int i = 0; i < int_0 - 1; i++)
            {
                for (int j = 0; j < int_0 - 1; j++)
                {
                    int item = j + i * int_0 + num;
                    int item2 = j + 1 + i * int_0 + num;
                    int item3 = j + (i + 1) * int_0 + num;
                    int item4 = j + 1 + (i + 1) * int_0 + num;
                    list_0.Add(item3);
                    list_0.Add(item);
                    list_0.Add(item2);
                    list_0.Add(item3);
                    list_0.Add(item2);
                    list_0.Add(item4);
                }
            }
        }
    }
}
