using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WypozyczalniaFilmow.DAL;
using WypozyczalniaFilmow.Models;

namespace WypozyczalniaFilmow.Controllers
{
    public class FilmyController : Controller
    {
        FilmyContext db;
        IWebHostEnvironment webHostEnvironment;

        public FilmyController(FilmyContext db, IWebHostEnvironment webHostEnvironment)
        {
            this.db = db;
            this.webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Lista(string nazwaKategorii)
        {
            var kategoria = db.Kategorie.Include("Filmy").Where(k=>k.Nazwa.ToUpper() == nazwaKategorii).Single();
            var Filmy = kategoria.Filmy.ToList();

            FilmyKategorii model = new FilmyKategorii();
            model.Kategoria = kategoria;
            model.FilmyKategoria = Filmy;
            model.FilmyNajnowsze = db.Filmy.OrderByDescending(f => f.DataDodania).Take(3);
            
            return View(model);
        }
        public IActionResult Szczegoly(int idFilmu)
        {
            var kategoria = db.Kategorie.Find(db.Filmy.Find(idFilmu).KategoriaId);
            var film = db.Filmy.Find(idFilmu);
            return View(film);
        }
        [HttpPost]
        public IActionResult Szukaj(string tekst)
        {
            var filmy = from f in db.Filmy select f;
            if (!String.IsNullOrEmpty(tekst)) {

                filmy = filmy.Where(f => f.Tytul.Contains(tekst));
                filmy.ToList();
                ViewBag.Fraza = tekst;
                return View(filmy);
            }
            return RedirectToAction("Wszystkie");

        }
        public IActionResult Wszystkie()
        {
            var filmy = db.Filmy.ToList();
            return View(filmy);
        }
        [HttpGet]
        public ActionResult DodajFilm()
        {
            DodawanieViewModel dodaj = new DodawanieViewModel();
            var kategoria = db.Kategorie.ToList();
            dodaj.Kategorie = kategoria;

            return View(dodaj);
        }
        [HttpPost]
        public ActionResult DodajFilm(DodawanieViewModel obj) {
            obj.film.DataDodania = DateTime.Now;
            var filePath = Path.Combine(webHostEnvironment.WebRootPath, "plakaty");
            var uniquePosterName = Guid.NewGuid() + "_" + obj.Plakat.FileName;
            var picFilePath = Path.Combine(filePath, uniquePosterName);
            obj.Plakat.CopyTo(new FileStream(picFilePath, FileMode.Create));
            obj.film.Plakat = uniquePosterName;
            db.Filmy.Add(obj.film);
            db.SaveChanges();
            return RedirectToAction("DodajFilm");
        }
        [HttpGet]
        public ActionResult EdytujFilm(int id) {
            var film = db.Filmy.Where(f => f.Id == id).FirstOrDefault();
            return View(film);
        
        }
        [HttpPost]
        public ActionResult EdytujFilm(Film obj)
        {
            var film = db.Filmy.Where(f => f.Id == obj.Id).FirstOrDefault();
            film.Tytul = obj.Tytul;
            film.Rezyser = obj.Rezyser;
            film.Opis = obj.Opis;
            film.Cena = obj.Cena;
            db.Entry(film).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Szczegoly", new { idFilmu = film.Id });

        }
    }
}
