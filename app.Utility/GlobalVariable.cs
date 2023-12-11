﻿using System.ComponentModel;
using System.Reflection;

namespace app.Utility
{
    public static class GlobalVariable
    {
        public static string GetEnumDescription(Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return en.ToString();
            
        }

        public static List<object> GetEnumSelectionList<T>()
        {
            var list = new List<object>();

            foreach (var item in Enum.GetValues(typeof(T)))
            {
                list.Add(new { Value = (int)item, Text = GetEnumDescription((Enum)Enum.Parse(typeof(T), item.ToString())) });
            }
            return list;
           
        }
    }
}
