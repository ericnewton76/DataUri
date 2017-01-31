using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;
using NUnit.Framework;

namespace DataUriTests
{
	[TestFixture]
	public class DataUriSerializationTests
	{

		[Test]
		public void DataContractSerializer_CanSerialize()
		{
			//arrange
			var ms = new System.IO.MemoryStream();
			var dataUri = new DataUri("text/plain", new byte[] { 0x40, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49 });
			var serializer = new System.Runtime.Serialization.DataContractSerializer(typeof(DataUri));

			var expectedVal = "data:text/plain;base64,QEFCQ0RFRkdISQ==";

			//act
			serializer.WriteObject(ms, dataUri);

			var streamString = System.Text.Encoding.UTF8.GetString(ms.ToArray());
			XDocument xdoc = XDocument.Parse("<root>" + streamString + "</root>");
			XElement datauriEl = xdoc.Element("root").Element(XName.Get("DataUri","http://schemas.datacontract.org/2004/07/System"));

			//assert

			Assert.That(datauriEl.Value, Is.EqualTo(expectedVal));
		}
		[Test]
		public void DataContractSerializer_CanSerializeObject()
		{
			//arrange
			var ms = new System.IO.MemoryStream();
			
			var sampleModelObject = new MockObject() { 
				image = new DataUri("text/plain", new byte[] { 0x40, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49 } )
			};
			var serializer = new System.Runtime.Serialization.DataContractSerializer(typeof(DataUri));

			var expectedVal = "data:text/plain;base64,QEFCQ0RFRkdISQ==";

			//act
			serializer.WriteObject(ms, sampleModelObject);

			var streamString = System.Text.Encoding.UTF8.GetString(ms.ToArray());
			XDocument xdoc = XDocument.Parse("<root>" + streamString + "</root>");
			XElement datauriEl = xdoc.Element("root").Element(XName.Get("DataUri", "http://schemas.datacontract.org/2004/07/System"));

			//assert

			Assert.That(datauriEl.Value, Is.EqualTo(expectedVal));
		}


	}

	[Serializable]
	[KnownType(typeof(DataUri))]
	[KnownType(typeof(MockObject))]
	public class MockObject
	{


		[DataMember]
		public DataUri image { get; set; }
	}

}
