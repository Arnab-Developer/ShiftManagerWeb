namespace ShiftManagerWeb.Data;

internal interface IShiftService
{
    public Task CreateEmployeeAsync(string firstName, string lastName);

    public Task UpdateEmployeeAsync(int employeeId, string firstName, string lastName);

    public Task AddScheduleAsync(int employeeId, DateTime date, Shift shift);

    public Task UpdateScheduleAsync(int employeeId, DateTime date, Shift shift);

    public Task DeleteScheduleAsync(int employeeId, DateTime date);

    public Task DeleteEmployeeAsync(int employeeId);

    public Task<IEnumerable<Schedule>> GetSchedulesAsync(string firstName, string lastName);

    public Task<IEnumerable<Schedule>> GetSchedulesAsync(DateTime date);

    public Task<IEnumerable<Schedule>> GetSchedulesAsync(Month month);
}