namespace Library.Core.Models
{
    public class Loan
    {
        private int id;
        private int userId;
        private int languageId;
        private DateTime date;

        public int Id { get =>  id; set => id = value; }
        public int UserId { get => userId; set => userId = value; }
        public int LanguageId { get => languageId; set => languageId = value; }
        public DateTime Date { get => date; set => date = value; }

        /// <summary>
        /// Returns a string representation of the Loan object.
        /// </summary>
        public override string ToString()
        {
            return $"{Id} - {Date}";
        }
    }
}
