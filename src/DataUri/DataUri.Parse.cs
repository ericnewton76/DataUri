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

			throw new NotImplementedException();
		}

	}
}
