using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace finalproject.Models
{
    public enum sex
    {
        male = 1, female = 0
    }
    public partial class Benefactor
    {
        [Key]
        public int Ben_Id { get; set; }
        public string Ben_Name { get; set; }
        public string Ben_Number1 { get; set; }
        public string Ben_Number2 { get; set; }
        public string Ben_Email { get; set; }
        public string Ben_UserName { get; set; }
        public string Ben_Password { get; set; }
        public string Ben_Country { get; set; }
        public string Ben_Address { get; set; }
        public sex Ben_sex { get; set; }
        public string AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        public virtual ApplicationUser User { get; set; }
    }

    [MetadataType(typeof(MetaBenfector))]
    public partial class Benefactor
    {

    }
    public class MetaBenfector
    {
        [Required]
        [Display(Name = "Name")]
        public string Ben_Name { get; set; }
        [Required]
        [Display(Name = "Phone Number 1")]
        public string Ben_Number1 { get; set; }
        [Required]
        [Display(Name = "Phone Number 2")]
        public string Ben_Number2 { get; set; }
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Ben_Email { get; set; }
        [Required]
        [Display(Name = "UserName")]
        public string Ben_UserName { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Ben_Password { get; set; }
        [Required]
        [Display(Name = "Country")]
        public string Ben_Country { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Ben_Address { get; set; }
        [Required]
        [Display(Name = "Type")]
        public sex Ben_sex { get; set; }
    }
}