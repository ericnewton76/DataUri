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

			int charIndex = 5;
			
			if(value.Substring(charIndex,6)=="base64")
			{
				charIndex += 7; //accounts for the ,
				string base64string = value.Substring(charIndex);
				byte[] bytes = Convert.FromBase64String(base64string);
				return new DataUri(bytes);
			}

			return null;
		}

	}
}
