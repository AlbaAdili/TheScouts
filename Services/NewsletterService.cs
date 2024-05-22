using System;
using TheScouts.Models;
using TheScouts.Repositories;

namespace TheScouts.Services
{
	public class NewsletterService : INewsletterService
	{
        private readonly INewsletterRepository _repository;

        public NewsletterService(INewsletterRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Newsletter newsletter)
        {
            await _repository.AddAsync(newsletter);
        }

        public async Task<bool> IsEmailSubscribedAsync(string email)
        {
            return await _repository.IsEmailSubscribedAsync(email);
        }
    }
}

