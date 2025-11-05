namespace MedVault.BE.Data.Entities.Common
{
    public interface IAuditableEntity
    {
        bool IsDeleted { get; set; }

        DateTime CreatedAt { get; set; }

        int? CreatedBy { get; set; }

        DateTime? UpdatedAt { get; set; }

        int? UpdatedBy { get; set; }
    }
}