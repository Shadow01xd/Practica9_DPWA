using HospitalProyect.Data;
using HospitalProyect.Models;

namespace HospitalProyect.Repositories
{
    public class RoleRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public RoleRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public List<RoleModel> GetAll()
        {
            return _applicationDbContext.RoleModel.ToList();
        }

        public RoleModel GetById(int id)
        {
            return _applicationDbContext.RoleModel.FirstOrDefault(r => r.Id == id);
        }

        public void Add(RoleModel roleModel)
        {
            _applicationDbContext.RoleModel.Add(roleModel);
            _applicationDbContext.SaveChanges();
        }

        public void Update(RoleModel roleModel)
        {
            _applicationDbContext.RoleModel.Update(roleModel);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var role = _applicationDbContext.RoleModel.Find(id);

            if (role != null)
            {
                _applicationDbContext.RoleModel.Remove(role);
                _applicationDbContext.SaveChanges();
            }
        }
    }
}
