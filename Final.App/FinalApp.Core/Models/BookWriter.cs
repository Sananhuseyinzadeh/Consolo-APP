
using System;
using System.Collections.Generic;
using FinalApp.Core.Models.Base;

namespace FinalApp.Core.Models
{
    public class BookWriter:BaseModel
    {
        private int _id;
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Books { get; set; }
        public List<Book> Book { get; set; }

        public BookWriter(string name,string surname,int books)
        {
            _id++;
            Id = _id;
            Name = name;
            SurName= surname;
            Books = books;
            Book = new List<Book>();
            CreatedDate = DateTime.UtcNow.AddHours(4);
            UpdatedDate= DateTime.UtcNow.AddHours(4);
        }

        public override string ToString()
        {
            return $"Name: {Name}, Surname: {SurName}, Books: {Books}, CreatDate: {CreatedDate}, UpdateDate: {UpdatedDate}";        
        }
    }
}
