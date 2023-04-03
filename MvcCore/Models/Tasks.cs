using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace MvcCore.Models
{
	public enum TaskStatus
	{
		Open = 0,
		InProgress = 1,
		Done = 2
	}
	public class Tasks
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string Name { get; set; }
		[Required, MaxLength(500)]
		public string? Description { get; set; }

		
		public int own_Id { get; set; }
		[ForeignKey(nameof(own_Id))]
		public Users User { get; set; }
		
		
		public DateTime AssignDate { get; set; }
		
		public int cat_Id { get; set; }
		[ForeignKey(nameof(cat_Id))]
		public CategoryTask Category { get; set; }

		public TaskStatus Status { get; set; }


	}
}
