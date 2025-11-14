using MedVault.BE.Common.Models.Request;
using MedVault.BE.Common.Models.Response;
using MedVault.BE.Data.Context;
using MedVault.BE.Data.Entities.Patient;
using MedVault.BE.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedVault.BE.Data.Repositories
{
    public class PatientHistoryRepository(MedVaultDbContext medVaultDbContext) : BaseRepository, IPatientHistoryRepository
    {
        public async Task<PatientHistory?> GetLastPatientHistoryByUserId(int userId)
        {
            return await medVaultDbContext.PatientHistories
                                          .Include(x => x.PatientProfile)
                                          .OrderByDescending(x => x.Id)
                                          .FirstOrDefaultAsync(a => a.PatientProfile.UserId == userId);
        }

        public async Task<int> GetPatientHistoryCountByUserId(int userId)
        {
            return await medVaultDbContext.PatientHistories
                                          .Include(x => x.MedicalDocumentes)
                                          .Include(x => x.PatientProfile)
                                          .AsNoTracking()
                                          .Where(a => a.PatientProfile.UserId == userId)
                                          .CountAsync();
        }

        public async Task<int> GetTotoalCheckupByUserId(int userId)
        {
            return await medVaultDbContext.PatientHistories
                                          .Include(x => x.DoctorProfile)
                                          .AsNoTracking()
                                          .Where(a => a.DoctorProfile.UserId == userId)
                                          .CountAsync();
        }

        public async Task<PageListResponse<PatientHistory>> GetPatientHistoryByPagination(PatientHistoryListRequest patientHistoryListRequest)
        {
            var query = medVaultDbContext.PatientHistories
                                         .Include(x => x.MedicalDocumentes)
                                            .ThenInclude(x => x.DocumentCategory)
                                         .Include(x => x.DoctorProfile)
                                            .ThenInclude(x => x.User);

            var sortingExpression = new Dictionary<string, Expression<Func<PatientHistory, object>>>
            {
                ["createdat"] = c => c.CreatedAt
            };

            return await GetPagedListAsync(
                query,
                patientHistoryListRequest,
                (query, request) =>
                {
                    if (request.DocotorId > 0)
                        query = query.Where(d => d.DoctorId == request.DocotorId);

                    if (request.CreatedDate.HasValue)
                        query = query.Where(d => d.CreatedAt.Date == request.CreatedDate.Value.Date);

                    if (request.CategoryType > 0)
                        query = query.Where(d => d.MedicalDocumentes.Any(x => x.DocumentCategoryId == request.CategoryType));

                    return query;
                },
                x => x,
                sortingExpression
            );
        }

        public async Task<int> AddPatientHistory(PatientHistory patientHistory)
        {
            await medVaultDbContext.PatientHistories.AddAsync(patientHistory);
            await medVaultDbContext.SaveChangesAsync();
            return patientHistory.Id;
        }

        public async Task UpdatePatientHistory(PatientHistory patientHistory)
        {
            medVaultDbContext.PatientHistories.Update(patientHistory);
            await medVaultDbContext.SaveChangesAsync();
        }

        public async Task<PatientHistory?> GetPatientHistoryById(int id)
        {
            return await medVaultDbContext.PatientHistories
                                          .Include(q => q.PatientProfile)
                                            .ThenInclude(q => q.User)
                                          .Include(q => q.DoctorProfile)
                                            .ThenInclude(q => q.User)
                                          .Include(q => q.MedicalDocumentes)
                                          .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
