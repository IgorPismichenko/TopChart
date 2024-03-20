using TopChart.Models;

namespace TopChart.Repositories
{
    public interface IRepositoryCommentsVideo
    {
        Task<List<CommentVideo>> GetCommentList();
        Task Create(CommentVideo item);
        Task Delete(int id);
        Task Save();
    }
}
