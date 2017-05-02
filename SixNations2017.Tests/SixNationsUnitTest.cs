using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SixNations2017.Controllers;
using SixNations2017.Models;
using System.Collections.Generic;

namespace SixNations2017.Tests
{
    [TestClass]
    public class SixNationsUnitTest
    {     
        [TestMethod]
        public void TestPointsTotal() //fail expected
        {
            Player player = new Player
            {
                ID = 21,
                Name = "Jonathan Sexton",
                InternationalTeam = InternationalTeam.Ireland,
                Position = Position.ScrumHalf,
                TriesScored = 2,
                ConversionScored = 10,
                Penalties = 3
            }; // 2*Tries = 10, 10*Conversions = 20, 3*Penalties = 9, Total Points Scored: 39
            Assert.AreEqual(player.PointsScored, 31);
        }

        [TestMethod]
        public void TestPointsTotal2() //pass expected
        {
            Player player = new Player
            {
                ID = 21,
                Name = "Jonathan Sexton",
                InternationalTeam = InternationalTeam.Ireland,
                Position = Position.ScrumHalf,
                TriesScored = 2,
                ConversionScored = 10,
                Penalties = 3
            }; // 2*Tries = 10, 10*Conversions = 20, 3*Penalties = 9, Total Points Scored: 39
            Assert.AreEqual(player.PointsScored, 39);
        }

        [TestMethod]
        public void CreatePlayer()
        {
            Player player1 = new Player
            {
                Name = "Leigh Halfpenny",
                ID = 22,
                InternationalTeam = InternationalTeam.Wales,
                Position = Position.NumberEight,
                TriesScored = 2,
                ConversionScored = 1,
                Penalties = 1
            };

            
        }

    }
}
