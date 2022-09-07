
namespace AM.Server;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<ApartmentInfo, ApartmentInfoView>().ReverseMap();
        CreateMap<UnitInfo, UnitInfoView>().ReverseMap();

        //CreateMap<LocationBackUp, LocationBackUpDTO>().ReverseMap(); // do tarafe


    }

}

