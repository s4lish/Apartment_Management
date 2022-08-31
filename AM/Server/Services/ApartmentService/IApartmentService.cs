namespace AM.Server.Services.ApartmentService
{
    public interface IApartmentService
    {
        Task<ApartmentInfoView> GetInfo();
        Task<bool> SetInfo(ApartmentInfoView info);
    }
}
