using System.ComponentModel.DataAnnotations;

namespace StudentSystem.WebApi.Models
{
    public class Student
    {
        public int Id { get; set; }
        
        
        [Required(ErrorMessage = "Öğrenci adı boş olamaz.")]
        public string Name { get; set; }
     
        
        [Required(ErrorMessage = "Öğrenci soyadı boş olamaz.")]
        public string Surname { get; set; }
     
        
        [Required(ErrorMessage = "Öğrenci numarası boş olamaz.")]

        public int No { get; set; }
        
    }
}
