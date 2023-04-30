

using System;
using FinalApp.Core.Enums;
using FinalApp.Core.Models.Base;

namespace FinalApp.Core.Models
{
    public class Book:BaseModel
    {
        private static int _id;
        public string Name { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public bool BookInStock { get; set; }
        public BookCategory Category { get; set; }
        public BookWriter BookWriter { get; set; }


        public Book(string name,double price,double discountprice,BookCategory category,BookWriter bookWriter)
        {
            Id++;
            Id = _id;
            Name = name;
            Price = price;
            DiscountPrice = discountprice;
            Category = category;
            BookWriter = bookWriter;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }


        public override string ToString()
        {
            if (DiscountPrice < Price)
            {
                return $"There is {Price- DiscountPrice} discountprice, Name: {Name}, Price: {DiscountPrice}, Category: {Category},BookWriter: {BookWriter}";
            }

            return $"Name: {Name}, Price: {Price}, Category{Category}, BookWriter: {BookWriter}";
        }
    }
}
