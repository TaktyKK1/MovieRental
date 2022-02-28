using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WypozyczalniaFilmow.Models
{
    public class Kategoria
    {
        [Key]
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public ICollection<Film> Filmy { get; set; }
    }
}
