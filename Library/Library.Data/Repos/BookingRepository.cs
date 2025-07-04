using Library.Core.Models;

namespace Library.Data.Repos
{
    public class BookingRepository : ICrud<Booking>
    {
        private readonly Database _db;

        public BookingRepository(string connStr)
        {
            _db = new Database(connStr);
        }

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
            return new Booking();
        }

        public int Add(Booking booking)
        {
            return 1;
        }

        public int Update(Booking booking)
        {
            return 1;
        }

        public int Delete(int id)
        {
            return 1;
        }
    }
}
