using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PracticalTest.Models
{
    public class TitleLookUp
    {
        [Key]
        public int TitleID { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }
    }
}