using Library.Core.Models;
using Microsoft.Data.SqlClient;

namespace Library.Data.Repos
{
    public class NationRepository : ICrud<Nation>
    {
        private readonly Database _db;

        public NationRepository(string connectionString)
        {
            _db = new Database(connectionString);
        }

        public List<Nation> GetAll()
        {
            var nations = new List<Nation>();
            string query = "SELECT * FROM Nations";
            using var reader = _db.ExecuteReader(query);

            while (reader.Read())
            {
                nations.Add(new Nation
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                });
            }

            return nations;
        }

        public Nation? GetById(int id)
        {
            string query = "SELECT * FROM Nations WHERE Id = @idPlaceholder";
            var parameters = new[]
            {
                new SqlParameter("@idPlaceholder", id)
            };
            using var reader = _db.ExecuteReader(query, parameters);

            if (reader.Read())
            {
                var nation = new Nation
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                };

                return nation;
            }
            
            return null;
        }

        public int Add(Nation nation)
        {
            string query = "INSERT INTO Nations Name VALUES @namePlaceholder";
            var parameters = new[]
            {
                new SqlParameter("@namePlaceholder", nation.Name)
            };

            return _db.ExecuteNonQuery(query, parameters);
        }

        public int Update(Nation nation)
        {
            string query = "UPDATE Nations SET Name = @namePlaceholder WHERE Id = @idPlaceholder";
            var parameters = new[]
            {
                new SqlParameter("@idPlaceholder", nation.Id),
                new SqlParameter("@namePlaceholder", nation.Name)
            };

            return _db.ExecuteNonQuery(query, parameters);
        }

        public int Delete(int id)
        {
            string query = "DELETE FROM Nations WHERE Id = @idPlaceholder";
            var parameters = new[]
            {
                new SqlParameter("@idPlaceholder", id)
            };

            return _db.ExecuteNonQuery(query, parameters);
        }
    }
}
