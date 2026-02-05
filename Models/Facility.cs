namespace WebApiProject.Models;

public class Facility
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsWorking { get; set; }
    public DateTime TimeRunning { get; set; }
}