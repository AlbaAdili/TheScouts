using System;
using TheScouts.Data;
using TheScouts.Models;
using Microsoft.EntityFrameworkCore;
namespace TheScouts.Repositories
{
	public class PositionRepository : IPositionRepository
	{
		private readonly ApplicationDbContext _context;

		public PositionRepository(ApplicationDbContext context)
		{
			_context = context;
		}

        public async Task<IEnumerable<Position>> GetAllAsync()
		{
			return await _context.Positions.ToListAsync();
		}

		public async Task<Position> FindOneAsync(int id)
		{
            return await _context.Positions.FindAsync(id);
        }

        public async Task AddAsync(Position position)
		{
			await _context.Positions.AddAsync(position);
			await _context.SaveChangesAsync();
		}

        public async Task UpdateAsync(Position position)
        {
            _context.Positions.Update(position);
            await _context.SaveChangesAsync();

        }
        public async Task DeleteAsync(int id)
		{
            var position = await _context.Positions.FindAsync(id);
            if (position != null)
            {
                _context.Positions.Remove(position);
                await _context.SaveChangesAsync();
            }
        }
    }
}

