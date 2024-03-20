using TopChart.Models;

namespace TopChart.Repositories
{
    public interface IRepositoryUsers
    {
        Task<List<Users>> GetUsersList();
        IQueryable<Users> CheckUser(LoginModel logon);
        IQueryable<Users> CheckRegisterUser(RegisterModel reg);
        Users GetUserById(int? Id);
        bool UserExists(int id);
        Task Create(Users item);
        void Update(Users item);
        Task Delete(int id);
        Task Save();
    }
}
