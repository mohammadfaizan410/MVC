using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Customer
    {
        [Required]
        public int Id { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public int Age { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
