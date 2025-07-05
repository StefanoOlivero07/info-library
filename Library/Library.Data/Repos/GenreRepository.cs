using Library.Core.Models;
using Microsoft.Data.SqlClient;

namespace Library.Data.Repos
{
    public class GenreRepository : ICrud<Genre>
    {
        private readonly Database _db;

        public GenreRepository(string connectionString)
        {
            _db = new Database(connectionString);
        }

        public List<Genre> GetAll()
        {
            var genres = new List<Genre>();
            string query = "SELECT * FROM Genres";
            using var reader = _db.ExecuteReader(query);

            while (reader.Read())
            {
                genres.Add(new Genre
                {
                    Id = reader.GetInt32(0),
                    Description = reader.GetString(1)
                });
            }

            return genres;
        }

        public Genre? GetById(int id)
        {
            string query = "SELECT * FROM Genres WHERE Id = @idPlaceholder";
            var parameters = new[]
            {
                new SqlParameter("@idPlaceholder", id)
            };
            using var reader = _db.ExecuteReader(query, parameters);

            if (reader.Read())
            {
                var genre = new Genre
                {
                    Id = reader.GetInt32(0),
                    Description = reader.GetString(1)
                };

                return genre;
            }

            return null;
        }

        public int Add(Genre genre)
        {
            string query = "INSERT INTO Genres Description VALUES @descriptionPlaceholder";
            var parameters = new[]
            {
                new SqlParameter("@descriptionPlaceholder", genre.Description)
            };

            return _db.ExecuteNonQuery(query, parameters);
        }

        public int Update(Genre genre)
        {
            string query = "UPDATE Genres SET Description = @descriptionPlaceholder WHERE Id = @idPlaceholder";
            var parameters = new[]
            {
                new SqlParameter("@idPlaceholder", genre.Id),
                new SqlParameter("@descriptionPlaceholder", genre.Description)
            };

            return _db.ExecuteNonQuery(query, parameters);
        }

        public int Delete(int id)
        {
            string query = "DELETE FROM Genres WHERE Id = @idPlaceholder";
            var parameters = new[]
            {
                new SqlParameter("@idPlaceholder", id)
            };

            return _db.ExecuteNonQuery(query, parameters);
        }
    }
}
