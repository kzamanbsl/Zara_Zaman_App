namespace app.Utility.UtilityServices
{
    public class UtilityService : IUtilityService
    {
        public string GetEnumDescription(Enum en)
        {
            var result = GlobalVariable.GetEnumDescription(en);
            return result;
        }

        public List<EnumSelectListModel> GetEnumSelectionList<T>()
        {
            var result = GlobalVariable.GetEnumSelectionList<T>();
            return result;
        }
    }
}
