using System.ComponentModel.DataAnnotations.Schema;

namespace EasyInventory_Backend.Profiles.Domain.Model.Aggregates;

public partial class ProfileAudit
{
    [Column("CreatedAt")]
    public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdatedAt")]
    public DateTimeOffset? UpdatedDate { get; set; }
    
}