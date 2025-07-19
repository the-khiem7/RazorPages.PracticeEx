using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class LionProfileRepo : ILionProfileRepo
    {
        public void Add(LionProfile profile)
        {
            var context = new Su25lionDbContext();
            try
            {
                context.Add(profile);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("error at add", ex);
            }
            finally
            {
                context.Dispose();
            }
        }

        public void Delete(int id)
        {
            var context = new Su25lionDbContext();
            try
            {
                var p = context.LionProfiles.Find(id);
                context.Remove(p);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("error at add", ex);
            }
            finally
            {
                context.Dispose();
            }
        }

        public List<LionProfile> GetAll()
        {
            var context = new Su25lionDbContext();
            var list = new List<LionProfile>();
            try
            {
                list = context.LionProfiles.Include(p => p.LionType).ToList();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("error at add", ex);
            }
            finally
            {
                context.Dispose();
            }
        }

        public LionProfile? GetById(int id)
        {
            var context = new Su25lionDbContext();
            try
            {
                return context.LionProfiles.Include(p => p.LionType)
                    .FirstOrDefault(p => p.LionProfileId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("error at add", ex);
            }
            finally
            {
                context.Dispose();
            }
        }

        public List<LionProfile> Search(double? weight, string lionTypeName)
        {
            var context = new Su25lionDbContext();
            var query = context.LionProfiles.Include(x => x.LionType).AsQueryable();

            if (weight.HasValue || !string.IsNullOrEmpty(lionTypeName))
            {
                query = query.Where(x =>
                    (weight.HasValue && x.Weight == weight.Value) ||
                    (!string.IsNullOrEmpty(lionTypeName) && x.LionType.LionTypeName.Contains(lionTypeName))
                );
            }

            return query.OrderByDescending(x => x.ModifiedDate).ToList();
        }

        public void Update(LionProfile profile)
        {
            var context = new Su25lionDbContext();
            try
            {
                context.Entry<LionProfile>(profile).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("error at add", ex);
            }
            finally
            {
                context.Dispose();
            }
        }
    }
}
