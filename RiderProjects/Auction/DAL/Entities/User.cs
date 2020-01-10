using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(255)]
        public string LastName { get; set; }
        
        public string Login { get; set; }
        
        public string Password { get; set; }

        public string Email { get; set; }

        public string Role  { get; set; }
    }
}