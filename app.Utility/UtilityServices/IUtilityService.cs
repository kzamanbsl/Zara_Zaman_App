using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Utility.UtilityServices
{
    public interface IUtilityService
    {
        string GetEnumDescription(Enum en);
        List<object> GetEnumSelectionList<T>();
    }
}


