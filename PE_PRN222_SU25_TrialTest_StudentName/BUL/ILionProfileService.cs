using BusinessObjects;

namespace BUL
{
    public interface ILionProfileService
    {
        void Save(LionProfile lionProfile);
        void Delete(LionProfile lionProfile);
        void Update(LionProfile lionProfile);
        List<LionProfile> GetAll();
        LionProfile GetById(int lionProfileId);
        List<LionProfile> Search(double? weight, string lionTypeName);
    }
}
