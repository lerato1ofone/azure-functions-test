using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PracticalTest.Models
{
    public class Employee
    {
        [Required]
        [Key]
        public int EmployeeID { get; set; }

        [Column(TypeName = "varchar(25)")]
        public string EmployeeNo { get; set; }

        [ForeignKey("PersonID")]
        public virtual int PersonID { get; set; }
    }
}
