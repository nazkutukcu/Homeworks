using System;
using System.Collections.Generic;
using System.Linq;
using static System.Reflection.Metadata.BlobBuilder;

class Program
{
    static void Main()
    {
        List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "Hobbit", Author = "J.R.R. Tolkien", Genre = "Fantastik", PageCount = 310 },
            new Book { Id = 2, Title = "Bülbülü Öldürmek", Author = "Harper Lee", Genre = "Roman", PageCount = 281 },
            new Book { Id = 3, Title = "1984", Author = "George Orwell", Genre = "Distopya", PageCount = 328 },
            new Book { Id = 4, Title = "Büyük Gatsby", Author = "F. Scott Fitzgerald", Genre = "Klasik", PageCount = 180 },
            new Book { Id = 5, Title = "Harry Potter ve Felsefe Taşı", Author = "J.K. Rowling", Genre = "Fantastik", PageCount = 320 },
            new Book { Id = 6, Title = "Çavdar Tarlasında Çocuklar", Author = "J.D. Salinger", Genre = "Roman", PageCount = 224 },
            new Book { Id = 7, Title = "Yüzüklerin Efendisi", Author = "J.R.R. Tolkien", Genre = "Fantastik", PageCount = 1178 },
            new Book { Id = 8, Title = "Cesur Yeni Dünya", Author = "Aldous Huxley", Genre = "Distopya", PageCount = 311 },
            new Book { Id = 9, Title = "Aşk ve Gurur", Author = "Jane Austen", Genre = "Klasik", PageCount = 432 },
            new Book { Id = 10, Title = "Açlık Oyunları", Author = "Suzanne Collins", Genre = "Bilim Kurgu", PageCount = 374 }
        };

        FilterByGenre(books, "Fantastik");
        GroupByAuthor(books);
        SelectTitleAndAuthor(books);
        BooksCount(books);
        SumPageCount(books);
        SkipAndTake(books);
        OrderByTitle(books);

        Console.ReadLine();
    }

    static void PrintBooks(string header, IEnumerable<Book> bookList)
    {
        Console.WriteLine($"--- {header} ---");
        foreach (var book in bookList)
        {
            Console.WriteLine($"ID: {book.Id}, Başlık: {book.Title}, Yazar: {book.Author}, Tür: {book.Genre}, Sayfa Sayısı: {book.PageCount}");
        }
        Console.WriteLine();
    }

    //filtering books based on the genre with using Where method
    static void FilterByGenre(List<Book> books, string genre)
    {
        var filteredBooks = books.Where(b => b.Genre == genre);

        PrintBooks($"Sadece {genre} Türündeki Kitaplar", filteredBooks);
    }

    //categorizing  books based on the authors with using GroupBy method
    static void GroupByAuthor(List<Book> books)
    {
        var groupedBooks = books.GroupBy(b => b.Author);
        Console.WriteLine("--- Yazarlarına Göre Kitapları Gruplandırma --- ");

        foreach (var group in groupedBooks)
        {
            PrintBooks($"{group.Key} Yazarındaki Kitaplar", group);
        }
    }

    // selecting only the titles and authors of books using the Select method
    static void SelectTitleAndAuthor(List<Book> books)
    {
        var selectedData = books.Select(b => new { b.Title, b.Author });
        Console.WriteLine("Kitaplar ve Yazarları: ");

        foreach (var item in selectedData)
        {
            Console.WriteLine($"Kitap: {item.Title}, Yazar: {item.Author}");
        }
        Console.WriteLine();
    }

    // counting the total number of books with Count method
    static void BooksCount(List<Book> books)
    {
        var totalPageCount = books.Count();
        Console.WriteLine($"Toplam Kitap Sayısı: {totalPageCount}");
    }

    //calculating the total number of pages using Sum method
    static void SumPageCount(List<Book> books)
    {
        var sumOfPageCount = books.Sum(b => b.PageCount);
        Console.WriteLine($"Toplam Sayfa Sayısı: {sumOfPageCount}");
    }
   
    // skipping the first 2 books and taking the next 3 books using Skip and Take methods
    static void SkipAndTake(List<Book> books)
    {
        var skippedAndTakenBooks = books.Skip(2).Take(3);
        PrintBooks("İlk 2 Kitap Atıldı, Sonraki 3 Kitap Alındı", skippedAndTakenBooks);
    }

    // sorting books in alphabetical order based on title using OrderBy method
    static void OrderByTitle(List<Book> books)
    {
        var orderedBooks = books.OrderBy(b => b.Title);

        PrintBooks("Kitaplar Alfabetik Sıraya Göre Sıralı", orderedBooks);
    }
}

class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int PageCount { get; set; }
}
