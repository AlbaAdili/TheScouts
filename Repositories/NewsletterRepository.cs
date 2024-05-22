using System;
using Microsoft.EntityFrameworkCore;
using TheScouts.Data;
using TheScouts.Models;

namespace TheScouts.Repositories
{
	public class NewsletterRepository : INewsletterRepository
	{
        private readonly ApplicationDbContext _context;

        public NewsletterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Newsletter newsletter)
        {
            await _context.Newsletters.AddAsync(newsletter);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsEmailSubscribedAsync(string email)
        {
            return await _context.Newsletters.AnyAsync(n => n.Email == email);
        }
    }
}

