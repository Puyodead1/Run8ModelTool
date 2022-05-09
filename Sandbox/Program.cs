using SharpDX;
using System.Text;

namespace Sandbox
{
    public static class Sandbox
    {

        public static void Log<T>(T arg, string paramName)
        {
            Console.WriteLine($"{paramName}: {arg}");
        }

        //public static void Log<T>(T arg, string prefix)
        //{
        //    string paramName = nameof(arg);
        //    Console.WriteLine($"[{prefix}]{paramName}: {arg}");
        //}

        //public static void Log<T>(T arg, string prefix, int prefix2)
        //{
        //    string paramName = nameof(arg);
        //    Console.WriteLine($"{prefix2}[{prefix}]{paramName}: {arg}");
        //}

        public static int Main(string[] args)
        {
            List<Vector4> list_0 = new List<Vector4>();
            using (FileStream fileStream = new FileStream("C:\\Run8Studios\\Run8 Train Simulator V3\\Content\\V3Routes\\Regions\\SouthernCA\\Config.ind", FileMode.Open))
            {
                using (BinaryReader binaryReader = new BinaryReader(fileStream))
                {
                    vmethod_1(binaryReader);
                }
            }
            return 0;
        }

        internal static void vmethod_1(BinaryReader binaryReader_0)
        {
            Console.WriteLine($"skip: {binaryReader_0.ReadInt32()}");
            int NumberOfIndustries = binaryReader_0.ReadInt32();
            Console.WriteLine($"NumberOfIndustries: {NumberOfIndustries}");
            for (int i = 0; i < NumberOfIndustries; i++)
            {
                method_3(binaryReader_0);
            }
        }

        static void method_3(BinaryReader binaryReader_0)
        {
            binaryReader_0.ReadInt32();
            string IndustryName = smethod_10(binaryReader_0);
            Console.WriteLine($"IndustryName: {IndustryName}");
            string LocalCode = smethod_10(binaryReader_0);
            Console.WriteLine($"LocalCode: {LocalCode}");
            string IndustryTag = smethod_10(binaryReader_0);
            Console.WriteLine($"IndustryTag: {IndustryTag}");
            bool bool_0 = binaryReader_0.ReadBoolean();
            Console.WriteLine($"bool_0(method_3): {bool_0}");
            int NumberOfTracks = binaryReader_0.ReadInt32();
            Console.WriteLine($"NumberOfTracks: {NumberOfTracks}");
            for (int i = 0; i < NumberOfTracks; i++)
            {
                method_1_645(binaryReader_0);
            }
            int NumberOfCars = binaryReader_0.ReadInt32();
            Console.WriteLine($"NumberOfCars: {NumberOfCars}");
            for (int j = 0; j < NumberOfCars; j++)
            {
                method_1_648(binaryReader_0);
            }
            Console.Write("\n");
        }

        internal static void method_1_645(BinaryReader binaryReader_0)
        {
            binaryReader_0.ReadInt32();
            int Prefix = binaryReader_0.ReadInt32();
            Console.WriteLine($"Prefix: {Prefix}");
            int Section = binaryReader_0.ReadInt32();
            Console.WriteLine($"Section: {Section}");
            int Node = binaryReader_0.ReadInt32();
            Console.WriteLine($"Node: {Node}");
        }

        internal static void method_1_648(BinaryReader binaryReader_0)
        {
            int num = binaryReader_0.ReadInt32();
            Console.WriteLine($"num(method_1_648): {num}");
            ECarType ecarType_0 = (ECarType)binaryReader_0.ReadByte();
            Console.WriteLine($"CarType: {ecarType_0}");
            bool bool_0 = binaryReader_0.ReadBoolean();
            Console.WriteLine($"bool_0(method_1_648): {bool_0}");
            int Time = binaryReader_0.ReadInt32();
            Console.WriteLine($"Time: {Time}");
            int Capacity = binaryReader_0.ReadInt32();
            Console.WriteLine($"Capacity: {Capacity}");
            int DestinationCount = binaryReader_0.ReadInt32();
            Console.WriteLine($"DestinationCount: {DestinationCount}");
            for (int i = 0; i < DestinationCount; i++)
            {
                string s = smethod_10(binaryReader_0);
                Console.WriteLine($"Destination[{i}]: {s}");
            }
            if (num >= 2)
            {
                int num3 = binaryReader_0.ReadInt32();
                for (int j = 0; j < num3; j++)
                {
                    string s = smethod_10(binaryReader_0);
                    Console.WriteLine($"j[{j}](method_1_648): {s}");
                }
            }
        }
        static string smethod_10(BinaryReader binaryReader_0)
		{
			int count = binaryReader_0.ReadInt32();
            return smethod_3(binaryReader_0.ReadBytes(count));
		}

        static string smethod_3(byte[] byte_0)
        {
            byte[] array = new byte[byte_0.Length / 2];
            int num = 0;
            for (int i = 0; i < array.Length; i++)
            {
                byte[] array2 = array;
                int num2 = i;
                array2[num2] |= (byte)(byte_0[num++] << 4);
                byte[] array3 = array;
                int num3 = i;
                array3[num3] |= (byte)(byte_0[num++] >> 4);
            }
            return Encoding.UTF8.GetString(array);
        }
    }
}
