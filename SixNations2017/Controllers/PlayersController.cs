using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SixNations2017.Models;
using System.Collections.Generic;

namespace SixNations2017.Controllers
{
    public class PlayersController : Controller
    {
        private SixNations2017Context db = new SixNations2017Context();

        // GET: Players

        public ActionResult Index(string searchString, string option)
        {
            var players = from p in db.Players
                         select p;

            if (!String.IsNullOrEmpty(searchString) & option == "Name")
            {
                players = players.Where(x => x.Name.Contains(searchString));
                return View(players);
            }
            
            else if(!String.IsNullOrEmpty(searchString) & option == "Team")
            {
                try
                {
                    InternationalTeam teamValue = (InternationalTeam)Enum.Parse(typeof(InternationalTeam), searchString);
                    if (Enum.IsDefined(typeof(InternationalTeam), teamValue) | teamValue.ToString().Contains(","))
                        players = players.Where(x => x.InternationalTeam.ToString().ToUpper() == teamValue.ToString().ToUpper());
                    return View(players);
                }
                catch (ArgumentException)
                {
                    return new HttpStatusCodeResult(404);
                }    
            }
            else if(!String.IsNullOrEmpty(searchString) & option == "Position")
            {
                try
                {
                    Position positionValue = (Position)Enum.Parse(typeof(Position), searchString);
                    if (Enum.IsDefined(typeof(Position), positionValue) | positionValue.ToString().Contains(","))
                        players = players.Where(x => x.Position.ToString().ToUpper() == positionValue.ToString().ToUpper());
                    return View(players);
                }
                catch (ArgumentException)
                {
                    return new HttpStatusCodeResult(404); //edit exception 
                }
            }
        

            else
            {
                return View(db.Players.OrderBy(x=> x.TriesScored).ToList());
            }
                     
        }




        // GET: Players/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: Players/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "ID,Name,Position,InternationalTeam,TriesScored,ConversionScored,Penalties")] Player player)
        {
            if (db.Players.Any(x => x.Name == player.Name & x.InternationalTeam == player.InternationalTeam)) //if the player name & team already exist, user cannot enter details, error displayed
            {
                ModelState.AddModelError("Player", "Player already exists, please enter a different player");
            }


            else if (ModelState.IsValid)
            {
                db.Players.Add(player);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           
            return View(player);
        }

        // GET: Players/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Players/Edit/5
        //if the player name & team already exist, user cannot enter details, error displayed
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Position,InternationalTeam,TriesScored,ConversionScored,Penalties")] Player player)
        {
            if (db.Players.Any(x => x.Name == player.Name & x.InternationalTeam == player.InternationalTeam)) 
            {
                ModelState.AddModelError("Player", "Player already exists, please enter a different player");
            }

            else if (ModelState.IsValid)
            {
                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(player);
        }

        // GET: Players/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Player player = db.Players.Find(id);
            db.Players.Remove(player);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
