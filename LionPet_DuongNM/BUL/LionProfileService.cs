using BusinessObjects;
using DAL;

namespace BUL
{
    public class LionProfileService : ILionProfileService
    {
        private readonly ILionProfileRepo repo;
        public LionProfileService(ILionProfileRepo repo)
        {
            this.repo = repo;
        }
        public void Delete(LionProfile lionProfile)
        {
            repo.Delete(lionProfile.LionProfileId);
        }

        public List<LionProfile> GetAll()
        {
            return repo.GetAll();
        }

        public LionProfile GetById(int lionProfileId)
        {
            return repo.GetById(lionProfileId);
        }

        public void Save(LionProfile lionProfile)
        {
            repo.Add(lionProfile);
        }

        public List<LionProfile> Search(double? weight, string lionTypeName)
        {
            return repo.Search(weight, lionTypeName);
        }

        public void Update(LionProfile lionProfile)
        {
            repo.Update(lionProfile);
        }
    }
}
