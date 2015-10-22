using System;
using System.Collections.Generic;
using System.Text;

namespace System.Net
{
	public partial class DataUri
	{

		/// <summary>
		/// Parses a string for a data-uri
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static DataUri Parse(string value)
		{
			if(value == null) throw new ArgumentNullException("value");

			if(value.StartsWith("data:") == false) throw new ArgumentException("A data-uri must start with 'data'.");

			byte[] bytes;
			string mediaType;
			ParseInternal(value, out mediaType, out bytes);

			if(mediaType == "") mediaType = "text/plain";

			return new DataUri(mediaType, bytes);
		}

		private static void ParseInternal(string value, out string mediatype, out byte[] bytes)
		{
			mediatype = null; //cant guarantee it ever gets set.
			bool base64encoding=false;
			bytes = null;

			int parseState = 0; int charIndex = 4; int lastCharIndex = -1; bool parseStateChanged = false;
			StringBuilder sb = new StringBuilder();
			while(charIndex < value.Length)
			{
				switch(value[charIndex])
				{
					case ':':
						parseState = 1; parseStateChanged = true; //media-type
						lastCharIndex = charIndex;
						break;
					case ';':
						parseState += 1; parseStateChanged = true; //increment
						lastCharIndex = charIndex;
						break;
					case ',':
						parseState = 4; parseStateChanged = true;
						lastCharIndex = charIndex;
						break;
				}

				if(parseStateChanged==false && parseState > 0 && charIndex < value.Length)
					sb.Append(value[charIndex]);

				charIndex++; 
				
				
				if(parseStateChanged)
				{
					switch(parseState)
					{
						case 2:
							mediatype = sb.ToString(); sb.Length=0;
							break;
						case 4:
							if(sb.ToString() == "base64")
								base64encoding = true;
							sb.Length = 0;
							break;
					}
					parseStateChanged = false;
					
					if(parseState == 4) break;
				}

			}

			bytes = ParseInternal_ReadBytes(value, charIndex, base64encoding);
		}

		private static byte[] ParseInternal_ReadBytes(string value, int charIndex, bool base64encoding)
		{
			if(base64encoding)
			{
				return Convert.FromBase64String(value.Substring(charIndex));
			}
			else
			{
				throw new NotImplementedException();
			}
		}

	}
}
