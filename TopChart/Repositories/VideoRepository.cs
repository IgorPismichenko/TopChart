using Microsoft.EntityFrameworkCore;
using TopChart.Models;

namespace TopChart.Repositories
{
    public class VideoRepository: IRepositoryVideo
    {
        private readonly TopChartDbContext _context;

        public VideoRepository(TopChartDbContext context)
        {
            _context = context;
        }
        public async Task<List<Video>> GetVideoList()
        {
            return await _context.Video.ToListAsync();
        }
        public async Task Create(Video t)
        {
            await _context.Video.AddAsync(t);
        }
        public async Task Delete(int id)
        {
            Video? v = await _context.Video.FindAsync(id);
            if (v != null)
                _context.Video.Remove(v);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
