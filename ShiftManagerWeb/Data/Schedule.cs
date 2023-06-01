namespace ShiftManagerWeb.Data;

internal class Schedule
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("date")]
    public DateTime Date { get; set; }

    [JsonPropertyName("shift")]
    public Shift Shift { get; set; }

    [JsonPropertyName("employee")]
    public Employee Employee { get; set; }

    public Schedule()
    {
        Employee = new Employee();
    }
}