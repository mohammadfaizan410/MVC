using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [MinLength(4, ErrorMessage= "{0} must be minimum {1}")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [MinLength(4, ErrorMessage = "{0} must be minimum {1}")]
        public string Description { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        public int Price { get; set; }
        public bool IsFeaturedOutput { get; set; }
        public bool IsTopRatedOutput { get; set; }
        public bool IsNearbyOutput { get; set; }

    }
}
