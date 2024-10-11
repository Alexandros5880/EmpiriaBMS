namespace EmpiriaBMS.Core.Dtos.Base
{
    public interface IEntityDto
    {
        public long Id { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime LastUpdatedDate { get; set; }
        bool IsDeleted { get; set; }
    }
}