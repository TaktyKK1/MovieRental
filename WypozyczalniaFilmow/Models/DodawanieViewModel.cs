﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WypozyczalniaFilmow.Models
{
    public class DodawanieViewModel
    {
        public Film film { get; set; }
        public IFormFile Plakat { get; set; }
        public List<Kategoria> Kategorie { get; set; }

    }
}
