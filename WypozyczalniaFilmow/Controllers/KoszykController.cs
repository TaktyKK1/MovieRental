using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WypozyczalniaFilmow.DAL;
using WypozyczalniaFilmow.Helpers;
using WypozyczalniaFilmow.Models;

namespace WypozyczalniaFilmow.Controllers
{
    public class KoszykController : Controller
    {
        FilmyContext db;

        public KoszykController(FilmyContext db)
        {
            this.db = db;
        }


[Route("Koszyk")]
        public IActionResult Index()
        {

            var cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "koszyk");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Film.Cena * item.Ilosc);

            return View();
        }
        public IActionResult Kup(int id)
        {
            var film = db.Filmy.Find(id);
            if(SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "koszyk") == null)
            {
                List<CartItem> cart = new List<CartItem>();
                cart.Add(new CartItem { Film = film, Ilosc = 1, Wartosc = film.Cena });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "koszyk", cart);
            }
            else
            {
                List<CartItem> cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "koszyk");
                int index = InCart(id);
                if(index != -1)
                {
                    cart[index].Ilosc++;
                }
                else
                {
                    cart.Add(new CartItem { Film = film, Ilosc = 1, Wartosc = film.Cena });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "koszyk", cart);
            }


            return RedirectToAction("Index");

        }
        public IActionResult Usun(int id)
        {
            List<CartItem> cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "koszyk");
            int index = InCart(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "koszyk", cart);
            return RedirectToAction("Index");
        }
        private int InCart(int id)
        {
            List<CartItem> cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "koszyk");
            for(int i = 0; i < cart.Count(); i++)
            {
                if (cart[i].Film.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;

        }




    }
}
