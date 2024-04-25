
namespace app.Utility.UtilityServices
{
    public interface IUtilityService
    {
        string GetEnumDescription(Enum en);
        List<EnumSelectListModel> GetEnumSelectionList<T>();
    }
}


