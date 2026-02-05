using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewBKO.Core.Entities;

public class Facility
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public bool IsWorking { get; set; }

    public DateTime TimeRunning { get; set; }

    public ICollection<Equipment> Equipments { get; set; } = new List<Equipment>();

    public long? ParentId { get; set; }

    [ForeignKey("ParentId")]
    public Facility? Parent { get; set; }

    public ICollection<Facility> Children { get; set; } = new List<Facility>();
}