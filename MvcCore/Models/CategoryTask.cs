using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCore.Models
{
    public class CategoryTask
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string category_Name { get; set; }
        public IEnumerable<Tasks>? Tasks{get;set;}


	}
}
