using System;
using TheScouts.Models;

namespace TheScouts.Repositories
{
	public interface IContactRepository
	{
        Task<IEnumerable<Contact>> GetAllAsync();
        Task<Contact> FindOneAsync(int id);
        Task AddAsync(Contact contact);
    }
}

