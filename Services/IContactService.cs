using System;
using TheScouts.Models;

namespace TheScouts.Services
{
	public interface IContactService
	{
        Task<IEnumerable<Contact>> GetAllAsync();
        Task<Contact> FindOneAsync(int id);
        Task AddAsync(Contact contact);
    }
}

