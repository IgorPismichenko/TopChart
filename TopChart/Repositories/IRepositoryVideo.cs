using TopChart.Models;

namespace TopChart.Repositories
{
    public interface IRepositoryVideo
    {
        Task<List<Video>> GetVideoList();
        Task Create(Video item);
        Task Delete(int id);
        Task Save();
    }
}
