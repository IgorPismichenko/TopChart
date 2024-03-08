using TopChart.Models;

namespace TopChart.Repositories
{
    public interface IRepositoryUsers
    {
        Task<List<Users>> GetUsersList();
        Task Create(Users item);
        void Update(Users item);
        Task Delete(int id);
        Task Save();
    }
}
