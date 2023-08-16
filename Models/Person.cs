using System.ComponentModel.DataAnnotations;

namespace NetAPIApp.Models
{
    public class Person
    {
        [Key]
        public string PersonID { get; set;}
        public string FullName { get; set;}
        public string Address { get; set; }
    }
}