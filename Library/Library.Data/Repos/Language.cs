using Library.Core.Models;
using Microsoft.Data.SqlClient;

namespace Library.Data.Repos
{
    public class LanguageRepository : ICrud<Language>
    {
        private readonly Database _db;

        public LanguageRepository(string connectionString)
        {
           _db = new Database(connectionString); 
        }

        public List<Language> GetAll()
        {
            var languages = new List<Language>();
            string query = "SELECT * FROM Languages";
            using var reader = _db.ExecuteReader(query);

            while (reader.Read())
            {
                languages.Add(new Language
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                });
            }

            return languages;
        }

        public Language? GetById(int id)
        {
            string query = "SELECT * FROM Languages WHERE Id = @idPlaceholder";
            var parameters = new[]
            {
                new SqlParameter("@idPlaceholder", id)
            };
            using var reader = _db.ExecuteReader(query, parameters);

            if (reader.Read())
            {
                var language = new Language
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                };

                return language;
            }

            return null;
        }

        public int Add(Language language)
        {
            string query = "INSERT INTO Languages Name VALUES @namePlaceholder";
            var parameters = new[]
            {
                new SqlParameter("@namePlaceholder", language.Name)
            };

            return _db.ExecuteNonQuery(query, parameters);
        }

        public int Update(Language language)
        {
            string query = "UPDATE Languages SET Name = @namePlaceholder WHERE Id = @idPlaceholder";
            var parameters = new[]
            {
                new SqlParameter("@idPlaceholder", language.Id),
                new SqlParameter("@namePlaceholder", language.Name)
            };

            return _db.ExecuteNonQuery(query, parameters);
        }

        public int Delete(int id)
        {
            string query = "DELETE FROM Languages WHERE Id = @idPlaceholder";
            var parameters = new[]
            {
                new SqlParameter("@idPlaceholder", id)
            };

            return _db.ExecuteNonQuery(query, parameters);
        }
    }
}
