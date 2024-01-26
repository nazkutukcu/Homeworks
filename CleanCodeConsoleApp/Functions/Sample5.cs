using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeConsoleApp.Functions
{
    /// <summary>
    /// "Limiting function arguments" prensibi, bir fonksiyonun aldığı parametre sayısının sınırlı olması
    /// gerektiğini savunur. Bu prensibe uymak, kodun daha sade, anlaşılır ve bakımı kolay olmasını sağlar. 

    //Örnek olarak bir kütüphanedeki kitapları filtreleyen bir method yazdım.
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Rating { get; set; }
        public DateTime PublicationDate { get; set; }
    }

    //BAD
    public class BadBookFilter
    {
        public List<Book> FilterBooks(string title, string author, string genre, int minRating, DateTime publicationDate)
        {
            // Filtreleme işlemleri...

            return new List<Book>(); // Dönüş değeri sadece örnek olması açısından ekledim.
        }
    }

    //GOOD
    public class GoodBookFilter
    {
        // Tek bir parametre alarak fonksiyonun kullanımını daha basitleştirdik.
        public List<Book> FilterBooks(BookFilterOptions options)
        {
            // Filtreleme işlemleri...

            return new List<Book>(); 
        }
    }

    // Filtreleme seçeneklerini içeren sınıf
    public class BookFilterOptions
    {
        public string FilterTitle { get; set; }
        public string FilterAuthor { get; set; }
        public string FilterGenre { get; set; }
        public int MinRating { get; set; }
        public DateTime FilterPublicationDate { get; set; }
    }
}
