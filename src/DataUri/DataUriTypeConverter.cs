using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
	public class DataUriTypeConverter : System.ComponentModel.TypeConverter
	{
		public override bool IsValid(ComponentModel.ITypeDescriptorContext context, object value)
		{
			string valstr = value as string;
			if(valstr != null)
			{
				if(valstr.StartsWith("data:"))
					return true;
			}
			return false;
		}
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
				string valstr = value as string;
				if(string.IsNullOrEmpty(valstr) == false && valstr.StartsWith("data:"))
					return DataUri.Parse(valstr);
				else
					return null;
			}
			return base.ConvertFrom(context, culture, value);
		}
	}
}
