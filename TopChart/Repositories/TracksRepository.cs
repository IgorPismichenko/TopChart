using Microsoft.EntityFrameworkCore;
using TopChart.Models;

namespace TopChart.Repositories
{
    public class TracksRepository: IRepositoryTracks
    {
        private readonly TopChartDbContext _context;

        public TracksRepository(TopChartDbContext context)
        {
            _context = context;
        }
        public async Task<List<Tracks>> GetTracksList()
        {
            return await _context.Tracks.ToListAsync();
        }
        public async Task Create(Tracks t)
        {
            await _context.Tracks.AddAsync(t);
        }
        public async Task Delete(int id)
        {
            Tracks? t = await _context.Tracks.FindAsync(id);
            if (t != null)
                _context.Tracks.Remove(t);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
