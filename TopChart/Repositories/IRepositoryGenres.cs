using TopChart.Models;

namespace TopChart.Repositories
{
    public interface IRepositoryGenres
    {
        Task<List<Genre>> GetGenresList();
        Task Create(Genre item);
        Task Delete(int id);
        Task Save();
    }
}
