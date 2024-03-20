using System.Collections;
using TopChart.Models;

namespace TopChart.Repositories
{
    public interface IRepositorySingers
    {
        Task<List<Singer>> GetSingersList();
        IEnumerable GetValues();

        Singer GetSinger(int? id);
        Task Create(Singer item);
        Task Delete(int id);
        Task Save();
    }
}
