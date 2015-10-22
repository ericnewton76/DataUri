using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace DataUriTests
{
	[TestFixture]
	public class DataUri_Output_Tests
	{

		[Test]
		[TestCase("image/jpeg","41424344454647", "data:image/jpeg;base64,QUJDREVGRw==")]
		public void ToString(string mediatype, string hexbytes, string expectedOutput)
		{
			//arrange
			var datauri = new DataUri(mediatype, ByteArrayHelpers.HexStringToByteArray(hexbytes));

			//act
			var actual = datauri.ToString();

			//assert
			Assert.That(actual, Is.EqualTo(expectedOutput));
		}

	}
}
