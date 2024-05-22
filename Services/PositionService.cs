using System;
using TheScouts.Repositories;
using TheScouts.Models;
namespace TheScouts.Services
{
	public class PositionService : IPositionService
	{
		private readonly IPositionRepository _repository;

		public PositionService(IPositionRepository repository)
		{
			_repository = repository;
		}

        public async Task<IEnumerable<Position>> GetAllAsync()
		{
			return await _repository.GetAllAsync();
		}

        public async Task<Position> FindOneAsync(int id)
		{
			return await _repository.FindOneAsync(id);
		}

        public async Task AddAsync(Position position)
		{
			await _repository.AddAsync(position);
		}

        public async Task UpdateAsync(Position position)
		{
			await _repository.UpdateAsync(position);
		}

        public async Task DeleteAsync(int id)
		{
			await _repository.DeleteAsync(id);
		}
    }
}

