﻿using Microsoft.EntityFrameworkCore;
using System.Collections;
using TopChart.Models;

namespace TopChart.Repositories
{
    public class SingersRepository: IRepositorySingers
    {
        private readonly TopChartDbContext _context;

        public SingersRepository(TopChartDbContext context)
        {
            _context = context;
        }
        public async Task<List<Singer>> GetSingersList()
        {
            return await _context.Singer.ToListAsync();
        }
        public IEnumerable GetValues()
        {
            return _context.Singer;
        }
        public async Task Create(Singer s)
        {
            await _context.Singer.AddAsync(s);
        }
        public async Task Delete(int id)
        {
            Singer? s = await _context.Singer.FindAsync(id);
            if (s != null)
                _context.Singer.Remove(s);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public Singer GetSinger(int? id)
        {
            return _context.Singer.FirstOrDefault(a => a.Id == id);
        }
    }
}
