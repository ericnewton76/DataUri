using System;

using NUnit.Framework;

using System.Net;

namespace DataUriTests
{
	[TestFixture]
	public class DataUriTypeConverterTests
	{
		[Test]
		public void CanConvertFrom_String_Returns_True()
		{
			//arrange
			DataUriTypeConverter c = Create_DataUriTypeConverter();

			//act
			var actual = c.CanConvertFrom(typeof(string));

			//assert
			Assert.That(actual, Is.EqualTo(true));

		}

		[Test]
		public void ConvertTo_DataUri()
		{
			//arrange
			var value = "data:image/jpeg;base64,QUJDREVGRw==";

			var expected_DataUri = new DataUri("image/jpeg", new byte[] { 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47 });

			//act
			var typeconverter = Create_DataUriTypeConverter();
			var actual_DataUri = (DataUri)typeconverter.ConvertFrom(value);

			//assert
			Assert.That(actual_DataUri, Is.Not.Null);
			Assert.That(actual_DataUri, Is.TypeOf<System.DataUri>());
			//Assert.That(actual_DataUri.MediaType, Is.EqualTo("image/jpeg"));
			//Assert.That(actual_DataUri.Bytes, Is.EqualTo(expected_DataUri.Bytes));
		}

		DataUriTypeConverter Create_DataUriTypeConverter()
		{
			return new DataUriTypeConverter();
		}
	}
}
