using HospitalProyect.Data;
using HospitalProyect.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalProyect.Repositories
{
    public class AuthRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AuthRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public bool RegisterUser(UserModel userModel)
        {
            try
            {
                _applicationDbContext.UserModel.Add(userModel);
                _applicationDbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public UserModel? ValidateUser(string email, string password)
        {
            return _applicationDbContext.UserModel
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}
