namespace Library.Core.Models
{
    public class Book
    {
        private int id;
        private string? title;
        private int authorId;
        private int year;
        private int nationId;
        private int languageId;
        private decimal price;
        private int pages;

        public int Id { get => id; set => id = value; }
        public string? Title { get => title; set => title = value; }
        public int AuthorId { get => authorId; set => authorId = value; }
        public int Year { get => year; set => year = value; }
        public int NationId { get => nationId; set => nationId = value; }
        public int LanguageId { get => languageId; set => languageId = value; }
        public decimal Price { get => price; set => price = value; }
        public int Pages { get => pages; set => pages = value; }


        /// <summary>
        /// Returns a string representation of the Book object.
        /// </summary>
        public override string ToString()
        {
            return $"{Id} - {Title}";
        }
    }
}
