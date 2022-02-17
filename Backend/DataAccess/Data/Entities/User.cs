using System.ComponentModel.DataAnnotations;

namespace DataAccess.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Range(0, 150)]
        public int Age { get; set; }
    }
}
