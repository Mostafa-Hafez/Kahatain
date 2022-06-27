using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace finalproject.Models
{
    public partial class Videos
    {
        [Key]
        public int Vid_ID { get; set; }
        public string Vid_Name { get; set; }
        public string Vid_Des { get; set; }
        public int Pr_Id { get; set; }
        [ForeignKey("Pr_Id")]
        public virtual Programs Program { get; set; }

    }
    [MetadataType(typeof(metavideos))]
    public partial class Videos
    {
       
    }
    public class metavideos
    {
        [Required]
        [Display(Name ="Name")]
        public string Vid_Name { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Vid_Des { get; set; }
    }


    public partial class Files
    {
        [Key]
        public int Fl_ID { get; set; }
        public string Fl_Name { get; set; }
        public string Fl_Des { get; set; }
        public int Pr_Id { get; set; }
        [ForeignKey("Pr_Id")]
        public virtual Programs Program { get; set; }
    }

    [MetadataType(typeof(metafiles))]
    public partial class Files
    {

    }
    public class metafiles
    {
        [Required]
        [Display(Name = "Name")]
        public string Fl_Name { get; set; }
        
        [Required]
        [Display(Name = "Description")]
        public string Fl_Des { get; set; }
    }

    public partial class Sounds
    {
        [Key]
        public int Sd_ID { get; set; }
        public string Sd_Name { get; set; }
        public string Sd_Des { get; set; }
        public int Pr_Id { get; set; }
        [ForeignKey("Pr_Id")]
        public virtual Programs Program { get; set; }
    }

    [MetadataType(typeof(metasounds))]
    public partial class Sounds
    {

    }
    public class metasounds
    {
        [Required]
        [Display(Name ="Name")]
        public string Sd_Name { get; set; }
        [Required]
        [Display(Name ="Description")]
        public string Sd_Des { get; set; }
    }
}