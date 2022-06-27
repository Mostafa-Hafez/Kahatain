using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace finalproject.Models
{
    public partial class Child
    {
        [Key]
        public int Ch_ID { get; set; }
        public string Ch_Name { get; set; }
        public string Ch_PhoneNumber { get; set; }
        public int Ch_Age { get; set; }
        public DateTime Ch_DOB { get; set; }
        public string Ch_Address { get; set; }
        public string Ch_Govrnate { get; set; }
        public sex Ch_sex { get; set; }
        public string Ch_PlaceBorn { get; set; }
        public string Ch_FatherName { get; set; }
        public string Ch_MotherName { get; set; }
        public DateTime Ch_MotherDOB { get; set; }
        public DateTime Ch_DateFatherDeath { get; set; }
        public string Ch_Image { get; set; }


        public int Vol_ID { get; set; }
        [ForeignKey("Vol_ID")]
        public virtual Volunteer Volunteer { get; set; }

        public virtual List<Dependant> Brothers { get; set; }
    }


    
    public partial class Dependant
    {
        [Key]
        public string Dep_id { get; set; }
        public string Dep_Name { get; set; }
        public int Dep_Age { get; set; }
        public DateTime Dep_DOB { get; set; }


        public int Ch_id { get; set; }
        [ForeignKey("Ch_id")]
        public virtual Child child { get; set; }
    }

    [MetadataType(typeof(MetaChild))]
    public partial class Child
    {
    }
    public class MetaChild
    {

        public string Ch_ID { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Ch_Name { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]        
        public string Ch_PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Age")]
        public int Ch_Age { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        public DateTime Ch_DOB { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Ch_Address { get; set; }
        [Required]
        [Display(Name = "Govrnate")]
        public string Ch_Govrnate { get; set; }
        [Display(Name = "Sex")]
        public sex Ch_sex { get; set; }
        [Required]
        [Display(Name = "Place Of Born")]
        public string Ch_PlaceBorn { get; set; }
        [Required]
        [Display(Name = "Father Name")]
        public string Ch_FatherName { get; set; }
        [Required]
        [Display(Name = "Mother Name")]
        public string Ch_MotherName { get; set; }
        [Required]
        [Display(Name = "Mother Date of birth")]
        [DataType(DataType.Date)]
        public DateTime Ch_MotherDOB { get; set; }
        [Required]
        [Display(Name = "Date Of Father Death")]
        [DataType(DataType.Date)]
        public DateTime Ch_DateFatherDeath { get; set; }
        [Required]
        [DataType(DataType.Upload)]
        [Display(Name = "Image")]
        public string Ch_Image { get; set; }


    }

    [MetadataType(typeof(MetaDependant))]
    public partial class Dependant
    {

    }
    public class MetaDependant
    {
        [Required]
        [Display(Name = "Name")]
        public string Dep_Name { get; set; }
        [Required]
        [Display(Name = "Age")]
        public int Dep_Age { get; set; }
        [Required]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime Dep_DOB { get; set; }
    }



}