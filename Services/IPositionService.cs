using System;
using TheScouts.Models;

namespace TheScouts.Services
{
	public interface IPositionService
	{
        Task<IEnumerable<Position>> GetAllAsync();
        Task<Position> FindOneAsync(int id);
        Task AddAsync(Position position);
        Task UpdateAsync(Position position);
        Task DeleteAsync(int id);
    }
}

