using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class VendorModel
    {
    public int Id { get; set; }

        [DisplayName("Vendor Title")]
        [Required(ErrorMessage = "Title is required!")]
        public string Title { get; set; }

        [DisplayName("Vendor Password")]
        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; }

        [DisplayName("Vendor Username")]
        [Required(ErrorMessage = "Username is required!")]
        public string Username { get; set; }

        [DisplayName("Created Date")]
        [Required(ErrorMessage = "Created date is required!")]
        public DateTime CreatedDate { get; set; }
    }
}
