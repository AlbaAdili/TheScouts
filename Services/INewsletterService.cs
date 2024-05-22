using System;
using TheScouts.Models;

namespace TheScouts.Services
{
	public interface INewsletterService
	{
        Task AddAsync(Newsletter newsletter);
        Task<bool> IsEmailSubscribedAsync(string email);
    }
}

