namespace Library.Core.Models
{
    public class Language
    {
        private int id;
        private string? name;

        public int Id { get =>  id; set => id = value; }
        public string? Name { get => name; set => name = value; }

        /// <summary>
        /// Returns a string representation of the Language object.
        /// </summary>
        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }
}
