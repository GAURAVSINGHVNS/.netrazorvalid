using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace mvcvalid.Models
{
    public class tblregistration
    {
        [Key]
        public int rid { get; set; }


        [Required(ErrorMessage ="please enter your name!!")]
        public string rname { get; set; }

        [Required(ErrorMessage = "please enter your email!!")]
        public string remail { get; set; }

        [Required(ErrorMessage = "please enter your password!!")]
        public string rpassword { get; set; }

        public string rimg { get; set; }
    }
}