namespace Library.Core.Models
{
    public class Nation
    {
        private int id;
        private string? name;

        public int Id { get => id; set => id = value; }
        public string? Name { get => name; set => name = value; }

        /// <summary>
        /// Returns a string representation of the Nation object.
        /// </summary>
        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }
}
