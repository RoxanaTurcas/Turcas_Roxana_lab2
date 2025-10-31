
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Turcas_Roxana_lab2.Models
{
    public class Author
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        public ICollection<Book>? Books { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
    }
}
