using System;
using NUnit.Framework;

using DataUri = System.DataUri;

namespace DataUriTests
{
	[TestFixture]
	public class DataUriTests
	{
		
		[Test]
		public void ctor_Null_Bytes_throws_ArgumentNullException()
		{
			//arrange

			//act

			//assert
			Assert.Throws<ArgumentNullException>(()=>{
				new DataUri((byte[])null);
			});
		}
		[Test]
		public void ctor2_Null_Bytes_throws_ArgumentNullException()
		{
			//arrange

			//act

			//assert
			Assert.Throws<ArgumentNullException>(() =>
			{
				new DataUri((string)null,(byte[])null);
			});
		}

		#region test helpers
		public static byte[] HexStringToByteArray(string hexString) //http://stackoverflow.com/a/8235530/323456
		{
			if (hexString.Length % 2 != 0)
			{
				throw new ArgumentException("The hex values string cannot have an odd number of digits.");
			}

			byte[] HexAsBytes = new byte[hexString.Length / 2];
			for (int index = 0; index < HexAsBytes.Length; index++)
			{
				string byteValue = hexString.Substring(index * 2, 2);
				HexAsBytes[index] = byte.Parse(byteValue, System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.InvariantCulture);
			}

			return HexAsBytes;
		}
		#endregion

	}
}