namespace InterviewBKO.Application.DTOs;

public class EquipmentDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string SerialNumber { get; set; } = string.Empty;
    public bool IsOperational { get; set; }
    public long FacilityId { get; set; }
}

public class CreateEquipmentDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string SerialNumber { get; set; } = string.Empty;
    public bool IsOperational { get; set; }
    public long FacilityId { get; set; }
}

public class UpdateEquipmentDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string SerialNumber { get; set; } = string.Empty;
    public bool IsOperational { get; set; }
}