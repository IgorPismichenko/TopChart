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

        public IQueryable<Tracks> GetSearchList(string name)
        {
            return _context.Tracks.Where(a => a.Name == name);
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

        public Tracks GetTrack(int? id)
        {
            return _context.Tracks.FirstOrDefault(a => a.Id == id);
        }

        public void Update(Tracks t)
        {
            _context.Entry(t).State = EntityState.Modified;
        }

        public async Task<List<Tracks>> GetSortedTracksList()
        {
            var tracks = await _context.Tracks.ToListAsync();
            for(int i = 0;i < tracks.Count; i++)
            {
                for(int j = 0;j < tracks.Count - 1 - i; j++)
                {
                    if (tracks[j].Like < tracks[j + 1].Like)
                    {
                        Tracks tmp = tracks[j];
                        tracks[j] = tracks[j + 1];
                        tracks[j + 1] = tmp;
                    }
                }
            }
            return tracks;
        }
    }
}
