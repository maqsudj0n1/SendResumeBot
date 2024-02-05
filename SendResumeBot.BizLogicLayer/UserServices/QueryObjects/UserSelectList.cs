using WEBASE.Models;

namespace SendResumeBot.BizLogicLayer.Services;

public static class UserSelectList
{
    public static PagedSelectList<int> AsSelectList(this PagedResult<UserListDto> pagedResult)
    {
        return new PagedSelectList<int>(
            pagedResult,
            pagedResult
                .Rows
                .Select(a => new SelectListItem<int>
                {
                    Value = a.Id,
                    Text = a.FullName
                }));
    }
}
