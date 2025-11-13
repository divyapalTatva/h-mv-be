using MedVault.BE.Data.Context;
using MedVault.BE.Data.Entities.Master;
using MedVault.BE.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace MedVault.BE.Data.Repositories
{
    public class DocumentCategoryRepository(MedVaultDbContext medVaultDbContext) : IDocumentCategoryRepository
    {
        public async Task<List<DocumentCategory>> GetDocumentCategoryForDropdown()
        {
            return await medVaultDbContext.DocumentCategories
                .AsNoTracking()
                .OrderBy(g => g.DocumentCategoryName)
                .ToListAsync();
        }
    }
}
