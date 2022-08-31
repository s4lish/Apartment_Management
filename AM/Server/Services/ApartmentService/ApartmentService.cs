using AutoMapper.QueryableExtensions;

namespace AM.Server.Services.ApartmentService
{
    public class ApartmentService : IApartmentService
    {
        private readonly ApartmentDB _db;
        private readonly IMapper _mapper;


        public ApartmentService(ApartmentDB db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ApartmentInfoView> GetInfo()
        {
            var apartmenInfo = await _db.ApartmentInfo.ProjectTo<ApartmentInfoView>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();


            return apartmenInfo ?? new ApartmentInfoView();
        }

        public async Task<bool> SetInfo(ApartmentInfoView info)
        {
            try
            {

                var apartment = _mapper.Map<ApartmentInfo>(info);

                var check = await _db.ApartmentInfo.FirstOrDefaultAsync();

                if (check == null)
                {
                    await _db.ApartmentInfo.AddAsync(apartment);
                }
                else
                {
                    
                    check.Address = apartment.Address;
                    check.Title = apartment.Title;
                    check.UnitNumber = apartment.UnitNumber;
                    check.PhoneNumber = apartment.PhoneNumber;


                }

                await _db.SaveChangesAsync();


                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
