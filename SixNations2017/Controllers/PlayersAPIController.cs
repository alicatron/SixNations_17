using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SixNations2017.Models;
using System.Data;
using System.Data.Entity;
using System.Web.Http.Description;
using System.Web.Http.WebHost;
using System.Text.RegularExpressions;
using System.Data.Entity.Infrastructure;

namespace SixNations2017.Controllers
{
    [RoutePrefix("api/sixnations")]
    public class APIController : ApiController
    {
        private SixNations2017Context db = new SixNations2017Context();

        //GET: return all players in order by penalties
        [Route("all")]
        public IHttpActionResult GetPlayers()
        {
            return Ok(db.Players.OrderBy(p => p.Name).ToList());
        }

        // GET: returns name and tries scored in tournament.
        [Route("tries")]
        public IHttpActionResult GetTries()
        {
            return Ok(db.Players.OrderBy(p => p.TriesScored).Select(m => new { m.Name, m.TriesScored }));

        }

        //GET: Players by team keyword

        /*[Route("team/{team}")]
        public IHttpActionResult GetTeam(string team)
        {
            String pattern = @"\b" + team.ToUpper() + @"\b";         // \bKEYWORD\b
            var results = db.Players.Where(m => Regex.Match(m.InternationalTeam.ToString(), pattern).Success == true).Select(m => new { m.Name, m.InternationalTeam });
            if (results.Count() == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(results);
            }
        }*/

        [Route("id/{id}")]
        [ResponseType(typeof(Player))]
        public IHttpActionResult GetPlayer(int id)
        {
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return NotFound();
            }

            return Ok(player);
        }

        // PUT: api/Players1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlayer(int id, Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != player.ID)
            {
                return BadRequest();
            }

            db.Entry(player).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Players1
        [Route("add")]
        [ResponseType(typeof(Player))]
        public IHttpActionResult PostPlayer(Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Players.Add(player);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = player.ID }, player);
        }

        // DELETE: api/Players1/5
        [Route("delete")]
        [ResponseType(typeof(Player))]
        public IHttpActionResult DeletePlayer(int id)
        {
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return NotFound();
            }

            db.Players.Remove(player);
            db.SaveChanges();

            return Ok(player);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlayerExists(int id)
        {
            return db.Players.Count(e => e.ID == id) > 0;
        }
    }



}

