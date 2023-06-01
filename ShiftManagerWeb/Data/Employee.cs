namespace ShiftManagerWeb.Data;

internal class Employee
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }

    [JsonPropertyName("lastName")]
    public string LastName { get; set; }

    [JsonPropertyName("schedules")]
    public IList<Schedule> Schedules { get; set; }

    public Employee()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Schedules = Enumerable.Empty<Schedule>().ToList();
    }
}