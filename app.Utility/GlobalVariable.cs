using System.ComponentModel;
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

        public static List<EnumSelectListModel> GetEnumSelectionList<T>()
        {
            var list = new List<EnumSelectListModel>();

            foreach (var item in Enum.GetValues(typeof(T)))
            {
                list.Add(new EnumSelectListModel() { Value = (int)item, Text = GetEnumDescription((Enum)Enum.Parse(typeof(T), item.ToString())) });
            }
            return list;
           
        }

        public static string FormatDateForView(DateTime? date)
        {
            var strDate = "";
            if (date == null) { return strDate; }

            var dt=(DateTime) date;
            strDate = dt.ToString("dd-MM-yyyy");

            return strDate;

        }

        public static string FormatDateTimeForView(DateTime? date)
        {
            var strDateTime = "";
            if (date == null) { return strDateTime; }

            var dt = (DateTime)date;
            strDateTime = dt.ToString("dd-MM-yyyy hh:mm tt");
            return strDateTime;

        }

        public static string FormatTimeForView(DateTime? date)
        {
            var strTime = "";
            if (date == null) { return strTime; }

            var dt = (DateTime)date;
            //strTime = dt.ToString("hh:mm:ss tt");
            strTime = dt.ToString("hh:mm tt");
            return strTime;

        }
    }
}
