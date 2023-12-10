using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace app.Utility.UtilityServices
{
    public class UtilityService : IUtilityService
    {
        public string GetEnumDescription(Enum en)
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

        public List<object> GetEnumSelectionList<T>()
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
