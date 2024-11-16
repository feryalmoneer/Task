using System.ComponentModel.DataAnnotations;
namespace Task.Dot_s.StudentDot_s
{
    public class GetAllStudentDots
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Student Name is required.")]
        [MinLength(5, ErrorMessage = "Minimum length for the student name is 5 characters.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the student name is 30 characters.")]
        public string StudentName { get; set; } 

        [Required(ErrorMessage = "Price is required.")]
        [Range(20, 3000, ErrorMessage = "Price must be between 20 and 3000.")]
        public string Price { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [MinLength(10, ErrorMessage = "Minimum length for the description is 10 characters.")]
        public string Description { get; set; }
    }
}
