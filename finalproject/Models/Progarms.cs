using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace finalproject.Models
{
    public enum type
    {
        Quraan,
        Ethics,
        Education,
        Social,
        ForVolunteer

    }
    public partial class Programs
    {


        [Key]
        public int Pr_ID { get; set; }
        public type Pr_Type { get; set; }
        public string Pr_Name { get; set; }

        public string Pr_Descrition { get; set; }

    }

    [MetadataType(typeof(metaprograms))]
    public partial class Programs
    {

    }
    public class metaprograms
    {
        [Required]
        [Display(Name ="Type")]
        public type Pr_Type { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Pr_Name { get; set; }
        [Required]
        [Display(Name = "Descrition")]
        public string Pr_Descrition { get; set; }
    }


    public partial class Grades
    {
        [Key]
        public int Gr_Id { get; set; }
        public double Grade { get; set; }
        public int Pr_Id { get; set; }
        [ForeignKey("Pr_Id")]
        public virtual Programs Program { get; set; }
        public int Ch_Id { get; set; }
        [ForeignKey("Ch_Id")]
        public virtual Child Child { get; set; }
    }

    //[MetadataType(typeof(metaGrades))]
    //public partial class Grades
    //{

    //}
    //public class metaGrades
    //{

    //}
}