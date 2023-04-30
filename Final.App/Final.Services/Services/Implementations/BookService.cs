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
    public class BookService : IBookService
    {
        private readonly BookWriterRepository _repository = new BookWriterRepository();
        public async Task<string> BuyBook(int bookwriterId, int bookId)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            BookWriter bookWriter = await _repository.GetAsync(bookwriter => bookwriter.Id == bookwriterId);

            Book book = bookWriter.Book.FirstOrDefault(x => x.Id == bookId);
            Console.ForegroundColor = ConsoleColor.Green;

            if (book != null)
            {
                book.BookInStock = true;
                return "This book is available for sale";
            }

            return "This book is already sold";
        }

        public async Task<string> CreateAsync(int id, string name, double price, double discountprice, BookCategory category)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            BookWriter bookWriter = await _repository.GetAsync(Book => Book.Id == id);
            if (bookWriter == null)
                return "There is no book";
            if (await ValideteBook(name, price, discountprice) != null)
            {
                return await ValideteBook(name, price, discountprice);
            }
            Book book = new Book(name, price, discountprice, category, bookWriter);

            bookWriter.Book.Add(book);

            Console.ForegroundColor = ConsoleColor.Green;
            return "Created";
        }

        private async Task<string> ValideteBook(string name, double price, double discountprice)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "The title of the book is incorrect";
            if (price < 0)
                return "Add valid price";
            if (discountprice > price || discountprice <= 0)
                return "Add valid discountprice";
            return null;

        }

        public async Task<string> DeleteAsync(int bookwriterId, int bookId)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            BookWriter bookWriter = await _repository.GetAsync(bookwriter => bookwriter.Id == bookwriterId);
            if (bookWriter == null)
                return "There is no such book writer";
            Book book = bookWriter.Book.FirstOrDefault(Book => Book.Id == bookId);
            if (book == null)
                return "There is no book";

            bookWriter.Book.Remove(book);
            Console.ForegroundColor = ConsoleColor.Green;
            return "Deleted";
        }

        public async Task GetAllAsync() 
        {
            foreach (var item in await _repository.GetAllAsync())
            {

                foreach (var prod in item.Book)
                {
                    Console.WriteLine(prod);
                }
            }
        }

        public async Task<Book> GetAsync(int bookwriterId, int bookId)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            BookWriter bookWriter = await _repository.GetAsync(bookwriter => bookwriter.Id == bookwriterId);
            if (bookWriter == null)
            {
                Console.WriteLine("The BookWriter is not found");
                return null;
            }
            Book book = bookWriter.Book.FirstOrDefault(Book => Book.Id == bookId);
            if (book == null)
            {
                Console.WriteLine("The book is not found");
                return null;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            return book;
        }

        public async Task<string> UpdateAsync(int bookwriterId, int bookId, string name, double price, double discountprice)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            BookWriter bookWriter = await _repository.GetAsync(bookwriter => bookwriter.Id == bookwriterId);
            if (bookWriter == null)
                return "The BookWriter is not found";

            if (await ValideteBook(name, price, discountprice) != null)
            {
                return await ValideteBook(name, price, discountprice);
            }



            Book book = bookWriter.Book.FirstOrDefault(Book => Book.Id == bookId);
            book.Name = name;
            book.Price = price;
            book.DiscountPrice = discountprice;

            Console.ForegroundColor = ConsoleColor.Green;
            return "Updated";

        }
    }





}
