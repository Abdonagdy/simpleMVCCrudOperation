using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCore.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(50)]
		public string Email { get; set; }
        IEnumerable<Tasks>? Tasks { get; set; }
       
    }
   
}

