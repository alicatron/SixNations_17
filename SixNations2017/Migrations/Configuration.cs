namespace SixNations2017.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SixNations2017.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SixNations2017.Models.SixNations2017Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SixNations2017.Models.SixNations2017Context context)
        {

            context.Players.AddOrUpdate(x => x.ID,
            new Player() { Name = "Keith Earls", Position = Position.Wing, InternationalTeam = InternationalTeam.Ireland, TriesScored = 3 },
            new Player() { Name = "Owen Farrell", Position = Position.Centre, InternationalTeam = InternationalTeam.England, TriesScored = 1, ConversionScored = 5, Penalties = 4 },
            new Player() { Name = "Greig Laidlaw", Position = Position.ScrumHalf, InternationalTeam = InternationalTeam.Scotland, TriesScored = 2, ConversionScored = 7, Penalties = 1 },
            new Player() { Name = "George North", Position = Position.Wing, InternationalTeam = InternationalTeam.Wales, TriesScored = 5 },
            new Player() { Name = "Sergio Parisse", Position = Position.NumberEight, InternationalTeam = InternationalTeam.Italy, TriesScored = 3 },
            new Player() { Name = "Damien Chouly", Position = Position.BackRow, InternationalTeam = InternationalTeam.France, TriesScored = 1 }
            
            );
            
        }
    }
}
