using MedVault.BE.Data.Entities.Master;

namespace MedVault.BE.Data.IRepositories
{
    public interface IDocumentCategoryRepository
    {
        Task<List<DocumentCategory>> GetDocumentCategoryForDropdown();
    }
}
