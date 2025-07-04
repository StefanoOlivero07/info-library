using Library.Core.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient.DataClassification;
using System.ComponentModel.DataAnnotations;

namespace Library.Data.Repos
{
    public class AuthorRepository : ICrud<Author>
    {
        private readonly Database _db;

        public AuthorRepository(string connStr)
        {
            _db = new Database(connStr);
        }

        public List<Author> GetAll()
        {
            var authors = new List<Author>();
            string query = "SELECT * FROM Authors";
            using var reader = _db.ExecuteReader(query);

            while (reader.Read())
            {
                authors.Add(new Author
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Surname = reader.GetString(2)
                });
            }

            return authors;
        }

        public Author? GetById(int id)
        {
            string query = "SELECT * FROM Authors WHERE Id = @idPlaceholder";
            var parameters = new[]
            {
                new SqlParameter("@idPlaceholder", id)
            };
            using var reader = _db.ExecuteReader(query, parameters);

            if (reader.Read())
            {
                var author = new Author
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Surname = reader.GetString(2)
                };

                return author;
            }

            return null;
        }

        public int Add(Author author)
        {
            string query = "INSERT INTO Authors (Name, Surname) VALUES (@namePlaceholder, @surnamePlaceholder)";
            var parameters = new[]
            {
                new SqlParameter("@namePlaceholder", author.Name),
                new SqlParameter("@surnamePlaceholder", author.Surname)
            };

            return _db.ExecuteNonQuery(query, parameters);
        }

        public int Update(Author author)
        {
            string query = "UPDATE Authors SET Name = @namePlaceholder, Surname = @surnamePlaceholder WHERE Id = @idPlaceholder";
            var parameters = new[]
            {
                new SqlParameter("@idPlaceholder", author.Id),
                new SqlParameter("@namePlaceholder", author.Name),
                new SqlParameter("@surnamePlaceholder", author.Surname)
            };

            return _db.ExecuteNonQuery(query, parameters);
        }

        public int Delete(int id)
        {
            string query = "DELETE FROM Authors WHERE Id = @idPlaceholder";
            var parameters = new[]
            {
                new SqlParameter("@idPlaceholder", id)
            };

            return _db.ExecuteNonQuery(query, parameters);
        }
    }
}
