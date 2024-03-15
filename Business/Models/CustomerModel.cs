using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        [MaxLength(50, ErrorMessage = "Name must be less than {1} characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required!")]
        [MaxLength(100, ErrorMessage = "Address must be less than {1} characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Age is required!")]
        [Range(18, 120, ErrorMessage = "Age must be between {1} and {2}")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Registration date is required!")]
        public DateTime RegistrationDate { get; set; }
    }
}
