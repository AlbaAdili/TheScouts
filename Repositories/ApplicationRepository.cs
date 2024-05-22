using System;
using Microsoft.EntityFrameworkCore;
using TheScouts.Data;
using TheScouts.Models;

namespace TheScouts.Repositories
{
	public class ApplicationRepository : IApplicationRepository
	{
        private readonly ApplicationDbContext _context;

        public ApplicationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Application>> GetAllAsync()
        {
            return await _context.Applications.Include(a => a.Position).ToListAsync();
        }

        public async Task<Application> FindOneAsync(int id)
        {
            return await _context.Applications.FindAsync(id);
        }

        public async Task<Position> FindPositionAsync(int id)
        {
            return await _context.Positions.FindAsync(id);
        }

        public async Task<IEnumerable<Application>> FindApplicationsAsync(int id)
        {
            return await _context.Applications.Where(application => application.PositionId == id).ToListAsync();
        }

        public async Task AddAsync(Application application)
        {
            await _context.Applications.AddAsync(application);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Application>> FindApplicationsByUserIdAsync(string userId)
        {
            return await _context.Applications.Include(a => a.Position).Where(a => a.UserId == userId).ToListAsync();
        }

        public async Task<Application> UpdateStatus(int applicationId, string status)
        {
            var application = await _context.Applications.FindAsync(applicationId);

            if (application != null)
            {
                application.Status = status;

                await _context.SaveChangesAsync();
            }
            return application;
        }

        public async Task<string> GetPositionNameByIdAsync(int positionId)
        {
            var position = await _context.Positions.FindAsync(positionId);
            if(position != null)
            {
                return position.JobTitle;
            } else
            {
                return null;
            }
        }
    }
}

