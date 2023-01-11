using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cloud6212Task2.Models
{
    [Table("Items")]
    public class Item
    {
        // EF automatically makes the PK an identity when its property is set to an int data type
        //https://www.entityframeworktutorial.net/code-first/key-dataannotations-attribute-in-code-first.aspx 
        [Key] 
        public int Id { get; set; }
        [Required] 
        [StringLength (50)]
        public string Name { get; set; }
        public double? Price { get; set; }
        public string Quantity { get; set; }   
        public string ImageUrl { get; set; }
        public string FileName { get; set; }


    }
}
