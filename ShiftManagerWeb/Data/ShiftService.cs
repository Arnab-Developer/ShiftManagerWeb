using Microsoft.Extensions.Options;
using ShiftManagerWeb.Options;
using System.Text.Json;

namespace ShiftManagerWeb.Data;

internal class ShiftService : IShiftService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IOptionsMonitor<ShiftOptions> _shiftOptionsAccessor;

    public ShiftService(IHttpClientFactory httpClientFactory,
        IOptionsMonitor<ShiftOptions> shiftOptionsAccessor)
    {
        _httpClientFactory = httpClientFactory;
        _shiftOptionsAccessor = shiftOptionsAccessor;
    }

    public async Task CreateEmployeeAsync(string firstName, string lastName)
    {
        var url = $"{_shiftOptionsAccessor.CurrentValue.ShiftUrl}/create-employee?firstName={firstName}&lastName={lastName}";
        using var httpClient = _httpClientFactory.CreateClient();
        using var apiResponseMessage = await httpClient.PostAsync(url, default);

        apiResponseMessage.EnsureSuccessStatusCode();
    }

    public async Task UpdateEmployeeAsync(int employeeId, string firstName, string lastName)
    {
        var url = $"{_shiftOptionsAccessor.CurrentValue.ShiftUrl}/update-employee?employeeId={employeeId}&firstName={firstName}&lastName={lastName}";
        using var httpClient = _httpClientFactory.CreateClient();
        using var apiResponseMessage = await httpClient.PostAsync(url, default);

        apiResponseMessage.EnsureSuccessStatusCode();
    }

    public async Task AddScheduleAsync(int employeeId, DateTime date, Shift shift)
    {
        var url = $"{_shiftOptionsAccessor.CurrentValue.ShiftUrl}/add-schedule?employeeId={employeeId}&date={date}&shift={shift}";
        using var httpClient = _httpClientFactory.CreateClient();
        using var apiResponseMessage = await httpClient.PutAsync(url, default);

        apiResponseMessage.EnsureSuccessStatusCode();
    }

    public async Task UpdateScheduleAsync(int employeeId, DateTime date, Shift shift)
    {
        var url = $"{_shiftOptionsAccessor.CurrentValue.ShiftUrl}/update-schedule?employeeId={employeeId}&date={date}&shift={shift}";
        using var httpClient = _httpClientFactory.CreateClient();
        using var apiResponseMessage = await httpClient.PutAsync(url, default);

        apiResponseMessage.EnsureSuccessStatusCode();
    }

    public async Task DeleteScheduleAsync(int employeeId, DateTime date)
    {
        var url = $"{_shiftOptionsAccessor.CurrentValue.ShiftUrl}/delete-schedule?employeeId={employeeId}&date={date}";
        using var httpClient = _httpClientFactory.CreateClient();
        using var apiResponseMessage = await httpClient.DeleteAsync(url);

        apiResponseMessage.EnsureSuccessStatusCode();
    }

    public async Task DeleteEmployeeAsync(int employeeId)
    {
        var url = $"{_shiftOptionsAccessor.CurrentValue.ShiftUrl}/delete-employee?employeeId={employeeId}";
        using var httpClient = _httpClientFactory.CreateClient();
        using var apiResponseMessage = await httpClient.DeleteAsync(url, default);

        apiResponseMessage.EnsureSuccessStatusCode();
    }

    public async Task<IEnumerable<Schedule>> GetSchedulesAsync(string firstName, string lastName)
    {
        var url = $"{_shiftOptionsAccessor.CurrentValue.ShiftUrl}/get-schedule-by-name?firstName={firstName}&lastName={lastName}";
        using var httpClient = _httpClientFactory.CreateClient();
        using var apiResponseMessage = await httpClient.GetAsync(url);

        apiResponseMessage.EnsureSuccessStatusCode();

        using var apiResponseStream = await apiResponseMessage.Content.ReadAsStreamAsync();
        var schedules = await JsonSerializer.DeserializeAsync<IEnumerable<Schedule>>(apiResponseStream);
        return schedules ?? Enumerable.Empty<Schedule>();
    }

    public async Task<IEnumerable<Schedule>> GetSchedulesAsync(DateTime date)
    {
        var url = $"{_shiftOptionsAccessor.CurrentValue.ShiftUrl}/get-schedule-by-date?date={date}";
        using var httpClient = _httpClientFactory.CreateClient();
        using var apiResponseMessage = await httpClient.GetAsync(url);

        apiResponseMessage.EnsureSuccessStatusCode();

        using var apiResponseStream = await apiResponseMessage.Content.ReadAsStreamAsync();
        var schedules = await JsonSerializer.DeserializeAsync<IEnumerable<Schedule>>(apiResponseStream);
        return schedules ?? Enumerable.Empty<Schedule>();
    }

    public async Task<IEnumerable<Schedule>> GetSchedulesAsync(Month month)
    {
        var url = $"{_shiftOptionsAccessor.CurrentValue.ShiftUrl}/get-schedule-by-month?month={month}";
        using var httpClient = _httpClientFactory.CreateClient();
        using var apiResponseMessage = await httpClient.GetAsync(url);

        apiResponseMessage.EnsureSuccessStatusCode();

        using var apiResponseStream = await apiResponseMessage.Content.ReadAsStreamAsync();
        var schedules = await JsonSerializer.DeserializeAsync<IEnumerable<Schedule>>(apiResponseStream);
        return schedules ?? Enumerable.Empty<Schedule>();
    }
}