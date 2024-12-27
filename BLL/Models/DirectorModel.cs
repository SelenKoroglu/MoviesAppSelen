using BLL.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class DirectorModel
    {
        public Director Record { get; set; }

        public string Name => Record.Name;
        public string Surname => Record.Surname;

        //public bool IsRetired => Record.IsRetired;

        [DisplayName("Working Status")]
        public string IsRetired => Record.IsRetired ? "Retired" : "Not Retired";

        public string FullName => $"{Record.Name} {Record.Surname}";
    }
}
