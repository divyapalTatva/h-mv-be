using MedVault.BE.Common.Models.Request;
using MedVault.BE.Common.Models.Response;
using MedVault.BE.Data.Context;
using MedVault.BE.Data.Entities.Master;
using MedVault.BE.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedVault.BE.Data.Repositories
{
    public class HospitalRepository(MedVaultDbContext medVaultDbContext) : BaseRepository, IHospitalRepository
    {
        public async Task<PageListResponse<Hospital>> GetHospitalsByPagination(PageListRequest pageListRequest)
        {
            var query = medVaultDbContext.Hospitals;

            var sortingExpression = new Dictionary<string, Expression<Func<Hospital, object>>>
            {
                ["STATUS"] = c => c.IsActive
            };

            return await GetPagedListAsync(
                query,
                pageListRequest,
                (query, request) =>
                {
                    return query;
                },
                x => new Hospital
                {
                    Id = x.Id,
                    HospitalName = x.HospitalName,
                    Address = x.Address,
                    ContactNumber = x.ContactNumber,
                    IsActive = x.IsActive
                },
                sortingExpression
            );
        }

        public async Task<List<Hospital>> GetHospitalsForDropdown()
        {
            return await medVaultDbContext.Hospitals
                .AsNoTracking()
                .OrderBy(g => g.HospitalName)
                .Select(x => new Hospital
                {
                    Id = x.Id,
                    HospitalName = x.HospitalName,
                    IsActive = x.IsActive
                })
                .ToListAsync();
        }
    }
}
