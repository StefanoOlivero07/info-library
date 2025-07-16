using Library.Core.Models;
using Microsoft.Data.SqlClient;

namespace Library.Data.Repos
{
    public class BookRepository : ICrud<Book>
    {
        private readonly Database _db;

        public BookRepository(string connectionString)
        {
           _db = new Database(connectionString);
        }

        // ---------- CRUD methods ----------
        #region
        public List<Book> GetAll()
        {
            var books = new List<Book>();
            string query = "SELECT * FROM Books";
            using var reader = _db.ExecuteReader(query);

            while (reader.Read())
            {
                books.Add(new Book
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    AuthorId = reader.GetInt32(2),
                    Year = reader.GetInt32(3),
                    NationId = reader.GetInt32(4),
                    LanguageId = reader.GetInt32(5),
                    Price = reader.GetDecimal(6),
                    Pages = reader.GetInt32(7)
                });
            }

            return books;
        }

        public Book? GetById(int id)
        {
            string query = "SELECT * FROM Books WHERE Id = @idPlaceholder";
            var parameters = new[]
            {
                new SqlParameter("@idPlaceholder", id)
            };
            using var reader = _db.ExecuteReader(query, parameters);

            if (reader.Read())
            {
                var book = new Book
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    AuthorId = reader.GetInt32(2),
                    Year = reader.GetInt32(3),
                    NationId = reader.GetInt32(4),
                    LanguageId = reader.GetInt32(5),
                    Price = reader.GetDecimal(6),
                    Pages = reader.GetInt32(7)
                };

                return book;
            }

            return null;
        }

        public int Add(Book book)
        {
            string query = "INSERT INTO Books Title, AuthorId, Year, NationId, LanguageId, Price, Pages VALUES @titlePlaceholder, @authorIdPlaceholder, @yearPlaceholder," +
                "@nationIdPlaceholder, @languageIdPlaceholder, @pricePlaceholder, @pagesPlaceholder";
            var parameters = new[]
            {
                new SqlParameter("@titlePlaceholder", book.Title),
                new SqlParameter("@authorIdPlaceholder", book.AuthorId),
                new SqlParameter("@yearPlaceholder", book.Year),
                new SqlParameter("@nationIdPlaceholder", book.NationId),
                new SqlParameter("@languageIdPlaceholder", book.LanguageId),
                new SqlParameter("@pricePlaceholder", book.Price),
                new SqlParameter("@pagesPlaceholder", book.Pages)
            };

            return _db.ExecuteNonQuery(query, parameters);
        }

        public int Update(Book book)
        {
            string query = "UDATE Books SET Title = @titlePlaceholder, AuthorId = @authorIdPlaceholder, Year = @yearPlaceholder, NationId = @nationIdPlaceholder," +
                "LanguageId = @languageIdPlaceholder, LanguageId = @languageIdPlaceholder, Price = @pricePlaceholder, Pages = @pagesPlaceholder " +
                "WHERE Id = @idPlaceholder";
            var parameters = new[]
            {
                new SqlParameter("@idPlaceholder", book.Id),
                new SqlParameter("@titlePlaceholder", book.Title),
                new SqlParameter("@authorIdPlaceholder", book.AuthorId),
                new SqlParameter("@yearPlaceholder", book.Year),
                new SqlParameter("@nationIdPlaceholder", book.NationId),
                new SqlParameter("@languageIdPlaceholder", book.LanguageId),
                new SqlParameter("@pricePlaceholder", book.Price),
                new SqlParameter("@pagesPlaceholder", book.Pages)
            };

            return _db.ExecuteNonQuery(query, parameters);
        }

        public int Delete(int id)
        {
            string query = "DELETE FROM Books WHERE Id = @idPlaceholder";
            var parameters = new[]
            {
                new SqlParameter("@idPlaceholder", id)
            };

            return _db.ExecuteNonQuery(query, parameters);
        }
        #endregion
        // ---------- Specific methods ----------
        public List<Book> GetBookedBooks()
        {
            var books = new List<Book>();
            string query = @"SELECT bk.Id AS BookId, bk.Title, bk.Year, Price, Pages
                             FROM Bookings bks
                             JOIN Books bk ON bks.BookId = bk.Id;";
            using var reader = _db.ExecuteReader(query);

            while (reader.Read())
            {
                books.Add(new Book
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    Year = reader.GetInt32(2),
                    Price = reader.GetDecimal(3),
                    Pages = reader.GetInt32(4)
                });
            }

            return books;
        }
    }
}
