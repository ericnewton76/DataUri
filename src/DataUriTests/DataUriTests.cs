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

	}
}