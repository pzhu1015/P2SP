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
	public static class EnumHelper
	{	
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

        /// <summary>
        /// 获取枚举描述
        /// </summary>
        /// <param name="enumName"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum enumName)
        {
            string description;
            FieldInfo fieldInfo = enumName.GetType().GetField(enumName.ToString());
            DescriptionAttribute[] attributes = GetDescriptAttr(fieldInfo);
            if (attributes != null && attributes.Length > 0)
            {
                description = attributes[0].Description;
            }
            else
            {
                throw new ArgumentException($"{enumName} not found description", nameof(enumName));
            }
            return description;
        }
        
        /// <summary>
        /// 获取枚举描述属性
        /// </summary>
        /// <param name="fieldInfo"></param>
        /// <returns></returns>
        private static DescriptionAttribute[] GetDescriptAttr(this FieldInfo fieldInfo)
        {
            return (DescriptionAttribute[])fieldInfo?.GetCustomAttributes(typeof(DescriptionAttribute), false);
        }
        
        /// <summary>
        /// 通过描述获取枚举值
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="description"></param>
        /// <returns></returns>
        public static TEnum GetEnum<TEnum>(string description)
        {
            Type type = typeof(TEnum);
            foreach (FieldInfo field in type.GetFields())
            {
                DescriptionAttribute[] curDesc = GetDescriptAttr(field);
                if (curDesc != null && curDesc.Length > 0)
                {
                    if (curDesc[0].Description == description)
                        return (TEnum)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (TEnum)field.GetValue(null);
                }
            }
            throw new ArgumentException($"{description} not found enum.", nameof(description));
        }
	}
}
