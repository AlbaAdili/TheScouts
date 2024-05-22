using System;
using TheScouts.Repositories;
using TheScouts.Models;

namespace TheScouts.Services
{
	public class ApplicationService : IApplicationService
	{
        private readonly IApplicationRepository _repository;

        public ApplicationService(IApplicationRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Application>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Application> FindOneAsync(int id)
        {
            return await _repository.FindOneAsync(id);
        }

        public async Task<Position> FindPositionAsync(int id)
        {
            return await _repository.FindPositionAsync(id);
        }

        public async Task<IEnumerable<Application>> FindApplicationsAsync(int id)
        {
            return await _repository.FindApplicationsAsync(id);
        }

        public async Task AddAsync(Application application)
        {
            await _repository.AddAsync(application);
        }

        public async Task<IEnumerable<Application>> FindApplicationsByUserIdAsync(string userId)
        {
            return await _repository.FindApplicationsByUserIdAsync(userId);
        }

        public async Task<Application> UpdateStatus(int applicationId, string status)
        {
            return await _repository.UpdateStatus(applicationId, status);
        }

        public async Task<string> GetPositionNameByIdAsync(int positionId)
        {
            return await _repository.GetPositionNameByIdAsync(positionId);
        }
    }
}

