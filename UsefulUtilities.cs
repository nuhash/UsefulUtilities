#define UNITY 
using System;
#if UNITY
using UnityEngine;
#endif
namespace NuHash.UsefulUtilities
{
	public class NMath {
		#if UNITY
		public static Vector3 ScalarProduct3(Vector3 a,Vector3 b){
			return new Vector3(a.x*b.x,a.y*b.y,a.z*b.z);
		}
		#endif

		static int[] tab64 = new int[64]{
			63,  0, 58,  1, 59, 47, 53,  2,
			60, 39, 48, 27, 54, 33, 42,  3,
			61, 51, 37, 40, 49, 18, 28, 20,
			55, 30, 34, 11, 43, 14, 22,  4,
			62, 57, 46, 52, 38, 26, 32, 41,
			50, 36, 17, 19, 29, 10, 13, 21,
			56, 45, 25, 31, 35, 16,  9, 12,
			44, 24, 15,  8, 23,  7,  6,  5};
		
		public static byte Log2_64 (UInt64 value)
		{
			value |= value >> 1;
			value |= value >> 2;
			value |= value >> 4;
			value |= value >> 8;
			value |= value >> 16;
			value |= value >> 32;
			return (byte)tab64[(((value - (value >> 1))*0x07EDD5E59A4E28C2)) >> 58];
		}

		public static UInt64 IntPow(UInt64 x, UInt64 pow)
		{
			UInt64 ret = 1;
			while ( pow != 0ul )
			{
				if ( (pow & 1ul) == 1ul )
					ret *= x;
				x *= x;
				pow >>= 1;
			}
			return ret;
		}
	}
}

