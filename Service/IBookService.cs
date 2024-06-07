using BookStoreApi.Models;

namespace BookStoreApi.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetAsync();
        Task<Book?> GetByIdAsync(string id);
        Task CreateAsync(Book newBook);
        Task UpdateAsync(string id, Book updatedBook);
        Task DeleteAsync(string id);
    }
}