using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace System
{

	[TypeConverter(typeof(DataUriTypeConverter))]
	public sealed partial class DataUri
	{

		/// <summary>
		/// Construct a new DataUri instance
		/// </summary>
		/// <param name="bytes"></param>
		public DataUri(byte[] bytes)
		{
			if (bytes == null) throw new ArgumentNullException("bytes");
			this.Bytes = bytes;
		}

		/// <summary>
		/// Construct a new DataUri instance
		/// </summary>
		/// <param name="mediaType"></param>
		/// <param name="bytes"></param>
		public DataUri(string mediaType, byte[] bytes) : this(bytes)
		{
			this.MediaType = mediaType;
		}

		/// <summary>
		/// Gets the bytes for this data-uri instance.
		/// </summary>
		public byte[] Bytes { get; private set; }

		/// <summary>
		/// Gets the Media type for this data-uri instance.
		/// </summary>
		public string MediaType { get; private set; }

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

	}
}
