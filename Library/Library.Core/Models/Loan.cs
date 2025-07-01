namespace Library.Core.Models
{
    public class Loan
    {
        private int id;
        private int userId;
        private int bookId;
        private DateTime date;

        public int Id { get =>  id; set => id = value; }
        public int UserId { get => userId; set => userId = value; }
        public int BookId { get => bookId; set => bookId = value; }
        public DateTime DateOfLoan { get => date; set => date = value; }

        /// <summary>
        /// Returns a string representation of the Loan object.
        /// </summary>
        public override string ToString()
        {
            return $"{Id} - {DateOfLoan}";
        }
    }
}
