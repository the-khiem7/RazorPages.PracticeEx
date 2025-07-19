using BusinessObjects;

namespace DAL
{
    public class LionTypeRepo : ILionTypeRepo
    {
        public LionType GetLionTypeById(int id)
        {
            var context = new Su25lionDbContext();
            var cc = context.LionTypes.Find(id);
            context.Dispose();
            return cc;
        }

        public List<LionType> GetLionTypes()
        {
            var context = new Su25lionDbContext();
            var list = context.LionTypes.ToList();
            context.Dispose();
            return list;
        }
    }
}
