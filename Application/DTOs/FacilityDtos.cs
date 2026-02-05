namespace InterviewBKO.Application.DTOs;

public class FacilityDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsWorking { get; set; }
    public DateTime TimeRunning { get; set; }
    public List<EquipmentDto> Equipments { get; set; } = new();
    public long? ParentId { get; set; }
    public List<FacilityDto> Children { get; set; } = new();
}

public class CreateFacilityDto
{
    public string Name { get; set; } = string.Empty;
    public bool IsWorking { get; set; }
    public DateTime TimeRunning { get; set; }
    public long? ParentId { get; set; }
}

public class UpdateFacilityDto
{
    public string Name { get; set; } = string.Empty;
    public bool IsWorking { get; set; }
    public DateTime TimeRunning { get; set; }
    public long? ParentId { get; set; }
}