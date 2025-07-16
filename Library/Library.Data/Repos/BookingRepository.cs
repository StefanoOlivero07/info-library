using Library.Core.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;

namespace Library.Data.Repos
{
    public class BookingRepository : ICrud<Booking>
    {
        private readonly Database _db;

        public BookingRepository(string connStr)
        {
            _db = new Database(connStr);
        }

        /*
        ---------- CRUD methods ----------
        */
        #region
        public List<Booking> GetAll()
        {
            var bookings = new List<Booking>();
            string query = "SELECT * FROM Bookings";
            using var reader = _db.ExecuteReader(query);

            while (reader.Read())
            {
                bookings.Add(new Booking()
                {
                    Id = reader.GetInt32(0),
                    UserId = reader.GetInt32(1),
                    BookId = reader.GetInt32(2)
                });
            }

            return bookings;
        }

        public Booking? GetById(int id)
        {
            string query = "SELECT * FROM Bookings WHERE Id = @idPlaceholder";
            var parameters = new[]
            {
                new SqlParameter("@idPlaceholder", id)
            };
            using var reader = _db.ExecuteReader(query, parameters);

            if (reader.Read())
            {
                return new Booking
                {
                    Id = reader.GetInt32(0),
                    UserId = reader.GetInt32(1),
                    BookId = reader.GetInt32(2)
                };
            }
            
            return null;
        }

        public int Add(Booking booking)
        {
            string query = "INSERT INTO Bookings UserId, BookId VALUES @userIdPlaceholder, @bookIdPlaceholder";
            var parameters = new[]
            {
                new SqlParameter("@userIdPlaceholder", booking.UserId),
                new SqlParameter("@bookIdPlaceholder", booking.BookId)
            };

            return _db.ExecuteNonQuery(query, parameters);
        }

        public int Update(Booking booking)
        {
            string query = "UPDATE Bookings SET UserId = @userIdPlaceholder, BookId = @bookIdPlaceholder WHERE Id = @idPlaceholder";
            var parameters = new[]
            {
                new SqlParameter("@idPlaceholder", booking.Id),
                new SqlParameter("@userIdPlaceholder", booking.UserId),
                new SqlParameter("@bookIdPlaceholder", booking.BookId)
            };

            return _db.ExecuteNonQuery(query, parameters);
        }

        public int Delete(int id)
        {
            string query = "DELETE Booking WHERE Id = @idPlaceholder";
            var parameters = new[]
            {
                new SqlParameter("@idPlaceholder", id)
            };

            return _db.ExecuteNonQuery(query, parameters);
        }
        #endregion

        /*
        ---------- Booking methods ----------
        */
        #region

        public int AddBooking(int userId, int bookId)
        {
            string query = "INSERT INTO Bookings (UserId, BookId) VALUES (@userIdPlaceholder, @bookIdPlaceholder)";
            var parameters = new[]
            {
                new SqlParameter("@userIdPlaceholder", userId),
                new SqlParameter("@bookIdPlaceholder", bookId)
            };

            return _db.ExecuteNonQuery(query, parameters);
        }

        #endregion
    }
}
