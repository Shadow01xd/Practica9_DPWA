using HospitalProyect.Data;
using HospitalProyect.Models;

namespace HospitalProyect.Repositories
{
    public class StaffCategoryRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public StaffCategoryRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public List<StaffCategoryModel> GetAll()
        {
            return _applicationDbContext.staffCategoryModel.ToList();
        }

        public StaffCategoryModel GetById(int id)
        {
            return _applicationDbContext.staffCategoryModel.FirstOrDefault(p => p.Id == id);
        }

        public void Add(StaffCategoryModel staffCategoryModel)
        {
            _applicationDbContext.staffCategoryModel.Add(staffCategoryModel);
            _applicationDbContext.SaveChanges();
        }

        public void Update(StaffCategoryModel staffCategoryModel)
        {
            _applicationDbContext.staffCategoryModel.Update(staffCategoryModel);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var staffCategory = _applicationDbContext.staffCategoryModel.Find(id);

            if (staffCategory != null)
            {
                _applicationDbContext.staffCategoryModel.Remove(staffCategory);
                _applicationDbContext.SaveChanges();
            }
        }
    }
}
