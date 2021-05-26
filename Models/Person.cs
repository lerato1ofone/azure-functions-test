using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticalTest.Models
{
    public class Person
    {
        [Key]
        public int PersonID { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Surname { get; set; }

        [ForeignKey("TitleID")]
        public virtual int TitleID { get; set; }
    }
}
