using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace finalproject.Models
{
    public partial class Volunteer
    {
        [Key]
        public int Vol_ID { get; set; }
        public string Vol_Name { get; set; }
        public string Vol_UserName { get; set; }
        public string Vol_Password { get; set; }
        public string Vol_ConfirmPassword { get; set; }
        public string Vol_Govrnate { get; set; }
        public string Vol_Number1 { get; set; }
        public string Vol_Number2 { get; set; }
        public string Vol_Address { get; set; }
        public string Vol_email { get; set; }
        public sex Vol_Sex { get; set; }
        public string Vol_Job { get; set; }
        public bool Vol_Place { get; set; }
        public string Vol_Skills { get; set; }
        public string Vol_Certificates { get; set; }

        public string AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        public virtual ApplicationUser User { get; set; }
        public virtual List<Child> children { get; set; }
    }


    [MetadataType(typeof(MetaVol))]
    public partial class Volunteer
    {

    }

    public class MetaVol
    {
        [Required]
        [Display(Name = "Name")]
        public string Vol_Name { get; set; }
        [Required]
        [Display(Name = "UserName")]
        public string Vol_UserName { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Vol_Password { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Vol_Password", ErrorMessage = "The password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        public string Vol_ConfirmPassword { get; set; }
        [Required]
        [Display(Name = "govrnate")]
        public string Vol_Govrnate { get; set; }
        [Required]
        [Display(Name = "Phone number 1")]
        [DataType(DataType.PhoneNumber)]
        public string Vol_Number1 { get; set; }
        
        [Display(Name = "Phone Number 2")]
        [DataType(DataType.PhoneNumber)]
        public string Vol_Number2 { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Vol_Address { get; set; }
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Vol_email { get; set; }
        [Display(Name = "Type")]
        public sex Vol_Sex { get; set; }

        [Display(Name = "Your Job")]
        public string Vol_Job { get; set; }
        [Required]
        [Display(Name = "Place")]
        public bool Vol_Place { get; set; }

        [Display(Name = "Skills")]
        public string Vol_Skills { get; set; }

        [Display(Name = "Cetificates")]
        public string Vol_Certificates { get; set; }
    }

    public class editvol
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Vol_Name { get; set; }
        
        [Required]
        [Display(Name = "govrnate")]
        public string Vol_Govrnate { get; set; }
        [Required]
        [Display(Name = "Phone number 1")]
        [DataType(DataType.PhoneNumber)]
        public string Vol_Number1 { get; set; }
      
        [Display(Name = "Phone Number 2")]
        [DataType(DataType.PhoneNumber)]
        public string Vol_Number2 { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Vol_Address { get; set; }
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Vol_email { get; set; }
        

        [Display(Name = "Your Job")]
        public string Vol_Job { get; set; }
        [Required]
        [Display(Name = "Place")]
        public bool Vol_Place { get; set; }

        [Display(Name = "Skills")]
        public string Vol_Skills { get; set; }

        [Display(Name = "Cetificates")]
        public string Vol_Certificates { get; set; }
    }
}

