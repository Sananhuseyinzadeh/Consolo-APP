

using System.Collections.Generic;
using System.Threading.Tasks;
using FinalApp.Core.Models;

namespace Final.Services.Services.Interfaces
{
    public interface IBookWriterService
    {
        Task<string> CreateAsync(string name, string surname,int books);
        Task<string> DeleteAsync(int id);
        Task<string> UpdateAsync(int id, string name, string surname, int books);
        Task<BookWriter> GetAsync(int id);
        Task GetAllAsync();
        Task<List<Book>> GetAllBookAsync(int id);
        
    }
}
