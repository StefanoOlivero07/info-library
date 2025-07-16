using Library.Core.Models;
using Microsoft.Data.SqlClient;

namespace Library.Data.Repos
{
    public class LoanRepository : ICrud<Loan>
    {
        private const int LOANDURATION = 90;
        private readonly Database _db;

        public LoanRepository(string connStr)
        {
            _db = new Database(connStr);
        }

        /* 
        ---------- CRUD methods ----------
        */
        #region

        public List<Loan> GetAll()
        {
            var loans = new List<Loan>();
            string query = "SELECT * FROM Loans";
            using var reader = _db.ExecuteReader(query);

            while (reader.Read())
            {
                loans.Add(new Loan()
                {
                    Id = reader.GetInt32(0),
                    UserId = reader.GetInt32(1),
                    BookId = reader.GetInt32(2),
                    DateOfLoan = reader.GetDateTime(3)
                });
            }


            return loans;
        }

        public Loan? GetById(int id)
        {
            string query = "SELECT * FROM Loans WHERE Id = @idPlaceholder";
            var parameters = new[]
            {
                new SqlParameter("@idPlaceholder", id)
            };
            using var reader = _db.ExecuteReader(query, parameters);

            if (reader.Read())
            {
                var loan = new Loan
                {
                    Id = reader.GetInt32(0),
                    UserId = reader.GetInt32(1),
                    BookId = reader.GetInt32(2),
                    DateOfLoan = reader.GetDateTime(3)
                };

                return loan;
            }

            return null;
        }

        public int Add(Loan loan)
        {
            string query = "INSERT INTO Loans UserId, BookId, DateOfLoan VALUES @userIdPlaceholder, @bookIdPlaceholder, @dateOfLoanPlaceholder";
            var parameters = new[]
            {
                new SqlParameter("@userIdPlaceholder", loan.UserId),
                new SqlParameter("@bookIdPlaceholder", loan.BookId),
                new SqlParameter("@dateOfLoanPlaceholder", loan.DateOfLoan)
            };

            try
            {
                return _db.ExecuteNonQuery(query, parameters);
            }
            catch
            {
                return -1;
            }
        }

        public int Update(Loan loan)
        {
            string query = "UPDATE Loans SET UserId = @userIdPlaceholder, BookId = @bookIdPlaceholder, DateOfLoan = @dateOfLoanPlaceholder WHERE Id = @idPlaceholder";
            var parameters = new[]
            {
                new SqlParameter("@userIdPlaceholder", loan.UserId),
                new SqlParameter("@bookIdPlaceholder", loan.BookId),
                new SqlParameter("@dateOfLoanPlaceholder", loan.DateOfLoan)
            };

            try
            {
                return _db.ExecuteNonQuery(query, parameters);
            }
            catch
            {
                return -1;
            }
        }

        public int Delete(int id)
        {
            string query = "DELETE FROM Loans WHERE Id = @idPlaceholder";
            var parameters = new[]
            {
                new SqlParameter("@idPlaceholder", id)
            };

            return _db.ExecuteNonQuery(query, parameters);
        }
        #endregion

        /*
        ---------- Loan methods ----------
        */
        #region
        public bool IsBookLoaned(int bookId)
        {
            string query = $"SELECT * FROM Loans WHERE BookId = @bookIdPlaceholder AND DATEADD(DAY, {LOANDURATION}, DateOfLoan) < GETDATE()";
            var parameters = new[]
            {
                new SqlParameter("@bookIdPlaceholder", bookId)
            };
            using var reader = _db.ExecuteReader(query, parameters);

            return reader.Read() ? true : false;
        }

        public List<Loan> GetByUserId(int userId)
        {
            var loans = new List<Loan>();
            string query = "SELECT * FROM Loans WHERE UserId = @userIdPlaceholder";
            var parameters = new[]
            {
                new SqlParameter("@userIdPlaceholder", userId)
            };
            using var reader = _db.ExecuteReader(query, parameters);

            while (reader.Read())
            {
                loans.Add(new Loan
                {
                    Id = reader.GetInt32(0),
                    UserId = reader.GetInt32(1),
                    BookId = reader.GetInt32(2),
                    DateOfLoan = reader.GetDateTime(3),
                });
            }

            return loans;
        }

        #endregion
    }
}
