using Microsoft.EntityFrameworkCore;
using TopChart.Models;

namespace TopChart.Repositories
{
    public class UsersRepository: IRepositoryUsers
    {
        private readonly TopChartDbContext _context;

        public UsersRepository(TopChartDbContext context)
        {
            _context = context;
        }
        public async Task<List<Users>> GetUsersList()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task Create(Users u)
        {
            await _context.Users.AddAsync(u);
        }

        public void Update(Users u)
        {
            _context.Entry(u).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            Users? u = await _context.Users.FindAsync(id);
            if (u != null)
                _context.Users.Remove(u);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
