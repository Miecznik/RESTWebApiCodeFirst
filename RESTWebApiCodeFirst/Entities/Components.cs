using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RESTWebApiCodeFirst.Entities;


[Table("Components")]
[PrimaryKey(nameof(Code))]
public class Components
{
    [Key]
    [MaxLength(10)]
    public string Code { get; set; }
    [MaxLength(300)]
    public string Name { get; set; }
    [MaxLength(300)]
    public string Description { get; set; }
    public int ComponentManufacturersId { get; set; }
    public int ComponentTypesId { get; set; }

    public ICollection<PCComponents> PCComponents { get; set; } = [];
    
    [ForeignKey(nameof(ComponentManufacturersId))]
    public ComponentManufacturers ComponentManufacturers { get; set; }
    
    [ForeignKey(nameof(ComponentTypesId))]
    public ComponentTypes ComponentTypes { get; set; }
}