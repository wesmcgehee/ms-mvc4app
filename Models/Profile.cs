using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Mvc4App.Models
{
    // ref: http://nickstips.wordpress.com/2011/08/11/asp-net-mvc-ajax-dialog-form-using-jquery-ui/ 
    public class Profile
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 3)]
        [Display(Name = "Nick name")]
        public string NickName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int Age { get; set; }
    }
}