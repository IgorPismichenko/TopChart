using Microsoft.EntityFrameworkCore;
using TopChart.Models;

namespace TopChart.Repositories
{
    public class CommentsRepository: IRepositoryComments
    {
        private readonly TopChartDbContext _context;

        public CommentsRepository(TopChartDbContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetCommentList()
        {
            return await _context.Comment.ToListAsync();
        }

        public async Task Create(Comment c)
        {
            await _context.Comment.AddAsync(c);
        }
        public async Task Delete(int id)
        {
            Comment? c = await _context.Comment.FindAsync(id);
            if (c != null)
                _context.Comment.Remove(c);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
