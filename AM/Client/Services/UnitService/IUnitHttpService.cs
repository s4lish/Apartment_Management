using MudBlazor;

namespace AM.Client.Services.UnitService
{
    public interface IUnitHttpService
    {
        Task<bool> SetInfo(UnitInfoView unit);
        Task<TableData<UnitInfoView>> GetInfo(PaginationParameters parameters);

        Task<bool> ChangeActiveStatus(int Id);

    }
}
