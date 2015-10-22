using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
	public class DataUriTypeConverter : System.ComponentModel.TypeConverter
	{

		public override bool CanConvertFrom(ComponentModel.ITypeDescriptorContext context, Type sourceType)
		{
			if(sourceType == typeof(string))
				return true;

			return base.CanConvertFrom(context, sourceType);
		}

		public override object ConvertFrom(ComponentModel.ITypeDescriptorContext context, Globalization.CultureInfo culture, object value)
		{
			if(value is string)
			{
				return DataUri.Parse((string)value);
			}
			return base.ConvertFrom(context, culture, value);
		}
	}
}
