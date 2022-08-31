namespace AM.Client.Services.ApartmentService
{
    public interface IApartmentHttpService
    {
        Task<ApartmentInfoView> Get();
        Task<bool> SetInfo(ApartmentInfoView info);
    }
}
