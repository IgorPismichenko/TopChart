using Microsoft.EntityFrameworkCore;
using System.Collections;
using TopChart.Models;

namespace TopChart.Repositories
{
    public class GenreRepository: IRepositoryGenres
    {
        private readonly TopChartDbContext _context;

        public GenreRepository(TopChartDbContext context)
        {
            _context = context;
        }
        public async Task<List<Genre>> GetGenresList()
        {
            return await _context.Genre.ToListAsync();
        }

        public IEnumerable GetValues()
        {
            return _context.Genre;
        }
        public async Task Create(Genre g)
        {
            await _context.Genre.AddAsync(g);
        }
        public async Task Delete(int id)
        {
            Genre? g = await _context.Genre.FindAsync(id);
            if (g != null)
                _context.Genre.Remove(g);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public Genre GetGenre(int? id)
        {
            return _context.Genre.FirstOrDefault(a => a.Id == id);
        }
    }
}
