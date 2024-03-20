using System.Collections;
using TopChart.Models;

namespace TopChart.Repositories
{
    public interface IRepositoryGenres
    {
        Task<List<Genre>> GetGenresList();
        IEnumerable GetValues();

        Genre GetGenre(int? id);
        Task Create(Genre item);
        Task Delete(int id);
        Task Save();
    }
}
