using System;
using TheScouts.Models;
using TheScouts.Repositories;

namespace TheScouts.Services
{
	public class ContactService : IContactService
	{
        private readonly IContactRepository _repository;

        public ContactService(IContactRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Contact> FindOneAsync(int id)
        {
            return await _repository.FindOneAsync(id);
        }

        public async Task AddAsync(Contact contact)
        {
            await _repository.AddAsync(contact);
        }
    }
}

