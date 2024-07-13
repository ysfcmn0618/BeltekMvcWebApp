using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace BeltekMvcWebApp.Models

{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }


        
        public string Name { get; set; }


        
        public string Surname { get; set; }

        public int Number { get; set; }


        [ForeignKey("Class")]
        public int ClassId { get; set; }

        public virtual Class Class { get; set; }

    }
}
