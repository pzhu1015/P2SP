/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-5-16
 * Time: 15:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Reflection;

namespace Helper
{
	/// <summary>
	/// Description of EnumHelper.
	/// </summary>
	public class EnumHelper
	{
		public EnumHelper()
		{
		}
		
		public static string GetEnumDescription(Enum value)
		{
		    FieldInfo fi = value.GetType().GetField(value.ToString());
		
		    DescriptionAttribute[] attributes =
		        (DescriptionAttribute[])fi.GetCustomAttributes(
		        typeof(DescriptionAttribute),
		        false);
		
		    if (attributes != null &&
		        attributes.Length > 0)
		        return attributes[0].Description;
		    else
		        return value.ToString();
		}
	}
}
