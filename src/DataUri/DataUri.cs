using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace System
{

	[TypeConverter(typeof(DataUriTypeConverter))]
	[Serializable]
	public sealed partial class DataUri : System.Xml.Serialization.IXmlSerializable
	{

		private DataUri() { }

		/// <summary>
		/// Construct a new DataUri instance
		/// </summary>
		/// <param name="bytes"></param>
		public DataUri(byte[] bytes)
		{
			if (bytes == null) throw new ArgumentNullException("bytes");
			this._Bytes = bytes;
		}

		/// <summary>
		/// Construct a new DataUri instance
		/// </summary>
		/// <param name="mediaType"></param>
		/// <param name="bytes"></param>
		public DataUri(string mediaType, byte[] bytes) : this(bytes)
		{
			this._MediaType = mediaType;
		}

		private byte[] _Bytes;
		private string _MediaType;

		/// <summary>
		/// Gets the bytes for this data-uri instance.
		/// </summary>
		public byte[] Bytes 
		{
			get { return this._Bytes; }
		}

		/// <summary>
		/// Gets the Media type for this data-uri instance.
		/// </summary>
		public string MediaType
		{
			get { return _MediaType; }
		}

		public override string ToString()
		{
			return ToString("B");
		}

		public string ToString(string format)
		{
			if(format == null) throw new ArgumentNullException("format");

			switch(format)
			{
				case "B":
					return "data:" + this.MediaType + ";base64," + Convert.ToBase64String(this.Bytes);
				default:
					throw new ArgumentException(string.Format("Unexpected format '{0}'.", format));
			}
		}



		public Xml.Schema.XmlSchema GetSchema()
		{
			throw new NotImplementedException();
		}

		void System.Xml.Serialization.IXmlSerializable.ReadXml(Xml.XmlReader reader)
		{
			var content = reader.ReadInnerXml();

			string mediatype;
			byte[] bytes;
			ParseInternal(content, out mediatype, out bytes);

			this._MediaType = mediatype;
			this._Bytes = bytes;
		}

		void System.Xml.Serialization.IXmlSerializable.WriteXml(Xml.XmlWriter writer)
		{
			writer.WriteValue(this.ToString());
		}
	}
}
