using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Vendor
    {
        [Required]
        public int Id { get; set; }
        public String Title { get; set; }
        public String Password { get; set; }
        public String Username { get; set; }
        public DateTime CreatedDate { get; set; }
     }
}
