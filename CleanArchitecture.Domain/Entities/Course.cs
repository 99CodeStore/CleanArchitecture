using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class Course
    {

        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings =false)]
        [StringLength(maximumLength: 150,MinimumLength = 2)]
        public string Name { get; set; }

        [MinLength(length: 150, ErrorMessage = "Please Enter minmum 150 characters Cousre Description.")]
        public string Description { get; set; }
       
        public string ImageUrl { get; set; }

    }
}
