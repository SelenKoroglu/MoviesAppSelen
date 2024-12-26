using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAL
{
    public class Director
    {
        public int Id { get; set; }

        [Required]
        [StringLength(70)]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }

        public bool IsRetired { get; set; }

        public List<Movie> Movies { get; set; } = new List<Movie>();


    }
}
