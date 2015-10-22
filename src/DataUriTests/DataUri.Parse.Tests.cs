using System;
using System.Collections.Generic;
using NUnit.Framework;
using DataUri = System.Net.DataUri;

namespace DataUriTests
{
	[TestFixture]
	public class DataUri_Parse_Tests
	{
		
		[Test]
		[TestCase("data:;base64,QUJDREVGR0hJSktMTU5PUFFSU1RVVldYWVo=", "4142434445464748494A4B4C4D4E4F505152535455565758595A")]
		[TestCase("data:;base64,TG9yZW0gaXBzdW0gZG9sYXIgc2l0IGFtb3Q=", "4c6f72656d20697073756d20646f6c61722073697420616d6f74")]
		public void Parse_Base64_NoMediaType(string input, string expectedBytesStr)
		{
			//arrange
			byte[] expectedBytes = HexStringToByteArray(expectedBytesStr);
			string expected_MediaType = "text/plain"; //if not specified, media type is assumed to be text/plain

			//act
			var datauri = DataUri.Parse(input);

			//assert
			Assert.That(datauri, Is.Not.Null);
			Assert.That(datauri.Bytes, Is.EqualTo(expectedBytes));
			Assert.That(datauri.MediaType, Is.EqualTo(expected_MediaType)); 
		}

		[Test]
		[TestCase("data:image/jpeg;base64,QUJDREVGR0hJSktMTU5PUFFSU1RVVldYWVo=", "4142434445464748494A4B4C4D4E4F505152535455565758595A")]
		[TestCase("data:image/jpeg;base64,TG9yZW0gaXBzdW0gZG9sYXIgc2l0IGFtb3Q=", "4c6f72656d20697073756d20646f6c61722073697420616d6f74")]
		public void Parse_Base64_Specified_MediaType(string input, string expectedBytesStr)
		{
			//arrange
			byte[] expectedBytes = HexStringToByteArray(expectedBytesStr);
			string expected_MediaType = "image/jpeg"; //if not specified, media type is assumed to be text/plain

			//act
			var datauri = DataUri.Parse(input);

			//assert
			Assert.That(datauri, Is.Not.Null);
			Assert.That(datauri.Bytes, Is.EqualTo(expectedBytes));
			Assert.That(datauri.MediaType, Is.EqualTo(expected_MediaType));
		}

		[Test]
		[TestCase("DATA:base64,QUJDREVGR0hJSktMTU5PUFFSU1RVVldYWVo=")]
		[TestCase("http://base64,TG9yZW0gaXBzdW0gZG9sYXIgc2l0IGFtb3Q=")]
		public void Must_start_with_data_throws_ArgumentException(string input)
		{
			//assert
			
			//act

			//assert
			Assert.Throws<ArgumentException>(() => {
				DataUri.Parse(input);
			});
		}

		[Test]
		public void Null_Value_throws_ArgumentNullException()
		{
			//assert
			
			//act

			//assert
			Assert.Throws<ArgumentNullException>(() => {
				DataUri.Parse((string)null);
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