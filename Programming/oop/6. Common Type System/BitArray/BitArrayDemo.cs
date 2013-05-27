using System;

namespace BitArray
{
    class BitArrayDemo
    {
        static void Main()
        {
            try
            {
                BitArray64 bArr = new BitArray64(34);
                BitArray64 bArrTwo = new BitArray64(34);

                foreach (int b in bArr) Console.Write(b);
                Console.WriteLine();
                Console.WriteLine("Hash code: {0}", bArr.GetHashCode());

                bArr[5] = 0;

                foreach (byte b in bArr) Console.Write(b);
                Console.WriteLine();

                Console.WriteLine("Hash code now: {0}", bArr.GetHashCode());

                bArr[5] = 1; // bArr = 34 again

                Console.WriteLine("bArr == bArrTwo : {0}", (bArr == bArrTwo));
                Console.WriteLine("bArr != bArrTwo : {0}", (bArr != bArrTwo));
                Console.WriteLine("bArr equals bArrTwo : {0}", bArr.Equals(bArrTwo));

                bArrTwo[24] = 1;
                Console.WriteLine("bArr equals bArrTwo : {0}", bArr.Equals(bArrTwo));
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
