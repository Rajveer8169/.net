using System.ComponentModel.DataAnnotations;

namespace PracticeAdoNet.Models
{
    public class Employees
    {
        public int Id {  get; set; }

        [Required]
        public string EmpName { get; set; } = string.Empty;

        [Required]
        public string Gender {  get; set; } = string.Empty;

        [Required]
        public int Age { get; set; }

        [Required]
        public string Designation {  get; set; } = string.Empty;

        [Required]
        public string City { get; set; } = string.Empty;

        public string State { get; set; } = "";
    }
}
