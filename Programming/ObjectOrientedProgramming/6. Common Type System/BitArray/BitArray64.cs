using System;
using System.Collections.Generic;
using System.Collections;

namespace BitArray
{
    public class BitArray64 : IEnumerable<int>
    {
        private ulong bits;

        public ulong Bits
        {
            get { return bits; }
            set { bits = value; }
        }

        public BitArray64(ulong bits)
        {
            this.bits = bits;
        }

        public override bool Equals(object bitArray)
        {
            return bits.Equals((bitArray as BitArray64).bits);
        }

        public override int GetHashCode()
        {
            return bits.GetHashCode();
        }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index > 63) throw new IndexOutOfRangeException("Index out of range (must be between 0 and 63!)");
                return (int)((bits & ((ulong)1 << index)) >> index);
            }
            set
            {
                if (index < 0 || index > 63) throw new IndexOutOfRangeException("Index out of range (must be between 0 and 63!)");
                bits = (value == 0) ? (bits & ~((ulong)1 << index)) : (bits | ((ulong)1 << index));
            }
        }

        public static bool operator ==(BitArray64 bits1, BitArray64 bits2)
        {
            return (bits1.bits == bits2.bits);
        }

        public static bool operator !=(BitArray64 bits1, BitArray64 bits2)
        {
            return (bits1.bits != bits2.bits);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < 64; i++)
            {
                yield return this[i];
            }
        }
    }
}
