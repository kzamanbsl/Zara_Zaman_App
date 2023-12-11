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
            var result = GlobalVariable.GetEnumDescription(en);
            return result;
        }

        public List<object> GetEnumSelectionList<T>()
        {
            var result = GlobalVariable.GetEnumSelectionList<T>();
            return result;
        }
    }
}
