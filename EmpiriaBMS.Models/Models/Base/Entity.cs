using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpiriaBMS.Models.Models;
public class Entity : IEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime CreatedDate { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime LastUpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public Entity()
    {
        CreatedDate = DateTime.Now.ToUniversalTime();
        LastUpdatedDate = DateTime.Now.ToUniversalTime();
    }
}