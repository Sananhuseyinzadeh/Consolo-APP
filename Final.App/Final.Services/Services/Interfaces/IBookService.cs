

using System.Collections.Generic;
using System.Threading.Tasks;
using FinalApp.Core.Enums;
using FinalApp.Core.Models;

namespace Final.Services.Services.Interfaces
{
    public interface IBookService
    {
        Task<string> CreateAsync(int id,string name, double price, double discountprice,BookCategory category);
        Task<string> DeleteAsync(int bookwriterId,int bookId);
        Task<string> UpdateAsync(int bookwriterId,int bookId,string name, double price, double discountprice);
        Task<Book> GetAsync(int bookwriterId,int bookId);
        Task GetAllAsync();
        Task<string> BuyBook(int bookwriterId,int bookId);
    }
}
