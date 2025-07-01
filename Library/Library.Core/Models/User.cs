namespace Library.Core.Models
{
    public class User
    {
        private int id;

        private DateTime dateOfBirth;

        private string? name;

        private string? surname;

        private string? email;

        public int Id { get => id; set => id = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string? Name { get => name; set => name = value; }
        public string? Surname { get => surname; set => surname = value; }
        public string? Email { get => email; set => email = value; }

        /// <summary>
        /// Returns a string representation of the User object.
        /// </summary>
        public override string ToString()
        {
            return $"{Id} - {Name} {Surname}";
        }
    }
}
