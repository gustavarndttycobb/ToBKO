using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewBKO.Core.Entities;


public class Equipment
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }


    public string Name { get; set; } = string.Empty;


    public string Description { get; set; } = string.Empty;


    public string SerialNumber { get; set; } = string.Empty;
    public bool IsOperational { get; set; }

    public long FacilityId { get; set; }

    [ForeignKey("FacilityId")]
    public Facility Facility { get; set; } = null!;
}