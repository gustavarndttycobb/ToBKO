namespace InterviewBKO.Application.DTOs;

public class FacilityDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsWorking { get; set; }
    public DateTime TimeRunning { get; set; }
}

public class CreateFacilityDto
{
    public string Name { get; set; } = string.Empty;
    public bool IsWorking { get; set; }
    public DateTime TimeRunning { get; set; }
}

public class UpdateFacilityDto
{
    public string Name { get; set; } = string.Empty;
    public bool IsWorking { get; set; }
    public DateTime TimeRunning { get; set; }
}