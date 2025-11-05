using MedVault.BE.Common.Constants;
using MedVault.BE.Common.Models.Request;
using MedVault.BE.Common.Models.Response;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;

namespace MedVault.BE.Data.Repositories
{
    public abstract class BaseRepository
    {
        protected async Task<PageListResponse<TResponse>> GetPagedListAsync<TEntity, TRequest, TResponse>(
            IQueryable<TEntity> query,
            TRequest requestModel,
            Func<IQueryable<TEntity>, TRequest, IQueryable<TEntity>>? customFilters,
            Expression<Func<TEntity, TResponse>> selector,
            Dictionary<string, Expression<Func<TEntity, object>>>? sortExpressions = null
        )
            where TEntity : class
            where TRequest : PageListRequest
        {
            if (customFilters != null)
                query = customFilters(query, requestModel);

            query = query.AsNoTracking();

            int totalRecords = await query.CountAsync();

            if (!string.IsNullOrEmpty(requestModel.SortColumn))
            {
                bool isAscending = string.Equals(requestModel.SortOrder, SystemConstant.ASCENDING, StringComparison.OrdinalIgnoreCase);

                if (sortExpressions != null && sortExpressions.TryGetValue(requestModel.SortColumn.ToLower(), out var sortExpr))
                {
                    query = isAscending ? query.OrderBy(sortExpr) : query.OrderByDescending(sortExpr);
                }
                else
                {
                    // fallback to dynamic string-based OrderBy
                    query = query.OrderBy(
                        $"{requestModel.SortColumn} {(isAscending ? SystemConstant.ASCENDING : SystemConstant.DESCENDING)}"
                    );
                }
            }

            if (requestModel.PageIndex >= 1 && requestModel.PageSize > 0)
            {
                int skip = (requestModel.PageIndex - 1) * requestModel.PageSize;
                query = query.Skip(skip).Take(requestModel.PageSize);
            }

            var items = await query.Select(selector).ToListAsync();

            return new PageListResponse<TResponse>(
                requestModel.PageIndex,
                requestModel.PageSize,
                totalRecords,
                items
            );
        }
    }
}
