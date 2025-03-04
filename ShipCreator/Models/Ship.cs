using System.ComponentModel.DataAnnotations;
namespace ShipCreator.Models;

public class Ship
{
    public Guid ShipID { get; set; }
    
    [Required]
    [StringLength(60, MinimumLength = 3)]
    public string Name { get; set; }
    
    [Required]
    [RegularExpression("^(Brigantine|Sloop|Galleon)$",
        ErrorMessage = "Ship type must be Brigantine, Sloop, or Galleon")]
    [Display(Name = "Ship Type")]
    public string Type { get; set; }
    
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Miles traveled must be a positive number greater than 0.")]
    public int NauticalMilage { get; set; }
    
    [Required]
    [RegularExpression("^(Guardians of Fortune|Reaper's Bones|Servants of the Flame)$",
        ErrorMessage = "Pledged Faction must be Guardians of Fortune, Reaper's Bones, or Servants of the Flame")]
    [Display(Name = "Pledged Faction")]
    public string PledgedFaction { get; set; }
}