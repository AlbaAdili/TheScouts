using System;
using TheScouts.Models;

namespace TheScouts.Repositories
{
	public interface IApplicationRepository
	{
        Task<IEnumerable<Application>> GetAllAsync();
        Task<Application> FindOneAsync(int id);
        Task<Position> FindPositionAsync(int id);
        Task<IEnumerable<Application>> FindApplicationsAsync(int id);
        Task AddAsync(Application application);
        Task<IEnumerable<Application>> FindApplicationsByUserIdAsync(string userId);
        Task<Application> UpdateStatus(int applicationId, string status);
        Task<string> GetPositionNameByIdAsync(int positionId);
    }
}

