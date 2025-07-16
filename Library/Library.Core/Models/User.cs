using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Core.Models
{
    public class User
    {
        private int id;

        private DateTime dateOfBirth;

        private string? name;

        private string? surname;

        private string? email;

        private readonly string? fullName;

        public int Id { get => id; set => id = value; }
        [Required(ErrorMessage = "Date of birth must not be empty")]
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        [Required(ErrorMessage = "Name must not be empty")]
        public string? Name { get => name; set => name = value; }
        [Required(ErrorMessage = "Surname must not be empty")]
        public string? Surname { get => surname; set => surname = value; }
        [Required(ErrorMessage = "Email must not be empty")]
        public string? Email { get => email; set => email = value; }

        public string? FullName { get => name + " " + surname; }

        /// <summary>
        /// Returns a string representation of the User object.
        /// </summary>
        public override string ToString()
        {
            return $"{Id} - {Name} {Surname}";
        }
    }
}
