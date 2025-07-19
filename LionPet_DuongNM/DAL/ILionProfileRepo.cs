using BusinessObjects;

namespace DAL
{
    public interface ILionProfileRepo
    {
        List<LionProfile> GetAll();
        LionProfile? GetById(int id);
        void Add(LionProfile profile);
        void Update(LionProfile profile);
        void Delete(int id);
        List<LionProfile> Search(double? weight, string lionTypeName);
    }
}
