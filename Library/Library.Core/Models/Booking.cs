namespace Library.Core.Models
{
    public class Booking
    {
        private int id;
        private int userId;
        private int languageId;

        public int Id { get =>  id; set => id = value; }
        public int UserId { get => userId; set => userId = value; }
        public int LanguageId { get => languageId; set => languageId = value; }

        /// <summary>
        /// Returns a string representation of the Booking object.
        /// </summary>
        public override string ToString()
        {
            return $"{Id}";
        }
    }
}
