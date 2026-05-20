using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RESTWebApiCodeFirst.Entities;
[Table("PCComponents")]
[PrimaryKey(nameof(PCId), nameof(ComponentCode))]
public class PCComponents
{
    
    public int PCId { get; set; }
    [MaxLength(10)]
    public string ComponentCode { get; set; }
    public int Amount { get; set; }
    
    [ForeignKey(nameof(PCId))]
    public PCs PCs { get; set; }
    [ForeignKey(nameof(ComponentCode))]
    public Components Component { get; set; }
    
}