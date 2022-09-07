namespace AM.Server.Services.UnitService
{
    public interface IUnitService
    {
        Task<bool> SetUnit(UnitInfoView unit);
        Task<Pagination<UnitInfoView>> Get(int PageNumber, int PageSize,string filter1);

        Task<bool> ChangeActiveStatus(int Id);

    }
}
