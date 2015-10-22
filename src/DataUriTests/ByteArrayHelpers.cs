using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataUriTests
{
	internal class ByteArrayHelpers
	{

		public static byte[] HexStringToByteArray(string hexString) //http://stackoverflow.com/a/8235530/323456
		{
			if(hexString.Length % 2 != 0)
			{
				throw new ArgumentException("The hex values string cannot have an odd number of digits.");
			}

			byte[] HexAsBytes = new byte[hexString.Length / 2];
			for(int index = 0; index < HexAsBytes.Length; index++)
			{
				string byteValue = hexString.Substring(index * 2, 2);
				HexAsBytes[index] = byte.Parse(byteValue, System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.InvariantCulture);
			}

			return HexAsBytes;
		}

	}
}
