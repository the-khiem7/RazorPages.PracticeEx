using BusinessObjects;
using DAL;

namespace BUL
{
    public class LionTypeService : ILionTypeService
    {
        private readonly ILionTypeRepo _repo;
        public LionTypeService(ILionTypeRepo repo)
        {
            _repo = repo;
        }
        public List<LionType> GetLionTypes()
        {
            return _repo.GetLionTypes();
        }
    }
}
