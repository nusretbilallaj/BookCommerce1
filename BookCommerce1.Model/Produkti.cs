using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCommerce1.Model
{
    [Table("Produkti")]
    public class Produkti
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Kerkohet emri")]
        public string Emri { get; set; }
        [Required(ErrorMessage = "Kerkohet pershkrimi")]
        public string Pershkrimi { get; set; }
        [Required(ErrorMessage = "Kerkohet isbn")]
        public string Isbn { get; set; }

        [Required(ErrorMessage = "Kerkohet autori")]
        public string Autori { get; set; }

        [Required(ErrorMessage = "Kerkohet cmimi baze")]
        [Range(0.1,1000)]
        public double CmimiBaze { get; set; }

        [Required(ErrorMessage = "Kerkohet cmimi baze")]
        [Range(0.1, 1000)]
        public double Cmimi { get; set; }

        [Required(ErrorMessage = "Kerkohet  cmimi100")]
        [Range(0.1, 1000)]
        public double Cmimi100 { get; set; }
        [Required(ErrorMessage = "Kerkohet  cmimi50")]
        [Range(0.1, 1000)]
        public double Cmimi50 { get; set; }

        public int KategoriaId { get; set; }
        [ForeignKey("KategoriaId")]
        public Kategoria Kategoria { get; set; }

        public int MbulesaId { get; set; }
        [ForeignKey("MbulesaId")]
        public Mbulesa Mbulesa { get; set; }
        [Required(ErrorMessage = "Kerkohet  fotografia")]
        public string ImagePath { get; set; }

    }
}
