using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Data.Repositories.Books;
using Final.Services.Services.Interfaces;
using FinalApp.Core.Enums;
using FinalApp.Core.Models;

namespace Final.Services.Services.Implementations
{
    public class BookWriterService : IBookWriterService
    {
        private readonly BookWriterRepository _repository = new BookWriterRepository();
        public async Task<string> CreateAsync(string name, string surname, int books)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (string.IsNullOrWhiteSpace(name))
                return "There is no such Name";

            if (string.IsNullOrWhiteSpace(surname))
                return "There is no such Surname";

            if (books < 0)
                return "The book is not found";

            Console.ForegroundColor = ConsoleColor.Green;
            BookWriter bookWriter = new BookWriter(name, surname, books);
            await _repository.AddAsync(bookWriter);
            return "Successfully craeted";
        }

        public async Task<string> DeleteAsync(int id)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            BookWriter bookWriter = await _repository.GetAsync(book => book.Id == id);
            if (bookWriter == null)
                return "There is no such book writer";

            await _repository.RemoveAsync(bookWriter);

            Console.ForegroundColor = ConsoleColor.Green;

            return "Deleted";
        }

        public async Task GetAllAsync()
        {
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var item in await _repository.GetAllAsync())
            {
                Console.WriteLine(item);
            }
        }

        public  async Task<List<Book>> GetAllBookAsync(int id)
        {
            BookWriter bookWriter = await _repository.GetAsync(book => book.Id == id);
            if (bookWriter == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The BookWriter is not found");
                return null;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            return bookWriter.Book;
        }

        public async Task<BookWriter> GetAsync(int id)
        {
            BookWriter bookWriter = await _repository.GetAsync(book => book.Id == id);

            if (bookWriter == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The BookWriter is not found");
                return null;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            return bookWriter;
        }

        public async Task<string> UpdateAsync(int id, string name, string surname, int books)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (string.IsNullOrWhiteSpace(name))
                return "The name is not found";

            if (string.IsNullOrWhiteSpace(surname))
                return "The surname is not found";

            BookWriter bookwriter = await _repository.GetAsync(s => s.Id == id);
            if (bookwriter == null)
                return "The book is not found";

            bookwriter.Name = name;
            bookwriter.SurName = surname; 
            bookwriter.Books = books;

            Console.ForegroundColor = ConsoleColor.Green;
            return "Updated";
        }
    }
}
