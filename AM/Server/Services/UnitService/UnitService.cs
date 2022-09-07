using AutoMapper.QueryableExtensions;

namespace AM.Server.Services.UnitService
{
    public class UnitService : IUnitService
    {
        private readonly ApartmentDB _db;
        private readonly IMapper _mapper;

        public UnitService(ApartmentDB dB, IMapper mapper)
        {
            _db = dB;
            _mapper = mapper;
        }

        public async Task<bool> ChangeActiveStatus(int Id)
        {
            try
            {
                var unit = await _db.UnitInfo.FindAsync(Id);

                unit.isActive = !unit.isActive;

                await _db.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Pagination<UnitInfoView>> Get(int PageNumber, int PageSize,string filter1)
        {
            var query = _db.UnitInfo.OrderBy(o => o.Id).AsQueryable().ProjectTo<UnitInfoView>(_mapper.ConfigurationProvider);

            if (!string.IsNullOrEmpty(filter1))
            {
                query = query.Where(x => x.MobileMalek.Contains(filter1) || x.MobileMostajer.Contains(filter1) || x.NameFamilyMalek.Contains(filter1) || x.NameFamilyMostajer.Contains(filter1) || x.NumberUnit == filter1 || x.NumberParking == filter1);
            }

            var pagedList = await PagedList<UnitInfoView>.ToPagedList(query, PageNumber, PageSize);

            return pagedList;
        }

        public async Task<bool> SetUnit(UnitInfoView unit)
        {
            try
            {
                var newUnit = _mapper.Map<UnitInfo>(unit);

                newUnit.Password = PubliceService.GetRandomString(8,"0123456789");

                await _db.UnitInfo.AddAsync(newUnit);
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
