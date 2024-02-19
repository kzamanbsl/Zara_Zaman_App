using app.EntityModel.DataTablePaginationModels;
using app.Services.ProductServices;

namespace app.Services.AttendanceServices
{
    public interface IAttendanceService
    {
        Task<bool> AddRecord(AttendanceViewModel vm);
        Task<bool> UpdateRecord(AttendanceViewModel vm);
        Task<AttendanceViewModel> GetRecordById(long id);
        Task<AttendanceViewModel> CheckEmployeeTodaysAttendance(long employeeId, DateTime date);
        Task<bool> DeleteRecord(long id);
        Task<AttendanceViewModel> GetAllRecord();
        Task<DataTablePagination<AttendanceSearchDto>> SearchAsync(DataTablePagination<AttendanceSearchDto> searchDto);
    }
}
