using System;
using TheScouts.Data;
using TheScouts.Models;
using Microsoft.EntityFrameworkCore;

namespace TheScouts.Repositories
{
	public class ContactRepository : IContactRepository
	{
        private readonly ApplicationDbContext _context;

        public ContactRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> FindOneAsync(int id)
        {
            return await _context.Contacts.FindAsync(id);
        }

        public async Task AddAsync(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
        }
    }
}

