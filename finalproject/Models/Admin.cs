
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace finalproject.Models
{
    public partial class Admins
    {
        [Key]
        public int Adm_ID { get; set; }
        public string Adm_Name { get; set; }
        public string Adm_UserName { get; set; }
        public string Adm_Email { get; set; }
        public string Adm_Password { get; set; }
        public string Adm_Number1 { get; set; }
        public string Adm_Number2 { get; set; }

        public string AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        public virtual ApplicationUser User { get; set; }

    }


    [MetadataType(typeof(Admins))]
    public partial class Admins
    {
    }

    public class MetaAdmin
    {
        [Required]
        [Display(Name = "Name")]
        public String Adm_Name { get; set; }
        [Required]
        [Display(Name = "UserName")]
        public String Adm_UserName { get; set; }
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public String Adm_Email { get; set; }
        [Required]
        [Display(Name = "Paswword")]
        [DataType(DataType.Password)]
        public String Adm_Password { get; set; }
        [Required]
        [Display(Name = "Phone Number 1")]
        [DataType(DataType.PhoneNumber)]
        public String Adm_Number1 { get; set; }
        [Required]
        [Display(Name = "Phone Number 2")]
        [DataType(DataType.PhoneNumber)]
        public String Adm_Number2 { get; set; }
    }
}