using BusinessObjects;

namespace DAL
{
    public interface ILionTypeRepo
    {
        List<LionType> GetLionTypes();
        LionType GetLionTypeById(int id);
    }
}
