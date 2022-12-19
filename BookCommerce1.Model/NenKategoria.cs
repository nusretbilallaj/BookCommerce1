using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCommerce1.Model
{
    [Table("NenKategoria")]
    public class NenKategoria
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Kerkohet emri")]
        public string Emri { get; set; }
        [Required(ErrorMessage = "Kerkohet renditja")]
        [Range(1,1000,ErrorMessage = "Specifikoni renditjen 1-1000")]
        public int Renditja { get; set; }

    }
}
