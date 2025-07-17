using Library.Core.Models;
using Microsoft.Data.SqlClient;

namespace Library.Data.Repos
{
    public class UserRepository : ICrud<User>
    {
        private readonly Database _db;

        public UserRepository(string connStr)
        {
            _db = new Database(connStr);
        }

        /*
        ---------- CRUD methods ----------
        */
        #region
        public List<User> GetAll()
        {
            var users = new List<User>();
            string query = "SELECT * FROM Users";
            using var reader = _db.ExecuteReader(query);

            while (reader.Read())
            {
                users.Add(new User
                {
                    Id = reader.GetInt32(0),
                    DateOfBirth = reader.GetDateTime(1),
                    Name = reader.GetString(2),
                    Surname = reader.GetString(3),
                    Email = reader.GetString(4),
                });
            }

            return users;
        }

        public User? GetById(int id)
        {
            string query = "SELECT * FROM Users WHERE Id = @idPlaceholder";
            var parameters = new[] { new SqlParameter("@idPlaceholder", id) };
            using var reader = _db.ExecuteReader(query, parameters);

            if (reader.Read())
            {
                var user = new User
                {
                    Id = reader.GetInt32(0),
                    DateOfBirth = reader.GetDateTime(1),
                    Name = reader.GetString(2),
                    Surname = reader.GetString(3),
                    Email = reader.GetString(4),
                };

                return user;
            }

            return null;
        }

        public int Add(User user)
        {
            string query = "INSERT INTO Users (DateOfBirth, Name, Surname, Email)" +
                "VALUES (@datePlaceholder, @namePlaceholder, @surnamePlaceholder, @emailPlaceholder)";
            
            var parameters = new[] { new SqlParameter("@datePlaceholder", user.DateOfBirth),
            new SqlParameter("@namePlaceholder", user.Name), new SqlParameter("@surnamePlaceholder", user.Surname),
            new SqlParameter("@emailPlaceholder", user.Email)};

            return _db.ExecuteNonQuery(query, parameters);
        }

        public int Update(User user)
        {
            string query = "UPDATE Users SET DateOfBirth = @datePlaceholder," +
                "Name = @namePlaceholder, Surname = @surnamePlaceholder, Email = @emailPlaceholder " +
                "WHERE Id = @idPlaceholder";

            var parameters = new[]
            {
                new SqlParameter("@idPlaceholder", user.Id),
                new SqlParameter("@datePlaceholder", user.DateOfBirth),
                new SqlParameter("@namePlaceholder", user.Name),
                new SqlParameter("@surnamePlaceholder", user.Surname),
                new SqlParameter("@emailPlaceholder", user.Email)

            };

            return _db.ExecuteNonQuery(query, parameters);
        }

        public int Delete(int id)
        {
            string query = "DELETE FROM Users WHERE Id = @idPlaceholder";

            var parameters = new[]
            {
                new SqlParameter("@idPlaceholder", id)

            };

            return _db.ExecuteNonQuery(query, parameters);
        }
        #endregion

        /*
        ---------- User methods ----------
        */
        #region
        public bool CanLoan(int userId)
        {
            string query = @"SELECT COUNT(*) AS LoansNumber
                            FROM Loans l 
                            WHERE l.UserId = @userIdPlaceholder";
            var parameters = new[]
            {
                new SqlParameter("@userIdPlaceholder", userId)
            };
            using var reader = _db.ExecuteReader(query, parameters);

            if (reader.Read())
            {
                int loansNumber = reader.GetInt32(0);

                return loansNumber < 3;
            }
            return false;
        }
        #endregion
    }
}
