using TopChart.Models;

namespace TopChart.Repositories
{
    public interface IRepositoryTracks
    {
        Task<List<Tracks>> GetTracksList();
        Task Create(Tracks item);
        Task Delete(int id);
        Task Save();
    }
}
