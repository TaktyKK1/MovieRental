using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WypozyczalniaFilmow.DAL;
using WypozyczalniaFilmow.Helpers;
using WypozyczalniaFilmow.Infrastructure;
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

            var cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, Consts.CartSessionKey);
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Film.Cena * item.Ilosc);

            return View();
        }
        public IActionResult Kup(int id)
        {
            var film = db.Filmy.Find(id);
            {
                List<CartItem> cart = new List<CartItem>();
                cart.Add(new CartItem { Film = film, Ilosc = 1, Wartosc = film.Cena });
            }
            else
            {
                int index = InCart(id);
                {
                    cart[index].Ilosc++;
                }
                else
                {
                    cart.Add(new CartItem { Film = film, Ilosc = 1, Wartosc = film.Cena });
                }
            }


            return RedirectToAction("Index");

        }
        public IActionResult Usun(int id)
        {
        }
        private int InCart(int id)
        {
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
