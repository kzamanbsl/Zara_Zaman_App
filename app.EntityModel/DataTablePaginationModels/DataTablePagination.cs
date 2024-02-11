namespace app.EntityModel.DataTablePaginationModels;

public class DataTablePagination<T> where T : class
{
    public DataTablePagination()
    {
        Search = new DataTableGlobalSearch();
    }

    public int? Draw { get; set; }
    public int? Start { get; set; }
    public int? Length { get; set; }
    public DataTableGlobalSearch Search { get; set; }
    public T SearchVm { get; set; }
    public List<T> Data { get; set; }=new List<T>();
    public int RecordsFiltered { get; set; }
    public int RecordsTotal { get; set; }
}
