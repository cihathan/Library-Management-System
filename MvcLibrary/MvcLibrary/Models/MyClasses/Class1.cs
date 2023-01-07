using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MvcLibrary.Models.Entity;
namespace MvcLibrary.Models.MyClasses
{
    public class Class1
    {
        public IEnumerable<Book> BooksValue { get; set; }
        public IEnumerable<About> AboutValue { get; set; }
    }
}