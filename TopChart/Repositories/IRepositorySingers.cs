using TopChart.Models;

namespace TopChart.Repositories
{
    public interface IRepositorySingers
    {
        Task<List<Singer>> GetSingersList();
        Task Create(Singer item);
        Task Delete(int id);
        Task Save();
    }
}
