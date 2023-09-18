using System;
using System.Collections.Generic;


namespace LibraryProject
{
    public class LibraryApp
    {
        public static void Main()
        {
            ErrorHandler errorHandler = new ErrorHandler();
            LibraryCatalog perpustakaan = new LibraryCatalog();
            Console.WriteLine("------- Aplikasi Perpustakaan Buku Sederhana -------");
            Console.WriteLine("--pilih salah satu Menu dibawah ini--");
            Console.WriteLine("1. Menambah Buku");
            Console.WriteLine("2. Menghapus Buku");
            Console.WriteLine("3. Mencari Buku dengan judul");
            Console.WriteLine("4. Menampilkan semua buku dalam katalog");
            Console.WriteLine("5. Keluar");
            Console.Write("Masukan pilihan mu : ");

            int pilihan = errorHandler.GetUserInput(1, 5);
            while (pilihan != 5)
            {
                switch (pilihan)
                {
                    case 1:
                        Console.WriteLine("Judul buku :");
                        string judul = errorHandler.GetUserInput();
                        Console.WriteLine("Penulis buku :");
                        string penulis = errorHandler.GetUserInput();
                        Console.WriteLine("Tahun terbit buku :");
                        int tahunTerbit = errorHandler.GetUserInput(1500, 2023);

                        perpustakaan.AddBook(judul, penulis, tahunTerbit);
                        Console.WriteLine("buku berhasil ditambahkan");
                        break;
                    case 2:
                        if (perpustakaan.books.Count != 0)
                        {
                            for (int i = 0; i < perpustakaan.books.Count; i++)
                            {
                                Console.WriteLine($"{i} - {perpustakaan.books[i].Title}");
                            }

                            Console.WriteLine("pilih mana yang ingin dihapus :");
                            int index = errorHandler.GetUserInput(0, perpustakaan.books.Count - 1);

                            perpustakaan.RemoveBook(index);
                            Console.WriteLine("buku berhasil dihapus");
                        }
                        else
                        {
                            Console.WriteLine("masih belum ada buku , tolong tambah dulu");
                        }
                        break;
                    case 3:
                        if (perpustakaan.books.Count != 0)
                        {
                            Console.WriteLine("Masukan judul buku yang ingin dicari :");
                            string cari = errorHandler.GetUserInput();
                            perpustakaan.FindBook(cari);
                        }
                        else
                        {
                            Console.WriteLine("masih belum ada buku , tolong tambah dulu");
                        }
                        break;
                    case 4:
                        if (perpustakaan.books.Count != 0)
                        {
                            perpustakaan.ListBook();
                        }
                        else
                        {
                            Console.WriteLine("masih belum ada buku , tolong tambah dulu");
                        }
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("------- Aplikasi Perpustakaan Buku Sederhana -------");
                Console.WriteLine("--pilih salah satu Menu dibawah ini--");
                Console.WriteLine("1. Menambah Buku");
                Console.WriteLine("2. Menghapus Buku");
                Console.WriteLine("3. Mencari Buku dengan judul");
                Console.WriteLine("4. Menampilkan semua buku dalam katalog");
                Console.WriteLine("5. Keluar");
                Console.Write("Masukan pilihan mu : ");
                pilihan = errorHandler.GetUserInput(1, 5);
                Console.WriteLine();
            }
            Console.WriteLine("terimakasih sudah menggunakan aplikasi kami");
        }




        public class Book
        {
            public string Title;
            public string Author;
            public int PublicationYear;

            public Book(string T, string A, int PY)
            {
                Title = T;
                Author = A;
                PublicationYear = PY;
            }
        }

        public class LibraryCatalog
        {
            public List<Book> books = new List<Book>();

            public void AddBook(string judul, string penulis, int tahun)
            {
                Book book = new Book(judul, penulis, tahun);
                books.Add(book);
            }
            public void RemoveBook(int index)
            {
                books.RemoveAt(index);
            }
            public void FindBook(string judul)
            {
                bool bookFound = false;
                foreach (Book book in books)
                {
                    if (book.Title.ToLower().Contains(judul.ToLower()))
                    {
                        Console.WriteLine("Buku ditemukan :");
                        Console.WriteLine($"judul : {book.Title}");
                        Console.WriteLine($"author : {book.Author}");
                        Console.WriteLine($"tahun publish : {book.PublicationYear}");
                        bookFound = true;
                    }
                }
                if (!bookFound)
                {
                    Console.WriteLine("Buku tidak ditemukan");
                }
            }
            public void ListBook()
            {
                Console.WriteLine("buku yang tersedia :");
                int count = 1;
                foreach (Book book in books)
                {
                    Console.WriteLine($"{count}. Judul : {book.Title} , Penulis : {book.Author}, Tahun Terbit : {book.PublicationYear}");
                    Console.WriteLine();
                    count++;
                }

            }
        }

        public class ErrorHandler
        {

            public string GetUserInput()
            {
                while (true)
                {
                    string? input = Console.ReadLine();
                    if (!string.IsNullOrEmpty(input))
                    {
                        return input;
                    }
                    else
                    {
                        Console.WriteLine("input tidak boleh kosong");
                    }
                }

            }
            public int GetUserInput(int min, int max)
            {
                while (true)
                {
                    string input = GetUserInput();
                    if (int.TryParse(input, out int pilihan))
                    {
                        if (pilihan >= min && pilihan <= max)
                        {
                            return pilihan;
                        }
                        else
                        {
                            Console.WriteLine($"masukan antara angka ({min} - {max})");
                        }
                    }
                    else
                    {
                        Console.WriteLine("masukan hanya angka");
                    }
                }
            }

        }


    }


}

