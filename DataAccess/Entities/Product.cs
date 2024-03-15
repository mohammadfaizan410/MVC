using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public int Price { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsTopRated { get; set; }
        public bool IsNearby { get; set; }
    }
}
