using MedVault.BE.Common.Constants;
using System.ComponentModel.DataAnnotations;

namespace MedVault.BE.Common.Models.Request
{
    public class PageListRequest
    {
        public string? SearchQuery { get; set; } = string.Empty;

        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = SystemConstant.DEFAULT_PAGE_SIZE;

        [RegularExpression(ValidationConstants.SORT_ORDER_REGEX, ErrorMessage = ExceptionMessage.VALIDATE_SORT_ORDER)]
        public string SortOrder { get; set; } = SystemConstant.ASCENDING;

        public string SortColumn { get; set; } = SystemConstant.DEFAULT_SORT_COLUMN;

        public PageListRequest()
        {
            PageIndex = PageIndex < 1 ? 1 : PageIndex;
            PageSize = PageSize < 1 ? SystemConstant.DEFAULT_PAGE_SIZE : PageSize;
        }
    }
}
