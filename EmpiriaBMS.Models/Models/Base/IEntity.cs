
namespace EmpiriaBMS.Models.Models
{
    public interface IEntity
    {
        long Id { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime LastUpdatedDate { get; set; }

        bool IsDeleted { get; set; }
    }
}