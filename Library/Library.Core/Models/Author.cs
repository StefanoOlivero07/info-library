namespace Library.Core.Models
{
    public class Author
    {
        private int id;
        public string? name;
        public string? surname;

        public int Id { get => id; set => id = value; }
        public string? Name { get => name; set => name = value; }
        public string? Surname { get => surname; set => surname = value; }

        /// <summary>
        /// Returns a string representation of the Author object.
        /// </summary>
        public override string ToString()
        {
            return $"{Id} - {Name} {Surname}";
        }
    }
}
