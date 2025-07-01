namespace Library.Core.Models
{
    public class Genre
    {
        private int id;
        private string? description;

        public int Id { get =>  id; set => id = value; }
        public string? Description { get => description; set => description = value; }

        /// <summary>
        /// Returns a string representation of the Genre object.
        /// </summary>
        public override string ToString()
        {
            return $"{Id} - {Description}";
        }
    }
}
