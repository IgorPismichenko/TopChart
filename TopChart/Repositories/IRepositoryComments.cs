using TopChart.Models;

namespace TopChart.Repositories
{
    public interface IRepositoryComments
    {
        Task<List<Comment>> GetCommentList();
        Task Create(Comment item);
        Task Delete(int id);
        Task Save();
    }
}
