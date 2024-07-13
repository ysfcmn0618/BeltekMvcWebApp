using System.ComponentModel.DataAnnotations;

namespace BeltekMvcWebApp.Models
{
    public class Class
    {
       
        public Class()
        {           
             Students = new List<Student>();
        }

        
        public int ClassId { get; set; }

        
        public string ClassName { get; set; }

        
        public int Quota { get; set; }
        public virtual ICollection<Student> Students { get; set; }

    }
}
