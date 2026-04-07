using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eglise_mambowa
{
    internal class revenuModel
    {
        // Propriétés avec getters et setters
        public DateTime Date { get; set; }
        public string Typerevenu { get; set; }
        public decimal Montant { get; set; }
        public string Description { get; set; }
        public int IdUser { get; set; }
    }
}
